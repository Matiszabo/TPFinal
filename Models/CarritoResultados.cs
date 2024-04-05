using System;

namespace TPFinal.Models
{
    public class CarritosResultados
    {
 
        /*
        public CarritosResultados(int _IdCarrito, DateTime _Fecha, string _Nombre, int _CantLikes, bool _EstaFinalizado)
        {
            _IdCarrito = IdCarrito;
            _Fecha=Fecha;
            _Nombre = Nombre;
            _CantLikes = CantLikes;
            _EstaFinalizado=EstaFinalizado;
        }
        */
        public CarritosResultados() { 

        }
      
       public int IdCarrito    { get; set; }

        public string Nombre    { get; set; }
        public int CantLikes   { get; set; }
        public bool EstaFinalizado    { get; set; }
        public DateTime Fecha    { get; set; }


    }
}