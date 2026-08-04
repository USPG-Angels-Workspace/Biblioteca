using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Biblioteca.Controllers;

// Controlador base: las acciones de cualquier controlador que herede de
// esta clase requieren haber iniciado sesión; si no, redirige al login.
public class ControladorAutenticado : Controller
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var bibliotecarioId = HttpContext.Session.GetInt32("BibliotecarioId");
        if (bibliotecarioId == null)
        {
            context.Result = RedirectToAction("Login", "Cuenta");
            return;
        }

        ViewBag.BibliotecarioNombre = HttpContext.Session.GetString("BibliotecarioNombre");
        base.OnActionExecuting(context);
    }
}
