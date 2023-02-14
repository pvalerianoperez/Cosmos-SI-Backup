
Create Procedure [dbo].[Mensajeria_Chat_Mensaje_Consultar]

	@MensajeID int

As

	Select * 
	From MsjChatMensaje
	Where MensajeID = @MensajeID

Return 0