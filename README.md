# Biblioteca
[2do Semestre] Sistema de gestión de biblioteca

Sistema de Gestión Bibliotecaria en C# con Windows Forms (.NET 8), pensado
para practicar POO (encapsulamiento, herencia y polimorfismo).

## Cómo ejecutarlo

Requiere Windows (Windows Forms no tiene interfaz gráfica en Linux/Mac).

1. Abrir `Biblioteca.slnx` en Visual Studio, o desde la terminal:
   ```
   dotnet run
   ```
2. Iniciar sesión con el bibliotecario por defecto: usuario `admin`, contraseña `admin123`.

Los datos (libros, usuarios, préstamos y bibliotecarios) se guardan en archivos
JSON dentro de `Data/`, que se crean automáticamente en el primer uso.

## Estructura

- `Models/` — clases del dominio (`Persona`, `Usuario`, `Bibliotecario`, `Libro`, `Prestamo`).
- `Services/` — lógica de negocio y persistencia en JSON.
- `Forms/` — interfaz gráfica (Login, Principal, Libros, Usuarios, Préstamos).
