
Create Procedure [dbo].[Mensajeria_Chat_Conversacion_Listado]

	@ConRegistrosBorrados bit = 0

As

	If (@ConRegistrosBorrados = 0)
		Begin
	
			Select	 *
			From   MsjChatConversacion
			Where  MsjChatConversacion.Borrada is null

		End
	Else
		Begin

			Select	 *
			From   MsjChatConversacion

		End

return 0