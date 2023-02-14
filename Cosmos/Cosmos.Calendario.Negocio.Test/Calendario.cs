
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cosmos.Framework;
using Cosmos.Seguridad;

namespace Cosmos.Calendario.Negocio.Test
{
    [TestClass]
    public class Calendario
    {
        Cosmos.Seguridad.Entidades.DataForLog oInfoForLog;

        [TestMethod]
        public void Calendario_Listado()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                List<Cosmos.Calendario.Entidades.Calendario> Calendarios = new List<Entidades.Calendario>();
                Calendarios = Cosmos.Calendario.Negocio.Calendario.Listado();

                //Assert.AreNotEqual(Calendarios.Count, 0);
            }
        }

        [TestMethod]
        public void Calendario_Listado_incluidos_borrados()
        {
            bool conBorrados = true;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                List<Cosmos.Calendario.Entidades.Calendario> Calendarios = new List<Entidades.Calendario>();
                Calendarios = Cosmos.Calendario.Negocio.Calendario.Listado(conBorrados);

                //Assert.AreNotEqual(Calendarios.Count, 0);
            }
        }

        [TestMethod]
        public void Calendario_Guardar()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Calendario.Entidades.Calendario oCalendario = new Cosmos.Calendario.Entidades.Calendario();
                oCalendario.CalendarioClave = "Clave";
                oCalendario.Nombre = "Nombre";
                oCalendario.NombreCorto = "Corto";
                oCalendario.CalendarioTipoID = 1;
                oCalendario.Borrado = false;

                oCalendario = Cosmos.Calendario.Negocio.Calendario.Guardar(oCalendario, oInfoForLog);

                Assert.AreNotEqual(oCalendario.CalendarioID, -1);
            }
        }

        [TestMethod]
        public void Calendario_Eliminar()
        {
            int CalendarioIDEliminar = 7;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Calendario.Entidades.Calendario oCalendario = new Cosmos.Calendario.Entidades.Calendario();
                oCalendario.CalendarioID = CalendarioIDEliminar;

                bool AlgunError = false;
                AlgunError = Cosmos.Calendario.Negocio.Calendario.Eliminar(oCalendario, oInfoForLog);

                Assert.AreEqual(false, AlgunError);
            }
        }

        /* Calendario Personal */

        [TestMethod]
        public void Calendario_Mis_Calendarios()
        {
            int PersonaID = 1;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                List<Cosmos.Calendario.Entidades.Calendario> Calendarios = new List<Entidades.Calendario>();
                Calendarios = Cosmos.Calendario.Negocio.Calendario.Mis_Calendarios(PersonaID);

                Assert.AreNotEqual(Calendarios.Count, 0);
            }
        }

        [TestMethod]
        public void CalendarioPersona_Guardar_Insertar()
        {
            //int CalendarioID = 7;
            int PersonaID  = 1;
            string Mensaje_Error = "";
            bool Dueno = true;

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Calendario.Entidades.Calendario oCalendario = new Cosmos.Calendario.Entidades.Calendario();
                oCalendario.CalendarioClave = "Clave";
                oCalendario.Nombre = "Nombre";
                oCalendario.NombreCorto = "Corto";
                oCalendario.CalendarioTipoID = 1;
                oCalendario.Borrado = false;

                oCalendario.Dueno = Dueno;
                oCalendario.PersonaID = PersonaID;
                oCalendario.CalendarioPermisoInt = 3;

                oCalendario = Cosmos.Calendario.Negocio.Calendario.Guardar(oCalendario, oInfoForLog);

                Assert.AreNotEqual(oCalendario.CalendarioID, -1);
            }
        }

        [TestMethod]
        public void CalendarioPersona_Guardar_Actualizar()
        {
            int CalendarioID = 22;
            int CalendarioPersonaID = 1;
            int PersonaID = 1;
            string Mensaje_Error = "";
            bool Dueno = false;

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Calendario.Entidades.Calendario oCalendario = new Cosmos.Calendario.Entidades.Calendario();
                oCalendario.CalendarioID = CalendarioID;
                oCalendario.CalendarioClave = "Clave";
                oCalendario.Nombre = "Nombre";
                oCalendario.NombreCorto = "Corto";
                oCalendario.CalendarioTipoID = 1;
                oCalendario.Borrado = false;

                oCalendario.Dueno = Dueno;
                oCalendario.PersonaID = PersonaID;
                oCalendario.CalendarioPersonaID = CalendarioPersonaID;
                oCalendario.CalendarioPermisoInt = 3;

                oCalendario = Cosmos.Calendario.Negocio.Calendario.Guardar(oCalendario, oInfoForLog);

                Assert.AreNotEqual(oCalendario.CalendarioID, -1);
            }
        }


        [TestMethod]
        public void CalendarioPersona_Compartir_Calendario()
        {
            int CalendarioID = 22;
            int PersonaID = 2;
            string Mensaje_Error = "";
            bool Dueno = true;
            int CalendarioPermisoInt = 3;

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Calendario.Entidades.Calendario oCalendario = new Cosmos.Calendario.Entidades.Calendario();

                oCalendario.CalendarioID = CalendarioID;
                oCalendario.Dueno = Dueno;
                oCalendario.PersonaID = PersonaID;
                oCalendario.CalendarioPermisoInt = CalendarioPermisoInt;

                oCalendario = Cosmos.Calendario.Negocio.Calendario.Compartir(oCalendario, oInfoForLog);

                Assert.AreNotEqual(oCalendario.CalendarioID, -1);
            }
        }


        [TestMethod]
        public void CalendarioPersona_DesCompartir_Calendario()
        {
            int CalendarioPersonaID = 10;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Calendario.Entidades.Calendario oCalendario = new Cosmos.Calendario.Entidades.Calendario();

                oCalendario.CalendarioPersonaID = CalendarioPersonaID;

                oCalendario = Cosmos.Calendario.Negocio.Calendario.DesCompartir(oCalendario, oInfoForLog);

                //Assert.AreNotEqual(oCalendario.CalendarioID, -1);
            }
        }


        public int inicializa_Configuracion(string Licencia, ref Cosmos.Seguridad.Entidades.DataForLog oInfoForLog, ref string Mensaje_Error_oConfig)
        {
            int iError_oConfig = 0;
            Mensaje_Error_oConfig = "";

            SQLHelper.ConnectionString = Properties.Settings.Default.Sistema;

            oInfoForLog = new Seguridad.Entidades.DataForLog(1,"","","");
            oInfoForLog.UsuarioIDForLog = 1;
            oInfoForLog.IpAddressForLog = "148.202.1.1";
            oInfoForLog.HostNameForLog = "XPS13";
            oInfoForLog.DescripcionForLog = "Cosmos.Calendario.Negocio.Test";

            return iError_oConfig;
        }

    }
}
