CREATE PROCEDURE [dbo].[Compras_Requisicion_ListadoFiltros]
@EmpresaID int, 
@SucursalID int, 
@FechaInicial smalldatetime,
@FechaFinal smalldatetime,
@EstatusDocumento nvarchar(max)
AS

SET NOCOUNT ON 

SELECT	a.*, d.PpalSerieClave as Serie, e.Nombre as EstatusDocumento, c.Nombre as Area, 
		(SELECT COUNT(b.CmpRequisicionEncabezadoID) FROM CmpRequisicionDetalle b WHERE b.CmpRequisicionEncabezadoID = a.CmpRequisicionEncabezadoID) as Movimientos
FROM	CmpRequisicionEncabezado a 			
			INNER JOIN PpalSerie d ON a.PpalSerieID = d.PpalSerieID
			LEFT OUTER JOIN CfgEstatusDocumento e ON a.CfgEstatusDocumentoID = e.CfgEstatusDocumentoID
			LEFT OUTER JOIN PpalArea c ON a.PpalAreaID = c.PpalAreaID
ORDER	BY a.Fecha DESC

SET NOCOUNT OFF