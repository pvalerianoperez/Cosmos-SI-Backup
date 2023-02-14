using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Cosmos.Api.Entidades;


namespace Cosmos.Api.Client.Seguridad
{
    public partial class PerfilOpcionAccion
    {
        public static RespuestaBase EliminarPerfilOpcion(int perfilID, int opcionID)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = new Cosmos.Entidades.Seguridad.PerfilOpcionAccion() { PerfilID = perfilID, OpcionID = opcionID };

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            try
            {
                string url = string.Format("{0}/api/Seguridad/PerfilOpcionAccion/EliminarPerfilOpcion", AppGlobals.ApiURL);
                respuesta = Funciones.GetAPI(url, solicitud);
            }
            catch (Exception ex)
            {

                respuesta.CodigoRespuesta = 0;
                respuesta.MensajeRespuesta = "";
                respuesta.CodigoError = 1;
                respuesta.MensajeError = ex.Message;
                respuesta.Exitoso = false;
                respuesta.Datos = null;
            }

            //regresa la respuesta
            return respuesta;
        }

        

    }


}