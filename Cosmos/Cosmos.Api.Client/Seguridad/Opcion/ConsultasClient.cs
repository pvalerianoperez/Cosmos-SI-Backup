using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.Api.Entidades;
using Newtonsoft.Json;



namespace Cosmos.Api.Client.Seguridad
{
    public partial class Opcion
    {
        public static List<Cosmos.Entidades.Seguridad.Opcion> ListadoModuloID( int moduloID)
        {
            List<Cosmos.Entidades.Seguridad.Opcion> listado =Listado();
            return listado.Where(o => o.ModuloID == moduloID).ToList();
        }

        public static List<Cosmos.Entidades.Seguridad.Opcion> ListadoPerfilID(int perfilID)
        {
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = new Cosmos.Entidades.Seguridad.Perfil() { PerfilID = perfilID };

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Entidades.Seguridad.Opcion> listado = new List<Cosmos.Entidades.Seguridad.Opcion>();

            //intenta llamar al servicio
            try
            {
                string url = string.Format("{0}/api/Seguridad/Opcion/ListadoPerfilID", AppGlobals.ApiURL);
                respuesta = Funciones.GetAPI(url, solicitud);
                if (respuesta.Exitoso)
                {
                    listado = JsonConvert.DeserializeObject<List<Cosmos.Entidades.Seguridad.Opcion>>(JsonConvert.SerializeObject(respuesta.Datos));
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
