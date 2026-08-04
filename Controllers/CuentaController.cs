using Biblioteca.Models;
using Biblioteca.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers;

public class CuentaController : Controller
{
    private readonly BibliotecarioService bibliotecarioService;
    private readonly UsuarioService usuarioService;

    public CuentaController(BibliotecarioService bibliotecarioService, UsuarioService usuarioService)
    {
        this.bibliotecarioService = bibliotecarioService;
        this.usuarioService = usuarioService;
    }

    public IActionResult Index()
    {
        return RedirectToAction("Login");
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string nombreUsuario, string contrasena)
    {
        if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(contrasena))
        {
            ViewBag.Error = "Ingresa el usuario y la contraseña.";
            return View();
        }

        var bibliotecario = bibliotecarioService.ValidarLogin(nombreUsuario, contrasena);
        if (bibliotecario != null)
        {
            HttpContext.Session.SetInt32("PersonaId", bibliotecario.GetId());
            HttpContext.Session.SetString("PersonaNombre", bibliotecario.GetNombre());
            HttpContext.Session.SetString("PersonaRol", "Empleado");
            return RedirectToAction("Index", "Libros");
        }

        var usuario = usuarioService.ValidarLogin(nombreUsuario, contrasena);
        if (usuario != null)
        {
            HttpContext.Session.SetInt32("PersonaId", usuario.GetId());
            HttpContext.Session.SetString("PersonaNombre", usuario.GetNombre());
            HttpContext.Session.SetString("PersonaRol", "Usuario");
            return RedirectToAction("Index", "Portal");
        }

        ViewBag.Error = "Usuario o contraseña incorrectos.";
        return View();
    }

    public IActionResult Registro()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Registro(string nombre, string identificacion, string contacto, string nombreUsuario, string contrasena)
    {
        if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(contrasena))
        {
            ViewBag.Error = "Ingresa un usuario y una contraseña.";
            return View();
        }

        if (usuarioService.ExisteNombreUsuario(nombreUsuario))
        {
            ViewBag.Error = "Ese nombre de usuario ya está en uso.";
            return View();
        }

        try
        {
            var usuario = new Usuario(0, nombre, identificacion, contacto, nombreUsuario, contrasena, DateTime.Now);
            usuarioService.Agregar(usuario);

            HttpContext.Session.SetInt32("PersonaId", usuario.GetId());
            HttpContext.Session.SetString("PersonaNombre", usuario.GetNombre());
            HttpContext.Session.SetString("PersonaRol", "Usuario");
            return RedirectToAction("Index", "Portal");
        }
        catch (ArgumentException ex)
        {
            ViewBag.Error = ex.Message;
            return View();
        }
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}
