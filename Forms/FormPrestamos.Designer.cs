namespace Biblioteca.Forms;

partial class FormPrestamos
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblUsuario = new Label();
        cmbUsuarios = new ComboBox();
        lblLibro = new Label();
        cmbLibros = new ComboBox();
        lblFechaPrestamo = new Label();
        dtpFechaPrestamo = new DateTimePicker();
        lblFechaDevolucionEsperada = new Label();
        dtpFechaDevolucionEsperada = new DateTimePicker();
        btnPrestar = new Button();
        btnDevolver = new Button();
        dgvPrestamos = new DataGridView();
        colIdPrestamo = new DataGridViewTextBoxColumn();
        colUsuarioPrestamo = new DataGridViewTextBoxColumn();
        colLibroPrestamo = new DataGridViewTextBoxColumn();
        colFechaPrestamo = new DataGridViewTextBoxColumn();
        colFechaDevolucionEsperada = new DataGridViewTextBoxColumn();
        colFechaDevolucionReal = new DataGridViewTextBoxColumn();
        colEstado = new DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)dgvPrestamos).BeginInit();
        SuspendLayout();
        //
        // lblUsuario
        //
        lblUsuario.AutoSize = true;
        lblUsuario.Location = new Point(20, 20);
        lblUsuario.Name = "lblUsuario";
        lblUsuario.Size = new Size(56, 15);
        lblUsuario.TabIndex = 0;
        lblUsuario.Text = "Usuario:";
        //
        // cmbUsuarios
        //
        cmbUsuarios.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbUsuarios.FormattingEnabled = true;
        cmbUsuarios.Location = new Point(100, 17);
        cmbUsuarios.Name = "cmbUsuarios";
        cmbUsuarios.Size = new Size(220, 23);
        cmbUsuarios.TabIndex = 1;
        //
        // lblLibro
        //
        lblLibro.AutoSize = true;
        lblLibro.Location = new Point(340, 20);
        lblLibro.Name = "lblLibro";
        lblLibro.Size = new Size(40, 15);
        lblLibro.TabIndex = 2;
        lblLibro.Text = "Libro:";
        //
        // cmbLibros
        //
        cmbLibros.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbLibros.FormattingEnabled = true;
        cmbLibros.Location = new Point(400, 17);
        cmbLibros.Name = "cmbLibros";
        cmbLibros.Size = new Size(220, 23);
        cmbLibros.TabIndex = 3;
        //
        // lblFechaPrestamo
        //
        lblFechaPrestamo.AutoSize = true;
        lblFechaPrestamo.Location = new Point(20, 60);
        lblFechaPrestamo.Name = "lblFechaPrestamo";
        lblFechaPrestamo.Size = new Size(97, 15);
        lblFechaPrestamo.TabIndex = 4;
        lblFechaPrestamo.Text = "Fecha préstamo:";
        //
        // dtpFechaPrestamo
        //
        dtpFechaPrestamo.Location = new Point(140, 57);
        dtpFechaPrestamo.Name = "dtpFechaPrestamo";
        dtpFechaPrestamo.Size = new Size(150, 23);
        dtpFechaPrestamo.TabIndex = 5;
        //
        // lblFechaDevolucionEsperada
        //
        lblFechaDevolucionEsperada.AutoSize = true;
        lblFechaDevolucionEsperada.Location = new Point(340, 60);
        lblFechaDevolucionEsperada.Name = "lblFechaDevolucionEsperada";
        lblFechaDevolucionEsperada.Size = new Size(150, 15);
        lblFechaDevolucionEsperada.TabIndex = 6;
        lblFechaDevolucionEsperada.Text = "Devolución esperada:";
        //
        // dtpFechaDevolucionEsperada
        //
        dtpFechaDevolucionEsperada.Location = new Point(500, 57);
        dtpFechaDevolucionEsperada.Name = "dtpFechaDevolucionEsperada";
        dtpFechaDevolucionEsperada.Size = new Size(150, 23);
        dtpFechaDevolucionEsperada.TabIndex = 7;
        //
        // btnPrestar
        //
        btnPrestar.Location = new Point(20, 100);
        btnPrestar.Name = "btnPrestar";
        btnPrestar.Size = new Size(140, 30);
        btnPrestar.TabIndex = 8;
        btnPrestar.Text = "Registrar préstamo";
        btnPrestar.UseVisualStyleBackColor = true;
        btnPrestar.Click += btnPrestar_Click;
        //
        // btnDevolver
        //
        btnDevolver.Location = new Point(170, 100);
        btnDevolver.Name = "btnDevolver";
        btnDevolver.Size = new Size(140, 30);
        btnDevolver.TabIndex = 9;
        btnDevolver.Text = "Registrar devolución";
        btnDevolver.UseVisualStyleBackColor = true;
        btnDevolver.Click += btnDevolver_Click;
        //
        // dgvPrestamos
        //
        dgvPrestamos.AllowUserToAddRows = false;
        dgvPrestamos.AllowUserToDeleteRows = false;
        dgvPrestamos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvPrestamos.AutoGenerateColumns = false;
        dgvPrestamos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvPrestamos.Columns.AddRange(new DataGridViewColumn[] { colIdPrestamo, colUsuarioPrestamo, colLibroPrestamo, colFechaPrestamo, colFechaDevolucionEsperada, colFechaDevolucionReal, colEstado });
        dgvPrestamos.Location = new Point(20, 145);
        dgvPrestamos.MultiSelect = false;
        dgvPrestamos.Name = "dgvPrestamos";
        dgvPrestamos.ReadOnly = true;
        dgvPrestamos.RowHeadersVisible = false;
        dgvPrestamos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvPrestamos.Size = new Size(720, 330);
        dgvPrestamos.TabIndex = 10;
        //
        // colIdPrestamo
        //
        colIdPrestamo.HeaderText = "Id";
        colIdPrestamo.Name = "colIdPrestamo";
        colIdPrestamo.Visible = false;
        //
        // colUsuarioPrestamo
        //
        colUsuarioPrestamo.HeaderText = "Usuario";
        colUsuarioPrestamo.Name = "colUsuarioPrestamo";
        //
        // colLibroPrestamo
        //
        colLibroPrestamo.HeaderText = "Libro";
        colLibroPrestamo.Name = "colLibroPrestamo";
        //
        // colFechaPrestamo
        //
        colFechaPrestamo.HeaderText = "Fecha préstamo";
        colFechaPrestamo.Name = "colFechaPrestamo";
        //
        // colFechaDevolucionEsperada
        //
        colFechaDevolucionEsperada.HeaderText = "Devolución esperada";
        colFechaDevolucionEsperada.Name = "colFechaDevolucionEsperada";
        //
        // colFechaDevolucionReal
        //
        colFechaDevolucionReal.HeaderText = "Devolución real";
        colFechaDevolucionReal.Name = "colFechaDevolucionReal";
        //
        // colEstado
        //
        colEstado.HeaderText = "Estado";
        colEstado.Name = "colEstado";
        //
        // FormPrestamos
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(760, 500);
        Controls.Add(dgvPrestamos);
        Controls.Add(btnDevolver);
        Controls.Add(btnPrestar);
        Controls.Add(dtpFechaDevolucionEsperada);
        Controls.Add(lblFechaDevolucionEsperada);
        Controls.Add(dtpFechaPrestamo);
        Controls.Add(lblFechaPrestamo);
        Controls.Add(cmbLibros);
        Controls.Add(lblLibro);
        Controls.Add(cmbUsuarios);
        Controls.Add(lblUsuario);
        MinimumSize = new Size(600, 400);
        Name = "FormPrestamos";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Gestión de préstamos";
        ((System.ComponentModel.ISupportInitialize)dgvPrestamos).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblUsuario;
    private ComboBox cmbUsuarios;
    private Label lblLibro;
    private ComboBox cmbLibros;
    private Label lblFechaPrestamo;
    private DateTimePicker dtpFechaPrestamo;
    private Label lblFechaDevolucionEsperada;
    private DateTimePicker dtpFechaDevolucionEsperada;
    private Button btnPrestar;
    private Button btnDevolver;
    private DataGridView dgvPrestamos;
    private DataGridViewTextBoxColumn colIdPrestamo;
    private DataGridViewTextBoxColumn colUsuarioPrestamo;
    private DataGridViewTextBoxColumn colLibroPrestamo;
    private DataGridViewTextBoxColumn colFechaPrestamo;
    private DataGridViewTextBoxColumn colFechaDevolucionEsperada;
    private DataGridViewTextBoxColumn colFechaDevolucionReal;
    private DataGridViewTextBoxColumn colEstado;
}
