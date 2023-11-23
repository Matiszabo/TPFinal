using System;

namespace TPFinal.Models
{
    public class Juego
    {
        private int _idJuego;
        private string _nombre;
        private int _cantLikes;
        private string _descripcionJuego;
        private DateTime _fechaCreacion;
        private string _imagen;
        public List<Usuario> UsuariosQueDieronLike { get; set; }
        public List<JuegoUsuarioLikes> Likes { get; set; }

        private int _precio;

        private int _fkCategoria;

        public Juego(int IdJuego, string Nombre, int CantLikes, string DescripcionJuego, DateTime FechaCreacion, string Imagen, int Precio, int fkCategoria)
        {
            _idJuego = IdJuego;
            _nombre = Nombre;
            _cantLikes = CantLikes;
            _descripcionJuego = DescripcionJuego;
            _fechaCreacion = FechaCreacion;
            _imagen = Imagen;
            _precio = Precio;
            _fkCategoria = fkCategoria;

        }
        public Juego() { }
        public int IdJuego
        {
            get { return _idJuego; }
            set { _idJuego = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public int CantLikes
        {
            get { return _cantLikes; }
            set { _cantLikes = value; }
        }
        public string Descripcion
        {
            get { return _descripcionJuego; }
            set { _descripcionJuego = value; }
        }
        public DateTime FechaCreacion
        {
            get { return _fechaCreacion; }
            set { _fechaCreacion = value; }
        }
        public string Imagen
        {
            get { return _imagen; }
            set { _imagen = value; }
        }
        public int Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

         public int fkCategoria
        {
            get { return _fkCategoria; }
            set { _fkCategoria = value; }
        }

    }
}