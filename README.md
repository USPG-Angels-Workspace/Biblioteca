# Biblioteca
[2do Semestre] Sistema de gestión de biblioteca

Sistema de Gestión Bibliotecaria en C# con ASP.NET Core MVC, pensado
para practicar POO (encapsulamiento, herencia y polimorfismo) y el patrón MVC.

## Cómo ejecutarlo

1. Desde la raíz del proyecto, generar los datos de ejemplo (solo la primera vez,
   o cuando quieras reiniciar los datos desde cero):
   ```bash
   dotnet run -- seed
   ```
2. Levantar la app:
   ```bash
   dotnet run
   ```
3. Abrir en el navegador la URL que muestra la consola (por ejemplo `http://localhost:5000`).
4. Iniciar sesión con alguna de las credenciales de ejemplo (o crear una cuenta de
   socio nueva desde el link "Crear cuenta" del login):

   | Rol | Email | Contraseña | Qué ve |
   |---|---|---|---|
   | Empleado (bibliotecario) | `admin@biblioteca.edu.gt` | `admin123` | Gestión de libros, usuarios, empleados y préstamos |
   | Usuario (socio) | `maria.lopez@uspg.edu.gt`, `carlos.perez@uspg.edu.gt` o `ana.ramirez@uspg.edu.gt` | `usuario123` | Su portal: sus propios préstamos y el catálogo disponible |

Corre igual en Windows, Linux o Mac — no requiere nada adicional (los estilos
usan [Tailwind CSS por CDN](https://tailwindcss.com/), sin necesidad de Node/npm).

Los datos (libros, usuarios, préstamos y bibliotecarios) se guardan en archivos
JSON dentro de `Data/`, que **no se suben al repo** (están en `.gitignore`) —
se generan localmente con `dotnet run -- seed`, o simplemente usando la app
(registrar un socio, agregar un libro, etc. ya crea los archivos si no existen).

## Roles

- **Empleado** (`Bibliotecario`): gestiona el ingreso de libros, usuarios y otros
  empleados, y registra los préstamos/devoluciones.
- **Usuario** (socio, `Usuario`): tiene su propio login (email + contraseña) y, al
  entrar, solo ve sus propios préstamos (activos e historial) y el catálogo de
  libros disponibles — el préstamo en sí lo sigue registrando un empleado. Su
  identificación es el carnet de estudiante: año (2 dígitos) + número (5 dígitos),
  ej. `2600100`.

## Estructura

- `Models/` — clases del dominio (`Persona`, `Usuario`, `Bibliotecario`, `Libro`, `Prestamo`). `Persona`
  concentra los datos y credenciales comunes; `Usuario` y `Bibliotecario` heredan de ella.
- `Services/` — lógica de negocio y persistencia en JSON.
- `Controllers/` — controladores MVC (`Cuenta`, `Libros`, `Usuarios`, `Empleados`, `Prestamos`, `Portal`).
  `ControladorEmpleado`/`ControladorUsuario` restringen cada grupo de pantallas según el rol de la sesión.
- `Views/` — vistas Razor (`.cshtml`), con un layout compartido (`Views/Shared/_Layout.cshtml`)
  que define el menú lateral (distinto según el rol) y carga Tailwind por CDN.
- `DataSeeder.cs` — genera los datos de ejemplo (usa los mismos `Services` que la app,
  no escribe JSON directamente). Se ejecuta con `dotnet run -- seed`.
