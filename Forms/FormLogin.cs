using Biblioteca.Models;
using Biblioteca.Services;

namespace Biblioteca.Forms;

public partial class FormLogin : Form
{
    private readonly BibliotecarioService bibliotecarioService;
    private Bibliotecario? bibliotecarioActual;

    public FormLogin(BibliotecarioService bibliotecarioService)
    {
        this.bibliotecarioService = bibliotecarioService;
        InitializeComponent();
    }

    public Bibliotecario? ObtenerBibliotecarioActual()
    {
        return bibliotecarioActual;
    }

    private void btnIngresar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtContrasena.Text))
        {
            lblMensaje.Text = "Ingresa el usuario y la contraseña.";
            return;
        }

        var bibliotecario = bibliotecarioService.ValidarLogin(txtUsuario.Text, txtContrasena.Text);
        if (bibliotecario == null)
        {
            lblMensaje.Text = "Usuario o contraseña incorrectos.";
            return;
        }

        bibliotecarioActual = bibliotecario;
        DialogResult = DialogResult.OK;
        Close();
    }
}
