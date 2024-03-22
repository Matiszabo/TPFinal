using System;

namespace TPFinal.Models
{
    public class CarritosResultados
    {
        private int IdCarrito;
        private date Fecha;
        private string Nombre;
        private int CantLikes;
        private bool _EstaFinalizado;

        public CarritosResultados(int _IdCarrito, date _Fecha, string _Nombre, int _CantLikes, bool _EstaFinalizado)
        {
            _IdCarrito = IdCarrito;
            _Fecha=Fecha;
            _Nombre = Nombre;
            _CantLikes = CantLikes;
            _EstaFinalizado=EstaFinalizado;
        }
        public CarritosResultados() { 

        }
        
        public int IdCarrito
        {
            get { return _IdCarritos; }
            set { _IdCarrito = value; }
        }

        public date Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public int CantLikes
        {
            get { return _CantLikes; }
            set { _CantLikes = value; }
        }
        public bool EstaFinalizado
        {
            get { return _EstaFinalizado; }
            set { _EstaFinalizado = value; }
        }
    }
}