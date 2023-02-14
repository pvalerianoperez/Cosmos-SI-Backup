


CREATE PROCEDURE [dbo].[Presupuestos_RubroContable_Listado]
	@TituloRubroID int = null
AS
	SELECT 
		RubroContableID,
		Nombre,
		NombreCorto,
		PpalCuentaContableID,
		TituloRubroID
		
	FROM RubroContable
	WHERE @TituloRubroID IS NULL OR @TituloRubroID = TituloRubroID;
RETURN 0