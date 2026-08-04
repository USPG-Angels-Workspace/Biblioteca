using Biblioteca.Models;
using Biblioteca.Services;

namespace Biblioteca.Forms;

public partial class FormUsuarios : Form
{
    private readonly UsuarioService usuarioService;
    private int? idSeleccionado;

    public FormUsuarios(UsuarioService usuarioService)
    {
        this.usuarioService = usuarioService;
        InitializeComponent();
        RefrescarGrid(usuarioService.Listar());
    }

    private void RefrescarGrid(List<Usuario> usuarios)
    {
        dgvUsuarios.Rows.Clear();
        foreach (var usuario in usuarios)
        {
            dgvUsuarios.Rows.Add(
                usuario.GetId(),
                usuario.GetNombre(),
                usuario.GetIdentificacion(),
                usuario.GetContacto(),
                usuario.GetFechaRegistro().ToShortDateString());
        }
    }

    private void dgvUsuarios_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvUsuarios.CurrentRow == null) return;

        var id = (int)dgvUsuarios.CurrentRow.Cells["colId"].Value;
        var usuario = usuarioService.BuscarPorId(id);
        if (usuario == null) return;

        idSeleccionado = usuario.GetId();
        txtNombre.Text = usuario.GetNombre();
        txtIdentificacion.Text = usuario.GetIdentificacion();
        txtContacto.Text = usuario.GetContacto();
    }

    private void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            var usuario = new Usuario(0, txtNombre.Text, txtIdentificacion.Text, txtContacto.Text, DateTime.Now);
            usuarioService.Agregar(usuario);
            RefrescarGrid(usuarioService.Listar());
            LimpiarCampos();
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void btnEditar_Click(object sender, EventArgs e)
    {
        if (idSeleccionado == null)
        {
            MessageBox.Show("Selecciona un usuario de la tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        try
        {
            var usuarioExistente = usuarioService.BuscarPorId(idSeleccionado.Value)!;
            var usuarioEditado = new Usuario(usuarioExistente.GetId(), txtNombre.Text, txtIdentificacion.Text,
                txtContacto.Text, usuarioExistente.GetFechaRegistro());
            usuarioService.Editar(usuarioEditado);
            RefrescarGrid(usuarioService.Listar());
            LimpiarCampos();
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void btnEliminar_Click(object sender, EventArgs e)
    {
        if (idSeleccionado == null)
        {
            MessageBox.Show("Selecciona un usuario de la tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var confirmacion = MessageBox.Show("¿Eliminar el usuario seleccionado?", "Confirmar",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirmacion != DialogResult.Yes) return;

        usuarioService.Eliminar(idSeleccionado.Value);
        RefrescarGrid(usuarioService.Listar());
        LimpiarCampos();
    }

    private void btnBuscar_Click(object sender, EventArgs e)
    {
        RefrescarGrid(usuarioService.Buscar(txtBuscar.Text));
    }

    private void btnLimpiar_Click(object sender, EventArgs e)
    {
        LimpiarCampos();
    }

    private void LimpiarCampos()
    {
        idSeleccionado = null;
        txtNombre.Clear();
        txtIdentificacion.Clear();
        txtContacto.Clear();
        dgvUsuarios.ClearSelection();
    }
}
