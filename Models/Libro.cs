namespace Biblioteca.Models;

// Representa un libro del catálogo. La cantidad disponible nunca puede
// ser negativa ni superar la cantidad total (encapsulamiento).
public class Libro
{
    private int id;
    private string titulo = string.Empty;
    private string autor = string.Empty;
    private string isbn = string.Empty;
    private string categoria = string.Empty;
    private int cantidadTotal;
    private int cantidadDisponible;

    public Libro(int id, string titulo, string autor, string isbn, string categoria,
        int cantidadTotal, int cantidadDisponible)
    {
        SetId(id);
        SetTitulo(titulo);
        SetAutor(autor);
        SetISBN(isbn);
        SetCategoria(categoria);
        SetCantidadTotal(cantidadTotal);
        SetCantidadDisponible(cantidadDisponible);
    }

    public int GetId()
    {
        return id;
    }

    public void SetId(int valor)
    {
        id = valor;
    }

    public string GetTitulo()
    {
        return titulo;
    }

    public void SetTitulo(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException("El título no puede estar vacío.");
        titulo = valor.Trim();
    }

    public string GetAutor()
    {
        return autor;
    }

    public void SetAutor(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException("El autor no puede estar vacío.");
        autor = valor.Trim();
    }

    public string GetISBN()
    {
        return isbn;
    }

    public void SetISBN(string valor)
    {
        isbn = valor?.Trim() ?? string.Empty;
    }

    public string GetCategoria()
    {
        return categoria;
    }

    public void SetCategoria(string valor)
    {
        categoria = valor?.Trim() ?? string.Empty;
    }

    public int GetCantidadTotal()
    {
        return cantidadTotal;
    }

    public void SetCantidadTotal(int valor)
    {
        if (valor < 0)
            throw new ArgumentException("La cantidad total no puede ser negativa.");
        cantidadTotal = valor;
        if (cantidadDisponible > cantidadTotal)
            cantidadDisponible = cantidadTotal;
    }

    public int GetCantidadDisponible()
    {
        return cantidadDisponible;
    }

    public void SetCantidadDisponible(int valor)
    {
        if (valor < 0 || valor > cantidadTotal)
            throw new ArgumentException("La cantidad disponible debe estar entre 0 y la cantidad total.");
        cantidadDisponible = valor;
    }

    // No se guarda: se calcula a partir de cantidadDisponible.
    public bool EsDisponible()
    {
        return cantidadDisponible > 0;
    }

    public override string ToString()
    {
        return $"{GetTitulo()} — {GetAutor()}";
    }
}
