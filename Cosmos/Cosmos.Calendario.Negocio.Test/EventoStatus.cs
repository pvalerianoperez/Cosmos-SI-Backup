
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cosmos.Framework;
using Cosmos.Seguridad;


namespace Cosmos.Calendario.Negocio.Test
{
    [TestClass]
    public class EventoStatus
    {
        Cosmos.Seguridad.Entidades.DataForLog oInfoForLog;

        [TestMethod]
        public void EventoStatus_Listado()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                List<Cosmos.Calendario.Entidades.EventoStatus> EventoStatus = new List<Entidades.EventoStatus>();
                EventoStatus = Cosmos.Calendario.Negocio.EventoStatus.Listado();

                Assert.AreNotEqual(EventoStatus.Count, 0);
            }
        }

        [TestMethod]
        public void EventoStatus_Guardar()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Calendario.Entidades.EventoStatus oEventoStatus = new Cosmos.Calendario.Entidades.EventoStatus();
                oEventoStatus.EventoStatusClave = "Clave";
                oEventoStatus.Nombre = "Nombre";
                oEventoStatus.NombreCorto = "Corto";

                oEventoStatus = Cosmos.Calendario.Negocio.EventoStatus.Guardar(oEventoStatus, oInfoForLog);

                Assert.AreNotEqual(oEventoStatus.EventoStatusID, -1);
            }
        }

        [TestMethod]
        public void EventoStatus_Eliminar()
        {
            int EventoStatusIDEliminar = 2;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Calendario.Entidades.EventoStatus oEventoStatus = new Cosmos.Calendario.Entidades.EventoStatus();
                oEventoStatus.EventoStatusID = EventoStatusIDEliminar;

                bool AlgunError = false;
                AlgunError = Cosmos.Calendario.Negocio.EventoStatus.Eliminar(oEventoStatus, oInfoForLog);

                Assert.AreEqual(false, AlgunError);
            }
        }







        public int inicializa_Configuracion(string Licencia, ref Cosmos.Seguridad.Entidades.DataForLog oInfoForLog, ref string Mensaje_Error_oConfig)
        {
            int iError_oConfig = 0;
            Mensaje_Error_oConfig = "";

            SQLHelper.ConnectionString = Properties.Settings.Default.Sistema;

            oInfoForLog = new Seguridad.Entidades.DataForLog(1, "", "", "");
            oInfoForLog.UsuarioIDForLog = 1;
            oInfoForLog.IpAddressForLog = "148.202.1.1";
            oInfoForLog.HostNameForLog = "XPS13";
            oInfoForLog.DescripcionForLog = "Cosmos.Calendario.Negocio.Test";

            return iError_oConfig;
        }

    }
}
