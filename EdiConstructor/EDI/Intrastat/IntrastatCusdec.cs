using System.Text;
using EdiConstructor.Segmentos;
using EdiConstructor.Segmentos.AuxClass;

namespace EdiConstructor.EDI.Intrastat
{
    public abstract class IntrastatCusdec:EdiConstructor.EDI.Intrastat.Intrastat
    {
        //UNH
        private const string _idTipoMensaje_0065 = "CUSDEC";

        //BGM
        private const string _nombreDocumentoCodificado_1001 = "896";

        //CST
        private const string _calificadorListaCodigos1131 = "176";

        ////GIS
        //private const

        //Está OK
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


        protected override void MontarBgm(string nifDeclarante, string periodoAño, string periodoMes, string Flujo, 
                                          string numeroDeclaracion, string codigoDeFuncionDelMensaje1225)
        {

            var numDocumento = CrearNumeroDocumento(nifDeclarante, periodoAño, periodoMes, Flujo, numeroDeclaracion);
            var codFuncMensaje = CleanText(codigoDeFuncionDelMensaje1225);

            var bgm = new BGM(new DocumentoDelMensaje(_nombreDocumentoCodificado_1001, null, null, null),
                              numDocumento,
                              codFuncMensaje,
                              null);

            Segmentos.Add(bgm);
            Mensaje += bgm.getSegmento();
        }


        protected void MontarCstCabecera(string flujo)
        {
            var cst = new CST(null,
                              new CodigoIdentificacionAduanera(flujo, _calificadorListaCodigos1131, null));

            Segmentos.Add(cst);
            Mensaje += cst.getSegmento();
        }

        protected void MontarUns(string identificacionDeSeccion0081)
        {
            var uns = new UNS(identificacionDeSeccion0081);

            Segmentos.Add(uns);
            Mensaje += uns.getSegmento();
        }

        protected void MontarCnt(string calificadorControl6069, string valorControl6066)
        {
            var cnt = new CNT(new ControlDeTotales(calificadorControl6069, valorControl6066, null));

            Segmentos.Add(cnt);
            Mensaje += cnt.getSegmento();
        }


        //Controlar
        protected void MontarGis(string indicadorProcesoCodificado7365, string calificadorListaCodigosCodificado1131)
        {
            var dtm = new GIS(new IndicadorDeProceso(indicadorProcesoCodificado7365, calificadorListaCodigosCodificado1131,
                              null, null));

            Segmentos.Add(dtm);
            Mensaje += dtm.getSegmento();
        }



        ////Controlar
        //protected void MontarGisDeclaracionSinOperacion(string indicadorProcesoCodificado7365, string calificadorListaCodigosCodificado1131)
        //{
        //    var dtm = new GIS(new IndicadorDeProceso(indicadorProcesoCodificado7365, calificadorListaCodigosCodificado1131,
        //                      null, null));

        //    Segmentos.Add(dtm);
        //    Mensaje += dtm.getSegmento();
        //}



        protected override void MontarNad(string calificadorDeEntidad3035, string identificacionEntidadCodificada3039, string nombreEntidad)
        {
            var _idEntidadCod = CleanText(identificacionEntidadCodificada3039);
            var _nomEntidad = CleanText(nombreEntidad);

            var nad = new NAD(calificadorDeEntidad3035, new IdentificacionDeLaParte(_idEntidadCod, null, null),
                              null, _nomEntidad, null, null, null, null, null);

            Segmentos.Add(nad);
            Mensaje += nad.getSegmento();
        }



        private string CrearNumeroDocumento(string nifDeclarante,string periodAño,string periodMes,string flujo,string numeroDeclaracion)
        {
            var sb = new StringBuilder();

            sb.Append(nifDeclarante);
            sb.Append(periodAño + "" + periodMes);
            sb.Append(flujo);
            sb.Append(numeroDeclaracion);

            return sb.ToString();
        }
       
    }
}
