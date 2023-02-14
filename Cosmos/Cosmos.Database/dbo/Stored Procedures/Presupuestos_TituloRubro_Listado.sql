CREATE PROCEDURE [dbo].[Presupuestos_TituloRubro_Listado]
    @EmpresaID INT,
    @IngOEgr VARCHAR = NULL,
    @EjercicioOperativoID INT = NULL,
    @CentroCostosID INT = NULL
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
    WHERE (@EjercicioOperativoID IS NULL OR @EjercicioOperativoID = CfgEjercicioOperativoID)
    AND Ingreso_o_Egreso = @IngOEgr
    AND EmpresaID = @EmpresaID;
RETURN 0