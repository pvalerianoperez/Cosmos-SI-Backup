using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cosmos.Framework;
using Cosmos.Seguridad;

namespace Cosmos.Academico.Admision.Negocio.Test
{
    [TestClass]
    public class Zona
    {
        Cosmos.Seguridad.Entidades.DataForLog oInfoForLog;

        [TestMethod]
        public void RunAllTests_For_Zona()
        {

            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                
                int rowsDeleted = Cosmos.Academico.Admision.Negocio.Zona.InitTests();

                Zona_Guardar();
                Zona_Consultar();
                Zona_Guardar_Actualizar();
                Zona_Eliminar();
                Zona_Listado();
            }
        }

        [TestMethod]
        public void Zona_Listado()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                List<Cosmos.Academico.Admision.Entidades.Zona> Zonas = new List<Cosmos.Academico.Admision.Entidades.Zona>();
                Zonas = Cosmos.Academico.Admision.Negocio.Zona.Listado();

                Assert.AreEqual(Zonas.Count, 3);
            }
        }

        [TestMethod]
        public void Zona_Consultar()
        {
            int ZonaConsultar = 4;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.Zona oZona = new Cosmos.Academico.Admision.Entidades.Zona();
                oZona.ZonaID = ZonaConsultar;

                oZona = Cosmos.Academico.Admision.Negocio.Zona.Consultar(oZona);

                Assert.AreEqual(oZona.ZonaID, 4);
                Assert.AreEqual(oZona.ZonaClave, "ClaveX");
                Assert.AreEqual(oZona.Nombre, "Registro X");
                Assert.AreEqual(oZona.NombreCorto, "RegX");
                Assert.AreEqual(oZona.Descripcion, "Registro equis");
            }
        }

        [TestMethod]
        public void Zona_Guardar()
        {
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.Zona oZona = new Cosmos.Academico.Admision.Entidades.Zona();
                oZona.ZonaClave = "ClaveX";
                oZona.Nombre = "Registro X";
                oZona.NombreCorto = "RegX";
                oZona.Descripcion = "Registro equis";

                oZona = Cosmos.Academico.Admision.Negocio.Zona.Guardar(oZona, oInfoForLog);

                Assert.AreEqual(oZona.ZonaID, 4);
                Assert.AreEqual(oZona.ZonaClave, "ClaveX" );
                Assert.AreEqual(oZona.Nombre, "Registro X");
                Assert.AreEqual(oZona.NombreCorto, "RegX");
                Assert.AreEqual(oZona.Descripcion, "Registro equis");

            }
        }

        [TestMethod]
        public void Zona_Guardar_Actualizar()
        {
            int ZonaID = 4;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.Zona oZona = new Cosmos.Academico.Admision.Entidades.Zona();
                oZona.ZonaID = ZonaID;
                oZona.ZonaClave = "NuKey";
                oZona.Nombre = "Niu Register X";
                oZona.NombreCorto = "NuRegX";
                oZona.Descripcion = "Nuevo Registro Equis";

                oZona = Cosmos.Academico.Admision.Negocio.Zona.Guardar(oZona, oInfoForLog);

                Assert.AreEqual(oZona.ZonaID, 4);
                Assert.AreEqual(oZona.ZonaClave, "NuKey");
                Assert.AreEqual(oZona.Nombre, "Niu Register X");
                Assert.AreEqual(oZona.NombreCorto, "NuRegX");
                Assert.AreEqual(oZona.Descripcion, "Nuevo Registro Equis");
            }
        }

        [TestMethod]
        public void Zona_Eliminar()
        {
            int ZonaIDEliminar = 4;
            string Mensaje_Error = "";

            inicializa_Configuracion("", ref oInfoForLog, ref Mensaje_Error);
            if (Mensaje_Error.Length > 0)
            {
                Mensaje_Error = Mensaje_Error + "";
            }
            else
            {
                Cosmos.Academico.Admision.Entidades.Zona oZona = new Cosmos.Academico.Admision.Entidades.Zona();
                oZona.ZonaID = ZonaIDEliminar;

                bool AlgunError = false;
                AlgunError = Cosmos.Academico.Admision.Negocio.Zona.Eliminar(oZona, oInfoForLog);

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
            oInfoForLog.DescripcionForLog = "Cosmos.Academico.Admision.Negocio.Test";

            return iError_oConfig;
        }

    }
}
