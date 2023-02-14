CREATE PROCEDURE [dbo].[Presupuestos_PptoDetEgr_Consultar]
	@PptoDetEgrID INT = NULL
AS
	SELECT [PptoDetEgrID]
      ,[PptoEncEgrID]
      ,[ConceptoEgresoID]
      ,[PpalCuentaContableID]
      ,[RubroContableID]
  FROM [dbo].[PptoDetEgr]
  WHERE [PptoDetEgrID] = @PptoDetEgrID;
RETURN 0