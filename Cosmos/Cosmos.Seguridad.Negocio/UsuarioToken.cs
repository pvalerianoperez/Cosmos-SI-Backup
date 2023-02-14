
using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;
using Jose;

namespace Cosmos.Seguridad.Negocio
{
    public partial class UsuarioToken
    {

        public static Cosmos.Seguridad.Entidades.UsuarioToken Crear(Cosmos.Seguridad.Entidades.Usuario o, 
                                                                    string nombreHost,
                                                                    string ip,
                                                                    int utc)
        {
            Cosmos.Seguridad.Entidades.UsuarioToken obj;
            obj = Cosmos.Seguridad.Entidades.UsuarioToken.Crear(o, nombreHost, ip, utc);

            return obj;
        }

        public static Cosmos.Seguridad.Entidades.UsuarioToken Crear(string Jwt)
        {
            Cosmos.Seguridad.Entidades.UsuarioToken obj;
            obj = Cosmos.Seguridad.Entidades.UsuarioToken.Crear(Jwt);

            return obj;
        }

        public static Cosmos.Seguridad.Entidades.UsuarioToken GetInstance()
        {
            return Cosmos.Seguridad.Entidades.UsuarioToken.GetInstance();
        }

        public static string GetJwt()
        {
            Cosmos.Seguridad.Entidades.UsuarioToken oUsuarioToken;
            oUsuarioToken = GetInstance();
            return oUsuarioToken.GetJwt();
        }

    }
}
