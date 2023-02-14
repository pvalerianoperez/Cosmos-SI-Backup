
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cosmos.Framework;
using Cosmos.Seguridad;


namespace Cosmos.Calendario.Negocio.Test
{
    [TestClass]
    public class Evento
    {
        Cosmos.Seguridad.Entidades.DataForLog oInfoForLog;

        [TestMethod]
        public void Evento_Listado()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                List<Cosmos.Calendario.Entidades.Evento> Eventos = new List<Entidades.Evento>();
                Eventos = Cosmos.Calendario.Negocio.Evento.Listado();

                Assert.AreNotEqual(Eventos.Count, 0);
            }
        }

        [TestMethod]
        public void Evento_Guardar()
        {
            int CalendarioID = -1;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Calendario.Entidades.Evento oEvento = new Cosmos.Calendario.Entidades.Evento();
                oEvento.EventoTipoID = 1;
                oEvento.FechaInicio = DateTime.Parse("2019-01-01 09:00:00");
                oEvento.FechaFinal = DateTime.Parse("2019-01-01 11:00:00");
                oEvento.TodoElDia = false;
                oEvento.Tema = "Tema";
                oEvento.Locacion = "Locacion";
                oEvento.Descripcion = "Descripcion";
                oEvento.StatusID = 1;
                oEvento.EtiquetaID = 1;
                oEvento.RecursoID = 1;
                oEvento.RecursoIDs = "";
                oEvento.RecordatorioInfo = "";
                oEvento.RecurrenciaInfo = "";
                oEvento.CampoPersonalizado1 = "1";
                oEvento.CampoPersonalizado2 = "2";
                oEvento.CampoPersonalizado3 = "3";
                oEvento.CampoPersonalizado4 = "4";
                oEvento.CampoPersonalizado5 = "5";

                oEvento = Cosmos.Calendario.Negocio.Evento.Guardar(oEvento, CalendarioID, oInfoForLog);

                Assert.AreNotEqual(oEvento.EventoID, -1);
            }
        }

        [TestMethod]
        public void Evento_Guardar_En_Calendario()
        {
            int CalendarioID = 22;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Calendario.Entidades.Evento oEvento = new Cosmos.Calendario.Entidades.Evento();
                oEvento.EventoTipoID = 1;
                oEvento.FechaInicio = DateTime.Parse("2019-01-01 09:00:00");
                oEvento.FechaFinal = DateTime.Parse("2019-01-01 11:00:00");
                oEvento.TodoElDia = false;
                oEvento.Tema = "Tema";
                oEvento.Locacion = "Locacion";
                oEvento.Descripcion = "Descripcion";
                oEvento.StatusID = 1;
                oEvento.EtiquetaID = 1;
                oEvento.RecursoID = 1;
                oEvento.RecursoIDs = "";
                oEvento.RecordatorioInfo = "";
                oEvento.RecurrenciaInfo = "";
                oEvento.CampoPersonalizado1 = "1";
                oEvento.CampoPersonalizado2 = "2";
                oEvento.CampoPersonalizado3 = "3";
                oEvento.CampoPersonalizado4 = "4";
                oEvento.CampoPersonalizado5 = "5";

                oEvento = Cosmos.Calendario.Negocio.Evento.Guardar(oEvento, CalendarioID, oInfoForLog);

                Assert.AreNotEqual(oEvento.EventoID, -1);
            }
        }

        [TestMethod]
        public void Evento_Eliminar()
        {
            int EventoIDEliminar = 11;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Calendario.Entidades.Evento oEvento = new Cosmos.Calendario.Entidades.Evento();
                oEvento.EventoID = EventoIDEliminar;

                bool AlgunError = false;
                AlgunError = Cosmos.Calendario.Negocio.Evento.Eliminar(oEvento, oInfoForLog);

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
