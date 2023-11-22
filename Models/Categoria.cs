using System;

namespace TPFinal.Models
{
    public class Categoria
    {
        private int _idCategoria;
        private string _tipoCategoria;

        public Categoria(int IdCategoria, string TipoCategoria)
        {
            _idCategoria = IdCategoria;
            _tipoCategoria = TipoCategoria;

        }
        public Categoria() { }
        public int IdCategoria
        {
            get { return _idCategoria; }
            set { _idCategoria = value; }
        }

        public string TipoCategoria
        {
            get { return _tipoCategoria; }
            set { _tipoCategoria = value; }
        }
    }
}