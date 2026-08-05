# Data

Aquí se guardan los archivos `.json` con la información del sistema. Cada uno
es un arreglo plano de objetos, sin anidar:

- **`bibliotecarios.json`** — empleados: `Id`, `Nombre`, `Identificacion`,
  `Email`, `Contrasena`.
- **`usuarios.json`** — socios: igual que bibliotecarios, más
  `FechaRegistro`. `Identificacion` es el carnet de estudiante (año + 5
  dígitos, ej. `2600001`).
- **`libros.json`** — catálogo: `Id`, `Titulo`, `Autor`, `ISBN`, `Categoria`,
  `CantidadTotal`, `CantidadDisponible`.
- **`prestamos.json`** — préstamos: `Id`, `UsuarioId`, `LibroId`,
  `FechaPrestamo`, `FechaDevolucionEsperada`, `FechaDevolucionReal` (nulo
  mientras está activo), `Estado` (`Activo` o `Devuelto`).

`prestamos.json` **no guarda los datos del usuario ni del libro**, solo sus
`Id` — para ver el nombre hay que buscarlo en `usuarios.json`/`libros.json`
por ese `Id` (así lo hace la app al mostrar la tabla de préstamos).

**No se suben al repositorio** (están en `.gitignore`) — cada quien los genera
localmente con:

```bash
dotnet run -- seed
```

(ver `DataSeeder.cs` en la raíz del proyecto). El programa los actualiza
automáticamente cada vez que se agrega, edita o elimina algo.
