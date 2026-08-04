namespace Biblioteca.Models;

// Relaciona un Usuario con un Libro. Guarda los Id en vez de referencias
// directas para que sea sencillo de guardar en JSON.
public class Prestamo
{
    private int id;
    private int usuarioId;
    private int libroId;
    private DateTime fechaPrestamo;
    private DateTime fechaDevolucionEsperada;
    private DateTime? fechaDevolucionReal;
    private EstadoPrestamo estado;

    public Prestamo(int id, int usuarioId, int libroId, DateTime fechaPrestamo,
        DateTime fechaDevolucionEsperada, DateTime? fechaDevolucionReal, EstadoPrestamo estado)
    {
        SetId(id);
        SetUsuarioId(usuarioId);
        SetLibroId(libroId);
        SetFechaPrestamo(fechaPrestamo);
        SetFechaDevolucionEsperada(fechaDevolucionEsperada);
        SetFechaDevolucionReal(fechaDevolucionReal);
        SetEstado(estado);
    }

    public int GetId()
    {
        return id;
    }

    public void SetId(int valor)
    {
        id = valor;
    }

    public int GetUsuarioId()
    {
        return usuarioId;
    }

    public void SetUsuarioId(int valor)
    {
        usuarioId = valor;
    }

    public int GetLibroId()
    {
        return libroId;
    }

    public void SetLibroId(int valor)
    {
        libroId = valor;
    }

    public DateTime GetFechaPrestamo()
    {
        return fechaPrestamo;
    }

    public void SetFechaPrestamo(DateTime valor)
    {
        fechaPrestamo = valor;
    }

    public DateTime GetFechaDevolucionEsperada()
    {
        return fechaDevolucionEsperada;
    }

    public void SetFechaDevolucionEsperada(DateTime valor)
    {
        if (valor < fechaPrestamo)
            throw new ArgumentException("La fecha de devolución esperada no puede ser anterior a la fecha de préstamo.");
        fechaDevolucionEsperada = valor;
    }

    public DateTime? GetFechaDevolucionReal()
    {
        return fechaDevolucionReal;
    }

    public void SetFechaDevolucionReal(DateTime? valor)
    {
        fechaDevolucionReal = valor;
    }

    public EstadoPrestamo GetEstado()
    {
        return estado;
    }

    public void SetEstado(EstadoPrestamo valor)
    {
        estado = valor;
    }
}
