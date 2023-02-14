
Create Procedure [dbo].[Sistema_Log_Regla_Consultar]

@SistemaLogReglaID int

As

	Select  * 
	From    SistemaLogRegla
	Where   SistemaLogReglaID = @SistemaLogReglaID

Return 0