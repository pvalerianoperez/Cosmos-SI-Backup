using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cosmos.Api.Entidades;

namespace Cosmos.Api.Controllers
{
    public class Funciones
    {
        public static string ValorParametroApi(SolicitudBase solicitud, string parametro, string valorDefault = "") {
            string r = valorDefault;
            try
            {
                if (solicitud != null)
                {
                    if (solicitud.Parametros != null)
                    {
                        if (solicitud.Parametros.Count > 0)
                        {
                            List<ParametroApi> lst = solicitud.Parametros.Where(o => o.Nombre.ToLower().Equals(parametro.ToLower())).ToList();
                            if (lst.Count > 0)
                            {
                                r = lst[0].Valor;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) {
                r = valorDefault;
            }
            return r;
        }

       

        public static Boolean AccesoValido(SolicitudBase solicitud) {
            
            //1. log 

            //2. validar usuario y sesion


            //if (solicitud == null)
            //{
            //    throw new Exception("La solicitud no puede estar vacía.");
            //}
            //else {
            //    if (CastHelper.CStr2(solicitud.UsuarioID).Trim().Equals(""))
            //    {
            //        throw new Exception("La solicitud no contiene datos del usuario.");
            //    }
            //    else
            //    {
            //        if (CastHelper.CStr2(solicitud.SesionID).Trim().Equals(""))
            //        {
            //            throw new Exception("La solicitud no contiene datos de la sesión.");
            //        }
            //    }
            //}

            //return false;
            return true;
        }
    }
}