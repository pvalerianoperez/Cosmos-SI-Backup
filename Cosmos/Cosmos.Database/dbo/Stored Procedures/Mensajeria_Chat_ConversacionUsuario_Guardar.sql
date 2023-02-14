
Create Procedure [dbo].[Mensajeria_Chat_ConversacionUsuario_Guardar]

	 @UsuarioID				int
	,@ConversacionID		int
	,@PermisoConversacionID	int
	
	/************************************************/
	/* Campos para Log */
	,@UserIDForLog		int
	,@Descripcion		varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
	/************************************************/
As

Declare @TablaNombreIDForLog   nvarchar(100) = 'MsjChatConversacionUsuario'
Declare @Errores bit, @MensajeSistema nvarchar(300)

Begin Transaction 

Begin Try

	declare @isChangeBeLogged bit
	declare @logMessage       varchar(Max) = ''

    If Exists(Select UsuarioID From MsjChatConversacionUsuario Where UsuarioID = @UsuarioID And ConversacionID = @ConversacionID)
    Begin

		/****************************************************************************/
		/* Log */

		Exec	@isChangeBeLogged	=   Sistema_Log_Regla_Consultar_LogBit_U
				@UserID				=	@UserIDForLog,
				@TablaNombre		=   @TablaNombreIDForLog

		if @isChangeBeLogged = 1

		Begin

			declare 	@UsuarioID_				int
			declare 	@ConversacionID_		int
			declare 	@PermisoConversacionID_ int

			Select 	@PermisoConversacionID_		= PermisoConversacionID
			From	MsjChatConversacionUsuario 
			Where	UsuarioID = @UsuarioID And 
					ConversacionID = @ConversacionID
		
			if @PermisoConversacionID != @PermisoConversacionID_ set @logMessage = Concat(@logMessage, 'PermisoConversacionID::', @PermisoConversacionID_, ':', @PermisoConversacionID, ';')

			 Print @logMessage
			
		End
		/* Log */
		/****************************************************************************/


        Update  MsjChatConversacionUsuario
        Set     PermisoConversacionID = @PermisoConversacionID
        Where   UsuarioID = @UsuarioID And ConversacionID = @ConversacionID


		/****************************************************************************/
		/* Log */
		If @isChangeBeLogged = 1 And @@RowCount > 0 And Len(@logMessage) > 0

		Begin

			Execute 	 [dbo].[Sistema_Log_Guardar] @TablaNombre		= @TablaNombreIDForLog
													,@TablaID			= Null
													,@TablaColumna1		= @UsuarioID
													,@TablaColumna2		= @ConversacionID
													,@Operacion			= 'Update'
													,@UserID			= @UserIDForLog
													,@Descripcion		= @Descripcion
													,@Cambios			= @logMessage
													,@IpAddress			= @IpAddress
													,@HostName			= @HostName
		End
		/****************************************************************************/

    End
    Else
    Begin     
	
        Insert  Into MsjChatConversacionUsuario (
				 UsuarioID
				,ConversacionID
				,PermisoConversacionID
				)
        Values  (
				 @UsuarioID
				,@ConversacionID
				,@PermisoConversacionID
				)
        
        Set     @UsuarioID = SCOPE_IDENTITY()


		/****************************************************************************/
		/* Log */

		Exec	@isChangeBeLogged	=   Sistema_Log_Regla_Consultar_LogBit_C
				@UserID				=	@UserIDForLog,
				@TablaNombre		=   @TablaNombreIDForLog

		If @isChangeBeLogged = 1 And @@RowCount > 0

			set @logMessage = Concat(@logMessage, 'UsuarioID::', '', ':', @UsuarioID, ';')
			set @logMessage = Concat(@logMessage, 'ConversacionID::', '', ':', @ConversacionID, ';')
			set @logMessage = Concat(@logMessage, 'PermisoConversacionID::', '', ':', @PermisoConversacionID, ';')

			 Print @logMessage

		Begin

			Execute 	 [dbo].[Sistema_Log_Guardar] @TablaNombre		= @TablaNombreIDForLog
													,@TablaID			= Null
													,@TablaColumna1		= @UsuarioID
													,@TablaColumna2		= @ConversacionID
													,@Operacion			= 'Insert'
													,@UserID			= @UserIDForLog
													,@Descripcion		= @Descripcion
													,@Cambios			= @logMessage
													,@IpAddress			= @IpAddress
													,@HostName			= @HostName
		End
		/****************************************************************************/

    End
    Commit Transaction
End Try
Begin Catch
    RollBack Transaction
    Select @Errores = 1, @MensajeSistema = ERROR_MESSAGE()
End Catch 

Select  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@MensajeSistema, '') as Mensaje,
        @UsuarioID as UsuarioID