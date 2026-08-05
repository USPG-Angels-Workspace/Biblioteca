using Biblioteca.Models;
using Biblioteca.Services;

namespace Biblioteca;

// Genera datos de ejemplo usando los mismos Services de la app (los mismos
// Agregar()/CrearPrestamo() que usa cualquier pantalla) — no escribe JSON
// directamente. Se ejecuta con: dotnet run -- seed
public static class DataSeeder
{
    public static void Sembrar(UsuarioService usuarioService, LibroService libroService, PrestamoService prestamoService)
    {
        if (usuarioService.Listar().Count == 0)
        {
            // Identificación = carnet de estudiante (año + número), ej. 2600001.
            usuarioService.Agregar(new Usuario(0, "María Fernanda López", "2600001",
                "maria.lopez@uspg.edu.gt", "usuario123", DateTime.Now));
            usuarioService.Agregar(new Usuario(0, "Carlos Andrés Pérez", "2600002",
                "carlos.perez@uspg.edu.gt", "usuario123", DateTime.Now));
            usuarioService.Agregar(new Usuario(0, "Ana Lucía Ramírez", "2600003",
                "ana.ramirez@uspg.edu.gt", "usuario123", DateTime.Now));
        }

        if (libroService.Listar().Count == 0)
        {
            libroService.Agregar(new Libro(0, "Cien años de soledad", "Gabriel García Márquez",
                "978-0307474728", "Novela", 3, 3));
            libroService.Agregar(new Libro(0, "El Principito", "Antoine de Saint-Exupéry",
                "978-0156012195", "Fábula", 4, 4));
            libroService.Agregar(new Libro(0, "Clean Code", "Robert C. Martin",
                "978-0132350884", "Tecnología", 2, 2));
            libroService.Agregar(new Libro(0, "Introducción a la Programación", "Luis Joyanes Aguilar",
                "978-9701073947", "Educación", 5, 5));
            libroService.Agregar(new Libro(0, "Sapiens: De animales a dioses", "Yuval Noah Harari",
                "978-8499926223", "Historia", 2, 2));
        }

        var usuarios = usuarioService.Listar();
        var libros = libroService.Listar();

        if (prestamoService.Listar().Count == 0 && usuarios.Count >= 3 && libros.Count >= 3)
        {
            prestamoService.CrearPrestamo(usuarios[0].GetId(), libros[0].GetId(), DateTime.Now.AddDays(-7), DateTime.Now);
            prestamoService.CrearPrestamo(usuarios[1].GetId(), libros[2].GetId(), DateTime.Now.AddDays(-3), DateTime.Now.AddDays(4));

            // El tercero ya se devolvió: se crea y se marca como devuelto para mostrar ambos casos.
            var devuelto = prestamoService.CrearPrestamo(usuarios[2].GetId(), libros[1].GetId(),
                DateTime.Now.AddDays(-25), DateTime.Now.AddDays(-18));
            prestamoService.RegistrarDevolucion(devuelto.GetId(), DateTime.Now.AddDays(-19));
        }
    }
}
