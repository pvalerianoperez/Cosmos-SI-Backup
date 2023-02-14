using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cosmos.Framework;
using Cosmos.Seguridad;

namespace Cosmos.Academico.Admision.Negocio.Test
{
    [TestClass]
    public class MotivoBaja
    {
        Cosmos.Seguridad.Entidades.DataForLog oInfoForLog;

        [TestMethod]
        public void RunAllTests_For_MotivoBaja()
        {

            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {

                int rowsDeleted = Cosmos.Academico.Admision.Negocio.MotivoBaja.InitTests();

                MotivoBaja_Guardar();
                MotivoBaja_Consultar();
                MotivoBaja_Guardar_Actualizar();
                MotivoBaja_Eliminar();
                MotivoBaja_Listado();
            }
        }

        [TestMethod]
        public void MotivoBaja_Listado()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                List<Cosmos.Academico.Admision.Entidades.MotivoBaja> MotivoBajas = new List<Cosmos.Academico.Admision.Entidades.MotivoBaja>();
                MotivoBajas = Cosmos.Academico.Admision.Negocio.MotivoBaja.Listado();

                Assert.AreEqual(MotivoBajas.Count, 3);
            }
        }

        [TestMethod]
        public void MotivoBaja_Consultar()
        {
            int MotivoBajaConsultar = 4;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.MotivoBaja oMotivoBaja = new Cosmos.Academico.Admision.Entidades.MotivoBaja();
                oMotivoBaja.MotivoBajaID = MotivoBajaConsultar;

                oMotivoBaja = Cosmos.Academico.Admision.Negocio.MotivoBaja.Consultar(oMotivoBaja);

                Assert.AreEqual(oMotivoBaja.MotivoBajaID, 4);
                Assert.AreEqual(oMotivoBaja.MotivoBajaClave, "ClaveX");
                Assert.AreEqual(oMotivoBaja.Nombre, "Registro X");
                Assert.AreEqual(oMotivoBaja.NombreCorto, "RegX");
                Assert.AreEqual(oMotivoBaja.Descripcion, "Registro equis");
            }
        }

        [TestMethod]
        public void MotivoBaja_Guardar()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.MotivoBaja oMotivoBaja = new Cosmos.Academico.Admision.Entidades.MotivoBaja();
                oMotivoBaja.MotivoBajaClave = "ClaveX";
                oMotivoBaja.Nombre = "Registro X";
                oMotivoBaja.NombreCorto = "RegX";
                oMotivoBaja.Descripcion = "Registro equis";

                oMotivoBaja = Cosmos.Academico.Admision.Negocio.MotivoBaja.Guardar(oMotivoBaja, oInfoForLog);

                Assert.AreEqual(oMotivoBaja.MotivoBajaID, 4);
                Assert.AreEqual(oMotivoBaja.MotivoBajaClave, "ClaveX");
                Assert.AreEqual(oMotivoBaja.Nombre, "Registro X");
                Assert.AreEqual(oMotivoBaja.NombreCorto, "RegX");
                Assert.AreEqual(oMotivoBaja.Descripcion, "Registro equis");

            }
        }

        [TestMethod]
        public void MotivoBaja_Guardar_Actualizar()
        {
            int MotivoBajaID = 4;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.MotivoBaja oMotivoBaja = new Cosmos.Academico.Admision.Entidades.MotivoBaja();
                oMotivoBaja.MotivoBajaID = MotivoBajaID;
                oMotivoBaja.MotivoBajaClave = "NuKey";
                oMotivoBaja.Nombre = "Niu Register X";
                oMotivoBaja.NombreCorto = "NuRegX";
                oMotivoBaja.Descripcion = "Nuevo Registro Equis";

                oMotivoBaja = Cosmos.Academico.Admision.Negocio.MotivoBaja.Guardar(oMotivoBaja, oInfoForLog);

                Assert.AreEqual(oMotivoBaja.MotivoBajaID, 4);
                Assert.AreEqual(oMotivoBaja.MotivoBajaClave, "NuKey");
                Assert.AreEqual(oMotivoBaja.Nombre, "Niu Register X");
                Assert.AreEqual(oMotivoBaja.NombreCorto, "NuRegX");
                Assert.AreEqual(oMotivoBaja.Descripcion, "Nuevo Registro Equis");
            }
        }

        [TestMethod]
        public void MotivoBaja_Eliminar()
        {
            int MotivoBajaIDEliminar = 4;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.MotivoBaja oMotivoBaja = new Cosmos.Academico.Admision.Entidades.MotivoBaja();
                oMotivoBaja.MotivoBajaID = MotivoBajaIDEliminar;

                bool AlgunError = false;
                AlgunError = Cosmos.Academico.Admision.Negocio.MotivoBaja.Eliminar(oMotivoBaja, oInfoForLog);

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

