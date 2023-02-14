
Create Procedure [dbo].[Mensajeria_Comunica_Mensaje_ConsultarPorRemitente]

	 @MensajeID				int
	,@RemitenteID			int
	,@FechaBorrado			datetime

As

	declare @FechaBorrado_	datetime	= @FechaBorrado

	if @FechaBorrado_ != null
	begin
		Select * 
		From MsjComunicaMensaje
		Where MensajeID = @MensajeID And RemitenteID = @RemitenteID
	end

Return 0
