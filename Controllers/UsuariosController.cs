using Biblioteca.Models;
using Biblioteca.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers;

public class UsuariosController : ControladorAutenticado
{
    private readonly UsuarioService usuarioService;

    public UsuariosController(UsuarioService usuarioService)
    {
        this.usuarioService = usuarioService;
    }

    public IActionResult Index(string? buscar, int? editarId)
    {
        var usuarios = string.IsNullOrWhiteSpace(buscar) ? usuarioService.Listar() : usuarioService.Buscar(buscar);
        ViewBag.Buscar = buscar;
        ViewBag.UsuarioEditando = editarId.HasValue ? usuarioService.BuscarPorId(editarId.Value) : null;
        return View(usuarios);
    }

    [HttpPost]
    public IActionResult Guardar(int id, string nombre, string identificacion, string contacto)
    {
        try
        {
            if (id == 0)
            {
                var usuario = new Usuario(0, nombre, identificacion, contacto, DateTime.Now);
                usuarioService.Agregar(usuario);
            }
            else
            {
                var usuarioExistente = usuarioService.BuscarPorId(id);
                if (usuarioExistente == null)
                {
                    TempData["Error"] = "El usuario no existe.";
                    return RedirectToAction("Index");
                }

                var usuarioEditado = new Usuario(id, nombre, identificacion, contacto, usuarioExistente.GetFechaRegistro());
                usuarioService.Editar(usuarioEditado);
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
        usuarioService.Eliminar(id);
        return RedirectToAction("Index");
    }
}
