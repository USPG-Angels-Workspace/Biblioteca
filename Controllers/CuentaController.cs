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
    public IActionResult Login(string email, string contrasena)
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(contrasena))
        {
            ViewBag.Error = "Ingresa el email y la contraseña.";
            return View();
        }

        var bibliotecario = bibliotecarioService.ValidarLogin(email, contrasena);
        if (bibliotecario != null)
        {
            HttpContext.Session.SetInt32("PersonaId", bibliotecario.GetId());
            HttpContext.Session.SetString("PersonaNombre", bibliotecario.GetNombre());
            HttpContext.Session.SetString("PersonaRol", "Empleado");
            return RedirectToAction("Index", "Libros");
        }

        var usuario = usuarioService.ValidarLogin(email, contrasena);
        if (usuario != null)
        {
            HttpContext.Session.SetInt32("PersonaId", usuario.GetId());
            HttpContext.Session.SetString("PersonaNombre", usuario.GetNombre());
            HttpContext.Session.SetString("PersonaRol", "Usuario");
            return RedirectToAction("Index", "Portal");
        }

        ViewBag.Error = "Email o contraseña incorrectos.";
        return View();
    }

    public IActionResult Registro()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Registro(string nombre, string email, string contrasena)
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(contrasena))
        {
            ViewBag.Error = "Ingresa un email y una contraseña.";
            return View();
        }

        if (usuarioService.ExisteEmail(email))
        {
            ViewBag.Error = "Ese email ya está registrado.";
            return View();
        }

        try
        {
            var carnet = usuarioService.GenerarSiguienteCarnet();
            var usuario = new Usuario(0, nombre, carnet, email, contrasena, DateTime.Now);
            usuarioService.Agregar(usuario);

            HttpContext.Session.SetInt32("PersonaId", usuario.GetId());
            HttpContext.Session.SetString("PersonaNombre", usuario.GetNombre());
            HttpContext.Session.SetString("PersonaRol", "Usuario");
            TempData["Mensaje"] = $"¡Bienvenido! Tu carnet es {carnet}.";
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
