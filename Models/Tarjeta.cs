using System;

namespace TPFinal.Models
{
    public class Tarjeta
    {
    private int _numero;
    private string _titular;
    private int _codigoseg;

    public Tarjeta(int Numero, string Titular, int CodigoSeg)
    {
        _numero = Numero;   
        _titular = Titular;
        _codigoseg = CodigoSeg; 
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
        public int CodigoSeg
        {
        get { return _codigoseg; }
        set { _codigoseg = value; }
        }

    }
}