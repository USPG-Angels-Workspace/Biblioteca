using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers;

// Controlador base con acceso a los datos de la sesión de la persona
// que inició sesión (empleado o usuario). No exige ningún rol por sí sola.
public abstract class ControladorBase : Controller
{
    protected int? ObtenerPersonaId()
    {
        return HttpContext.Session.GetInt32("PersonaId");
    }

    protected string? ObtenerRol()
    {
        return HttpContext.Session.GetString("PersonaRol");
    }
}
