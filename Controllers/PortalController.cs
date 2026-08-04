using Biblioteca.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers;

// Portal de autoservicio del usuario (socio): solo lectura — ve sus propios
// préstamos y el catálogo de libros disponibles. El préstamo en sí lo
// sigue registrando un empleado.
public class PortalController : ControladorUsuario
{
    private readonly UsuarioService usuarioService;
    private readonly LibroService libroService;
    private readonly PrestamoService prestamoService;

    public PortalController(UsuarioService usuarioService, LibroService libroService, PrestamoService prestamoService)
    {
        this.usuarioService = usuarioService;
        this.libroService = libroService;
        this.prestamoService = prestamoService;
    }

    public IActionResult Index()
    {
        var personaId = ObtenerPersonaId()!.Value;

        var misPrestamos = prestamoService.Listar()
            .Where(p => p.GetUsuarioId() == personaId)
            .Select(p => new PrestamosController.PrestamoFila
            {
                Id = p.GetId(),
                Usuario = usuarioService.BuscarPorId(p.GetUsuarioId())?.GetNombre() ?? string.Empty,
                Libro = libroService.BuscarPorId(p.GetLibroId())?.GetTitulo() ?? "(libro eliminado)",
                FechaPrestamo = p.GetFechaPrestamo(),
                FechaDevolucionEsperada = p.GetFechaDevolucionEsperada(),
                FechaDevolucionReal = p.GetFechaDevolucionReal(),
                Estado = p.GetEstado().ToString()
            })
            .OrderByDescending(p => p.FechaPrestamo)
            .ToList();

        ViewBag.LibrosDisponibles = libroService.Listar().Where(l => l.EsDisponible()).ToList();

        return View(misPrestamos);
    }
}
