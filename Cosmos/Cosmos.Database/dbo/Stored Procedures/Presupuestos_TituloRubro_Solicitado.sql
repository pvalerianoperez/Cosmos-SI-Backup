CREATE PROCEDURE [dbo].[Presupuestos_TituloRubro_Solicitado]
    @EmpresaID INT,
    @IngOEgr VARCHAR = NULL,
    @EjercicioOperativoID INT = NULL,
    @PpalCentroCostosID INT = NULL
AS
	SELECT 
        TituloRubro.TituloRubroID,
	    TituloRubroClave,
        TituloRubro.Nombre,
        TituloRubro.NombreCorto,
        CalculoRemanente,
        NaturalezaID,
        EmpresaID,
        CfgEjercicioOperativoID,
        Ingreso_o_Egreso
	FROM TituloRubro
	JOIN RubroContable on (RubroContable.TituloRubroID = TituloRubro.TituloRubroID)
    WHERE (@IngOEgr IS NULL OR @IngOEgr = Ingreso_o_Egreso) 
	AND (@PpalCentroCostosID IS NULL OR  (@IngOEgr <> 'E' OR EXISTS(
		SELECT * FROM PptoEncEgr as encE
		JOIN PptoDetEgr as detE on (detE.PptoEncEgrID = encE.PptoEncEgrID)
		WHERE PpalCentroCostoID = @PpalCentroCostosID 
		AND DetE.RubroContableID = RubroContable.RubroContableID)
	))
	AND (@PpalCentroCostosID IS NULL OR (@IngOEgr <> 'I' OR EXISTS(
		SELECT * FROM PptoEncIng as encI
		JOIN PptoDetIng as detI on (detI.PptoEncIngID = encI.PptoEncIngID)
		WHERE PpalCentroCostoID = @PpalCentroCostosID
		AND DetI.RubroContableID = RubroContable.RubroContableID)
	))
    AND (@EjercicioOperativoID IS NULL OR @EjercicioOperativoID = TituloRubro.CfgEjercicioOperativoID)
    AND EmpresaID = @EmpresaID
	GROUP BY TituloRubro.TituloRubroID,
	    TituloRubroClave,
        TituloRubro.Nombre,
        TituloRubro.NombreCorto,
        CalculoRemanente,
        NaturalezaID,
        EmpresaID,
        TituloRubro.CfgEjercicioOperativoID,
        Ingreso_o_Egreso;
RETURN 0