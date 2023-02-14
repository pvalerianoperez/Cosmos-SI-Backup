using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.Framework;
using Jose;

namespace Cosmos.Seguridad.Entidades
{
    public class UsuarioToken : Cosmos.Seguridad.Entidades.Usuario
    {

        [JsonIgnore]
        private static string ISS = "CosmosERP";

        [JsonIgnore]
        private static byte[] secretKey = Util.Base64ToByteArray(Util.Base64Encode("secrettokenforapiservices".Reverse()));

        [ThreadStatic]
        [JsonIgnore]
        private static UsuarioToken instance;

        [JsonProperty("iss")]
        public string Iss { get; set; }

        [JsonProperty("exp")]
        public DateTime Exp { get; set; }

        [JsonProperty("hostname")]
        public string HostName { get; set; }

        [JsonProperty("ipaddress")]
        public string Ipaddress { get; set; }

        [JsonProperty("utc")]
        public int Utc { get; set; }

        private UsuarioToken(Usuario user, string hostname, string ipaddress, int utc)
        {
            UsuarioID = user.UsuarioID;
            Nombre = user.Nombre;
            CorreoElectronico = user.CorreoElectronico;
            HostName = hostname;
            Ipaddress = ipaddress;
            //Nombre = user.Usuarioname;
            Contrasena = user.Contrasena;
            //Roles = user.Roles;
            Utc = utc;
        }

        public string GetJwt()
        {
            Iss = ISS;
            //Exp = DateTime.Now.AddMinutes(20);
            Exp = DateTime.Now.AddDays(3650);
            return JWT.Encode(Util.ObjectToJson(this), secretKey, JwsAlgorithm.HS256);
        }

        public static UsuarioToken GetInstance()
        {
            return instance;
        }

        public static UsuarioToken Crear(Usuario Usuario, string nombreHost, string ip, int utc)
        {
            if (Usuario != null)
                instance = new UsuarioToken(Usuario, nombreHost, ip, utc);
            return instance;
        }

        public static UsuarioToken Crear(string jwt)
        {

            var json = Util.JsonToObject<dynamic>(JWT.Decode(jwt, secretKey));

            instance = new UsuarioToken(new Usuario()
            {
                UsuarioID = (int)json.UsuarioID,
                Nombre = (string)json.Nombre,
                CorreoElectronico = (string)json.CorreoElectronico
            }, (string)json.hostname, (string)json.ipaddress, (int)json.utc)
            {
                Iss = (string)json.iss,
                Exp = (DateTime)json.exp
            };

            if (instance.Iss != ISS)
                throw new Exception("El token no pertenece a este API");
            else if (instance.Exp < DateTime.Now)
                throw new Exception("El token ya expiró");

            return instance;
        }



    }
}


