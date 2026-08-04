namespace Biblioteca.Forms;

partial class FormLibros
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
        lblTitulo = new Label();
        txtTitulo = new TextBox();
        lblAutor = new Label();
        txtAutor = new TextBox();
        lblISBN = new Label();
        txtISBN = new TextBox();
        lblCategoria = new Label();
        txtCategoria = new TextBox();
        lblCantidadTotal = new Label();
        txtCantidadTotal = new TextBox();
        lblBuscar = new Label();
        txtBuscar = new TextBox();
        btnBuscar = new Button();
        btnAgregar = new Button();
        btnEditar = new Button();
        btnEliminar = new Button();
        btnLimpiar = new Button();
        dgvLibros = new DataGridView();
        colId = new DataGridViewTextBoxColumn();
        colTitulo = new DataGridViewTextBoxColumn();
        colAutor = new DataGridViewTextBoxColumn();
        colISBN = new DataGridViewTextBoxColumn();
        colCategoria = new DataGridViewTextBoxColumn();
        colCantidadTotal = new DataGridViewTextBoxColumn();
        colCantidadDisponible = new DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)dgvLibros).BeginInit();
        SuspendLayout();
        //
        // lblTitulo
        //
        lblTitulo.AutoSize = true;
        lblTitulo.Location = new Point(20, 20);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(42, 15);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Título:";
        //
        // txtTitulo
        //
        txtTitulo.Location = new Point(90, 17);
        txtTitulo.Name = "txtTitulo";
        txtTitulo.Size = new Size(200, 23);
        txtTitulo.TabIndex = 1;
        //
        // lblAutor
        //
        lblAutor.AutoSize = true;
        lblAutor.Location = new Point(310, 20);
        lblAutor.Name = "lblAutor";
        lblAutor.Size = new Size(38, 15);
        lblAutor.TabIndex = 2;
        lblAutor.Text = "Autor:";
        //
        // txtAutor
        //
        txtAutor.Location = new Point(370, 17);
        txtAutor.Name = "txtAutor";
        txtAutor.Size = new Size(200, 23);
        txtAutor.TabIndex = 3;
        //
        // lblISBN
        //
        lblISBN.AutoSize = true;
        lblISBN.Location = new Point(20, 55);
        lblISBN.Name = "lblISBN";
        lblISBN.Size = new Size(36, 15);
        lblISBN.TabIndex = 4;
        lblISBN.Text = "ISBN:";
        //
        // txtISBN
        //
        txtISBN.Location = new Point(90, 52);
        txtISBN.Name = "txtISBN";
        txtISBN.Size = new Size(150, 23);
        txtISBN.TabIndex = 5;
        //
        // lblCategoria
        //
        lblCategoria.AutoSize = true;
        lblCategoria.Location = new Point(310, 55);
        lblCategoria.Name = "lblCategoria";
        lblCategoria.Size = new Size(63, 15);
        lblCategoria.TabIndex = 6;
        lblCategoria.Text = "Categoría:";
        //
        // txtCategoria
        //
        txtCategoria.Location = new Point(390, 52);
        txtCategoria.Name = "txtCategoria";
        txtCategoria.Size = new Size(180, 23);
        txtCategoria.TabIndex = 7;
        //
        // lblCantidadTotal
        //
        lblCantidadTotal.AutoSize = true;
        lblCantidadTotal.Location = new Point(20, 90);
        lblCantidadTotal.Name = "lblCantidadTotal";
        lblCantidadTotal.Size = new Size(88, 15);
        lblCantidadTotal.TabIndex = 8;
        lblCantidadTotal.Text = "Cantidad total:";
        //
        // txtCantidadTotal
        //
        txtCantidadTotal.Location = new Point(140, 87);
        txtCantidadTotal.Name = "txtCantidadTotal";
        txtCantidadTotal.Size = new Size(80, 23);
        txtCantidadTotal.TabIndex = 9;
        //
        // lblBuscar
        //
        lblBuscar.AutoSize = true;
        lblBuscar.Location = new Point(310, 90);
        lblBuscar.Name = "lblBuscar";
        lblBuscar.Size = new Size(46, 15);
        lblBuscar.TabIndex = 10;
        lblBuscar.Text = "Buscar:";
        //
        // txtBuscar
        //
        txtBuscar.Location = new Point(370, 87);
        txtBuscar.Name = "txtBuscar";
        txtBuscar.Size = new Size(190, 23);
        txtBuscar.TabIndex = 11;
        //
        // btnBuscar
        //
        btnBuscar.Location = new Point(570, 86);
        btnBuscar.Name = "btnBuscar";
        btnBuscar.Size = new Size(90, 25);
        btnBuscar.TabIndex = 12;
        btnBuscar.Text = "Buscar";
        btnBuscar.UseVisualStyleBackColor = true;
        btnBuscar.Click += btnBuscar_Click;
        //
        // btnAgregar
        //
        btnAgregar.Location = new Point(20, 130);
        btnAgregar.Name = "btnAgregar";
        btnAgregar.Size = new Size(110, 30);
        btnAgregar.TabIndex = 13;
        btnAgregar.Text = "Agregar";
        btnAgregar.UseVisualStyleBackColor = true;
        btnAgregar.Click += btnAgregar_Click;
        //
        // btnEditar
        //
        btnEditar.Location = new Point(140, 130);
        btnEditar.Name = "btnEditar";
        btnEditar.Size = new Size(110, 30);
        btnEditar.TabIndex = 14;
        btnEditar.Text = "Editar";
        btnEditar.UseVisualStyleBackColor = true;
        btnEditar.Click += btnEditar_Click;
        //
        // btnEliminar
        //
        btnEliminar.Location = new Point(260, 130);
        btnEliminar.Name = "btnEliminar";
        btnEliminar.Size = new Size(110, 30);
        btnEliminar.TabIndex = 15;
        btnEliminar.Text = "Eliminar";
        btnEliminar.UseVisualStyleBackColor = true;
        btnEliminar.Click += btnEliminar_Click;
        //
        // btnLimpiar
        //
        btnLimpiar.Location = new Point(380, 130);
        btnLimpiar.Name = "btnLimpiar";
        btnLimpiar.Size = new Size(110, 30);
        btnLimpiar.TabIndex = 16;
        btnLimpiar.Text = "Limpiar campos";
        btnLimpiar.UseVisualStyleBackColor = true;
        btnLimpiar.Click += btnLimpiar_Click;
        //
        // dgvLibros
        //
        dgvLibros.AllowUserToAddRows = false;
        dgvLibros.AllowUserToDeleteRows = false;
        dgvLibros.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvLibros.AutoGenerateColumns = false;
        dgvLibros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvLibros.Columns.AddRange(new DataGridViewColumn[] { colId, colTitulo, colAutor, colISBN, colCategoria, colCantidadTotal, colCantidadDisponible });
        dgvLibros.Location = new Point(20, 175);
        dgvLibros.MultiSelect = false;
        dgvLibros.Name = "dgvLibros";
        dgvLibros.ReadOnly = true;
        dgvLibros.RowHeadersVisible = false;
        dgvLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvLibros.Size = new Size(720, 300);
        dgvLibros.TabIndex = 17;
        dgvLibros.SelectionChanged += dgvLibros_SelectionChanged;
        //
        // colId
        //
        colId.HeaderText = "Id";
        colId.Name = "colId";
        colId.Visible = false;
        //
        // colTitulo
        //
        colTitulo.HeaderText = "Título";
        colTitulo.Name = "colTitulo";
        //
        // colAutor
        //
        colAutor.HeaderText = "Autor";
        colAutor.Name = "colAutor";
        //
        // colISBN
        //
        colISBN.HeaderText = "ISBN";
        colISBN.Name = "colISBN";
        //
        // colCategoria
        //
        colCategoria.HeaderText = "Categoría";
        colCategoria.Name = "colCategoria";
        //
        // colCantidadTotal
        //
        colCantidadTotal.HeaderText = "Cantidad total";
        colCantidadTotal.Name = "colCantidadTotal";
        //
        // colCantidadDisponible
        //
        colCantidadDisponible.HeaderText = "Cantidad disponible";
        colCantidadDisponible.Name = "colCantidadDisponible";
        //
        // FormLibros
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(760, 500);
        Controls.Add(dgvLibros);
        Controls.Add(btnLimpiar);
        Controls.Add(btnEliminar);
        Controls.Add(btnEditar);
        Controls.Add(btnAgregar);
        Controls.Add(btnBuscar);
        Controls.Add(txtBuscar);
        Controls.Add(lblBuscar);
        Controls.Add(txtCantidadTotal);
        Controls.Add(lblCantidadTotal);
        Controls.Add(txtCategoria);
        Controls.Add(lblCategoria);
        Controls.Add(txtISBN);
        Controls.Add(lblISBN);
        Controls.Add(txtAutor);
        Controls.Add(lblAutor);
        Controls.Add(txtTitulo);
        Controls.Add(lblTitulo);
        MinimumSize = new Size(600, 400);
        Name = "FormLibros";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Gestión de libros";
        ((System.ComponentModel.ISupportInitialize)dgvLibros).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitulo;
    private TextBox txtTitulo;
    private Label lblAutor;
    private TextBox txtAutor;
    private Label lblISBN;
    private TextBox txtISBN;
    private Label lblCategoria;
    private TextBox txtCategoria;
    private Label lblCantidadTotal;
    private TextBox txtCantidadTotal;
    private Label lblBuscar;
    private TextBox txtBuscar;
    private Button btnBuscar;
    private Button btnAgregar;
    private Button btnEditar;
    private Button btnEliminar;
    private Button btnLimpiar;
    private DataGridView dgvLibros;
    private DataGridViewTextBoxColumn colId;
    private DataGridViewTextBoxColumn colTitulo;
    private DataGridViewTextBoxColumn colAutor;
    private DataGridViewTextBoxColumn colISBN;
    private DataGridViewTextBoxColumn colCategoria;
    private DataGridViewTextBoxColumn colCantidadTotal;
    private DataGridViewTextBoxColumn colCantidadDisponible;
}
