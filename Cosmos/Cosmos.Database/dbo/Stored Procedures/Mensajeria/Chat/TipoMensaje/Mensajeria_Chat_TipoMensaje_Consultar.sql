
Create Procedure [dbo].[Mensajeria_Chat_TipoMensaje_Consultar]

	@TipoMensajeID		int

As

	Select	* 
	From	MsjChatTipoMensaje
	Where	TipoMensajeID = @TipoMensajeID

Return 0

