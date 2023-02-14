using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cosmos.Framework;
using Cosmos.Seguridad;

namespace Cosmos.Academico.Admision.Negocio.Test
{
    [TestClass]
    public class TipoRepresentanteFamilia
    {
        Cosmos.Seguridad.Entidades.DataForLog oInfoForLog;

        [TestMethod]
        public void RunAllTests_For_TipoRepresentanteFamilia()
        {

            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {

                int rowsDeleted = Cosmos.Academico.Admision.Negocio.TipoRepresentanteFamilia.InitTests();

                TipoRepresentanteFamilia_Guardar();
                TipoRepresentanteFamilia_Consultar();
                TipoRepresentanteFamilia_Guardar_Actualizar();
                TipoRepresentanteFamilia_Eliminar();
                TipoRepresentanteFamilia_Listado();
            }
        }

        [TestMethod]
        public void TipoRepresentanteFamilia_Listado()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                List<Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia> TipoRepresentanteFamilias = new List<Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia>();
                TipoRepresentanteFamilias = Cosmos.Academico.Admision.Negocio.TipoRepresentanteFamilia.Listado();

                Assert.AreEqual(TipoRepresentanteFamilias.Count, 4);
            }
        }

        [TestMethod]
        public void TipoRepresentanteFamilia_Consultar()
        {
            int TipoRepresentanteFamiliaConsultar = 5;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia oTipoRepresentanteFamilia = new Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia();
                oTipoRepresentanteFamilia.TipoRepresentanteFamiliaID = TipoRepresentanteFamiliaConsultar;

                oTipoRepresentanteFamilia = Cosmos.Academico.Admision.Negocio.TipoRepresentanteFamilia.Consultar(oTipoRepresentanteFamilia);

                Assert.AreEqual(oTipoRepresentanteFamilia.TipoRepresentanteFamiliaID, 5);
                Assert.AreEqual(oTipoRepresentanteFamilia.TipoRepresentanteFamiliaClave, "ClaveX");
                Assert.AreEqual(oTipoRepresentanteFamilia.Nombre, "Registro X");
                Assert.AreEqual(oTipoRepresentanteFamilia.NombreCorto, "RegX");
                Assert.AreEqual(oTipoRepresentanteFamilia.Descripcion, "Registro equis");
            }
        }

        [TestMethod]
        public void TipoRepresentanteFamilia_Guardar()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia oTipoRepresentanteFamilia = new Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia();
                oTipoRepresentanteFamilia.TipoRepresentanteFamiliaClave = "ClaveX";
                oTipoRepresentanteFamilia.Nombre = "Registro X";
                oTipoRepresentanteFamilia.NombreCorto = "RegX";
                oTipoRepresentanteFamilia.Descripcion = "Registro equis";

                oTipoRepresentanteFamilia = Cosmos.Academico.Admision.Negocio.TipoRepresentanteFamilia.Guardar(oTipoRepresentanteFamilia, oInfoForLog);

                Assert.AreEqual(oTipoRepresentanteFamilia.TipoRepresentanteFamiliaID, 5);
                Assert.AreEqual(oTipoRepresentanteFamilia.TipoRepresentanteFamiliaClave, "ClaveX");
                Assert.AreEqual(oTipoRepresentanteFamilia.Nombre, "Registro X");
                Assert.AreEqual(oTipoRepresentanteFamilia.NombreCorto, "RegX");
                Assert.AreEqual(oTipoRepresentanteFamilia.Descripcion, "Registro equis");

            }
        }

        [TestMethod]
        public void TipoRepresentanteFamilia_Guardar_Actualizar()
        {
            int TipoRepresentanteFamiliaID = 5;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia oTipoRepresentanteFamilia = new Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia();
                oTipoRepresentanteFamilia.TipoRepresentanteFamiliaID = TipoRepresentanteFamiliaID;
                oTipoRepresentanteFamilia.TipoRepresentanteFamiliaClave = "NuKey";
                oTipoRepresentanteFamilia.Nombre = "Niu Register X";
                oTipoRepresentanteFamilia.NombreCorto = "NuRegX";
                oTipoRepresentanteFamilia.Descripcion = "Nuevo Registro Equis";

                oTipoRepresentanteFamilia = Cosmos.Academico.Admision.Negocio.TipoRepresentanteFamilia.Guardar(oTipoRepresentanteFamilia, oInfoForLog);

                Assert.AreEqual(oTipoRepresentanteFamilia.TipoRepresentanteFamiliaID, 5);
                Assert.AreEqual(oTipoRepresentanteFamilia.TipoRepresentanteFamiliaClave, "NuKey");
                Assert.AreEqual(oTipoRepresentanteFamilia.Nombre, "Niu Register X");
                Assert.AreEqual(oTipoRepresentanteFamilia.NombreCorto, "NuRegX");
                Assert.AreEqual(oTipoRepresentanteFamilia.Descripcion, "Nuevo Registro Equis");
            }
        }

        [TestMethod]
        public void TipoRepresentanteFamilia_Eliminar()
        {
            int TipoRepresentanteFamiliaIDEliminar = 5;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia oTipoRepresentanteFamilia = new Cosmos.Academico.Admision.Entidades.TipoRepresentanteFamilia();
                oTipoRepresentanteFamilia.TipoRepresentanteFamiliaID = TipoRepresentanteFamiliaIDEliminar;

                bool AlgunError = false;
                AlgunError = Cosmos.Academico.Admision.Negocio.TipoRepresentanteFamilia.Eliminar(oTipoRepresentanteFamilia, oInfoForLog);

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
