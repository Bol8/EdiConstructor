using EdiConstructor.Segmentos.AuxClass;

namespace EdiConstructor.Segmentos
{
    internal class MOA:SegmentoEDI
    {
        //C516 IMPORTE MONETARIO
        private readonly ImporteMonetario _importeMonetario_C516;



        public MOA(ImporteMonetario importeMonetarioC516) 
            : base("MOA")
        {
            _importeMonetario_C516 = importeMonetarioC516;

            Segmento = montaSegmento();
        }

        public override string getSegmento()
        {
           return Segmento;
        }

        protected sealed override string montaSegmento()
        {
            var cadena = _idSEgmento;
            cadena += C516_ImporteMonetario();
            cadena += cerrarSegmento();


            return cadena;
        }


        private string C516_ImporteMonetario()
        {
            var cadena = "";

            if (_importeMonetario_C516 != null)
            {
                cadena = unirElementos(":", _importeMonetario_C516.CalificadorTipoImporte_5025,
                                            _importeMonetario_C516.ImporteMonetario_5004,
                                            _importeMonetario_C516.MonedaCodificada_6345,
                                            _importeMonetario_C516.CalificadorMoneda_6343,
                                            _importeMonetario_C516.StatusCodificado_4405);
            }

            return "+" + cadena;
        }


        protected override string cerrarSegmento()
        {
            return _cierreSegmento;
        }
    }
}
