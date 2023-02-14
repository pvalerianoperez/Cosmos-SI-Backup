using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cosmos.Framework;
using Cosmos.Seguridad;

namespace Cosmos.Academico.Admision.Negocio.Test
{
    [TestClass]
    public class Vinculo
    {
        Cosmos.Seguridad.Entidades.DataForLog oInfoForLog;

        [TestMethod]
        public void RunAllTests_For_Vinculo()
        {

            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {

                int rowsDeleted = Cosmos.Academico.Admision.Negocio.Vinculo.InitTests();

                Vinculo_Guardar();
                Vinculo_Consultar();
                Vinculo_Guardar_Actualizar();
                Vinculo_Eliminar();
                Vinculo_Listado();
            }
        }

        [TestMethod]
        public void Vinculo_Listado()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                List<Cosmos.Academico.Admision.Entidades.Vinculo> Vinculos = new List<Cosmos.Academico.Admision.Entidades.Vinculo>();
                Vinculos = Cosmos.Academico.Admision.Negocio.Vinculo.Listado();

                Assert.AreEqual(Vinculos.Count, 3);
            }
        }

        [TestMethod]
        public void Vinculo_Consultar()
        {
            int VinculoConsultar = 4;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.Vinculo oVinculo = new Cosmos.Academico.Admision.Entidades.Vinculo();
                oVinculo.VinculoID = VinculoConsultar;

                oVinculo = Cosmos.Academico.Admision.Negocio.Vinculo.Consultar(oVinculo);

                Assert.AreEqual(oVinculo.VinculoID, 4);
                Assert.AreEqual(oVinculo.VinculoClave, "ClaveX");
                Assert.AreEqual(oVinculo.Nombre, "Registro X");
                Assert.AreEqual(oVinculo.NombreCorto, "RegX");
                Assert.AreEqual(oVinculo.Descripcion, "Registro equis");
            }
        }

        [TestMethod]
        public void Vinculo_Guardar()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.Vinculo oVinculo = new Cosmos.Academico.Admision.Entidades.Vinculo();
                oVinculo.VinculoClave = "ClaveX";
                oVinculo.Nombre = "Registro X";
                oVinculo.NombreCorto = "RegX";
                oVinculo.Descripcion = "Registro equis";

                oVinculo = Cosmos.Academico.Admision.Negocio.Vinculo.Guardar(oVinculo, oInfoForLog);

                Assert.AreEqual(oVinculo.VinculoID, 4);
                Assert.AreEqual(oVinculo.VinculoClave, "ClaveX");
                Assert.AreEqual(oVinculo.Nombre, "Registro X");
                Assert.AreEqual(oVinculo.NombreCorto, "RegX");
                Assert.AreEqual(oVinculo.Descripcion, "Registro equis");

            }
        }

        [TestMethod]
        public void Vinculo_Guardar_Actualizar()
        {
            int VinculoID = 4;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.Vinculo oVinculo = new Cosmos.Academico.Admision.Entidades.Vinculo();
                oVinculo.VinculoID = VinculoID;
                oVinculo.VinculoClave = "NuKey";
                oVinculo.Nombre = "Niu Register X";
                oVinculo.NombreCorto = "NuRegX";
                oVinculo.Descripcion = "Nuevo Registro Equis";

                oVinculo = Cosmos.Academico.Admision.Negocio.Vinculo.Guardar(oVinculo, oInfoForLog);

                Assert.AreEqual(oVinculo.VinculoID, 4);
                Assert.AreEqual(oVinculo.VinculoClave, "NuKey");
                Assert.AreEqual(oVinculo.Nombre, "Niu Register X");
                Assert.AreEqual(oVinculo.NombreCorto, "NuRegX");
                Assert.AreEqual(oVinculo.Descripcion, "Nuevo Registro Equis");
            }
        }

        [TestMethod]
        public void Vinculo_Eliminar()
        {
            int VinculoIDEliminar = 4;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.Vinculo oVinculo = new Cosmos.Academico.Admision.Entidades.Vinculo();
                oVinculo.VinculoID = VinculoIDEliminar;

                bool AlgunError = false;
                AlgunError = Cosmos.Academico.Admision.Negocio.Vinculo.Eliminar(oVinculo, oInfoForLog);

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
