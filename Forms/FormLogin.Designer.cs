namespace Biblioteca.Forms;

partial class FormLogin
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
        lblUsuario = new Label();
        txtUsuario = new TextBox();
        lblContrasena = new Label();
        txtContrasena = new TextBox();
        btnIngresar = new Button();
        lblMensaje = new Label();
        SuspendLayout();
        //
        // lblTitulo
        //
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTitulo.Location = new Point(30, 20);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(199, 32);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Biblioteca Digital";
        //
        // lblUsuario
        //
        lblUsuario.AutoSize = true;
        lblUsuario.Location = new Point(30, 80);
        lblUsuario.Name = "lblUsuario";
        lblUsuario.Size = new Size(56, 15);
        lblUsuario.TabIndex = 1;
        lblUsuario.Text = "Usuario:";
        //
        // txtUsuario
        //
        txtUsuario.Location = new Point(120, 77);
        txtUsuario.Name = "txtUsuario";
        txtUsuario.Size = new Size(180, 23);
        txtUsuario.TabIndex = 2;
        //
        // lblContrasena
        //
        lblContrasena.AutoSize = true;
        lblContrasena.Location = new Point(30, 120);
        lblContrasena.Name = "lblContrasena";
        lblContrasena.Size = new Size(75, 15);
        lblContrasena.TabIndex = 3;
        lblContrasena.Text = "Contraseña:";
        //
        // txtContrasena
        //
        txtContrasena.Location = new Point(120, 117);
        txtContrasena.Name = "txtContrasena";
        txtContrasena.PasswordChar = '*';
        txtContrasena.Size = new Size(180, 23);
        txtContrasena.TabIndex = 4;
        //
        // btnIngresar
        //
        btnIngresar.Location = new Point(120, 160);
        btnIngresar.Name = "btnIngresar";
        btnIngresar.Size = new Size(100, 30);
        btnIngresar.TabIndex = 5;
        btnIngresar.Text = "Ingresar";
        btnIngresar.UseVisualStyleBackColor = true;
        btnIngresar.Click += btnIngresar_Click;
        //
        // lblMensaje
        //
        lblMensaje.AutoSize = true;
        lblMensaje.ForeColor = Color.Red;
        lblMensaje.Location = new Point(30, 200);
        lblMensaje.Name = "lblMensaje";
        lblMensaje.Size = new Size(0, 15);
        lblMensaje.TabIndex = 6;
        //
        // FormLogin
        //
        AcceptButton = btnIngresar;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(330, 240);
        Controls.Add(lblMensaje);
        Controls.Add(btnIngresar);
        Controls.Add(txtContrasena);
        Controls.Add(lblContrasena);
        Controls.Add(txtUsuario);
        Controls.Add(lblUsuario);
        Controls.Add(lblTitulo);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FormLogin";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Iniciar sesión";
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitulo;
    private Label lblUsuario;
    private TextBox txtUsuario;
    private Label lblContrasena;
    private TextBox txtContrasena;
    private Button btnIngresar;
    private Label lblMensaje;
}
