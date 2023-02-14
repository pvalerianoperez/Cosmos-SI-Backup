
Create Procedure [dbo].[Mensajeria_Chat_ConversacionUsuario_Consultar]

	 @UsuarioID			int
	,@ConversacionID	int

As

	Select	[PermisoConversacionID]
	From	MsjChatConversacionUsuario
	Where	MsjChatConversacionUsuario.UsuarioID      = @UsuarioID And
			MsjChatConversacionUsuario.ConversacionID = @ConversacionID

Return 0