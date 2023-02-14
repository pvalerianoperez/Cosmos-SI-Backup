CREATE PROCEDURE [dbo].[Presupuestos_PptoAdiEncIng_GetByFilters]
	@EmpresaID int,
	@PeriodoOperativoID int,
	@PpalCentroCostoID int,
	@IngresoOEgreso varchar(1)
AS
	SELECT AdiEncIng.PptoAdiEncIngID,
		   AdiEncIng.PptoEncIngID,
		   AdiEncIng.FechaHora, 
		   AdiEncIng.Comentarios, 
		   AdiEncIng.EstatusDocumentoID
	FROM RubroContable as Rubro
	JOIN TituloRubro as Titulo on (Rubro.TituloRubroID = Titulo.TituloRubroID)
	JOIN PptoDetIng as Detalle on (Rubro.RubroContableID = Detalle.RubroContableID)
	JOIN PptoEncIng as Encabezado on (Encabezado.PptoEncIngID = Detalle.PptoEncIngID)
	JOIN PptoAdiEncIng as AdiEncIng on (AdiEncIng.PptoEncIngID = Detalle.PptoEncIngID)
	WHERE Titulo.CfgEjercicioOperativoID = @PeriodoOperativoID 
	AND Encabezado.PpalCentroCostoID = @PpalCentroCostoID 
	AND Titulo.EmpresaID = @EmpresaID
	AND Titulo.Ingreso_o_Egreso = @IngresoOEgreso;
RETURN 0