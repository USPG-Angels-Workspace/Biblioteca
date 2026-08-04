using Microsoft.AspNetCore.Mvc.Filters;

namespace Biblioteca.Controllers;

// Controlador base para el portal del usuario (socio): solo un usuario
// con sesión iniciada puede entrar, nunca un empleado.
public class ControladorUsuario : ControladorBase
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (ObtenerRol() != "Usuario")
        {
            context.Result = RedirectToAction("Login", "Cuenta");
            return;
        }

        ViewBag.PersonaNombre = HttpContext.Session.GetString("PersonaNombre");
        ViewBag.PersonaRol = "Usuario";
        base.OnActionExecuting(context);
    }
}
