CREATE PROCEDURE [dbo].[Presupuestos_PptoAdiEncEgr_GetByFilters]
	@EmpresaID int,
	@PeriodoOperativoID int,
	@PpalCentroCostoID int,
	@IngresoOEgreso varchar(1)
AS
	SELECT AdiEncEgr.PptoAdiEncEgrID,
		   AdiEncEgr.PptoEncEgrID,
		   AdiEncEgr.FechaHora, 
		   AdiEncEgr.Comentarios, 
		   AdiEncEgr.EstatusDocumentoID
	FROM RubroContable as Rubro
	JOIN TituloRubro as Titulo on (Rubro.TituloRubroID = Titulo.TituloRubroID)
	JOIN PptoDetEgr as Detalle on (Rubro.RubroContableID = Detalle.RubroContableID)
	JOIN PptoEncEgr as Encabezado on (Encabezado.PptoEncEgrID = Detalle.PptoEncEgrID)
	JOIN PptoAdiEncEgr as AdiEncEgr on (AdiEncEgr.PptoEncEgrID = Detalle.PptoEncEgrID)
	WHERE Titulo.CfgEjercicioOperativoID = @PeriodoOperativoID 
	AND Encabezado.PpalCentroCostoID = @PpalCentroCostoID 
	AND Titulo.EmpresaID = @EmpresaID
	AND Titulo.Ingreso_o_Egreso = @IngresoOEgreso;
RETURN 0