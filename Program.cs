using Libreria_Web;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        List<Usuario> Usuarios = new List<Usuario>
        {
            new Usuario("Carlos", "15467", true),
            new Usuario("Sol", "23459", true)
        };

        List<Libro> Catalogo = new List<Libro>
        {
            new Libro { Titulo = "Harry Potter y la piedra filosofal", Rubro = "Ficción", Precio = 800.0, Stock = 5 },
            new Libro { Titulo = "La primer guerra mundial y su contexto", Rubro = "Historia", Precio = 900.0, Stock = 3 }
        };

        Console.WriteLine("Ingrese su nombre de usuario:");
        string nombreUsuario = Console.ReadLine();

        Usuario usuario = null;


        // Recorriendo la lista con foreach...
        foreach (Usuario u in Usuarios)
        {
            if (u.NombreCompleto == nombreUsuario)
            {
                usuario = u;
                break;
            }
        }
        // Verificando  si se encontró el usuario...
        if (usuario == null || !usuario.EstaRegistrado)
        {
            Console.WriteLine("Usuario no registrado");
            return;
        }

        // Solicitar la contraseña
        Console.WriteLine("Ingrese su contraseña:");
        string contraseñaIngresada = Console.ReadLine();

        // Validar la contraseña
        usuario.ValidarContraseña(contraseñaIngresada);

            if (usuario.Contraseña == contraseñaIngresada)
            {
                Console.WriteLine("Inicio de sesión exitoso!");
            }
            else
            {
                Console.WriteLine("Contraseña incorrecta.");
                return;
            }
        
        // Selección de rubro
        Console.WriteLine("Seleccione un rubro: Ficción o Historia");
        string rubro = Console.ReadLine();
        List<Libro> librosDisponibles = Catalogo.FindAll(l => l.Rubro == rubro);

        Compra carrito = new Compra();

        foreach (var libro in librosDisponibles)
        {
            Console.WriteLine($"{libro.Titulo} - ${libro.Precio} - Stock: {libro.Stock}");
        }

        while (true)
        {
            Console.WriteLine("Ingrese el título del libro que quiere comprar o 'fin' para terminar:");
            string titulo = Console.ReadLine();

            if (titulo.ToLower() == "fin") break;

            Libro libroSeleccionado = librosDisponibles.Find(l => l.Titulo == titulo);
            if (libroSeleccionado != null)
            {
                Console.WriteLine("Ingrese la cantidad:");
                int cantidad = int.Parse(Console.ReadLine());
                carrito.AgregarLibro(libroSeleccionado, cantidad);
            }
            else
            {
                Console.WriteLine("Libro no encontrado");
            }
        }

        Console.WriteLine($"Total de la compra: ${carrito.Total}");
        Console.WriteLine("Ingrese los datos de la tarjeta de crédito:");

        Console.WriteLine("Número de tarjeta:");
        string numeroTarjeta = Console.ReadLine();

        Console.WriteLine("Fecha de vencimiento (MM/AA):");
        string fechaVencimiento = Console.ReadLine();

        Console.WriteLine("Código de seguridad:");
        string codigoSeguridad = Console.ReadLine();

        // Crear el objeto Pago con los datos ingresados
        Pago pago = new Pago(numeroTarjeta, fechaVencimiento, codigoSeguridad, carrito.Total);

        // Procesar el pago
        pago.ProcesarPago();

        if (pago.ValidarTarjeta())
        {
            Console.WriteLine("Compra realizada con éxito!");
            // Aquí podrías agregar la lógica para guardar la compra, descontar stock, etc.
        }
        else
        {
            Console.WriteLine("La compra no pudo ser procesada.");
        }
    }
}
    

