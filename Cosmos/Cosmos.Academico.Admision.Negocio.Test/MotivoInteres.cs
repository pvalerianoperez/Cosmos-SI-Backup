using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cosmos.Framework;
using Cosmos.Seguridad;

namespace Cosmos.Academico.Admision.Negocio.Test
{
    [TestClass]
    public class MotivoInteres
    {
        Cosmos.Seguridad.Entidades.DataForLog oInfoForLog;

        [TestMethod]
        public void RunAllTests_For_MotivoInteres()
        {

            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {

                int rowsDeleted = Cosmos.Academico.Admision.Negocio.MotivoInteres.InitTests();

                MotivoInteres_Guardar();
                MotivoInteres_Consultar();
                MotivoInteres_Guardar_Actualizar();
                MotivoInteres_Eliminar();
                MotivoInteres_Listado();
            }
        }

        [TestMethod]
        public void MotivoInteres_Listado()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                List<Cosmos.Academico.Admision.Entidades.MotivoInteres> MotivoInteress = new List<Cosmos.Academico.Admision.Entidades.MotivoInteres>();
                MotivoInteress = Cosmos.Academico.Admision.Negocio.MotivoInteres.Listado();

                Assert.AreEqual(MotivoInteress.Count, 9);
            }
        }

        [TestMethod]
        public void MotivoInteres_Consultar()
        {
            int MotivoInteresConsultar = 10;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.MotivoInteres oMotivoInteres = new Cosmos.Academico.Admision.Entidades.MotivoInteres();
                oMotivoInteres.MotivoInteresID = MotivoInteresConsultar;

                oMotivoInteres = Cosmos.Academico.Admision.Negocio.MotivoInteres.Consultar(oMotivoInteres);

                Assert.AreEqual(oMotivoInteres.MotivoInteresID, 10);
                Assert.AreEqual(oMotivoInteres.MotivoInteresClave, "ClaveX");
                Assert.AreEqual(oMotivoInteres.Nombre, "Registro X");
                Assert.AreEqual(oMotivoInteres.NombreCorto, "RegX");
                Assert.AreEqual(oMotivoInteres.Descripcion, "Registro equis");
            }
        }

        [TestMethod]
        public void MotivoInteres_Guardar()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.MotivoInteres oMotivoInteres = new Cosmos.Academico.Admision.Entidades.MotivoInteres();
                oMotivoInteres.MotivoInteresClave = "ClaveX";
                oMotivoInteres.Nombre = "Registro X";
                oMotivoInteres.NombreCorto = "RegX";
                oMotivoInteres.Descripcion = "Registro equis";

                oMotivoInteres = Cosmos.Academico.Admision.Negocio.MotivoInteres.Guardar(oMotivoInteres, oInfoForLog);

                Assert.AreEqual(oMotivoInteres.MotivoInteresID, 10);
                Assert.AreEqual(oMotivoInteres.MotivoInteresClave, "ClaveX");
                Assert.AreEqual(oMotivoInteres.Nombre, "Registro X");
                Assert.AreEqual(oMotivoInteres.NombreCorto, "RegX");
                Assert.AreEqual(oMotivoInteres.Descripcion, "Registro equis");

            }
        }

        [TestMethod]
        public void MotivoInteres_Guardar_Actualizar()
        {
            int MotivoInteresID = 10;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.MotivoInteres oMotivoInteres = new Cosmos.Academico.Admision.Entidades.MotivoInteres();
                oMotivoInteres.MotivoInteresID = MotivoInteresID;
                oMotivoInteres.MotivoInteresClave = "NuKey";
                oMotivoInteres.Nombre = "Niu Register X";
                oMotivoInteres.NombreCorto = "NuRegX";
                oMotivoInteres.Descripcion = "Nuevo Registro Equis";

                oMotivoInteres = Cosmos.Academico.Admision.Negocio.MotivoInteres.Guardar(oMotivoInteres, oInfoForLog);

                Assert.AreEqual(oMotivoInteres.MotivoInteresID, 10);
                Assert.AreEqual(oMotivoInteres.MotivoInteresClave, "NuKey");
                Assert.AreEqual(oMotivoInteres.Nombre, "Niu Register X");
                Assert.AreEqual(oMotivoInteres.NombreCorto, "NuRegX");
                Assert.AreEqual(oMotivoInteres.Descripcion, "Nuevo Registro Equis");
            }
        }

        [TestMethod]
        public void MotivoInteres_Eliminar()
        {
            int MotivoInteresIDEliminar = 10;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.MotivoInteres oMotivoInteres = new Cosmos.Academico.Admision.Entidades.MotivoInteres();
                oMotivoInteres.MotivoInteresID = MotivoInteresIDEliminar;

                bool AlgunError = false;
                AlgunError = Cosmos.Academico.Admision.Negocio.MotivoInteres.Eliminar(oMotivoInteres, oInfoForLog);

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

