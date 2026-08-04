using Biblioteca.Models;
using Biblioteca.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers;

public class PrestamosController : ControladorAutenticado
{
    private readonly UsuarioService usuarioService;
    private readonly LibroService libroService;
    private readonly PrestamoService prestamoService;

    public PrestamosController(UsuarioService usuarioService, LibroService libroService, PrestamoService prestamoService)
    {
        this.usuarioService = usuarioService;
        this.libroService = libroService;
        this.prestamoService = prestamoService;
    }

    public IActionResult Index()
    {
        ViewBag.Usuarios = usuarioService.Listar();
        // Solo se pueden prestar libros que tengan al menos una copia disponible.
        ViewBag.LibrosDisponibles = libroService.Listar().Where(l => l.EsDisponible()).ToList();

        var filas = prestamoService.Listar().Select(p => new PrestamoFila
        {
            Id = p.GetId(),
            Usuario = usuarioService.BuscarPorId(p.GetUsuarioId())?.GetNombre() ?? "(usuario eliminado)",
            Libro = libroService.BuscarPorId(p.GetLibroId())?.GetTitulo() ?? "(libro eliminado)",
            FechaPrestamo = p.GetFechaPrestamo(),
            FechaDevolucionEsperada = p.GetFechaDevolucionEsperada(),
            FechaDevolucionReal = p.GetFechaDevolucionReal(),
            Estado = p.GetEstado().ToString()
        }).ToList();

        return View(filas);
    }

    [HttpPost]
    public IActionResult Prestar(int usuarioId, int libroId, DateTime fechaPrestamo, DateTime fechaDevolucionEsperada)
    {
        try
        {
            prestamoService.CrearPrestamo(usuarioId, libroId, fechaPrestamo, fechaDevolucionEsperada);
        }
        catch (InvalidOperationException ex)
        {
            TempData["Error"] = ex.Message;
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Devolver(int id)
    {
        try
        {
            prestamoService.RegistrarDevolucion(id, DateTime.Now.Date);
        }
        catch (InvalidOperationException ex)
        {
            TempData["Error"] = ex.Message;
        }

        return RedirectToAction("Index");
    }

    // Fila de solo lectura para mostrar los préstamos en la vista, con
    // nombres en vez de los identificadores numéricos que guarda Prestamo.
    public class PrestamoFila
    {
        public int Id { get; set; }
        public string Usuario { get; set; } = string.Empty;
        public string Libro { get; set; } = string.Empty;
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucionEsperada { get; set; }
        public DateTime? FechaDevolucionReal { get; set; }
        public string Estado { get; set; } = string.Empty;
    }
}
