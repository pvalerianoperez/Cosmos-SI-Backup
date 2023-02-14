using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cosmos.Framework;
using Cosmos.Seguridad;

namespace Cosmos.Academico.Negocio.Test
{
    [TestClass]
    public class TipoDocumento
    {
        Cosmos.Seguridad.Entidades.DataForLog oInfoForLog;

        [TestMethod]
        public void RunAllTests_For_TipoDocumento()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                int rowsDeleted = Cosmos.Academico.Negocio.TipoDocumento.InitTests();

                TipoDocumento_Guardar();
                TipoDocumento_Consultar();
                TipoDocumento_Guardar_Actualizar();
                TipoDocumento_Eliminar();
                TipoDocumento_Listado();

            }
        }

        [TestMethod]
        public void TipoDocumento_Listado()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                List<Cosmos.Academico.Entidades.TipoDocumento> TipoDocumentos = new List<Cosmos.Academico.Entidades.TipoDocumento>();
                TipoDocumentos = Cosmos.Academico.Negocio.TipoDocumento.Listado();

                Assert.AreEqual(TipoDocumentos.Count, 2);
            }
        }

        [TestMethod]
        public void TipoDocumento_Consultar()
        {
            int TipoDocumentoConsultar = 3;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Entidades.TipoDocumento oTipoDocumento = new Cosmos.Academico.Entidades.TipoDocumento();
                oTipoDocumento.TipoDocumentoID = TipoDocumentoConsultar;

                oTipoDocumento = Cosmos.Academico.Negocio.TipoDocumento.Consultar(oTipoDocumento);

                Assert.AreEqual(oTipoDocumento.TipoDocumentoID, 3);
                Assert.AreEqual(oTipoDocumento.TipoDocumentoClave, "ClaveX");
                Assert.AreEqual(oTipoDocumento.Nombre, "Registro X");
                Assert.AreEqual(oTipoDocumento.NombreCorto, "RegX");
                Assert.AreEqual(oTipoDocumento.Descripcion, "Registro equis");
            }
        }

        [TestMethod]
        public void TipoDocumento_Guardar()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Entidades.TipoDocumento oTipoDocumento = new Cosmos.Academico.Entidades.TipoDocumento();
                oTipoDocumento.TipoDocumentoClave = "ClaveX";
                oTipoDocumento.Nombre = "Registro X";
                oTipoDocumento.NombreCorto = "RegX";
                oTipoDocumento.Descripcion = "Registro equis";

                oTipoDocumento = Cosmos.Academico.Negocio.TipoDocumento.Guardar(oTipoDocumento, oInfoForLog);

                Assert.AreEqual(oTipoDocumento.TipoDocumentoID, 3);
                Assert.AreEqual(oTipoDocumento.TipoDocumentoClave, "ClaveX");
                Assert.AreEqual(oTipoDocumento.Nombre, "Registro X");
                Assert.AreEqual(oTipoDocumento.NombreCorto, "RegX");
                Assert.AreEqual(oTipoDocumento.Descripcion, "Registro equis");
            }
        }

        [TestMethod]
        public void TipoDocumento_Guardar_Actualizar()
        {
            int TipoDocumentoID = 3;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Entidades.TipoDocumento oTipoDocumento = new Cosmos.Academico.Entidades.TipoDocumento();
                oTipoDocumento.TipoDocumentoID = TipoDocumentoID;
                oTipoDocumento.TipoDocumentoClave = "NuKey";
                oTipoDocumento.Nombre = "Niu Register X";
                oTipoDocumento.NombreCorto = "NuRegX";
                oTipoDocumento.Descripcion = "Nuevo Registro Equis";

                oTipoDocumento = Cosmos.Academico.Negocio.TipoDocumento.Guardar(oTipoDocumento, oInfoForLog);

                Assert.AreEqual(oTipoDocumento.TipoDocumentoID, 3);
                Assert.AreEqual(oTipoDocumento.TipoDocumentoClave, "NuKey");
                Assert.AreEqual(oTipoDocumento.Nombre, "Niu Register X");
                Assert.AreEqual(oTipoDocumento.NombreCorto, "NuRegX");
                Assert.AreEqual(oTipoDocumento.Descripcion, "Nuevo Registro Equis");
            }
        }

        [TestMethod]
        public void TipoDocumento_Eliminar()
        {
            int TipoDocumentoIDEliminar = 3;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Entidades.TipoDocumento oTipoDocumento = new Cosmos.Academico.Entidades.TipoDocumento();
                oTipoDocumento.TipoDocumentoID = TipoDocumentoIDEliminar;

                bool AlgunError = false;
                AlgunError = Cosmos.Academico.Negocio.TipoDocumento.Eliminar(oTipoDocumento, oInfoForLog);

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
            oInfoForLog.DescripcionForLog = "Cosmos.Academico.Negocio.Test";

            return iError_oConfig;
        }

    }
}
