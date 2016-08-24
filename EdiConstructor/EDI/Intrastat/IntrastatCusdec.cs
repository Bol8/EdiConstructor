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
            var numDocumento = CleanText(numeroDocumento1004);
            var codFuncMensaje = CleanText(codigoDeFuncionDelMensaje1225);

            var bgm = new BGM(new DocumentoDelMensaje(_nombreDocumentoCodificado_1001, null, null, null),
                              numDocumento,
                              codFuncMensaje,
                              null);

            Segmentos.Add(bgm);
            Mensaje += bgm.getSegmento();
        }


    }
}
