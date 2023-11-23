using System;

namespace TPFinal.Models
{
    public class Tarjeta
    {
        private int _numero;
        private string _titular;
        private int _codigoseq;

        public Tarjeta(int Numero, string Titular, int CodigoSeq)
        {
            _numero = Numero;
            _titular = Titular;
            _codigoseq = CodigoSeq;
        }
        public Tarjeta() { }
        public int Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

        public string Titular
        {
            get { return _titular; }
            set { _titular = value; }
        }
        public string CodigoSeq
        {
            get { return _codigoseq; }
            set { _codigoseq = value; }
        }

    }
}