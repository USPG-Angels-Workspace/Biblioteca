using Biblioteca.Models;
using Biblioteca.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers;

public class EmpleadosController : ControladorEmpleado
{
    private readonly BibliotecarioService bibliotecarioService;

    public EmpleadosController(BibliotecarioService bibliotecarioService)
    {
        this.bibliotecarioService = bibliotecarioService;
    }

    public IActionResult Index()
    {
        return View(bibliotecarioService.Listar());
    }

    [HttpPost]
    public IActionResult Guardar(int id, string nombre, string identificacion, string email, string contrasena)
    {
        try
        {
            if (id == 0)
            {
                var empleado = new Bibliotecario(0, nombre, identificacion, email, contrasena);
                bibliotecarioService.Agregar(empleado);
            }
            else
            {
                var empleadoExistente = bibliotecarioService.BuscarPorId(id);
                if (empleadoExistente == null)
                {
                    TempData["Error"] = "El empleado no existe.";
                    return RedirectToAction("Index");
                }

                // Si se deja en blanco la contraseña al editar, se conserva la actual.
                var contrasenaFinal = string.IsNullOrWhiteSpace(contrasena) ? empleadoExistente.GetContrasena() : contrasena;
                var empleadoEditado = new Bibliotecario(id, nombre, identificacion, email, contrasenaFinal);
                bibliotecarioService.Editar(empleadoEditado);
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
        bibliotecarioService.Eliminar(id);
        return RedirectToAction("Index");
    }
}
