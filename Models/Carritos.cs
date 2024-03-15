using System;

namespace TPFinal.Models
{
    public class Carritos
    {
        private int _IdCarrito;
        private int _IdUsuario;
        private date _Fecha;
        private bool _EstaFinalizado;

        public Carritos(int _IdCarrito, int _IdUsuario, date _Fecha, bool _EstaFinalizado)
        {
            _IdCarrito = IdCarrito;
            _IdUsuario = IdUsuario;
            _Fecha=Fecha;
            _EstaFinalizado=EstaFinalizado;
        }
        public Carritos() { }
        public int IdCarrito
        {
            get { return _IdCarritos; }
            set { _IdCarrito = value; }
        }

        public int IdUsuario
        {
            get { return _IdUsuario; }
            set { _IdUsuario = value; }
        }

        public date Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        public bool EstaFinalizado
        {
            get { return _EstaFinalizado; }
            set { _EstaFinalizado = value; }
        }
    }
}