namespace Biblioteca.Forms;

partial class FormUsuarios
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
        lblNombre = new Label();
        txtNombre = new TextBox();
        lblIdentificacion = new Label();
        txtIdentificacion = new TextBox();
        lblContacto = new Label();
        txtContacto = new TextBox();
        lblBuscar = new Label();
        txtBuscar = new TextBox();
        btnBuscar = new Button();
        btnAgregar = new Button();
        btnEditar = new Button();
        btnEliminar = new Button();
        btnLimpiar = new Button();
        dgvUsuarios = new DataGridView();
        colId = new DataGridViewTextBoxColumn();
        colNombre = new DataGridViewTextBoxColumn();
        colIdentificacion = new DataGridViewTextBoxColumn();
        colContacto = new DataGridViewTextBoxColumn();
        colFechaRegistro = new DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
        SuspendLayout();
        //
        // lblNombre
        //
        lblNombre.AutoSize = true;
        lblNombre.Location = new Point(20, 20);
        lblNombre.Name = "lblNombre";
        lblNombre.Size = new Size(55, 15);
        lblNombre.TabIndex = 0;
        lblNombre.Text = "Nombre:";
        //
        // txtNombre
        //
        txtNombre.Location = new Point(100, 17);
        txtNombre.Name = "txtNombre";
        txtNombre.Size = new Size(200, 23);
        txtNombre.TabIndex = 1;
        //
        // lblIdentificacion
        //
        lblIdentificacion.AutoSize = true;
        lblIdentificacion.Location = new Point(320, 20);
        lblIdentificacion.Name = "lblIdentificacion";
        lblIdentificacion.Size = new Size(89, 15);
        lblIdentificacion.TabIndex = 2;
        lblIdentificacion.Text = "Identificación:";
        //
        // txtIdentificacion
        //
        txtIdentificacion.Location = new Point(420, 17);
        txtIdentificacion.Name = "txtIdentificacion";
        txtIdentificacion.Size = new Size(170, 23);
        txtIdentificacion.TabIndex = 3;
        //
        // lblContacto
        //
        lblContacto.AutoSize = true;
        lblContacto.Location = new Point(20, 55);
        lblContacto.Name = "lblContacto";
        lblContacto.Size = new Size(58, 15);
        lblContacto.TabIndex = 4;
        lblContacto.Text = "Contacto:";
        //
        // txtContacto
        //
        txtContacto.Location = new Point(100, 52);
        txtContacto.Name = "txtContacto";
        txtContacto.Size = new Size(200, 23);
        txtContacto.TabIndex = 5;
        //
        // lblBuscar
        //
        lblBuscar.AutoSize = true;
        lblBuscar.Location = new Point(320, 55);
        lblBuscar.Name = "lblBuscar";
        lblBuscar.Size = new Size(46, 15);
        lblBuscar.TabIndex = 6;
        lblBuscar.Text = "Buscar:";
        //
        // txtBuscar
        //
        txtBuscar.Location = new Point(420, 52);
        txtBuscar.Name = "txtBuscar";
        txtBuscar.Size = new Size(170, 23);
        txtBuscar.TabIndex = 7;
        //
        // btnBuscar
        //
        btnBuscar.Location = new Point(600, 51);
        btnBuscar.Name = "btnBuscar";
        btnBuscar.Size = new Size(90, 25);
        btnBuscar.TabIndex = 8;
        btnBuscar.Text = "Buscar";
        btnBuscar.UseVisualStyleBackColor = true;
        btnBuscar.Click += btnBuscar_Click;
        //
        // btnAgregar
        //
        btnAgregar.Location = new Point(20, 95);
        btnAgregar.Name = "btnAgregar";
        btnAgregar.Size = new Size(110, 30);
        btnAgregar.TabIndex = 9;
        btnAgregar.Text = "Agregar";
        btnAgregar.UseVisualStyleBackColor = true;
        btnAgregar.Click += btnAgregar_Click;
        //
        // btnEditar
        //
        btnEditar.Location = new Point(140, 95);
        btnEditar.Name = "btnEditar";
        btnEditar.Size = new Size(110, 30);
        btnEditar.TabIndex = 10;
        btnEditar.Text = "Editar";
        btnEditar.UseVisualStyleBackColor = true;
        btnEditar.Click += btnEditar_Click;
        //
        // btnEliminar
        //
        btnEliminar.Location = new Point(260, 95);
        btnEliminar.Name = "btnEliminar";
        btnEliminar.Size = new Size(110, 30);
        btnEliminar.TabIndex = 11;
        btnEliminar.Text = "Eliminar";
        btnEliminar.UseVisualStyleBackColor = true;
        btnEliminar.Click += btnEliminar_Click;
        //
        // btnLimpiar
        //
        btnLimpiar.Location = new Point(380, 95);
        btnLimpiar.Name = "btnLimpiar";
        btnLimpiar.Size = new Size(110, 30);
        btnLimpiar.TabIndex = 12;
        btnLimpiar.Text = "Limpiar campos";
        btnLimpiar.UseVisualStyleBackColor = true;
        btnLimpiar.Click += btnLimpiar_Click;
        //
        // dgvUsuarios
        //
        dgvUsuarios.AllowUserToAddRows = false;
        dgvUsuarios.AllowUserToDeleteRows = false;
        dgvUsuarios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvUsuarios.AutoGenerateColumns = false;
        dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvUsuarios.Columns.AddRange(new DataGridViewColumn[] { colId, colNombre, colIdentificacion, colContacto, colFechaRegistro });
        dgvUsuarios.Location = new Point(20, 140);
        dgvUsuarios.MultiSelect = false;
        dgvUsuarios.Name = "dgvUsuarios";
        dgvUsuarios.ReadOnly = true;
        dgvUsuarios.RowHeadersVisible = false;
        dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvUsuarios.Size = new Size(720, 335);
        dgvUsuarios.TabIndex = 13;
        dgvUsuarios.SelectionChanged += dgvUsuarios_SelectionChanged;
        //
        // colId
        //
        colId.HeaderText = "Id";
        colId.Name = "colId";
        colId.Visible = false;
        //
        // colNombre
        //
        colNombre.HeaderText = "Nombre";
        colNombre.Name = "colNombre";
        //
        // colIdentificacion
        //
        colIdentificacion.HeaderText = "Identificación";
        colIdentificacion.Name = "colIdentificacion";
        //
        // colContacto
        //
        colContacto.HeaderText = "Contacto";
        colContacto.Name = "colContacto";
        //
        // colFechaRegistro
        //
        colFechaRegistro.HeaderText = "Fecha de registro";
        colFechaRegistro.Name = "colFechaRegistro";
        //
        // FormUsuarios
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(760, 500);
        Controls.Add(dgvUsuarios);
        Controls.Add(btnLimpiar);
        Controls.Add(btnEliminar);
        Controls.Add(btnEditar);
        Controls.Add(btnAgregar);
        Controls.Add(btnBuscar);
        Controls.Add(txtBuscar);
        Controls.Add(lblBuscar);
        Controls.Add(txtContacto);
        Controls.Add(lblContacto);
        Controls.Add(txtIdentificacion);
        Controls.Add(lblIdentificacion);
        Controls.Add(txtNombre);
        Controls.Add(lblNombre);
        MinimumSize = new Size(600, 400);
        Name = "FormUsuarios";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Gestión de usuarios";
        ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblNombre;
    private TextBox txtNombre;
    private Label lblIdentificacion;
    private TextBox txtIdentificacion;
    private Label lblContacto;
    private TextBox txtContacto;
    private Label lblBuscar;
    private TextBox txtBuscar;
    private Button btnBuscar;
    private Button btnAgregar;
    private Button btnEditar;
    private Button btnEliminar;
    private Button btnLimpiar;
    private DataGridView dgvUsuarios;
    private DataGridViewTextBoxColumn colId;
    private DataGridViewTextBoxColumn colNombre;
    private DataGridViewTextBoxColumn colIdentificacion;
    private DataGridViewTextBoxColumn colContacto;
    private DataGridViewTextBoxColumn colFechaRegistro;
}
