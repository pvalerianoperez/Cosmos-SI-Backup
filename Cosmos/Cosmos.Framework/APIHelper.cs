using Cosmos.Api.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
 
namespace Cosmos.Framework
{
    public class APIHelper
    {

        public static int APIUsuarioID { get; set; }
        public static int APIEmpresaID { get; set; }
        public static string APISesionID { get; set; }
        public static string APIURL { get; set; }
        public static int APIModuloID { get; set; }

        /// <summary>
        /// Recibe una respuesta de la API, revisa si fue exitosa, evalua el resultado y si encontro errores
        /// genera un System.Exception con el mensaje de error contenido en la propiedad "MensajeError", 
        /// en caso de que venga vacia, se utiliza "MensajeRespuesta" y si aun asi esta vacia, entonces se mostrara un mensaje generico de error.
        /// </summary>
        /// <param name="dr"></param>
        public static bool ErrorRespuestaAPI(RespuestaBase respuesta)
        {
            string mensajeError = "";
            bool errores = false;
            if (respuesta != null)
            {
                errores = (!respuesta.Exitoso);
                if (errores)
                {
                    mensajeError = CastHelper.CStr2(respuesta.MensajeError);
                    if (string.IsNullOrEmpty(mensajeError)) { mensajeError = CastHelper.CStr2(respuesta.MensajeRespuesta); }
                    if (string.IsNullOrEmpty(mensajeError)) { mensajeError = "No se recibió respuesta del servicio."; }
                    if (mensajeError.ToLower().StartsWith("the delete statement conflicted with the reference")) {
                        int inicia = mensajeError.IndexOf("table \"dbo.");
                        if (inicia >= 0) {
                            inicia += 11;
                            int termina = mensajeError.IndexOf("\"", inicia+1);
                            int longitud = termina - inicia;
                            string tabla = mensajeError.Substring(inicia, longitud);
                            mensajeError = string.Format("No se pudo eliminar la información porque existen registros relacionados en la tabla '{0}'.", tabla);
                        }                        
                    }
                    
                    throw new Exception(mensajeError);
                }
            }
            return errores;
        }

        /// <summary>
        /// Basado en una ruta de api, envia una solicitud y espera una respuesta
        /// </summary>
        /// <param name="url"></param>
        /// <param name="solicitud"></param>
        /// <returns></returns>
        public static RespuestaBase Execute(string url, SolicitudBase solicitud = null)
        {
            //construye la ruta completa de la API
            url = string.Format("{0}/{1}", APIURL, url);

            //si viene vacia entonces crea la solicitud. TODAS las peticiones deben llevar un objeto solicitud
            if (solicitud == null)
            {
                solicitud = new SolicitudBase();
            }
            //siempre pon los datos de la sesion
            solicitud.UsuarioID = APIUsuarioID;
            solicitud.EmpresaID = APIEmpresaID;
            solicitud.SesionID = APISesionID;

            RespuestaBase respuesta = new RespuestaBase();
            HttpResponseMessage result;
            try
            {
                var client = new HttpClient();
                var postTask = client.PostAsJsonAsync<SolicitudBase>(url, solicitud);
                postTask.Wait();
                result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<RespuestaBase>();
                    readTask.Wait();
                    respuesta = readTask.Result;
                }
                else
                {
                    throw new Exception(string.Format("El servicio respondió con el código {0}. ({1})", result.StatusCode, url));
                }
            }
            catch (Exception ex)
            {
                respuesta.CodigoError = 1;
                respuesta.Exitoso = false;
                respuesta.MensajeError = ex.Message;
            }
            return respuesta;
        }

        /// <summary>
        /// Busca el valor de un parametro en la respuesta de la API
        /// </summary>
        /// <param name="respuesta"></param>
        /// <param name="parametro"></param>
        /// <param name="valorDefault"></param>
        /// <returns></returns>

        public static string ValorParametroApi(RespuestaBase respuesta, string parametro, string valorDefault = "")
        {
            string r = valorDefault;
            try
            {
                if (respuesta != null)
                {
                    if (respuesta.Parametros != null)
                    {
                        if (respuesta.Parametros.Count > 0)
                        {
                            List<ParametroApi> lst = respuesta.Parametros.Where(o => o.Nombre.ToLower().Equals(parametro.ToLower())).ToList();
                            if (lst.Count > 0)
                            {
                                r = lst[0].Valor;
                            }
                        }
                    }
                }
            }
            catch
            {
                r = valorDefault;
            }
            return r;
        }
    }
}
