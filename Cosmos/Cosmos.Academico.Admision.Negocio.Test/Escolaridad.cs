using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cosmos.Framework;
using Cosmos.Seguridad;

namespace Cosmos.Academico.Admision.Negocio.Test
{
    [TestClass]
    public class Escolaridad
    {
        Cosmos.Seguridad.Entidades.DataForLog oInfoForLog;

        [TestMethod]
        public void RunAllTests_For_Escolaridad()
        {

            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {

                int rowsDeleted = Cosmos.Academico.Admision.Negocio.Escolaridad.InitTests();

                Escolaridad_Guardar();
                Escolaridad_Consultar();
                Escolaridad_Guardar_Actualizar();
                Escolaridad_Eliminar();
                Escolaridad_Listado();
            }
        }

        [TestMethod]
        public void Escolaridad_Listado()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                List<Cosmos.Academico.Admision.Entidades.Escolaridad> Escolaridads = new List<Cosmos.Academico.Admision.Entidades.Escolaridad>();
                Escolaridads = Cosmos.Academico.Admision.Negocio.Escolaridad.Listado();

                Assert.AreEqual(Escolaridads.Count, 4);
            }
        }

        [TestMethod]
        public void Escolaridad_Consultar()
        {
            int EscolaridadConsultar = 5;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.Escolaridad oEscolaridad = new Cosmos.Academico.Admision.Entidades.Escolaridad();
                oEscolaridad.EscolaridadID = EscolaridadConsultar;

                oEscolaridad = Cosmos.Academico.Admision.Negocio.Escolaridad.Consultar(oEscolaridad);

                Assert.AreEqual(oEscolaridad.EscolaridadID, 5);
                Assert.AreEqual(oEscolaridad.EscolaridadClave, "ClaveX");
                Assert.AreEqual(oEscolaridad.Nombre, "Registro X");
                Assert.AreEqual(oEscolaridad.NombreCorto, "RegX");
                Assert.AreEqual(oEscolaridad.Descripcion, "Registro equis");
            }
        }

        [TestMethod]
        public void Escolaridad_Guardar()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.Escolaridad oEscolaridad = new Cosmos.Academico.Admision.Entidades.Escolaridad();
                oEscolaridad.EscolaridadClave = "ClaveX";
                oEscolaridad.Nombre = "Registro X";
                oEscolaridad.NombreCorto = "RegX";
                oEscolaridad.Descripcion = "Registro equis";

                oEscolaridad = Cosmos.Academico.Admision.Negocio.Escolaridad.Guardar(oEscolaridad, oInfoForLog);

                Assert.AreEqual(oEscolaridad.EscolaridadID, 5);
                Assert.AreEqual(oEscolaridad.EscolaridadClave, "ClaveX");
                Assert.AreEqual(oEscolaridad.Nombre, "Registro X");
                Assert.AreEqual(oEscolaridad.NombreCorto, "RegX");
                Assert.AreEqual(oEscolaridad.Descripcion, "Registro equis");

            }
        }

        [TestMethod]
        public void Escolaridad_Guardar_Actualizar()
        {
            int EscolaridadID = 5;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.Escolaridad oEscolaridad = new Cosmos.Academico.Admision.Entidades.Escolaridad();
                oEscolaridad.EscolaridadID = EscolaridadID;
                oEscolaridad.EscolaridadClave = "NuKey";
                oEscolaridad.Nombre = "Niu Register X";
                oEscolaridad.NombreCorto = "NuRegX";
                oEscolaridad.Descripcion = "Nuevo Registro Equis";

                oEscolaridad = Cosmos.Academico.Admision.Negocio.Escolaridad.Guardar(oEscolaridad, oInfoForLog);

                Assert.AreEqual(oEscolaridad.EscolaridadID, 5);
                Assert.AreEqual(oEscolaridad.EscolaridadClave, "NuKey");
                Assert.AreEqual(oEscolaridad.Nombre, "Niu Register X");
                Assert.AreEqual(oEscolaridad.NombreCorto, "NuRegX");
                Assert.AreEqual(oEscolaridad.Descripcion, "Nuevo Registro Equis");
            }
        }

        [TestMethod]
        public void Escolaridad_Eliminar()
        {
            int EscolaridadIDEliminar = 5;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.Escolaridad oEscolaridad = new Cosmos.Academico.Admision.Entidades.Escolaridad();
                oEscolaridad.EscolaridadID = EscolaridadIDEliminar;

                bool AlgunError = false;
                AlgunError = Cosmos.Academico.Admision.Negocio.Escolaridad.Eliminar(oEscolaridad, oInfoForLog);

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
            oInfoForLog.DescripcionForLog = "Cosmos.Academico.Admision.Negocio.Test";

            return iError_oConfig;
        }

    }
}

