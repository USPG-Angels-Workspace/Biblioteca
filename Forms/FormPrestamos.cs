using Biblioteca.Models;
using Biblioteca.Services;

namespace Biblioteca.Forms;

public partial class FormPrestamos : Form
{
    private readonly UsuarioService usuarioService;
    private readonly LibroService libroService;
    private readonly PrestamoService prestamoService;

    public FormPrestamos(UsuarioService usuarioService, LibroService libroService, PrestamoService prestamoService)
    {
        this.usuarioService = usuarioService;
        this.libroService = libroService;
        this.prestamoService = prestamoService;
        InitializeComponent();

        dtpFechaPrestamo.Value = DateTime.Now;
        dtpFechaDevolucionEsperada.Value = DateTime.Now.AddDays(7);

        RefrescarCombos();
        RefrescarGrid();
    }

    private void RefrescarCombos()
    {
        cmbUsuarios.Items.Clear();
        foreach (var usuario in usuarioService.Listar())
        {
            cmbUsuarios.Items.Add(usuario);
        }

        // Solo se pueden prestar libros que tengan al menos una copia disponible.
        cmbLibros.Items.Clear();
        foreach (var libro in libroService.Listar().Where(l => l.EsDisponible()))
        {
            cmbLibros.Items.Add(libro);
        }
    }

    private void RefrescarGrid()
    {
        dgvPrestamos.Rows.Clear();
        foreach (var prestamo in prestamoService.Listar())
        {
            var nombreUsuario = usuarioService.BuscarPorId(prestamo.GetUsuarioId())?.GetNombre() ?? "(usuario eliminado)";
            var tituloLibro = libroService.BuscarPorId(prestamo.GetLibroId())?.GetTitulo() ?? "(libro eliminado)";
            var fechaDevolucionReal = prestamo.GetFechaDevolucionReal();

            dgvPrestamos.Rows.Add(
                prestamo.GetId(),
                nombreUsuario,
                tituloLibro,
                prestamo.GetFechaPrestamo().ToShortDateString(),
                prestamo.GetFechaDevolucionEsperada().ToShortDateString(),
                fechaDevolucionReal.HasValue ? fechaDevolucionReal.Value.ToShortDateString() : "-",
                prestamo.GetEstado().ToString());
        }
    }

    private void btnPrestar_Click(object sender, EventArgs e)
    {
        if (cmbUsuarios.SelectedItem is not Usuario usuario || cmbLibros.SelectedItem is not Libro libro)
        {
            MessageBox.Show("Selecciona un usuario y un libro disponible.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        try
        {
            prestamoService.CrearPrestamo(usuario.GetId(), libro.GetId(), dtpFechaPrestamo.Value.Date, dtpFechaDevolucionEsperada.Value.Date);
            RefrescarCombos();
            RefrescarGrid();
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    private void btnDevolver_Click(object sender, EventArgs e)
    {
        if (dgvPrestamos.CurrentRow == null)
        {
            MessageBox.Show("Selecciona un préstamo de la tabla.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var id = (int)dgvPrestamos.CurrentRow.Cells["colIdPrestamo"].Value;

        try
        {
            prestamoService.RegistrarDevolucion(id, DateTime.Now.Date);
            RefrescarCombos();
            RefrescarGrid();
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
