using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cosmos.Website.Recursos.Reportes
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack) {
                String reporte = string.Format("Cosmos.Website.Sistema.{0}", Request.QueryString["Reporte"]);
                reporte = "Cosmos.Website.Sistema.Compras.Reportes.ReporteEjemplo";
                //TipoCliente o = new Sistema.Compras.Reportes.TipoCliente();
                DevExpress.XtraReports.UI.XtraReport oReporte = null;
                try
                {
                    oReporte = (DevExpress.XtraReports.UI.XtraReport)MagicallyCreateInstance(reporte);
                    //oReporte.DataSource = Compras.Api.Client.TipoCliente.Listado();
                }
                catch (Exception ex) {
                    oReporte = null;
                }
                if (oReporte != null) {
                    //oReporte.FillDataSource();
                    this.ASPxWebDocumentViewer1.OpenReport(oReporte);

                }
                
            }

        }

        private static object MagicallyCreateInstance(string className)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var type = assembly.GetTypes()
                .First(t => t.FullName == className);

            return Activator.CreateInstance(type);
        }
    }
}