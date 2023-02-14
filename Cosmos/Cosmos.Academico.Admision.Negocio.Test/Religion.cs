using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cosmos.Framework;
using Cosmos.Seguridad;

namespace Cosmos.Academico.Admision.Negocio.Test
{
    [TestClass]
    public class Religion
    {
        Cosmos.Seguridad.Entidades.DataForLog oInfoForLog;

        [TestMethod]
        public void RunAllTests_For_Religion()
        {

            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {

                int rowsDeleted = Cosmos.Academico.Admision.Negocio.Religion.InitTests();

                Religion_Guardar();
                Religion_Consultar();
                Religion_Guardar_Actualizar();
                Religion_Eliminar();
                Religion_Listado();
            }
        }

        [TestMethod]
        public void Religion_Listado()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                List<Cosmos.Academico.Admision.Entidades.Religion> Religions = new List<Cosmos.Academico.Admision.Entidades.Religion>();
                Religions = Cosmos.Academico.Admision.Negocio.Religion.Listado();

                Assert.AreEqual(Religions.Count, 6);
            }
        }

        [TestMethod]
        public void Religion_Consultar()
        {
            int ReligionConsultar = 7;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.Religion oReligion = new Cosmos.Academico.Admision.Entidades.Religion();
                oReligion.ReligionID = ReligionConsultar;

                oReligion = Cosmos.Academico.Admision.Negocio.Religion.Consultar(oReligion);

                Assert.AreEqual(oReligion.ReligionID, 7);
                Assert.AreEqual(oReligion.ReligionClave, "ClaveX");
                Assert.AreEqual(oReligion.Nombre, "Registro X");
                Assert.AreEqual(oReligion.NombreCorto, "RegX");
                Assert.AreEqual(oReligion.Descripcion, "Registro equis");
            }
        }

        [TestMethod]
        public void Religion_Guardar()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.Religion oReligion = new Cosmos.Academico.Admision.Entidades.Religion();
                oReligion.ReligionClave = "ClaveX";
                oReligion.Nombre = "Registro X";
                oReligion.NombreCorto = "RegX";
                oReligion.Descripcion = "Registro equis";

                oReligion = Cosmos.Academico.Admision.Negocio.Religion.Guardar(oReligion, oInfoForLog);

                Assert.AreEqual(oReligion.ReligionID, 7);
                Assert.AreEqual(oReligion.ReligionClave, "ClaveX");
                Assert.AreEqual(oReligion.Nombre, "Registro X");
                Assert.AreEqual(oReligion.NombreCorto, "RegX");
                Assert.AreEqual(oReligion.Descripcion, "Registro equis");

            }
        }

        [TestMethod]
        public void Religion_Guardar_Actualizar()
        {
            int ReligionID = 7;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.Religion oReligion = new Cosmos.Academico.Admision.Entidades.Religion();
                oReligion.ReligionID = ReligionID;
                oReligion.ReligionClave = "NuKey";
                oReligion.Nombre = "Niu Register X";
                oReligion.NombreCorto = "NuRegX";
                oReligion.Descripcion = "Nuevo Registro Equis";

                oReligion = Cosmos.Academico.Admision.Negocio.Religion.Guardar(oReligion, oInfoForLog);

                Assert.AreEqual(oReligion.ReligionID, 7);
                Assert.AreEqual(oReligion.ReligionClave, "NuKey");
                Assert.AreEqual(oReligion.Nombre, "Niu Register X");
                Assert.AreEqual(oReligion.NombreCorto, "NuRegX");
                Assert.AreEqual(oReligion.Descripcion, "Nuevo Registro Equis");
            }
        }

        [TestMethod]
        public void Religion_Eliminar()
        {
            int ReligionIDEliminar = 7;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.Religion oReligion = new Cosmos.Academico.Admision.Entidades.Religion();
                oReligion.ReligionID = ReligionIDEliminar;

                bool AlgunError = false;
                AlgunError = Cosmos.Academico.Admision.Negocio.Religion.Eliminar(oReligion, oInfoForLog);

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
