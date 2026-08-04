using Biblioteca.Forms;
using Biblioteca.Services;

namespace Biblioteca;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        var bibliotecarioService = new BibliotecarioService();

        using var formLogin = new FormLogin(bibliotecarioService);
        if (formLogin.ShowDialog() == DialogResult.OK)
        {
            Application.Run(new FormPrincipal(formLogin.ObtenerBibliotecarioActual()!));
        }
    }
}