using Biblioteca.Models;
using Biblioteca.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers;

public class LibrosController : ControladorAutenticado
{
    private readonly LibroService libroService;

    public LibrosController(LibroService libroService)
    {
        this.libroService = libroService;
    }

    public IActionResult Index(string? buscar)
    {
        var libros = string.IsNullOrWhiteSpace(buscar) ? libroService.Listar() : libroService.Buscar(buscar);
        ViewBag.Buscar = buscar;
        return View(libros);
    }

    [HttpPost]
    public IActionResult Guardar(int id, string titulo, string autor, string isbn, string categoria, int cantidadTotal)
    {
        try
        {
            if (id == 0)
            {
                // Un libro recién registrado empieza con todas sus copias disponibles.
                var libro = new Libro(0, titulo, autor, isbn, categoria, cantidadTotal, cantidadTotal);
                libroService.Agregar(libro);
            }
            else
            {
                var libroExistente = libroService.BuscarPorId(id);
                if (libroExistente == null)
                {
                    TempData["Error"] = "El libro no existe.";
                    return RedirectToAction("Index");
                }

                // La cantidad disponible no se edita a mano: la controlan los préstamos y devoluciones.
                var libroEditado = new Libro(id, titulo, autor, isbn, categoria, cantidadTotal, libroExistente.GetCantidadDisponible());
                libroService.Editar(libroEditado);
            }
        }
        catch (ArgumentException ex)
        {
            TempData["Error"] = ex.Message;
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Eliminar(int id)
    {
        libroService.Eliminar(id);
        return RedirectToAction("Index");
    }
}
