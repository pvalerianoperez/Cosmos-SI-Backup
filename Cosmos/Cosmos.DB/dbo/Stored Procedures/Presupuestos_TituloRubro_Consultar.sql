CREATE PROCEDURE [dbo].[Presupuestos_TituloRubro_Consultar]
	@TituloRubroID INT
AS
	SELECT 
        TituloRubroID,
	    TituloRubroClave,
        Nombre,
        NombreCorto,
        CalculoRemanente,
        NaturalezaID,
        EmpresaID,
        CfgEjercicioOperativoID,
        Ingreso_o_Egreso
	FROM TituloRubro
	WHERE TituloRubroID = @TituloRubroID;
RETURN 0