# Arquitectura

Este documento explica el **porqué** del diseño (no el qué, que ya está en el
[README](../README.md)): cómo se aplican MVC, herencia y polimorfismo, y cómo
fluye una petición de punta a punta.

## Flujo de una petición

```
Navegador → Controller → Service (memoria + JSON) → Controller → View → Navegador
```

Los `Controllers/` **no contienen lógica de negocio**: reciben la petición,
la delegan a un `Service` y traducen el resultado a algo que la vista pueda
mostrar. Por ejemplo, `PrestamosController.Index` arma una lista de
`PrestamoFila` con nombres de usuario y libro en vez de exponer los `Id`
crudos que guarda `Prestamo` — la vista nunca necesita saber cómo se
persisten los datos.

Toda la lógica de negocio y la persistencia viven en `Services/`. Cada
Service (`UsuarioService`, `LibroService`, `BibliotecarioService`,
`PrestamoService`) sigue el mismo patrón:

1. En el constructor, carga la lista completa desde su archivo en `Data/*.json`
   hacia una lista en memoria (`Cargar()`).
2. Cada operación (`Agregar`, `Editar`, `Eliminar`, ...) muta esa lista en
   memoria y llama a `Guardar()`.
3. `Guardar()` **reescribe el archivo completo** con
   `JsonSerializerOptions { WriteIndented = true }` — no hay una base de
   datos real ni escrituras parciales.

Se registran como `Singleton` en `Program.cs` para que esa lista en memoria
sea la misma durante toda la vida de la aplicación.

## Jerarquía de `Persona` (herencia y polimorfismo)

```
Persona (abstracta)
├── Usuario       (socio: pide préstamos)
└── Bibliotecario (empleado: administra el sistema)
```

`Persona` concentra los datos y credenciales comunes a cualquier persona del
sistema (nombre, identificación, email, contraseña) y valida cada campo en su
propio setter (encapsulamiento: los campos son privados, solo se modifican a
través de `Set*` con validación).

El polimorfismo aparece en dos puntos concretos, no solo como concepto de
la materia:

- **`DescripcionRol()`** — método abstracto que cada subclase implementa
  (`"Usuario de biblioteca"` / `"Bibliotecario"`), usado por
  `Persona.ToString()` sin que esa clase sepa de qué subtipo se trata.
- **`SetIdentificacion()`** — `Persona` solo exige que no esté vacía;
  `Usuario` la sobrescribe (`override`) para además exigir el formato de
  carnet de estudiante (año de 2 dígitos + correlativo de 5, ej. `2600001`)
  con una expresión regular, llamando primero a `base.SetIdentificacion()`.
  `Bibliotecario` no la sobrescribe y usa la validación genérica de
  `Persona`, porque su identificación no tiene un formato especial.

## Autenticación y control de acceso por rol

`CuentaController.Login` prueba las credenciales primero contra
`BibliotecarioService.ValidarLogin` y luego contra `UsuarioService.ValidarLogin`;
la que responda define a dónde redirige (`Libros` para empleado, `Portal`
para usuario) y guarda en la sesión `PersonaId`, `PersonaNombre` y
`PersonaRol`.

El control de acceso reutiliza el mismo mecanismo de herencia:

```
ControladorBase           (lee PersonaId/PersonaRol de la sesión)
├── ControladorEmpleado   (exige PersonaRol == "Empleado")
└── ControladorUsuario    (exige PersonaRol == "Usuario")
```

`ControladorEmpleado` y `ControladorUsuario` sobrescriben
`OnActionExecuting` (hook de ASP.NET Core que corre antes de cualquier
acción) para redirigir a `Login` si el rol de la sesión no coincide. Los
controladores de pantallas concretas (`LibrosController`, `UsuariosController`,
`EmpleadosController`, `PrestamosController` → heredan de
`ControladorEmpleado`; `PortalController` → hereda de `ControladorUsuario`)
no repiten esa validación, la heredan.

## La única relación entre entidades: `Prestamo`

`Prestamo` no guarda referencias a objetos `Usuario`/`Libro`, sino sus `Id`
(`UsuarioId`, `LibroId`) — necesario para poder serializarlo a JSON de forma
plana. Por eso `PrestamoService` recibe `LibroService` por constructor
(inyección de dependencias): al crear un préstamo descuenta una unidad de
`Libro.CantidadDisponible`, y al registrar una devolución la repone. Es la
única dependencia entre Services de la aplicación.

`Libro.EsDisponible()` (`CantidadDisponible > 0`) es lo que
`PrestamosController.Index` usa para ofrecer solo libros con copias libres al
crear un préstamo nuevo.

## Datos de ejemplo (`dotnet run -- seed`)

`DataSeeder.Sembrar` no escribe los JSON directamente: llama a los mismos
métodos de los Services que usa cualquier pantalla (`Agregar`,
`CrearPrestamo`, `RegistrarDevolucion`), así que los datos de ejemplo pasan
por las mismas validaciones y reglas de negocio que un uso real de la app.
Se invoca desde `Program.cs` como un modo especial (`args.Contains("seed")`)
que genera los archivos en `Data/` y termina el proceso sin levantar el
servidor web.
