
using System;
using System.Data;
using System.Collections.Generic;


namespace Cosmos.Compras.Entidades
{
    public class ProveedorSucursal : Sucursal
    {        
        public int ProveedorSucursalID { get; set; }            
        public int ProveedorID { get; set; }            
        public string ProveedorClave { get; set; }

        public int Estatus { get; set; }

        public new void Load(DataRow dr){
            if(dr!=null)            
            {
                String nombreColumna;
                //llenalo con la informacion de la base de datos
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SucursalID", "Sucursal");
                if (!nombreColumna.Equals("")) { this.SucursalID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "SucursalClave", "Sucursal");
                if (!nombreColumna.Equals("")) { this.SucursalClave = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Nombre", "Sucursal");
                if (!nombreColumna.Equals("")) { this.Nombre = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "NombreCorto", "Sucursal");
                if (!nombreColumna.Equals("")) { this.NombreCorto = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "EmpresaID", "Sucursal");
                if (!nombreColumna.Equals("")) { this.EmpresaID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "DomicilioID", "Sucursal");
                if (!nombreColumna.Equals("")) { this.DomicilioID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AltaUsuarioID", "Sucursal");
                if (!nombreColumna.Equals("")) { this.AltaUsuarioID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "AltaFecha", "Sucursal");
                if (!nombreColumna.Equals("")) { this.AltaFecha = Cosmos.Framework.CastHelper.CDate2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ModificacionUsuarioID", "Sucursal");
                if (!nombreColumna.Equals("")) { this.ModificacionUsuarioID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ModificacionFecha", "Sucursal");
                if (!nombreColumna.Equals("")) { this.ModificacionFecha = Cosmos.Framework.CastHelper.CDate2(dr[nombreColumna]); }

                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ProveedorSucursalID", "ProveedorSucursal");
                if (!nombreColumna.Equals("")) { this.ProveedorSucursalID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ProveeedorClave", "ProveedorSucursal");
                if (!nombreColumna.Equals("")) { this.ProveedorClave = Cosmos.Framework.CastHelper.CStr2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "ProveedorID", "ProveedorSucursal");
                if (!nombreColumna.Equals("")) { this.ProveedorID = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
                nombreColumna = Cosmos.Framework.EntidadesHelper.ColumnaDatosPropiedadEntidad(dr, "Estatus", "ProveedorSucursal");
                if (!nombreColumna.Equals("")) { this.Estatus = Cosmos.Framework.CastHelper.CInt2(dr[nombreColumna]); }
            }
        }
    }
}
