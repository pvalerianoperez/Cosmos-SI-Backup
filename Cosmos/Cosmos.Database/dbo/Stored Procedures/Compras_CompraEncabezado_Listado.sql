﻿

CREATE PROCEDURE Compras_CompraEncabezado_Listado
AS

SELECT  CompraEncabezadoID,SucursalID,TipoDocumentoID,SerieID,Folio,ProveedorID,TipoMovimientoProveedorID,PersonalID,Fecha,Referencia,Concepto,EstatusDocumentoID,PreAutorizada,UsuarioIDPreAutoriza,FechaPreAutoriza,Autorizada,UsuarioIDAutoriza,FechaAutoriza
FROM    CompraEncabezado