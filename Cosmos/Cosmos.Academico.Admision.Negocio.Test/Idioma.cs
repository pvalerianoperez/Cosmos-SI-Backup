using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cosmos.Framework;
using Cosmos.Seguridad;

namespace Cosmos.Academico.Admision.Negocio.Test
{
    [TestClass]
    public class Idioma
    {
        Cosmos.Seguridad.Entidades.DataForLog oInfoForLog;

        [TestMethod]
        public void RunAllTests_For_Idioma()
        {

            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {

                int rowsDeleted = Cosmos.Academico.Admision.Negocio.Idioma.InitTests();

                Idioma_Guardar();
                Idioma_Consultar();
                Idioma_Guardar_Actualizar();
                Idioma_Eliminar();
                Idioma_Listado();
            }
        }

        [TestMethod]
        public void Idioma_Listado()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                List<Cosmos.Academico.Admision.Entidades.Idioma> Idiomas = new List<Cosmos.Academico.Admision.Entidades.Idioma>();
                Idiomas = Cosmos.Academico.Admision.Negocio.Idioma.Listado();

                Assert.AreEqual(Idiomas.Count, 4);
            }
        }

        [TestMethod]
        public void Idioma_Consultar()
        {
            int IdiomaConsultar = 5;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.Idioma oIdioma = new Cosmos.Academico.Admision.Entidades.Idioma();
                oIdioma.IdiomaID = IdiomaConsultar;

                oIdioma = Cosmos.Academico.Admision.Negocio.Idioma.Consultar(oIdioma);

                Assert.AreEqual(oIdioma.IdiomaID, 5);
                Assert.AreEqual(oIdioma.IdiomaClave, "ClaveX");
                Assert.AreEqual(oIdioma.Nombre, "Registro X");
                Assert.AreEqual(oIdioma.NombreCorto, "RegX");
                Assert.AreEqual(oIdioma.Descripcion, "Registro equis");
            }
        }

        [TestMethod]
        public void Idioma_Guardar()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.Idioma oIdioma = new Cosmos.Academico.Admision.Entidades.Idioma();
                oIdioma.IdiomaClave = "ClaveX";
                oIdioma.Nombre = "Registro X";
                oIdioma.NombreCorto = "RegX";
                oIdioma.Descripcion = "Registro equis";

                oIdioma = Cosmos.Academico.Admision.Negocio.Idioma.Guardar(oIdioma, oInfoForLog);

                Assert.AreEqual(oIdioma.IdiomaID, 5);
                Assert.AreEqual(oIdioma.IdiomaClave, "ClaveX");
                Assert.AreEqual(oIdioma.Nombre, "Registro X");
                Assert.AreEqual(oIdioma.NombreCorto, "RegX");
                Assert.AreEqual(oIdioma.Descripcion, "Registro equis");

            }
        }

        [TestMethod]
        public void Idioma_Guardar_Actualizar()
        {
            int IdiomaID = 5;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.Idioma oIdioma = new Cosmos.Academico.Admision.Entidades.Idioma();
                oIdioma.IdiomaID = IdiomaID;
                oIdioma.IdiomaClave = "NuKey";
                oIdioma.Nombre = "Niu Register X";
                oIdioma.NombreCorto = "NuRegX";
                oIdioma.Descripcion = "Nuevo Registro Equis";

                oIdioma = Cosmos.Academico.Admision.Negocio.Idioma.Guardar(oIdioma, oInfoForLog);

                Assert.AreEqual(oIdioma.IdiomaID, 5);
                Assert.AreEqual(oIdioma.IdiomaClave, "NuKey");
                Assert.AreEqual(oIdioma.Nombre, "Niu Register X");
                Assert.AreEqual(oIdioma.NombreCorto, "NuRegX");
                Assert.AreEqual(oIdioma.Descripcion, "Nuevo Registro Equis");
            }
        }

        [TestMethod]
        public void Idioma_Eliminar()
        {
            int IdiomaIDEliminar = 5;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.Idioma oIdioma = new Cosmos.Academico.Admision.Entidades.Idioma();
                oIdioma.IdiomaID = IdiomaIDEliminar;

                bool AlgunError = false;
                AlgunError = Cosmos.Academico.Admision.Negocio.Idioma.Eliminar(oIdioma, oInfoForLog);

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

