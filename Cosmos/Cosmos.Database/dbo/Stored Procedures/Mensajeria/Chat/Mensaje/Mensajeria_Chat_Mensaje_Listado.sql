
Create Procedure [dbo].[Mensajeria_Chat_Mensaje_Listado]

	@ConRegistrosBorrados bit = 0

As

	If (@ConRegistrosBorrados = 0)
		Begin
	
			Select	 [MensajeID]
					,[UsuarioID]
					,[ConversacionID]
					,[TipoMensajeID]
					,[Mensaje]
					,[Creado]
					,[Borrado]
			From   MsjChatMensaje
			Where  MsjChatMensaje.Borrado is null

		End
	Else
		Begin

			Select	 [MensajeID]
					,[UsuarioID]
					,[ConversacionID]
					,[TipoMensajeID]
					,[Mensaje]
					,[Creado]
					,[Borrado]
			From   MsjChatMensaje

		End

return 0