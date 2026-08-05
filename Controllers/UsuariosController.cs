using Biblioteca.Models;
using Biblioteca.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers;

public class UsuariosController : ControladorEmpleado
{
    private readonly UsuarioService usuarioService;

    public UsuariosController(UsuarioService usuarioService)
    {
        this.usuarioService = usuarioService;
    }

    public IActionResult Index(string? buscar)
    {
        var usuarios = string.IsNullOrWhiteSpace(buscar) ? usuarioService.Listar() : usuarioService.Buscar(buscar);
        ViewBag.Buscar = buscar;
        return View(usuarios);
    }

    [HttpPost]
    public IActionResult Guardar(int id, string nombre, string identificacion, string email, string contrasena)
    {
        try
        {
            if (id == 0)
            {
                // El carnet se genera solo (año + consecutivo), no lo captura el empleado.
                var carnet = usuarioService.GenerarSiguienteCarnet();
                var usuario = new Usuario(0, nombre, carnet, email, contrasena, DateTime.Now);
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

                // Si se deja en blanco la contraseña al editar, se conserva la actual.
                var contrasenaFinal = string.IsNullOrWhiteSpace(contrasena) ? usuarioExistente.GetContrasena() : contrasena;
                var usuarioEditado = new Usuario(id, nombre, identificacion, email,
                    contrasenaFinal, usuarioExistente.GetFechaRegistro());
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
