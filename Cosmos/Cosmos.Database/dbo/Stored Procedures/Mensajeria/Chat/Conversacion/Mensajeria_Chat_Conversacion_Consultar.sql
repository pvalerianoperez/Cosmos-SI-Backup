
Create Procedure [dbo].[Mensajeria_Chat_Conversacion_Consultar]

	@ConversacionID int

As

	Select * 
	From MsjChatConversacion
	Where ConversacionID = @ConversacionID

Return 0
