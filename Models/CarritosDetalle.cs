using System;

namespace TPFinal.Models
{
    public class Carritosdetalles
    {
        private int _IdCarritoDetalle;
        private int _IdCarrito;
        private int _IdJuego;

        public Carritosdetalles(int _IdCarritoDetalle, int _IdCarrito, int _IdJuego)
        {
            _IdCarritoDetalle = IdCarritosDetalles;
            _IdCarrito = IdCarrito;
            _IdJuego = IdJuego;
        }
        public Carritosdetalles() { 
            
        }

        public int IdCarritosDetalles
        {
            get { return _IdCarritoDetalle; }
            set { _IdCarritoDetalle = value; }
        }

        public int IdCarrito
        {
            get { return _IdCarrito; }
            set { _IdCarrito = value; }
        }

        public int IdJuego
        {
            get { return _IdJuego; }
            set { _IdJuego = value; }
        }
    }
}