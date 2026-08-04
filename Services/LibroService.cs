using System.Text.Json;
using System.Text.Json.Nodes;
using Biblioteca.Models;

namespace Biblioteca.Services;

// CRUD de libros del catálogo, con persistencia en JSON.
public class LibroService
{
    private readonly string rutaArchivo = Path.Combine(AppContext.BaseDirectory, "Data", "libros.json");
    private readonly List<Libro> libros = new();

    public LibroService()
    {
        Cargar();
    }

    public List<Libro> Listar()
    {
        return libros.ToList();
    }

    public Libro? BuscarPorId(int id)
    {
        return libros.FirstOrDefault(l => l.GetId() == id);
    }

    public List<Libro> Buscar(string texto)
    {
        if (string.IsNullOrWhiteSpace(texto)) return Listar();

        return libros.Where(l =>
            l.GetTitulo().Contains(texto, StringComparison.OrdinalIgnoreCase) ||
            l.GetAutor().Contains(texto, StringComparison.OrdinalIgnoreCase) ||
            l.GetCategoria().Contains(texto, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public void Agregar(Libro libro)
    {
        libro.SetId(libros.Count == 0 ? 1 : libros.Max(l => l.GetId()) + 1);
        libros.Add(libro);
        Guardar();
    }

    public void Editar(Libro libro)
    {
        var existente = BuscarPorId(libro.GetId());
        if (existente == null)
            throw new InvalidOperationException("El libro no existe.");

        existente.SetTitulo(libro.GetTitulo());
        existente.SetAutor(libro.GetAutor());
        existente.SetISBN(libro.GetISBN());
        existente.SetCategoria(libro.GetCategoria());
        existente.SetCantidadTotal(libro.GetCantidadTotal());
        existente.SetCantidadDisponible(libro.GetCantidadDisponible());
        Guardar();
    }

    public void Eliminar(int id)
    {
        libros.RemoveAll(l => l.GetId() == id);
        Guardar();
    }

    private void Cargar()
    {
        if (!File.Exists(rutaArchivo)) return;

        var arreglo = JsonNode.Parse(File.ReadAllText(rutaArchivo))!.AsArray();
        libros.Clear();
        foreach (var nodo in arreglo)
        {
            libros.Add(new Libro(
                nodo!["Id"]!.GetValue<int>(),
                nodo!["Titulo"]!.GetValue<string>(),
                nodo!["Autor"]!.GetValue<string>(),
                nodo!["ISBN"]!.GetValue<string>(),
                nodo!["Categoria"]!.GetValue<string>(),
                nodo!["CantidadTotal"]!.GetValue<int>(),
                nodo!["CantidadDisponible"]!.GetValue<int>()));
        }
    }

    private void Guardar()
    {
        Directory.CreateDirectory(Path.GetDirectoryName(rutaArchivo)!);
        var arreglo = new JsonArray();
        foreach (var libro in libros)
        {
            arreglo.Add(new JsonObject
            {
                ["Id"] = libro.GetId(),
                ["Titulo"] = libro.GetTitulo(),
                ["Autor"] = libro.GetAutor(),
                ["ISBN"] = libro.GetISBN(),
                ["Categoria"] = libro.GetCategoria(),
                ["CantidadTotal"] = libro.GetCantidadTotal(),
                ["CantidadDisponible"] = libro.GetCantidadDisponible()
            });
        }
        var opciones = new JsonSerializerOptions { WriteIndented = true };
        File.WriteAllText(rutaArchivo, arreglo.ToJsonString(opciones));
    }
}
