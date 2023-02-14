using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cosmos.Framework;
using Cosmos.Seguridad;

namespace Cosmos.Academico.Admision.Negocio.Test
{
    [TestClass]
    public class RazonNoViable
    {
        Cosmos.Seguridad.Entidades.DataForLog oInfoForLog;

        [TestMethod]
        public void RunAllTests_For_RazonNoViable()
        {

            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {

                int rowsDeleted = Cosmos.Academico.Admision.Negocio.RazonNoViable.InitTests();

                RazonNoViable_Guardar();
                RazonNoViable_Consultar();
                RazonNoViable_Guardar_Actualizar();
                RazonNoViable_Eliminar();
                RazonNoViable_Listado();
            }
        }

        [TestMethod]
        public void RazonNoViable_Listado()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                List<Cosmos.Academico.Admision.Entidades.RazonNoViable> RazonNoViables = new List<Cosmos.Academico.Admision.Entidades.RazonNoViable>();
                RazonNoViables = Cosmos.Academico.Admision.Negocio.RazonNoViable.Listado();

                Assert.AreEqual(RazonNoViables.Count, 3);
            }
        }

        [TestMethod]
        public void RazonNoViable_Consultar()
        {
            int RazonNoViableConsultar = 4;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.RazonNoViable oRazonNoViable = new Cosmos.Academico.Admision.Entidades.RazonNoViable();
                oRazonNoViable.RazonNoViableID = RazonNoViableConsultar;

                oRazonNoViable = Cosmos.Academico.Admision.Negocio.RazonNoViable.Consultar(oRazonNoViable);

                Assert.AreEqual(oRazonNoViable.RazonNoViableID, 4);
                Assert.AreEqual(oRazonNoViable.RazonNoViableClave, "ClaveX");
                Assert.AreEqual(oRazonNoViable.Nombre, "Registro X");
                Assert.AreEqual(oRazonNoViable.NombreCorto, "RegX");
                Assert.AreEqual(oRazonNoViable.Descripcion, "Registro equis");
            }
        }

        [TestMethod]
        public void RazonNoViable_Guardar()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.RazonNoViable oRazonNoViable = new Cosmos.Academico.Admision.Entidades.RazonNoViable();
                oRazonNoViable.RazonNoViableClave = "ClaveX";
                oRazonNoViable.Nombre = "Registro X";
                oRazonNoViable.NombreCorto = "RegX";
                oRazonNoViable.Descripcion = "Registro equis";

                oRazonNoViable = Cosmos.Academico.Admision.Negocio.RazonNoViable.Guardar(oRazonNoViable, oInfoForLog);

                Assert.AreEqual(oRazonNoViable.RazonNoViableID, 4);
                Assert.AreEqual(oRazonNoViable.RazonNoViableClave, "ClaveX");
                Assert.AreEqual(oRazonNoViable.Nombre, "Registro X");
                Assert.AreEqual(oRazonNoViable.NombreCorto, "RegX");
                Assert.AreEqual(oRazonNoViable.Descripcion, "Registro equis");

            }
        }

        [TestMethod]
        public void RazonNoViable_Guardar_Actualizar()
        {
            int RazonNoViableID = 4;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.RazonNoViable oRazonNoViable = new Cosmos.Academico.Admision.Entidades.RazonNoViable();
                oRazonNoViable.RazonNoViableID = RazonNoViableID;
                oRazonNoViable.RazonNoViableClave = "NuKey";
                oRazonNoViable.Nombre = "Niu Register X";
                oRazonNoViable.NombreCorto = "NuRegX";
                oRazonNoViable.Descripcion = "Nuevo Registro Equis";

                oRazonNoViable = Cosmos.Academico.Admision.Negocio.RazonNoViable.Guardar(oRazonNoViable, oInfoForLog);

                Assert.AreEqual(oRazonNoViable.RazonNoViableID, 4);
                Assert.AreEqual(oRazonNoViable.RazonNoViableClave, "NuKey");
                Assert.AreEqual(oRazonNoViable.Nombre, "Niu Register X");
                Assert.AreEqual(oRazonNoViable.NombreCorto, "NuRegX");
                Assert.AreEqual(oRazonNoViable.Descripcion, "Nuevo Registro Equis");
            }
        }

        [TestMethod]
        public void RazonNoViable_Eliminar()
        {
            int RazonNoViableIDEliminar = 4;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.RazonNoViable oRazonNoViable = new Cosmos.Academico.Admision.Entidades.RazonNoViable();
                oRazonNoViable.RazonNoViableID = RazonNoViableIDEliminar;

                bool AlgunError = false;
                AlgunError = Cosmos.Academico.Admision.Negocio.RazonNoViable.Eliminar(oRazonNoViable, oInfoForLog);

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

