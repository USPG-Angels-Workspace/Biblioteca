# Data

Aquí se guardan los archivos `.json` con la información del sistema
(`bibliotecarios.json`, `usuarios.json`, `libros.json`, `prestamos.json`).

**No se suben al repositorio** (están en `.gitignore`) — cada quien los genera
localmente con:

```bash
dotnet run -- seed
```

(ver `DataSeeder.cs` en la raíz del proyecto). El programa los actualiza
automáticamente cada vez que se agrega, edita o elimina algo.
