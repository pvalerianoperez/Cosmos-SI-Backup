
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cosmos.Framework;
using Cosmos.Seguridad;


namespace Cosmos.Calendario.Negocio.Test
{
    [TestClass]
    public class CalendarioTipo
    {
        Cosmos.Seguridad.Entidades.DataForLog oInfoForLog;

        [TestMethod]
        public void CalendarioTipo_Listado()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                List<Cosmos.Calendario.Entidades.CalendarioTipo> CalendarioTipos = new List<Entidades.CalendarioTipo>();
                CalendarioTipos = Cosmos.Calendario.Negocio.CalendarioTipo.Listado();

                Assert.AreNotEqual(CalendarioTipos.Count, 0);
            }
        }

        [TestMethod]
        public void CalendarioTipo_Guardar()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Calendario.Entidades.CalendarioTipo oCalendarioTipo = new Cosmos.Calendario.Entidades.CalendarioTipo();
                oCalendarioTipo.CalendarioTipoClave = "Clave";
                oCalendarioTipo.Nombre = "Nombre";
                oCalendarioTipo.NombreCorto = "Corto";

                oCalendarioTipo = Cosmos.Calendario.Negocio.CalendarioTipo.Guardar(oCalendarioTipo, oInfoForLog);

                Assert.AreNotEqual(oCalendarioTipo.CalendarioTipoID, -1);
            }
        }

        [TestMethod]
        public void CalendarioTipo_Eliminar()
        {
            int CalendarioTipoIDEliminar = 2;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Calendario.Entidades.CalendarioTipo oCalendarioTipo = new Cosmos.Calendario.Entidades.CalendarioTipo();
                oCalendarioTipo.CalendarioTipoID = CalendarioTipoIDEliminar;

                bool AlgunError = false;
                AlgunError = Cosmos.Calendario.Negocio.CalendarioTipo.Eliminar(oCalendarioTipo, oInfoForLog);

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
