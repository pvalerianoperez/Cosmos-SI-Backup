
Create Procedure [dbo].[Mensajeria_Chat_Mensaje_Consulta_Mensajes_xConversacion]
	
	 @UsuarioID				int
	,@ConversacionID		int
	,@Consulta_sin_Fecha	bit = 0
	
	/************************************************/
	/* Campos para Log */
	,@UserIDForLog		int				= 1
	,@Descripcion		varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
	/************************************************/

As
	/*
		Si llega el parámetro de consulta sin fecha en 1, voy a consultar con una
		fecha default 2020-01-01
	*/
	Declare @Fecha_Ultima_Consulta as datetime

	If @Consulta_sin_Fecha = 1
		Begin
			Set @Fecha_Ultima_Consulta = '2020-01-01'
		End
	Else
		Begin
			Exec @Fecha_Ultima_Consulta = Mensajeria_Chat_UltimaConsultaConversacion_Consultar
				  @UsuarioID			= @UsuarioID
				 ,@ConversacionID		= @ConversacionID
				 ,@UserIDForLog			= @UserIDForLog
				 ,@Descripcion			= @Descripcion
				 ,@IpAddress			= @IpAddress
				 ,@HostName				= @HostName
		End

	Select  *
	From    MsjChatMensaje
	Where   (ConversacionID = @ConversacionID) And 
			(Borrado Is Null) And
			(Creado >= @Fecha_Ultima_Consulta)