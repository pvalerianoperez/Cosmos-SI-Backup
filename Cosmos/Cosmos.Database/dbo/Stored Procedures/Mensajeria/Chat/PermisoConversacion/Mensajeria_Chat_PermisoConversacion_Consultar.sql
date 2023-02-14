
Create Procedure [dbo].[Mensajeria_Chat_PermisoConversacion_Consultar]

	@PermisoConversacionID		int

As

	Select	* 
	From	MsjChatPermisoConversacion
	Where	PermisoConversacionID = @PermisoConversacionID

Return 0

