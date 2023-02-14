
CREATE PROCEDURE [dbo].[Sistema_Log_Listado_TablaNombre]

	@TablaNombre varchar(100),
	@FechaInicial Datetime2 = null,
	@FechaFinal Datetime2 = GetUTCDate

As

	If @FechaInicial is not null

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
			Where [TablaNombre] = @TablaNombre And 
			      [FechaHoraCambioUTC] Between @FechaInicial And @FechaFinal

		End

	Else

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
			Where [TablaNombre] = @TablaNombre

		End



Return 0