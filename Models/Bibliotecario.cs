namespace Biblioteca.Models;

// Bibliotecario (empleado) que administra el sistema. Hereda de Persona,
// que ya trae el nombre/identificación/contacto y las credenciales de acceso.
public class Bibliotecario : Persona
{
    public Bibliotecario(int id, string nombre, string identificacion, string contacto,
        string nombreUsuario, string contrasena)
        : base(id, nombre, identificacion, contacto, nombreUsuario, contrasena)
    {
    }

    public override string DescripcionRol()
    {
        return "Bibliotecario";
    }
}
