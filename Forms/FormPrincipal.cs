using Biblioteca.Models;
using Biblioteca.Services;

namespace Biblioteca.Forms;

public partial class FormPrincipal : Form
{
    private readonly Bibliotecario bibliotecarioActual;
    private readonly UsuarioService usuarioService = new();
    private readonly LibroService libroService = new();
    private readonly PrestamoService prestamoService;

    public FormPrincipal(Bibliotecario bibliotecarioActual)
    {
        this.bibliotecarioActual = bibliotecarioActual;
        prestamoService = new PrestamoService(libroService);
        InitializeComponent();
        lblBienvenida.Text = $"Bienvenido, {this.bibliotecarioActual.GetNombre()}";
    }

    private void btnLibros_Click(object sender, EventArgs e)
    {
        using var formLibros = new FormLibros(libroService);
        formLibros.ShowDialog();
    }

    private void btnUsuarios_Click(object sender, EventArgs e)
    {
        using var formUsuarios = new FormUsuarios(usuarioService);
        formUsuarios.ShowDialog();
    }

    private void btnPrestamos_Click(object sender, EventArgs e)
    {
        using var formPrestamos = new FormPrestamos(usuarioService, libroService, prestamoService);
        formPrestamos.ShowDialog();
    }

    private void btnSalir_Click(object sender, EventArgs e)
    {
        Close();
    }
}
