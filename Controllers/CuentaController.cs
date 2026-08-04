using Biblioteca.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers;

public class CuentaController : Controller
{
    private readonly BibliotecarioService bibliotecarioService;

    public CuentaController(BibliotecarioService bibliotecarioService)
    {
        this.bibliotecarioService = bibliotecarioService;
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
        if (bibliotecario == null)
        {
            ViewBag.Error = "Usuario o contraseña incorrectos.";
            return View();
        }

        HttpContext.Session.SetInt32("BibliotecarioId", bibliotecario.GetId());
        HttpContext.Session.SetString("BibliotecarioNombre", bibliotecario.GetNombre());
        return RedirectToAction("Index", "Libros");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}
