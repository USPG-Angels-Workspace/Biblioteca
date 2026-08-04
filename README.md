# Biblioteca
[2do Semestre] Sistema de gestión de biblioteca

Sistema de Gestión Bibliotecaria en C# con ASP.NET Core MVC, pensado
para practicar POO (encapsulamiento, herencia y polimorfismo) y el patrón MVC.

## Cómo ejecutarlo

1. Desde la raíz del proyecto:
   ```bash
   dotnet run
   ```
2. Abrir en el navegador la URL que muestra la consola (por ejemplo `http://localhost:5000`).
3. Iniciar sesión con alguna de las credenciales de ejemplo:

   | Rol | Usuario | Contraseña | Qué ve |
   |---|---|---|---|
   | Empleado (bibliotecario) | `admin` | `admin123` | Gestión de libros, usuarios, empleados y préstamos |
   | Usuario (socio) | `maria`, `carlos` o `ana` | `usuario123` | Su portal: sus propios préstamos y el catálogo disponible |

Corre igual en Windows, Linux o Mac — no requiere nada adicional (los estilos
usan [Tailwind CSS por CDN](https://tailwindcss.com/), sin necesidad de Node/npm).

Los datos (libros, usuarios, préstamos y bibliotecarios) se guardan en archivos
JSON dentro de `Data/`, que ya incluyen datos de ejemplo para probar el sistema.

## Roles

- **Empleado** (`Bibliotecario`): gestiona el ingreso de libros, usuarios y otros
  empleados, y registra los préstamos/devoluciones.
- **Usuario** (socio, `Usuario`): tiene su propio login y, al entrar, solo ve
  sus propios préstamos (activos e historial) y el catálogo de libros
  disponibles — el préstamo en sí lo sigue registrando un empleado.

## Estructura

- `Models/` — clases del dominio (`Persona`, `Usuario`, `Bibliotecario`, `Libro`, `Prestamo`). `Persona`
  concentra los datos y credenciales comunes; `Usuario` y `Bibliotecario` heredan de ella.
- `Services/` — lógica de negocio y persistencia en JSON.
- `Controllers/` — controladores MVC (`Cuenta`, `Libros`, `Usuarios`, `Empleados`, `Prestamos`, `Portal`).
  `ControladorEmpleado`/`ControladorUsuario` restringen cada grupo de pantallas según el rol de la sesión.
- `Views/` — vistas Razor (`.cshtml`), con un layout compartido (`Views/Shared/_Layout.cshtml`)
  que define el menú lateral (distinto según el rol) y carga Tailwind por CDN.
