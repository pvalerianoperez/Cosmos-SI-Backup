using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cosmos.Framework;
using Cosmos.Seguridad;

namespace Cosmos.Academico.Admision.Negocio.Test
{
    [TestClass]
    public class TipoObservacion
    {
        Cosmos.Seguridad.Entidades.DataForLog oInfoForLog;

        [TestMethod]
        public void RunAllTests_For_TipoObservacion()
        {

            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {

                int rowsDeleted = Cosmos.Academico.Admision.Negocio.TipoObservacion.InitTests();

                TipoObservacion_Guardar();
                TipoObservacion_Consultar();
                TipoObservacion_Guardar_Actualizar();
                TipoObservacion_Eliminar();
                TipoObservacion_Listado();
            }
        }

        [TestMethod]
        public void TipoObservacion_Listado()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                List<Cosmos.Academico.Admision.Entidades.TipoObservacion> TipoObservacions = new List<Cosmos.Academico.Admision.Entidades.TipoObservacion>();
                TipoObservacions = Cosmos.Academico.Admision.Negocio.TipoObservacion.Listado();

                Assert.AreEqual(TipoObservacions.Count, 3);
            }
        }

        [TestMethod]
        public void TipoObservacion_Consultar()
        {
            int TipoObservacionConsultar = 4;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.TipoObservacion oTipoObservacion = new Cosmos.Academico.Admision.Entidades.TipoObservacion();
                oTipoObservacion.TipoObservacionID = TipoObservacionConsultar;

                oTipoObservacion = Cosmos.Academico.Admision.Negocio.TipoObservacion.Consultar(oTipoObservacion);

                Assert.AreEqual(oTipoObservacion.TipoObservacionID, 4);
                Assert.AreEqual(oTipoObservacion.TipoObservacionClave, "ClaveX");
                Assert.AreEqual(oTipoObservacion.Nombre, "Registro X");
                Assert.AreEqual(oTipoObservacion.NombreCorto, "RegX");
                Assert.AreEqual(oTipoObservacion.Descripcion, "Registro equis");
            }
        }

        [TestMethod]
        public void TipoObservacion_Guardar()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.TipoObservacion oTipoObservacion = new Cosmos.Academico.Admision.Entidades.TipoObservacion();
                oTipoObservacion.TipoObservacionClave = "ClaveX";
                oTipoObservacion.Nombre = "Registro X";
                oTipoObservacion.NombreCorto = "RegX";
                oTipoObservacion.Descripcion = "Registro equis";

                oTipoObservacion = Cosmos.Academico.Admision.Negocio.TipoObservacion.Guardar(oTipoObservacion, oInfoForLog);

                Assert.AreEqual(oTipoObservacion.TipoObservacionID, 4);
                Assert.AreEqual(oTipoObservacion.TipoObservacionClave, "ClaveX");
                Assert.AreEqual(oTipoObservacion.Nombre, "Registro X");
                Assert.AreEqual(oTipoObservacion.NombreCorto, "RegX");
                Assert.AreEqual(oTipoObservacion.Descripcion, "Registro equis");

            }
        }

        [TestMethod]
        public void TipoObservacion_Guardar_Actualizar()
        {
            int TipoObservacionID = 4;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.TipoObservacion oTipoObservacion = new Cosmos.Academico.Admision.Entidades.TipoObservacion();
                oTipoObservacion.TipoObservacionID = TipoObservacionID;
                oTipoObservacion.TipoObservacionClave = "NuKey";
                oTipoObservacion.Nombre = "Niu Register X";
                oTipoObservacion.NombreCorto = "NuRegX";
                oTipoObservacion.Descripcion = "Nuevo Registro Equis";

                oTipoObservacion = Cosmos.Academico.Admision.Negocio.TipoObservacion.Guardar(oTipoObservacion, oInfoForLog);

                Assert.AreEqual(oTipoObservacion.TipoObservacionID, 4);
                Assert.AreEqual(oTipoObservacion.TipoObservacionClave, "NuKey");
                Assert.AreEqual(oTipoObservacion.Nombre, "Niu Register X");
                Assert.AreEqual(oTipoObservacion.NombreCorto, "NuRegX");
                Assert.AreEqual(oTipoObservacion.Descripcion, "Nuevo Registro Equis");
            }
        }

        [TestMethod]
        public void TipoObservacion_Eliminar()
        {
            int TipoObservacionIDEliminar = 4;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.TipoObservacion oTipoObservacion = new Cosmos.Academico.Admision.Entidades.TipoObservacion();
                oTipoObservacion.TipoObservacionID = TipoObservacionIDEliminar;

                bool AlgunError = false;
                AlgunError = Cosmos.Academico.Admision.Negocio.TipoObservacion.Eliminar(oTipoObservacion, oInfoForLog);

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

