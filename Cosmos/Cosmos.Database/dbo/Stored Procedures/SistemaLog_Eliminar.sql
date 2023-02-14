
CREATE Procedure [dbo].[SistemaLog_Eliminar]

	@TablaNombre varchar(100) = null,
	@FechaInicial Datetime2   = null,
	@FechaFinal Datetime2     = GetUTCDate	
	
As

	If @TablaNombre is not null
		Begin
			If @FechaInicial is not null
				Begin
					Delete From [SistemaLog]
					Where [TablaNombre] = @TablaNombre And 
						  [FechaHoraCambioUTC] Between @FechaInicial And @FechaFinal
				End
			Else
				Begin
					Delete From [SistemaLog]
					Where [TablaNombre] = @TablaNombre
				End
		End
	Else
		Begin
			If @FechaInicial is not null
				Begin
					Delete From [SistemaLog]
					Where [FechaHoraCambioUTC] Between @FechaInicial And @FechaFinal
				End
			Else
				Begin
					Delete From [SistemaLog]
				End
		End

Return 0