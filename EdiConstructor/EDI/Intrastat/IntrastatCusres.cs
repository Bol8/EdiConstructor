﻿using System;
using EdiConstructor.Segmentos;
using EdiConstructor.Segmentos.AuxClass;

namespace EdiConstructor.EDI.Intrastat
{
    public abstract class IntrastatCusres:EdiConstructor.EDI.Intrastat.Intrastat
    {
        //UNH
        private const string _idTipoMensaje_0065 = "CUSRES";

       

        protected override void MontarUnh(string numeroReferenciaMensaje)
        {
            var _numeroReferencia = CleanText(numeroReferenciaMensaje);

            var unh = new UNH(_numeroReferencia,
                             new IdentificadorDelMensaje(_idTipoMensaje_0065, _numeroVersionTipoMensaje_0052,
                                                         _numeroPublicacionTipoMensaje_0054, _agenciaControladora_0051,
                                                         _codigoAsignadoDeAsociacion_0057),
                              null, null);

            Segmentos.Add(unh);
            Mensaje += unh.getSegmento();
        }


        protected override void MontarBgm(string numeroDocumento1004, string codigoDeFuncionDelMensaje1225)
        {
            throw new NotImplementedException();
        }



        protected override void MontarNad(string calificadorDeEntidad3035, string identificacionEntidadCodificada3039, string nombreEntidad)
        {
            var _idEntidadCod = CleanText(identificacionEntidadCodificada3039);
            var _nomEntidad = CleanText(nombreEntidad);

            var nad = new NAD(calificadorDeEntidad3035, new IdentificacionDeLaParte(_idEntidadCod, null, null),
                              null, _nomEntidad, null, null, null, null, null);

            Segmentos.Add(nad);
            Mensaje += nad.getSegmento();
        }
    }
}
