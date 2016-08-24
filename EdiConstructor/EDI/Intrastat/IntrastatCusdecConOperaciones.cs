using EdiConstructor.Segmentos;
using EdiConstructor.Segmentos.AuxClass;

namespace EdiConstructor.EDI.Intrastat
{
    public class IntrastatCusdecConOperaciones:IntrastatCusdec
    {
        //TDT
        private const string _calificadorRutaTransporte_8051 = "2";

        //CST partidas
        private const string _calificadorListaCodigosMercancia = "122";
        private const string _calificadorListaCodigosNaturalezaTransaccion = "112";
        private const string _calificadorListaCodigosRegimenEstadistico = "117";


        protected void MontarTod(string plazoEntregaCodificado4053)
        {
            var tod = new TOD(null, null,
                              new PlazoEntrega(plazoEntregaCodificado4053, null, null, null, null));

            Segmentos.Add(tod);
            Mensaje += tod.getSegmento();
        }


        protected void MontarTdt(string modoTransporteCodificado8067)
        {
            var tdt = new TDT(_calificadorRutaTransporte_8051, null,
                              new ModoTransporte(modoTransporteCodificado8067, null),
                              null, null, null, null, null);


            Segmentos.Add(tdt);
            Mensaje += tdt.getSegmento();
        }

        protected void MontarLoc(string calificadorDeLugar3227, string identificacionLugar)
        {
            var loc = new LOC(calificadorDeLugar3227,
                              new IdentificacionLugar(identificacionLugar, null, null, null),
                              null, null, null);

            Segmentos.Add(loc);
            Mensaje += loc.getSegmento();
        }


        protected void MontarMea(string calificadorAplicacionMedida6311, string calificadorUnidadMedida6411, string valorMedida6314)
        {
            var mea = new MEA(calificadorAplicacionMedida6311, null,
                              new ValorAmplitud(calificadorUnidadMedida6411, valorMedida6314, null, null),
                              null);

            Segmentos.Add(mea);
            Mensaje += mea.getSegmento();
        }


        protected void MontarCstPartidas(string numeroPartida, string codigoIdentificacionAduanera7361,
                                        string naturalezaTransaccion, string regimenEstadistico)
        {
            var cst = new CST(numeroPartida,
                              new CodigoIdentificacionAduanera(codigoIdentificacionAduanera7361, _calificadorListaCodigosMercancia, null),
                              null,
                              new CodigoIdentificacionAduanera(naturalezaTransaccion, _calificadorListaCodigosNaturalezaTransaccion, null),
                              new CodigoIdentificacionAduanera(regimenEstadistico, _calificadorListaCodigosRegimenEstadistico, null),
                              null);

            Segmentos.Add(cst);
            Mensaje += cst.getSegmento();
        }
    }
}
