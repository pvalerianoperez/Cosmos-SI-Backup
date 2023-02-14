CREATE PROCEDURE [dbo].[Presupuestos_PptoDetEgr_Listado]
	@RubroContableID INT = NULL
AS
	SELECT [PptoDetEgrID]
      ,[PptoEncEgrID]
      ,[ConceptoEgresoID]
      ,[PpalCuentaContableID]
      ,[RubroContableID]
  FROM [dbo].[PptoDetEgr]
  WHERE @RubroContableID IS NULL OR [RubroContableID] = @RubroContableID;
RETURN 0