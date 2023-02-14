using System;
using System.Collections.Generic;
using System.Data;
using Cosmos.Framework;

namespace Cosmos.Seguridad.Entidades
{
    public class DataForLog
    {

        const int longitudDescripcionForLog = 500;
        const int longitudIpAddressForLog = 40;
        const int longitudHostNameForLog = 50;

        ///************************************************/
        ///* Campos para Log */
        //,@UsuarioIDForLog int
        //,@DescripcionForLog varchar(500)    = null
        //,@IpAddressForLog varchar(40)     = null
        //,@HostNameForLog varchar(50)     = null
        ///************************************************/

        public int UsuarioIDForLog { get; set; }
        public string DescripcionForLog { get; set; }
        public string IpAddressForLog { get; set; }
        public string HostNameForLog { get; set; }

        public DataForLog(int UsuarioID, string Descripcion = "", string IpAddress="", string HostName="")
        {
            this.UsuarioIDForLog = UsuarioID;

            if (Descripcion.Length > longitudDescripcionForLog) Descripcion = Descripcion.Substring(0, longitudDescripcionForLog);
            this.DescripcionForLog = Descripcion;

            if (IpAddress.Length > longitudIpAddressForLog) IpAddress = IpAddress.Substring(0, longitudIpAddressForLog);
            this.IpAddressForLog = IpAddress;

            if (HostName.Length > longitudHostNameForLog) HostName = HostName.Substring(0, longitudHostNameForLog);
            this.HostNameForLog = HostName;

        }

        public DataForLog(Cosmos.Seguridad.Entidades.UsuarioToken oUserToken, string Descripcion = "")
        {
            DataForLog o = new DataForLog(oUserToken.UsuarioID, Descripcion, oUserToken.Ipaddress, oUserToken.HostName);
            this.UsuarioIDForLog = o.UsuarioIDForLog;
            this.DescripcionForLog = o.DescripcionForLog;
            this.IpAddressForLog = o.IpAddressForLog;
            this.HostNameForLog = o.HostNameForLog;
        }


    }
}
