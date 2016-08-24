using System;

namespace EdiConstructor.Segmentos
{
    public abstract class SegmentoEDI
    {
        protected readonly string _idSEgmento;
        protected const string _cierreSegmento = "'";
        protected string Segmento;


        protected SegmentoEDI(string idSegmento )
        {
            _idSEgmento = idSegmento;
        }

        public abstract string getSegmento();

        protected abstract string montaSegmento();

        protected abstract string cerrarSegmento();

        protected string unirElementos(string separator, params string[] args)
        {
            var cadena = string.Join(separator, args);

            return cadena;
        }

    }
}
