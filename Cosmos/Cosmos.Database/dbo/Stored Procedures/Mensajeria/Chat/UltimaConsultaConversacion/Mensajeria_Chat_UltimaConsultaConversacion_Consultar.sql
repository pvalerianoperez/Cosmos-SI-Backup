
Create Procedure [dbo].[Mensajeria_Chat_UltimaConsultaConversacion_Consultar]

	@UsuarioID		int,
	@ConversacionID int
	
	/************************************************/
	/* Campos para Log */
	,@UserIDForLog		int				= 1
	,@Descripcion		varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
	/************************************************/

As

	declare @Ultima_Consulta		datetime
	declare @Ultima_Consulta_Update datetime

	/* Consultamos la últifa fecha en la cual se consulto. */
	set @Ultima_Consulta = (
			Select	UltimaConsulta 
			From	MsjChatUltimaConsultaConversacion
			Where	UsuarioID      = @UsuarioID And
					ConversacionID = @ConversacionID
			)

	/* Si no habia sido consultada, entonces crea una por default y la graba. */
	if @Ultima_Consulta is null
		Begin
			Set @Ultima_Consulta_Update = CAST('2020-01-01' AS datetime)
			Set @Ultima_Consulta = @Ultima_Consulta_Update
		End
	Else
		Begin
			Set @Ultima_Consulta_Update = GetUTCDate()
		End

	Exec Mensajeria_Chat_UltimaConsultaConversacion_Guardar
			@UsuarioID			= @UsuarioID
			,@ConversacionID	= @ConversacionID
			,@UltimaConsulta	= @Ultima_Consulta_Update
			,@UserIDForLog		= @UserIDForLog
			,@Descripcion		= @Descripcion
			,@IpAddress			= @IpAddress
			,@HostName			= @HostName

	Select @Ultima_Consulta

Return 0

