using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cosmos.Framework;

namespace Cosmos.Website.Recursos.Utilerias
{
    public class AppGlobals
    {
        public static string ApiURL {
            get {
                return Properties.Settings.Default.ApiURL;
            }
        }
        public static int UsuarioID { get { return CastHelper.CInt2(HttpContext.Current.Session["UsuarioID"]); } set { HttpContext.Current.Session["UsuarioID"] = value; } }
        public static int EmpresaID { get { return CastHelper.CInt2(HttpContext.Current.Session["EmpresaID"]); } set { HttpContext.Current.Session["EmpresaID"] = value; } }
        public static int ModuloID { get { return CastHelper.CInt2(HttpContext.Current.Session["ModuloID"]); } set { HttpContext.Current.Session["ModuloID"] = value; } }
        public static string MotivoLogout { get { return CastHelper.CStr2(HttpContext.Current.Session["MotivoLogout"]).Trim(); } set { HttpContext.Current.Session["MotivoLogout"] = value; } }
        public static string SesionID { get; set; }
    }
}