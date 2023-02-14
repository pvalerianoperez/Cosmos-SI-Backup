using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using Cosmos.Api.Entidades;

namespace Cosmos.Api.Models
{
    public class JWTAuthorizeAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        readonly PermissionCatalogue permission;

        public JWTAuthorizeAttribute(PermissionCatalogue permission) : base() { this.permission = permission; }


        public override void OnActionExecuting(HttpActionContext context)
        {
            try
            {
                string authorization = context.Request.Headers.Authorization?.ToString();
                if (authorization != null && authorization.Length > 0)
                {
                    VerifyPermission(Cosmos.Seguridad.Negocio.UsuarioToken.Crear(authorization));
                }
                else if (permission == PermissionCatalogue.IPADDRESS)
                {
                    //Get users IP Address 
                    string ipAddress = HttpContext.Current.Request.UserHostAddress;

                    if (ipAddress != null && !IsIpAddressValid(ipAddress.Trim()))
                    {
                        var addresses =
                            Convert.ToString(ConfigurationManager.AppSettings["AuthorizeIPAddresses"]);

                        //string mensajeBody = "Una petición de la Ipaddress: " + ipAddress + " intentó accesar a una endpoint protegido por ipaddess válidos: " + addresses;
                        //mensajeBody = mensajeBody + "::Headers::" + HttpContext.Current.Request.Headers.ToString();

                        //Message oMensaje = new Message();
                        //oMensaje.FromId = 1;
                        //oMensaje.ToId = 1;
                        //oMensaje.Subject = "Intento de accesar a un EndPoint protegido por ipadddress.";
                        //oMensaje.Body = mensajeBody;
                        //oMensaje.ChannelTypeId = 2;
                        //MessageController.GetInstance().InsertaMensaje(oMensaje);

                        //Send back a HTTP Status code of 403 Forbidden  
                        //filterContext.Response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                        throw new Exception("Ipaddress no registrada en como permitida en el sistema.");
                    }
                }
                else
                {
                    throw new Exception("No se encontró llave de acceso al sistema");
                }
            }
            catch (Exception e)
            {
                context.Response = context.Request.CreateResponse(HttpStatusCode.Unauthorized, e.Message);
            }
            base.OnActionExecuting(context);
        }

        private void VerifyPermission(Cosmos.Seguridad.Entidades.UsuarioToken user)
        {
            if (permission != PermissionCatalogue.NONE)
            {
                //var dataProvider = DataProvider.GetInstance();

                //var parameters = new List<SqlParameter>() {
                //new SqlParameter("account_id",SqlDbType.Int){ Value = user.Id },
                //new SqlParameter("permission_name",SqlDbType.NVarChar,50){ Value = PermissionCatalogueValues.GetValue(permission)},
                //};

                //var data = dataProvider.Read(DataBases.DEFAULT, "account_has_permission", parameters);
            }
        }

        /// <summary> 
        /// Compares an IP address to list of valid IP addresses attempting to 
        /// find a match 
        /// </summary> 
        /// <param name="ipAddress">String representation of a valid IP Address</param> 
        /// <returns></returns> 
        public static bool IsIpAddressValid(string ipAddress)
        {
            //Split the users IP address into it's 4 octets (Assumes IPv4) 
            var incomingOctets = ipAddress.Trim().Split('.');

            //Get the valid IP addresses from the web.config 
            var addresses =
              Convert.ToString(ConfigurationManager.AppSettings["AuthorizeIPAddresses"]);

            //Store each valid IP address in a string array 
            var validIpAddresses = addresses.Trim().Split(',');

            //Iterate through each valid IP address 
            foreach (var validIpAddress in validIpAddresses)
            {
                //Return true if valid IP address matches the users 
                if (validIpAddress.Trim() == ipAddress)
                {
                    return true;
                }

                //Split the valid IP address into it's 4 octets 
                var validOctets = validIpAddress.Trim().Split('.');

                var matches = !validOctets.Where((t, index) => t != "*" && t != incomingOctets[index]).Any();

                //Iterate through each octet 

                if (matches)
                {
                    return true;
                }
            }

            //Found no matches 
            return false;
        }


    }
}






