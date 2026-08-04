using System.Text.Json;
using System.Text.Json.Nodes;
using Biblioteca.Models;

namespace Biblioteca.Services;

// Gestiona los préstamos: valida disponibilidad al crear uno y actualiza
// el libro correspondiente al crear o devolver un préstamo.
public class PrestamoService
{
    private readonly string rutaArchivo;
    private readonly List<Prestamo> prestamos = new();
    private readonly LibroService libroService;

    public PrestamoService(LibroService libroService, IWebHostEnvironment env)
    {
        this.libroService = libroService;
        rutaArchivo = Path.Combine(env.ContentRootPath, "Data", "prestamos.json");
        Cargar();
    }

    public List<Prestamo> Listar()
    {
        return prestamos.ToList();
    }

    public Prestamo? BuscarPorId(int id)
    {
        return prestamos.FirstOrDefault(p => p.GetId() == id);
    }

    public Prestamo CrearPrestamo(int usuarioId, int libroId, DateTime fechaPrestamo, DateTime fechaDevolucionEsperada)
    {
        var libro = libroService.BuscarPorId(libroId);
        if (libro == null)
            throw new InvalidOperationException("El libro seleccionado no existe.");
        if (!libro.EsDisponible())
            throw new InvalidOperationException("No hay unidades disponibles de este libro.");

        libro.SetCantidadDisponible(libro.GetCantidadDisponible() - 1);
        libroService.Editar(libro);

        var prestamo = new Prestamo(
            prestamos.Count == 0 ? 1 : prestamos.Max(p => p.GetId()) + 1,
            usuarioId,
            libroId,
            fechaPrestamo,
            fechaDevolucionEsperada,
            null,
            EstadoPrestamo.Activo);

        prestamos.Add(prestamo);
        Guardar();
        return prestamo;
    }

    public void RegistrarDevolucion(int prestamoId, DateTime fechaDevolucionReal)
    {
        var prestamo = BuscarPorId(prestamoId);
        if (prestamo == null)
            throw new InvalidOperationException("El préstamo no existe.");
        if (prestamo.GetEstado() == EstadoPrestamo.Devuelto)
            throw new InvalidOperationException("Este préstamo ya fue devuelto.");

        prestamo.SetFechaDevolucionReal(fechaDevolucionReal);
        prestamo.SetEstado(EstadoPrestamo.Devuelto);

        var libro = libroService.BuscarPorId(prestamo.GetLibroId());
        if (libro != null)
        {
            libro.SetCantidadDisponible(libro.GetCantidadDisponible() + 1);
            libroService.Editar(libro);
        }

        Guardar();
    }

    private void Cargar()
    {
        if (!File.Exists(rutaArchivo)) return;

        var arreglo = JsonNode.Parse(File.ReadAllText(rutaArchivo))!.AsArray();
        prestamos.Clear();
        foreach (var nodo in arreglo)
        {
            prestamos.Add(new Prestamo(
                nodo!["Id"]!.GetValue<int>(),
                nodo!["UsuarioId"]!.GetValue<int>(),
                nodo!["LibroId"]!.GetValue<int>(),
                nodo!["FechaPrestamo"]!.GetValue<DateTime>(),
                nodo!["FechaDevolucionEsperada"]!.GetValue<DateTime>(),
                nodo!["FechaDevolucionReal"]?.GetValue<DateTime>(),
                Enum.Parse<EstadoPrestamo>(nodo!["Estado"]!.GetValue<string>())));
        }
    }

    private void Guardar()
    {
        Directory.CreateDirectory(Path.GetDirectoryName(rutaArchivo)!);
        var arreglo = new JsonArray();
        foreach (var prestamo in prestamos)
        {
            arreglo.Add(new JsonObject
            {
                ["Id"] = prestamo.GetId(),
                ["UsuarioId"] = prestamo.GetUsuarioId(),
                ["LibroId"] = prestamo.GetLibroId(),
                ["FechaPrestamo"] = prestamo.GetFechaPrestamo(),
                ["FechaDevolucionEsperada"] = prestamo.GetFechaDevolucionEsperada(),
                ["FechaDevolucionReal"] = prestamo.GetFechaDevolucionReal(),
                ["Estado"] = prestamo.GetEstado().ToString()
            });
        }
        var opciones = new JsonSerializerOptions { WriteIndented = true };
        File.WriteAllText(rutaArchivo, arreglo.ToJsonString(opciones));
    }
}
