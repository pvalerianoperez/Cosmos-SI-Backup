
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cosmos.Framework;
using Cosmos.Seguridad;


namespace Cosmos.Calendario.Negocio.Test
{
    [TestClass]
    public class EventoTipo
    {
        Cosmos.Seguridad.Entidades.DataForLog oInfoForLog;

        [TestMethod]
        public void EventoTipo_Listado()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                List<Cosmos.Calendario.Entidades.EventoTipo> EventoTipos = new List<Entidades.EventoTipo>();
                EventoTipos = Cosmos.Calendario.Negocio.EventoTipo.Listado();

                Assert.AreNotEqual(EventoTipos.Count, 0);
            }
        }

        [TestMethod]
        public void EventoTipo_Guardar()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Calendario.Entidades.EventoTipo oEventoTipo = new Cosmos.Calendario.Entidades.EventoTipo();
                oEventoTipo.EventoTipoClave = "Clave";
                oEventoTipo.Nombre = "Nombre";
                oEventoTipo.NombreCorto = "Corto";

                oEventoTipo = Cosmos.Calendario.Negocio.EventoTipo.Guardar(oEventoTipo, oInfoForLog);

                Assert.AreNotEqual(oEventoTipo.EventoTipoID, -1);
            }
        }

        [TestMethod]
        public void EventoTipo_Eliminar()
        {
            int EventoTipoIDEliminar = 1;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Calendario.Entidades.EventoTipo oEventoTipo = new Cosmos.Calendario.Entidades.EventoTipo();
                oEventoTipo.EventoTipoID = EventoTipoIDEliminar;

                bool AlgunError = false;
                AlgunError = Cosmos.Calendario.Negocio.EventoTipo.Eliminar(oEventoTipo, oInfoForLog);

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
