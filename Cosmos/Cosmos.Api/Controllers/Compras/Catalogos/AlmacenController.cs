using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Cosmos.Framework;
using Newtonsoft.Json;
using static Cosmos.Framework.CastHelper;

namespace Cosmos.Api.Controllers.Compras.Catalogos
{
    public class AlmacenController : ApiController
    {
        [HttpPost]
        [Route("api/Compras/Catalogos/Almacen/List")]
        public RespuestaBase List() {

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            try
            {
                //establece la conexion
                SQLHelper.ConnectionString = Properties.Settings.Default.Sistema;

                //crea la lista vacia
                List<Entidades.Almacen> lst = new List<Entidades.Almacen>();

                //consulta la base de datos
                DataTable dt = SQLHelper.GetTable("Compras_Catalogos_Almacen_List");

                if (dt != null)
                {
                    //por cada datarow que exista...
                    foreach (DataRow dr in dt.Rows)
                    {
                        //crea un objeto de tipo entidad
                        Entidades.Almacen o = new Entidades.Almacen();

                        //llenalo con la informacion de la base de datos
                        o.AlmacenID = CInt2(dr["AlmacenID"]);
                        o.Nombre = CStr2(dr["Nombre"]);
                        o.NombreCorto = CStr2(dr["NombreCorto"]);

                        //agregalo a la lista
                        lst.Add(o);
                    }
                }

                respuesta.CodigoRespuesta = 1;
                respuesta.MensajeRespuesta = "OK";                
                respuesta.CodigoError = 0;
                respuesta.MensajeError = "";
                respuesta.Exitoso = true;
                respuesta.Datos = lst;

            }
            catch (Exception ex) {

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

        [HttpPost]
        [Route("api/Compras/Catalogos/Almacen/Insert")]
        public RespuestaBase Insert(SolicitudBase solicitud)
        {

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            try
            {

                if (solicitud == null) {
                    throw new Exception("La solicitud no puede estar vacía");
                }

                Entidades.Almacen o = JsonConvert.DeserializeObject<Entidades.Almacen>(JsonConvert.SerializeObject(solicitud.Datos));

                //establece la conexion
                SQLHelper.ConnectionString = Properties.Settings.Default.Sistema;

                SQLHelper.GetTable("Compras_Catalogos_Almacen_Insert", o.Nombre, o.NombreCorto);

                respuesta.CodigoRespuesta = 1;
                respuesta.MensajeRespuesta = "OK";
                respuesta.CodigoError = 0;
                respuesta.MensajeError = "";
                respuesta.Exitoso = true;


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
