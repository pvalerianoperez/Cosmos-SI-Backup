using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cosmos.Website.Sistema
{
    public partial class KeepAlive : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                Session["UltimaActualizacionSesion"] = DateTime.Now;
                Response.Write(Session["UltimaActualizacionSesion"]);
            }
        }
    }
}