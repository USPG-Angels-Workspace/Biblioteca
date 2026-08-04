namespace Biblioteca.Forms;

partial class FormPrincipal
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
        lblBienvenida = new Label();
        btnLibros = new Button();
        btnUsuarios = new Button();
        btnPrestamos = new Button();
        btnSalir = new Button();
        SuspendLayout();
        //
        // lblBienvenida
        //
        lblBienvenida.AutoSize = true;
        lblBienvenida.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblBienvenida.Location = new Point(30, 20);
        lblBienvenida.Name = "lblBienvenida";
        lblBienvenida.Size = new Size(107, 25);
        lblBienvenida.TabIndex = 0;
        lblBienvenida.Text = "Bienvenido";
        //
        // btnLibros
        //
        btnLibros.Location = new Point(30, 70);
        btnLibros.Name = "btnLibros";
        btnLibros.Size = new Size(240, 40);
        btnLibros.TabIndex = 1;
        btnLibros.Text = "Gestionar libros";
        btnLibros.UseVisualStyleBackColor = true;
        btnLibros.Click += btnLibros_Click;
        //
        // btnUsuarios
        //
        btnUsuarios.Location = new Point(30, 120);
        btnUsuarios.Name = "btnUsuarios";
        btnUsuarios.Size = new Size(240, 40);
        btnUsuarios.TabIndex = 2;
        btnUsuarios.Text = "Gestionar usuarios";
        btnUsuarios.UseVisualStyleBackColor = true;
        btnUsuarios.Click += btnUsuarios_Click;
        //
        // btnPrestamos
        //
        btnPrestamos.Location = new Point(30, 170);
        btnPrestamos.Name = "btnPrestamos";
        btnPrestamos.Size = new Size(240, 40);
        btnPrestamos.TabIndex = 3;
        btnPrestamos.Text = "Gestionar préstamos";
        btnPrestamos.UseVisualStyleBackColor = true;
        btnPrestamos.Click += btnPrestamos_Click;
        //
        // btnSalir
        //
        btnSalir.Location = new Point(30, 230);
        btnSalir.Name = "btnSalir";
        btnSalir.Size = new Size(240, 30);
        btnSalir.TabIndex = 4;
        btnSalir.Text = "Salir";
        btnSalir.UseVisualStyleBackColor = true;
        btnSalir.Click += btnSalir_Click;
        //
        // FormPrincipal
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(310, 290);
        Controls.Add(btnSalir);
        Controls.Add(btnPrestamos);
        Controls.Add(btnUsuarios);
        Controls.Add(btnLibros);
        Controls.Add(lblBienvenida);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FormPrincipal";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Biblioteca Digital - Menú principal";
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblBienvenida;
    private Button btnLibros;
    private Button btnUsuarios;
    private Button btnPrestamos;
    private Button btnSalir;
}
