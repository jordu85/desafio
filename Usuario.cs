

namespace Libreria_Web
{
    class Usuario
    {
        private string _nombreCompleto;
        private string _contraseña;
        private bool _estaRegistrado;

        public string NombreCompleto
        {
            get { return _nombreCompleto; }
            set { _nombreCompleto = value; }
        }
        public string Contraseña
        {
            get { return _contraseña; }
            set { _contraseña = value; }
        }
        public bool EstaRegistrado
        {
            get { return _estaRegistrado; }
            set { _estaRegistrado = value; }
        }
        public Usuario(string nombreCompleto, string contraseña, bool estaRegistrado)
        {
            nombreCompleto = _nombreCompleto;
            contraseña = _contraseña;
            estaRegistrado = _estaRegistrado;
        }
        public bool ValidarContraseña(string contraseñaIngresada)
        {
           return Contraseña == contraseñaIngresada;
        }

    }
}
