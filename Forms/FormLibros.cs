using Biblioteca.Models;
using Biblioteca.Services;

namespace Biblioteca.Forms;

public partial class FormLibros : Form
{
    private readonly LibroService libroService;
    private int? idSeleccionado;

    public FormLibros(LibroService libroService)
    {
        this.libroService = libroService;
        InitializeComponent();
        RefrescarGrid(libroService.Listar());
    }

    private void RefrescarGrid(List<Libro> libros)
    {
        dgvLibros.Rows.Clear();
        foreach (var libro in libros)
        {
            dgvLibros.Rows.Add(
                libro.GetId(),
                libro.GetTitulo(),
                libro.GetAutor(),
                libro.GetISBN(),
                libro.GetCategoria(),
                libro.GetCantidadTotal(),
                libro.GetCantidadDisponible());
        }
    }

    private void dgvLibros_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvLibros.CurrentRow == null) return;

        var id = (int)dgvLibros.CurrentRow.Cells["colId"].Value;
        var libro = libroService.BuscarPorId(id);
        if (libro == null) return;

        idSeleccionado = libro.GetId();
        txtTitulo.Text = libro.GetTitulo();
        txtAutor.Text = libro.GetAutor();
        txtISBN.Text = libro.GetISBN();
        txtCategoria.Text = libro.GetCategoria();
        txtCantidadTotal.Text = libro.GetCantidadTotal().ToString();
    }

    private void btnAgregar_Click(object sender, EventArgs e)
    {
        if (!int.TryParse(txtCantidadTotal.Text, out var cantidadTotal))
        {
            MessageBox.Show("La cantidad total debe ser un número entero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            // Un libro recién registrado empieza con todas sus copias disponibles.
            var libro = new Libro(0, txtTitulo.Text, txtAutor.Text, txtISBN.Text, txtCategoria.Text, cantidadTotal, cantidadTotal);
            libroService.Agregar(libro);
            RefrescarGrid(libroService.Listar());
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
            MessageBox.Show("Selecciona un libro de la tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (!int.TryParse(txtCantidadTotal.Text, out var cantidadTotal))
        {
            MessageBox.Show("La cantidad total debe ser un número entero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            var libroExistente = libroService.BuscarPorId(idSeleccionado.Value)!;
            // La cantidad disponible no se edita a mano: la controlan los préstamos y devoluciones.
            var libroEditado = new Libro(libroExistente.GetId(), txtTitulo.Text, txtAutor.Text, txtISBN.Text,
                txtCategoria.Text, cantidadTotal, libroExistente.GetCantidadDisponible());
            libroService.Editar(libroEditado);
            RefrescarGrid(libroService.Listar());
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
            MessageBox.Show("Selecciona un libro de la tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var confirmacion = MessageBox.Show("¿Eliminar el libro seleccionado?", "Confirmar",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (confirmacion != DialogResult.Yes) return;

        libroService.Eliminar(idSeleccionado.Value);
        RefrescarGrid(libroService.Listar());
        LimpiarCampos();
    }

    private void btnBuscar_Click(object sender, EventArgs e)
    {
        RefrescarGrid(libroService.Buscar(txtBuscar.Text));
    }

    private void btnLimpiar_Click(object sender, EventArgs e)
    {
        LimpiarCampos();
    }

    private void LimpiarCampos()
    {
        idSeleccionado = null;
        txtTitulo.Clear();
        txtAutor.Clear();
        txtISBN.Clear();
        txtCategoria.Clear();
        txtCantidadTotal.Clear();
        dgvLibros.ClearSelection();
    }
}
