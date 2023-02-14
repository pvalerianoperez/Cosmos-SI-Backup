using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cosmos.Framework;
using Cosmos.Seguridad;

namespace Cosmos.Academico.Negocio.Test
{
    [TestClass]
    public class Documento
    {
        Cosmos.Seguridad.Entidades.DataForLog oInfoForLog;

        [TestMethod]
        public void RunAllTests_For_Documento()
        {

            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                int rowsDeleted = Cosmos.Academico.Negocio.Documento.InitTests();

                Documento_Guardar();
                Documento_Consultar();
                Documento_Guardar_Actualizar();
                Documento_Eliminar();
                Documento_Listado();
            }
        }

        [TestMethod]
        public void Documento_Listado()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                List<Cosmos.Academico.Entidades.Documento> Documentos = new List<Cosmos.Academico.Entidades.Documento>();
                Documentos = Cosmos.Academico.Negocio.Documento.Listado();

                Assert.AreEqual(Documentos.Count, 10);
            }
        }

        [TestMethod]
        public void Documento_Consultar()
        {
            int DocumentoConsultar = 11;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Entidades.Documento oDocumento = new Cosmos.Academico.Entidades.Documento();
                oDocumento.DocumentoID = DocumentoConsultar;

                oDocumento = Cosmos.Academico.Negocio.Documento.Consultar(oDocumento);

                Assert.AreEqual(oDocumento.DocumentoID, 11);
                Assert.AreEqual(oDocumento.DocumentoClave, "ClaveX");
                Assert.AreEqual(oDocumento.Nombre, "Registro X");
                Assert.AreEqual(oDocumento.NombreCorto, "RegX");
                Assert.AreEqual(oDocumento.Descripcion, "Registro equis");
            }
        }

        [TestMethod]
        public void Documento_Guardar()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Entidades.Documento oDocumento = new Cosmos.Academico.Entidades.Documento();
                oDocumento.DocumentoClave = "ClaveX";
                oDocumento.Nombre = "Registro X";
                oDocumento.NombreCorto = "RegX";
                oDocumento.Descripcion = "Registro equis";

                oDocumento = Cosmos.Academico.Negocio.Documento.Guardar(oDocumento, oInfoForLog);

                Assert.AreEqual(oDocumento.DocumentoID, 11);
                Assert.AreEqual(oDocumento.DocumentoClave, "ClaveX" );
                Assert.AreEqual(oDocumento.Nombre, "Registro X");
                Assert.AreEqual(oDocumento.NombreCorto, "RegX");
                Assert.AreEqual(oDocumento.Descripcion, "Registro equis");

            }
        }

        [TestMethod]
        public void Documento_Guardar_Actualizar()
        {
            int DocumentoID = 11;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Entidades.Documento oDocumento = new Cosmos.Academico.Entidades.Documento();
                oDocumento.DocumentoID = DocumentoID;
                oDocumento.DocumentoClave = "NuKey";
                oDocumento.Nombre = "Niu Register X";
                oDocumento.NombreCorto = "NuRegX";
                oDocumento.Descripcion = "Nuevo Registro Equis";

                oDocumento = Cosmos.Academico.Negocio.Documento.Guardar(oDocumento, oInfoForLog);

                Assert.AreEqual(oDocumento.DocumentoID, 11);
                Assert.AreEqual(oDocumento.DocumentoClave, "NuKey");
                Assert.AreEqual(oDocumento.Nombre, "Niu Register X");
                Assert.AreEqual(oDocumento.NombreCorto, "NuRegX");
                Assert.AreEqual(oDocumento.Descripcion, "Nuevo Registro Equis");
            }
        }

        [TestMethod]
        public void Documento_Eliminar()
        {
            int DocumentoIDEliminar = 11;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Entidades.Documento oDocumento = new Cosmos.Academico.Entidades.Documento();
                oDocumento.DocumentoID = DocumentoIDEliminar;

                bool AlgunError = false;
                AlgunError = Cosmos.Academico.Negocio.Documento.Eliminar(oDocumento, oInfoForLog);

                Assert.AreEqual(false, AlgunError);
            }
        }


        public int inicializa_Configuracion(string Licencia, ref Cosmos.Seguridad.Entidades.DataForLog oInfoForLog, ref string Mensaje_Error_oConfig)
        {
            int iError_oConfig = 0;
            Mensaje_Error_oConfig = "";

            SQLHelper.ConnectionString = Properties.Settings.Default.Sistema;

            oInfoForLog = new Seguridad.Entidades.DataForLog(1,"","","");
            oInfoForLog.UsuarioIDForLog = 1;
            oInfoForLog.IpAddressForLog = "148.202.1.1";
            oInfoForLog.HostNameForLog = "XPS13";
            oInfoForLog.DescripcionForLog = "Cosmos.Academico.Negocio.Test";

            return iError_oConfig;
        }

    }
}
