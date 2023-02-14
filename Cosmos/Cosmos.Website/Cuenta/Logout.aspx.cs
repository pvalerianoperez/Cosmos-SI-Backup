using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cosmos.Website.Cuenta
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            string motivoLogout = Recursos.Utilerias.AppGlobals.MotivoLogout;
            Session.Abandon();
            if (motivoLogout == "")
            {
                Response.Redirect("~/Cuenta/Login.aspx");
            }
            else {
                ASPxLabel1.Text = motivoLogout;
            }                     
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}