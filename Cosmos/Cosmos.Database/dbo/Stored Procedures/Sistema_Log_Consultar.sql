
Create Procedure [dbo].[Sistema_Log_Consultar]

	@SistemaLogID Int

As

Begin

		Select 	
				[SistemaLogID]
			,[TablaNombre]
			,[TablaID]
			,[TablaColumna1]
			,[TablaColumna2]
			,[Operacion]
			,[UserID]
			,[Descripcion]
			,[Cambios]
			,[IpAddress]
			,[HostName]
			,[FechaHoraCambioUTC] 
		From [SistemaLog]
		Where [SistemaLogID] = @SistemaLogID

	End



Return 0