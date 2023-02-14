using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.Api.Entidades;
using Newtonsoft.Json;


namespace Cosmos.Api.Client.Seguridad
{
    public partial class PerfilOpcionAccion
    {
        public static List<Cosmos.Entidades.Seguridad.PerfilOpcionAccion> ListadoPerfilIDOpcionID(int perfilID, int opcionID)
        {

            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = new Cosmos.Entidades.Seguridad.PerfilOpcion() { PerfilID = perfilID, OpcionID = opcionID};

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Entidades.Seguridad.PerfilOpcionAccion> listado = new List<Cosmos.Entidades.Seguridad.PerfilOpcionAccion>();

            //intenta llamar al servicio
            try
            {
                string url = string.Format("{0}/api/Seguridad/PerfilOpcionAccion/ListadoPerfilIDOpcionID", AppGlobals.ApiURL);
                respuesta = Funciones.GetAPI(url, solicitud);
                if (respuesta.Exitoso)
                {
                    listado = JsonConvert.DeserializeObject<List<Cosmos.Entidades.Seguridad.PerfilOpcionAccion>>(JsonConvert.SerializeObject(respuesta.Datos));
                }
                else
                {
                    String mensajeError = CStr2(respuesta.MensajeError);
                    if (string.IsNullOrEmpty(mensajeError)) { mensajeError = CStr2(respuesta.MensajeRespuesta); }
                    if (string.IsNullOrEmpty(mensajeError)) { mensajeError = "No se recibió respuesta del servicio."; }
                    throw new Exception(mensajeError);
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            //regresa la respuesta
            return listado;
        }
    }
}
