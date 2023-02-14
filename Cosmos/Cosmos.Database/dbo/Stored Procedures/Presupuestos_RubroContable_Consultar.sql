CREATE PROCEDURE [dbo].[Presupuestos_RubroContable_Consultar]
	@RubroContableID int
AS
	SELECT 
		RubroContableID,
		Nombre,
		NombreCorto,
		PpalCuentaContableID,
		TituloRubroID
		
	FROM RubroContable
	WHERE @RubroContableID = RubroContableID;
RETURN 0