
using System;
using System.Collections.Generic;
using Cosmos.Api.Entidades;
using Cosmos.Framework;
using Newtonsoft.Json;


namespace Cosmos.Compras.Api.Client
{
    public partial class Persona
    {
    
        #region CRUD

        public static List<Cosmos.Compras.Entidades.Persona> Listado() {        
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Persona> listado = new List<Cosmos.Compras.Entidades.Persona>();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Persona/Listado", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta)) {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Persona>>(JsonConvert.SerializeObject(respuesta.Datos));
            }                            
                            
            //regresa la respuesta
            return listado;                                 
        }
        
        public static Cosmos.Compras.Entidades.Persona Consultar(int personaID) {
            return Consultar(new Cosmos.Compras.Entidades.Persona() { PersonaID = personaID  });
        }
        
        public static Cosmos.Compras.Entidades.Persona Consultar(Cosmos.Compras.Entidades.Persona o){
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Persona> listado = new List<Cosmos.Compras.Entidades.Persona>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Persona resultado = new Cosmos.Compras.Entidades.Persona();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Persona/Consultar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Persona>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0]; }
            }

            //regresa la respuesta
            return resultado;
        }
        
        public static Cosmos.Compras.Entidades.Persona Guardar(int personaID, string personaClave, string fisicaMoral, string nombreComercial, string razonSocial, string nombre, string apellidoPaterno, string apellidoMaterno, string rFC, string cURP, int sexoID, DateTime fechaNacimiento, int ciudadNacimientoID, int estadoCivilID, bool casadoCivil, bool casadoIglesia, string iniciales, string sobreNombre){ 
            return Guardar(new Cosmos.Compras.Entidades.Persona() { PersonaID = personaID, PersonaClave = personaClave, FisicaMoral = fisicaMoral, NombreComercial = nombreComercial, RazonSocial = razonSocial, Nombre = nombre, ApellidoPaterno = apellidoPaterno, ApellidoMaterno = apellidoMaterno, RFC = rFC, CURP = cURP, SexoID = sexoID, FechaNacimiento = fechaNacimiento, CiudadNacimientoID = ciudadNacimientoID, EstadoCivilID = estadoCivilID, CasadoCivil = casadoCivil, CasadoIglesia = casadoIglesia, Iniciales = iniciales, SobreNombre = sobreNombre });
        }

        public static Cosmos.Compras.Entidades.Persona Guardar(Cosmos.Compras.Entidades.Persona o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //listado de respuesta
            List<Cosmos.Compras.Entidades.Persona> listado = new List<Cosmos.Compras.Entidades.Persona>();

            //resultado del metodo 
            Cosmos.Compras.Entidades.Persona resultado = new Cosmos.Compras.Entidades.Persona();

            //intenta llamar al servicio            
            respuesta = APIHelper.Execute("api/Compras/Persona/Guardar", solicitud);
            if (!APIHelper.ErrorRespuestaAPI(respuesta))
            {
                listado = JsonConvert.DeserializeObject<List<Cosmos.Compras.Entidades.Persona>>(JsonConvert.SerializeObject(respuesta.Datos));
                if (listado != null && listado.Count > 0) { resultado = listado[0];}
            }
            
            //regresa la respuesta
            return resultado;
        }
        
        public static bool Eliminar(int personaID){
            return Eliminar(new Cosmos.Compras.Entidades.Persona() { PersonaID = personaID });
        }

        public static bool Eliminar(Cosmos.Compras.Entidades.Persona o){
            //crea la solicitud
            SolicitudBase solicitud = new SolicitudBase();
            solicitud.Datos = o;

            //crea la respuesta
            RespuestaBase respuesta = new RespuestaBase();

            //intenta llamar al servicio
            respuesta = APIHelper.Execute("api/Compras/Persona/Eliminar", solicitud);
            return !APIHelper.ErrorRespuestaAPI(respuesta);
        }
        
        #endregion
        
       
    }
}
