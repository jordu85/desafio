

namespace Libreria_Web
{
    internal class Compra
    {
        public List<Libro> Libros { get; set; } = new List<Libro>();
        public double Total { get; set; }

        public void AgregarLibro(Libro libro, int cantidad)
        {
            if (libro.Stock >= cantidad)
            {
                libro.Stock -= cantidad;
                Libros.Add(libro);
                Total += libro.Precio * cantidad;
            }
            else
            {
                Console.WriteLine($"No hay stock suficiente de {libro.Titulo}");
            }
        }
    }
}

