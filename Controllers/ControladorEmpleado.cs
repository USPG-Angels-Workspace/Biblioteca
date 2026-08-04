using Microsoft.AspNetCore.Mvc.Filters;

namespace Biblioteca.Controllers;

// Controlador base para las pantallas de gestión (Libros, Usuarios,
// Empleados, Préstamos): solo un empleado con sesión iniciada puede entrar.
public class ControladorEmpleado : ControladorBase
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (ObtenerRol() != "Empleado")
        {
            context.Result = RedirectToAction("Login", "Cuenta");
            return;
        }

        ViewBag.PersonaNombre = HttpContext.Session.GetString("PersonaNombre");
        ViewBag.PersonaRol = "Empleado";
        base.OnActionExecuting(context);
    }
}
