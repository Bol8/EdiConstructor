using System;
using EdiConstructor.Segmentos;
using EdiConstructor.Segmentos.AuxClass;

namespace EdiConstructor.EDI.Intrastat
{
    public abstract class Intrastat:EDI
    {
        //UNB
        private const string _identificadorSintaxis_0001 = "UNOA";
        private const string _numeroVersionSintaxis_0002 = "1";
        private const string _codCalificadorIdentificacionParticipante_0007 = "ZZ";
        private const string _idReceptor_0010 = "AEATADUE";


        //UNZ
        private const string _cuentaControlIntercambio_0036 = "1";

        //UNH
        protected const string _numeroVersionTipoMensaje_0052 = "1";
        protected const string _numeroPublicacionTipoMensaje_0054 = "921";
        protected const string _agenciaControladora_0051 = "UN";
        protected const string _codigoAsignadoDeAsociacion_0057 = "INT003";


        //MOA
        private const string _monedaCodificada = "EUR";
        private const string _calificadorTipoImporteTotalDeclaracion = "39";
        private const string _calificadorTipoImporteEspecificacionEuros = "ZZZ";

        //DTM
        private const string _calificadorFechaHoraPeriodo = "320";
        private const string _calificadorFechaHoraAltaDocumento = "137";

        //RFF
        private const string _calificadorReferencia_1153 = "ACW";

        //Está OK
        protected void MontarUnb(string idEmisor, string referenciaControlIntercambio0020, bool indicadorPrueba)
        {
            var _idEmisor = CleanText(idEmisor);
            var refControl = CleanText(referenciaControlIntercambio0020);

            var unb = new UNB(new IdentificadorDeSintaxis(_identificadorSintaxis_0001, _numeroVersionSintaxis_0002),
                              new EmisorDelIntercambio(_idEmisor, _codCalificadorIdentificacionParticipante_0007, null),
                              new ReceptorDelIntercambio(_idReceptor_0010, _codCalificadorIdentificacionParticipante_0007, null),
                              refControl,
                              null, null, null, null, null, true);

            Segmentos.Add(unb);
            Mensaje += unb.getSegmento();
        }

        //Está OK
        protected void MontarUnz(string referenciaControlIntercambio)
        {
            var refControl = CleanText(referenciaControlIntercambio);

            var unz = new UNZ(refControl, _cuentaControlIntercambio_0036);

            Segmentos.Add(unz);
            Mensaje += unz.getSegmento();
        }



        protected abstract void MontarUnh(string numeroReferenciaMensaje);
        protected abstract void MontarBgm(string nifDeclarante,string periodoAño,string periodoMes,string Flujo,string numeroDeclaracion,  string codigoDeFuncionDelMensaje1225);


        //protected void MontarCstCabecera(string codigoIdentificacionAduanera7361, string calificadorListaCodigos1131)
        //{
        //    var cst = new CST(null,
        //                      new CodigoIdentificacionAduanera(codigoIdentificacionAduanera7361, calificadorListaCodigos1131, null));

        //    Segmentos.Add(cst);
        //    Mensaje += cst.getSegmento();
        //}


        protected void MontarDtm(string calificadorFecha2005, string fechaHora)
        {
            var _calificadorFecha = CleanText(calificadorFecha2005);
            var _fechaHora = CleanText(fechaHora);

            var dtm = new DTM(new FechaHoraPeriodo(_calificadorFecha, _fechaHora, null));

            Segmentos.Add(dtm);
            Mensaje += dtm.getSegmento();
        }


        protected void MontarDtmFechaPeriodo(string periodoAño,string periodoMes)
        {
           // var _calificadorFecha = CleanText(calificadorFecha2005);
           // var _fechaHora = CleanText(fechaHora);
            var periodo = periodoAño + "" + periodoMes;

            var dtm = new DTM(new FechaHoraPeriodo(_calificadorFechaHoraPeriodo, periodo, null));

            Segmentos.Add(dtm);
            Mensaje += dtm.getSegmento();
        }

        protected void MontarDtmAltaDocumento(DateTime fechaAltaDocumento)
        {
           // var _calificadorFecha = CleanText(calificadorFecha2005);
            var _fechaHora = fechaAltaDocumento.ToString("yyMMdd");

            var dtm = new DTM(new FechaHoraPeriodo(_calificadorFechaHoraAltaDocumento, _fechaHora, null));

            Segmentos.Add(dtm);
            Mensaje += dtm.getSegmento();
        }

        protected void MontarCnt(string calificadorControl6069, string valorControl6066)
        {
            var cnt = new CNT(new ControlDeTotales(calificadorControl6069, valorControl6066, null));

            Segmentos.Add(cnt);
            Mensaje += cnt.getSegmento();
        }

        protected void MontarUnt(string numeroSegmentosMensaje0074, string numeroReferenciaMensaje0062)
        {
            var unt = new UNT(numeroSegmentosMensaje0074, numeroReferenciaMensaje0062);

            Segmentos.Add(unt);
            Mensaje += unt.getSegmento();
        }

        protected void MontarUns(string identificacionDeSeccion0081)
        {
            var uns = new UNS(identificacionDeSeccion0081);

            Segmentos.Add(uns);
            Mensaje += uns.getSegmento();
        }

        protected void MontarMoa(string calificadorTipoImporte5025, string importeMonetario5004)
        {
            var moa = new MOA(new ImporteMonetario(calificadorTipoImporte5025, importeMonetario5004, _monedaCodificada, null, null));

            Segmentos.Add(moa);
            Mensaje += moa.getSegmento();
        }

        protected void MontarMoaEspecificacionEuros()
        {
            var moa = new MOA(new ImporteMonetario(_calificadorTipoImporteEspecificacionEuros, null, _monedaCodificada, null, null));

            Segmentos.Add(moa);
            Mensaje += moa.getSegmento();
        }

        protected void MontarMoaImporteTotal(string importeMonetario5004)
        {
            var moa = new MOA(new ImporteMonetario(_calificadorTipoImporteTotalDeclaracion, null, _monedaCodificada, null, null));

            Segmentos.Add(moa);
            Mensaje += moa.getSegmento();
        }



        //Controlar
        protected abstract void MontarNad(string calificadorDeEntidad3035, string identificacionEntidadCodificada3039,
            string nombreEntidad);

        //Controlar
        protected void MontarGis(string indicadorProcesoCodificado7365, string calificadorListaCodigosCodificado1131)
        {
            var dtm = new GIS(new IndicadorDeProceso(indicadorProcesoCodificado7365, calificadorListaCodigosCodificado1131,
                              null, null));

            Segmentos.Add(dtm);
            Mensaje += dtm.getSegmento();
        }

        protected void MontarRff(string numeroReferencia1154)
        {
            var rff = new RFF(new Referencia(_calificadorReferencia_1153, numeroReferencia1154, null, null));

            Segmentos.Add(rff);
            Mensaje += rff.getSegmento();
        }



        //protected void MontarNad(string calificadorDeEntidad3035, string identificacionEntidadCodificada3039, string nombreEntidad)
        //{
        //    var _idEntidadCod = CleanText(identificacionEntidadCodificada3039);
        //    var _nomEntidad = CleanText(nombreEntidad);

        //    var nad = new NAD(calificadorDeEntidad3035, new IdentificacionDeLaParte(_idEntidadCod, null, null),
        //                      null, _nomEntidad, null, null, null, null, null);

        //    Segmentos.Add(nad);
        //    Mensaje += nad.getSegmento();
        //}
    }
}
