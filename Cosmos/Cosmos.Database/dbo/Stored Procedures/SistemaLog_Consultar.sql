
CREATE Procedure [dbo].[SistemaLog_Consultar]

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
			,[UsuarioID]
			,[Descripcion]
			,[Cambios]
			,[IpAddress]
			,[HostName]
			,[FechaHoraCambioUTC] 
		From [SistemaLog]
		Where [SistemaLogID] = @SistemaLogID

	End



Return 0