namespace Biblioteca.Models;

// Bibliotecario (empleado) que administra el sistema. Hereda de Persona,
// que ya trae el nombre/identificación/email y las credenciales de acceso.
public class Bibliotecario : Persona
{
    public Bibliotecario(int id, string nombre, string identificacion, string email, string contrasena)
        : base(id, nombre, identificacion, email, contrasena)
    {
    }

    public override string DescripcionRol()
    {
        return "Bibliotecario";
    }
}
