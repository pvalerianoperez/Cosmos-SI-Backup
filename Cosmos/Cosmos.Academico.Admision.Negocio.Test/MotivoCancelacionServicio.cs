using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cosmos.Framework;
using Cosmos.Seguridad;

namespace Cosmos.Academico.Admision.Negocio.Test
{
    [TestClass]
    public class MotivoCancelacionServicio
    {
        Cosmos.Seguridad.Entidades.DataForLog oInfoForLog;

        [TestMethod]
        public void RunAllTests_For_MotivoCancelacionServicio()
        {

            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {

                int rowsDeleted = Cosmos.Academico.Admision.Negocio.MotivoCancelacionServicio.InitTests();

                MotivoCancelacionServicio_Guardar();
                MotivoCancelacionServicio_Consultar();
                MotivoCancelacionServicio_Guardar_Actualizar();
                MotivoCancelacionServicio_Eliminar();
                MotivoCancelacionServicio_Listado();
            }
        }

        [TestMethod]
        public void MotivoCancelacionServicio_Listado()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                List<Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio> MotivoCancelacionServicios = new List<Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio>();
                MotivoCancelacionServicios = Cosmos.Academico.Admision.Negocio.MotivoCancelacionServicio.Listado();

                Assert.AreEqual(MotivoCancelacionServicios.Count, 3);
            }
        }

        [TestMethod]
        public void MotivoCancelacionServicio_Consultar()
        {
            int MotivoCancelacionServicioConsultar = 4;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio oMotivoCancelacionServicio = new Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio();
                oMotivoCancelacionServicio.MotivoCancelacionServicioID = MotivoCancelacionServicioConsultar;

                oMotivoCancelacionServicio = Cosmos.Academico.Admision.Negocio.MotivoCancelacionServicio.Consultar(oMotivoCancelacionServicio);

                Assert.AreEqual(oMotivoCancelacionServicio.MotivoCancelacionServicioID, 4);
                Assert.AreEqual(oMotivoCancelacionServicio.MotivoCancelacionServicioClave, "ClaveX");
                Assert.AreEqual(oMotivoCancelacionServicio.Nombre, "Registro X");
                Assert.AreEqual(oMotivoCancelacionServicio.NombreCorto, "RegX");
                Assert.AreEqual(oMotivoCancelacionServicio.Descripcion, "Registro equis");
            }
        }

        [TestMethod]
        public void MotivoCancelacionServicio_Guardar()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio oMotivoCancelacionServicio = new Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio();
                oMotivoCancelacionServicio.MotivoCancelacionServicioClave = "ClaveX";
                oMotivoCancelacionServicio.Nombre = "Registro X";
                oMotivoCancelacionServicio.NombreCorto = "RegX";
                oMotivoCancelacionServicio.Descripcion = "Registro equis";

                oMotivoCancelacionServicio = Cosmos.Academico.Admision.Negocio.MotivoCancelacionServicio.Guardar(oMotivoCancelacionServicio, oInfoForLog);

                Assert.AreEqual(oMotivoCancelacionServicio.MotivoCancelacionServicioID, 4);
                Assert.AreEqual(oMotivoCancelacionServicio.MotivoCancelacionServicioClave, "ClaveX");
                Assert.AreEqual(oMotivoCancelacionServicio.Nombre, "Registro X");
                Assert.AreEqual(oMotivoCancelacionServicio.NombreCorto, "RegX");
                Assert.AreEqual(oMotivoCancelacionServicio.Descripcion, "Registro equis");

            }
        }

        [TestMethod]
        public void MotivoCancelacionServicio_Guardar_Actualizar()
        {
            int MotivoCancelacionServicioID = 4;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio oMotivoCancelacionServicio = new Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio();
                oMotivoCancelacionServicio.MotivoCancelacionServicioID = MotivoCancelacionServicioID;
                oMotivoCancelacionServicio.MotivoCancelacionServicioClave = "NuKey";
                oMotivoCancelacionServicio.Nombre = "Niu Register X";
                oMotivoCancelacionServicio.NombreCorto = "NuRegX";
                oMotivoCancelacionServicio.Descripcion = "Nuevo Registro Equis";

                oMotivoCancelacionServicio = Cosmos.Academico.Admision.Negocio.MotivoCancelacionServicio.Guardar(oMotivoCancelacionServicio, oInfoForLog);

                Assert.AreEqual(oMotivoCancelacionServicio.MotivoCancelacionServicioID, 4);
                Assert.AreEqual(oMotivoCancelacionServicio.MotivoCancelacionServicioClave, "NuKey");
                Assert.AreEqual(oMotivoCancelacionServicio.Nombre, "Niu Register X");
                Assert.AreEqual(oMotivoCancelacionServicio.NombreCorto, "NuRegX");
                Assert.AreEqual(oMotivoCancelacionServicio.Descripcion, "Nuevo Registro Equis");
            }
        }

        [TestMethod]
        public void MotivoCancelacionServicio_Eliminar()
        {
            int MotivoCancelacionServicioIDEliminar = 4;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio oMotivoCancelacionServicio = new Cosmos.Academico.Admision.Entidades.MotivoCancelacionServicio();
                oMotivoCancelacionServicio.MotivoCancelacionServicioID = MotivoCancelacionServicioIDEliminar;

                bool AlgunError = false;
                AlgunError = Cosmos.Academico.Admision.Negocio.MotivoCancelacionServicio.Eliminar(oMotivoCancelacionServicio, oInfoForLog);

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

