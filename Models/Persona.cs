using System.Text.RegularExpressions;

namespace Biblioteca.Models;

// Clase base para cualquier persona del sistema (Usuario o Bibliotecario).
// Encapsula los datos comunes, incluidas las credenciales de acceso —
// ambas subclases inician sesión con su email y contraseña.
public abstract class Persona
{
    private int id;
    private string nombre = string.Empty;
    private string identificacion = string.Empty;
    private string email = string.Empty;
    private string contrasena = string.Empty;

    protected Persona(int id, string nombre, string identificacion, string email, string contrasena)
    {
        SetId(id);
        SetNombre(nombre);
        SetIdentificacion(identificacion);
        SetEmail(email);
        SetContrasena(contrasena);
    }

    public int GetId()
    {
        return id;
    }

    public void SetId(int valor)
    {
        id = valor;
    }

    public string GetNombre()
    {
        return nombre;
    }

    public void SetNombre(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException("El nombre no puede estar vacío.");
        nombre = valor.Trim();
    }

    public string GetIdentificacion()
    {
        return identificacion;
    }

    // Virtual: Usuario la sobrescribe para exigir el formato de carnet.
    public virtual void SetIdentificacion(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException("La identificación no puede estar vacía.");
        identificacion = valor.Trim();
    }

    public string GetEmail()
    {
        return email;
    }

    public void SetEmail(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor) || !Regex.IsMatch(valor.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            throw new ArgumentException("El email no es válido.");
        email = valor.Trim();
    }

    public string GetContrasena()
    {
        return contrasena;
    }

    public void SetContrasena(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException("La contraseña no puede estar vacía.");
        contrasena = valor;
    }

    // Cada subclase describe su propio rol (polimorfismo).
    public abstract string DescripcionRol();

    public override string ToString()
    {
        return $"{GetNombre()} ({DescripcionRol()})";
    }
}
