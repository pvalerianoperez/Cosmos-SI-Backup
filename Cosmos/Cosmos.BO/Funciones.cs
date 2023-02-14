using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static N400.Framework.CastHelper;
namespace Cosmos.BO
{
    class Funciones
    {
        /// <summary>
        /// Recibe un datarow, revisa si contiene la columna de "Errores", evalua el resultado y si encontro errores
        /// genera un System.Exception con el mensaje de error contenido en la columna "Mensaje" del datarow, 
        /// en caso de que no exista la columna o venga vacia, se utiliza un mensaje genérico de error.
        /// </summary>
        /// <param name="dr"></param>
        public static bool ErrorRespuestaSQL(DataRow dr) {
            bool errores = false;
            string mensajeError = "";
            if (dr != null) {
                if (dr.Table.Columns["Errores"] != null) {
                    errores = (CInt2(dr["Errores"]) != 0);
                    if (dr.Table.Columns["Mensaje"] != null) {
                        mensajeError = CStr2(dr["Mensaje"]).Trim();
                    }                    
                }
            }
            if (errores) {
                if (mensajeError.Equals("")) {
                    mensajeError = "Se encontró un error al procesar el comando SQL.";
                }
                throw new Exception(mensajeError);
            }
            return errores;
        }
    }
}
