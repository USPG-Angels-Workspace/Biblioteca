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
3. Iniciar sesión con el bibliotecario por defecto: usuario `admin`, contraseña `admin123`.

Corre igual en Windows, Linux o Mac — no requiere nada adicional (los estilos
usan [Tailwind CSS por CDN](https://tailwindcss.com/), sin necesidad de Node/npm).

Los datos (libros, usuarios, préstamos y bibliotecarios) se guardan en archivos
JSON dentro de `Data/`, que ya incluyen datos de ejemplo para probar el sistema.

## Estructura

- `Models/` — clases del dominio (`Persona`, `Usuario`, `Bibliotecario`, `Libro`, `Prestamo`).
- `Services/` — lógica de negocio y persistencia en JSON.
- `Controllers/` — controladores MVC (`Cuenta`, `Libros`, `Usuarios`, `Prestamos`).
- `Views/` — vistas Razor (`.cshtml`), con un layout compartido (`Views/Shared/_Layout.cshtml`)
  que define el menú lateral y carga Tailwind por CDN.
