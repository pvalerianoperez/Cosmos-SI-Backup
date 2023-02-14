CREATE PROCEDURE [dbo].[Presupuestos_PptoDetIng_Consultar]
	@PptoDetIngID INT
AS
	SELECT [PptoDetIngID]
      ,[PptoEncIngID]
      ,[PpalConceptoIngresoID]
      ,[PpalCuentaContableID]
      ,[RubroContableID]
  FROM [dbo].[PptoDetIng]
  WHERE [PptoDetIngID] = @PptoDetIngID;
RETURN 0