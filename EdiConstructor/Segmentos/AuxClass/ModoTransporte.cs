﻿



namespace EdiConstructor.Segmentos.AuxClass
{
    class ModoTransporte
    {
       
        public string ModoTransporteCodificado_8067 { get; private set; }
        public string ModoDeTransporte_8066 { get; private set; }

        public ModoTransporte(string modoTransporteCodificado8067, string modoDeTransporte8066)
        {
            ModoTransporteCodificado_8067 = modoTransporteCodificado8067;
            ModoDeTransporte_8066 = modoDeTransporte8066;
        }

    }
}
