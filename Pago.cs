

namespace Libreria_Web
{
    internal class Pago
    {
        private string _numeroTarjeta;
        private string _fechaVencimiento;
        private string _codSeguridad;
        private double _monto;

        public string NumeroTarjeta
        {
            get { return _numeroTarjeta; }
            set { _numeroTarjeta = value; }
        }

        public string FechaVencimiento
        {
            get { return _fechaVencimiento; }
            set { _fechaVencimiento = value; }
        }

        public string CodSeguridad
        {
            get { return _codSeguridad; }
            set { _codSeguridad = value; }
        }

        public double Monto
        {
            get { return _monto; }
            set { _monto = value; }  
        }

        
        public Pago(string numeroTarjeta, string fechaVencimiento, string codSeguridad, double monto)
        {
            _numeroTarjeta = numeroTarjeta;
            _fechaVencimiento = fechaVencimiento;
            _codSeguridad = codSeguridad;
            _monto = monto;
        }
        public bool ValidarTarjeta()
        {
            return NumeroTarjeta.Length == 16 && CodSeguridad.Length == 3;
        }


        public void ProcesarPago()
        {
            if (ValidarTarjeta())
            {
                Console.WriteLine($"Pago procesado con éxito por un total de: $ {Monto}");
            }
            else
            {
                Console.WriteLine("Error al procesar el pago. Chequee los datos de la tarjeta");
            }
        }
    }
}

