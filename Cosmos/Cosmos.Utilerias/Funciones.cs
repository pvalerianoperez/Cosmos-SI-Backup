using Cosmos.Api.Entidades;
using System;
using System.Data;
using static N400.Framework.CastHelper;
namespace Cosmos.Utilerias
{
    public class Funciones
    {

        ///// <summary>
        ///// Recibe un datarow, revisa si contiene la columna de "Errores", evalua el resultado y si encontro errores
        ///// genera un System.Exception con el mensaje de error contenido en la columna "Mensaje" del datarow, 
        ///// en caso de que no exista la columna o venga vacia, se utiliza un mensaje genérico de error.
        ///// </summary>
        ///// <param name="dr"></param>
        //public static bool ErrorRespuestaSQL(DataRow dr)
        //{
        //    bool errores = false;
        //    string mensajeError = "";
        //    if (dr != null)
        //    {
        //        if (dr.Table.Columns["Errores"] != null)
        //        {
        //            errores = (CInt2(dr["Errores"]) != 0);
        //            if (dr.Table.Columns["Mensaje"] != null)
        //            {
        //                mensajeError = CStr2(dr["Mensaje"]).Trim();
        //            }
        //        }
        //    }
        //    if (errores)
        //    {
        //        if (mensajeError.Equals(""))
        //        {
        //            mensajeError = "Se encontró un error al procesar el comando SQL.";
        //        }
        //        throw new Exception(mensajeError);
        //    }
        //    return errores;
        //}

        ///// <summary>
        ///// Recibe una respuesta de la API, revisa si fue exitosa, evalua el resultado y si encontro errores
        ///// genera un System.Exception con el mensaje de error contenido en la propiedad "MensajeError", 
        ///// en caso de que venga vacia, se utiliza "MensajeRespuesta" y si aun asi esta vacia, entonces se mostrara un mensaje generico de error.
        ///// </summary>
        ///// <param name="dr"></param>
        //public static bool ErrorRespuestaAPI(RespuestaBase respuesta)
        //{
        //    string mensajeError = "";
        //    bool errores = false;
        //    if (respuesta != null) {
        //        errores = (!respuesta.Exitoso);
        //        if (errores) {
        //            mensajeError = CStr2(respuesta.MensajeError);
        //            if (string.IsNullOrEmpty(mensajeError)) { mensajeError = CStr2(respuesta.MensajeRespuesta); }
        //            if (string.IsNullOrEmpty(mensajeError)) { mensajeError = "No se recibió respuesta del servicio."; }
        //            throw new Exception(mensajeError);
        //        }                
        //    }
        //    return errores;            
        //}

        ///// <summary>
        ///// Busca el nombre de la columna que corresponde a la propiedad, es utilizado por las entidades para mapear 
        ///// el contenido de una consulta SQL a la propiedad del objeto
        ///// </summary>
        ///// <param name="dr"></param>
        ///// <param name="columna"></param>
        ///// <param name="tabla"></param>
        ///// <returns></returns>
        //public static String ColumnaDatosPropiedadEntidad(DataRow dr, String columna, String tabla) {
        //    String r = "";
        //    if (tabla.StartsWith("Sistema")) {
        //        tabla = tabla.Replace("Sistema", "");
        //    }
        //    if (dr != null) {
        //        if (dr.Table != null) {
        //            if (dr.Table.Columns[columna] != null)
        //            {
        //                r = columna;
        //            }
        //            else {
        //                columna = tabla + columna;
        //                if (dr.Table.Columns[columna] != null) {
        //                    r = columna;
        //                }
        //            }
        //        }
        //    }
        //    return r;
        //}
    }
}
