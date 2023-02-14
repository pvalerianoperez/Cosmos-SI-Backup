using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cosmos.Framework;
using Cosmos.Seguridad;

namespace Cosmos.Academico.Admision.Negocio.Test
{
    [TestClass]
    public class Parentesco
    {
        Cosmos.Seguridad.Entidades.DataForLog oInfoForLog;

        [TestMethod]
        public void RunAllTests_For_Parentesco()
        {

            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {

                int rowsDeleted = Cosmos.Academico.Admision.Negocio.Parentesco.InitTests();

                Parentesco_Guardar();
                Parentesco_Consultar();
                Parentesco_Guardar_Actualizar();
                Parentesco_Eliminar();
                Parentesco_Listado();
            }
        }

        [TestMethod]
        public void Parentesco_Listado()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                List<Cosmos.Academico.Admision.Entidades.Parentesco> Parentescos = new List<Cosmos.Academico.Admision.Entidades.Parentesco>();
                Parentescos = Cosmos.Academico.Admision.Negocio.Parentesco.Listado();

                Assert.AreEqual(Parentescos.Count, 6);
            }
        }

        [TestMethod]
        public void Parentesco_Consultar()
        {
            int ParentescoConsultar = 7;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.Parentesco oParentesco = new Cosmos.Academico.Admision.Entidades.Parentesco();
                oParentesco.ParentescoID = ParentescoConsultar;

                oParentesco = Cosmos.Academico.Admision.Negocio.Parentesco.Consultar(oParentesco);

                Assert.AreEqual(oParentesco.ParentescoID, 7);
                Assert.AreEqual(oParentesco.ParentescoClave, "ClaveX");
                Assert.AreEqual(oParentesco.Nombre, "Registro X");
                Assert.AreEqual(oParentesco.NombreCorto, "RegX");
                Assert.AreEqual(oParentesco.Descripcion, "Registro equis");
            }
        }

        [TestMethod]
        public void Parentesco_Guardar()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.Parentesco oParentesco = new Cosmos.Academico.Admision.Entidades.Parentesco();
                oParentesco.ParentescoClave = "ClaveX";
                oParentesco.Nombre = "Registro X";
                oParentesco.NombreCorto = "RegX";
                oParentesco.Descripcion = "Registro equis";

                oParentesco = Cosmos.Academico.Admision.Negocio.Parentesco.Guardar(oParentesco, oInfoForLog);

                Assert.AreEqual(oParentesco.ParentescoID, 7);
                Assert.AreEqual(oParentesco.ParentescoClave, "ClaveX");
                Assert.AreEqual(oParentesco.Nombre, "Registro X");
                Assert.AreEqual(oParentesco.NombreCorto, "RegX");
                Assert.AreEqual(oParentesco.Descripcion, "Registro equis");

            }
        }

        [TestMethod]
        public void Parentesco_Guardar_Actualizar()
        {
            int ParentescoID = 7;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.Parentesco oParentesco = new Cosmos.Academico.Admision.Entidades.Parentesco();
                oParentesco.ParentescoID = ParentescoID;
                oParentesco.ParentescoClave = "NuKey";
                oParentesco.Nombre = "Niu Register X";
                oParentesco.NombreCorto = "NuRegX";
                oParentesco.Descripcion = "Nuevo Registro Equis";

                oParentesco = Cosmos.Academico.Admision.Negocio.Parentesco.Guardar(oParentesco, oInfoForLog);

                Assert.AreEqual(oParentesco.ParentescoID, 7);
                Assert.AreEqual(oParentesco.ParentescoClave, "NuKey");
                Assert.AreEqual(oParentesco.Nombre, "Niu Register X");
                Assert.AreEqual(oParentesco.NombreCorto, "NuRegX");
                Assert.AreEqual(oParentesco.Descripcion, "Nuevo Registro Equis");
            }
        }

        [TestMethod]
        public void Parentesco_Eliminar()
        {
            int ParentescoIDEliminar = 7;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.Parentesco oParentesco = new Cosmos.Academico.Admision.Entidades.Parentesco();
                oParentesco.ParentescoID = ParentescoIDEliminar;

                bool AlgunError = false;
                AlgunError = Cosmos.Academico.Admision.Negocio.Parentesco.Eliminar(oParentesco, oInfoForLog);

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
