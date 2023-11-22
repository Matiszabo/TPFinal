using System;

namespace TPFinal.Models
{
    public class Usuario
    {
        private int _idUsuario;
        private string _contraseña;
        private string _nombre;

        public Usuario(int IdUsuario, string Contraseña, string Nombre)
        {
            _idUsuario = IdUsuario;
            _contraseña = Contraseña;
            _nombre = Nombre;
        }
        public Usuario() { }
        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Contraseña
        {
            get { return _contraseña; }
            set { _contraseña = value; }
        }

    }
}