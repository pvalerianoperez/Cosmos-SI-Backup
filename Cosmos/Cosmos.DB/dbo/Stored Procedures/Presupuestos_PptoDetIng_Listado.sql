CREATE PROCEDURE [dbo].[Presupuestos_PptoDetIng_Listado]
	@RubroContableID INT = NULL
AS
	SELECT 
		PptoDetIngID
      ,PptoEncIngID
      ,PpalConceptoIngresoID
      ,PpalCuentaContableID
      ,RubroContableID
  FROM PptoDetIng
  WHERE @RubroContableID IS NULL OR RubroContableID = @RubroContableID;
RETURN 0