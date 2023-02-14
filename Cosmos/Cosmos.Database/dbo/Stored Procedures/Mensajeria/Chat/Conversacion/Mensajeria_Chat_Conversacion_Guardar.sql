
CREATE Procedure [dbo].[Mensajeria_Chat_Conversacion_Guardar]

	 @ConversacionID		int				= null
	,@Nombre				int
	
	/************************************************/
	/* Campos para Log */
	,@UserIDForLog		int
	,@Descripcion		varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
	/************************************************/

As

Declare @TablaNombreIDForLog   nvarchar(100) = 'MsjChatConversacion'
Declare @Errores bit, @MensajeSistema nvarchar(300)

Begin Transaction 

Begin Try

	declare @isChangeBeLogged bit
	declare @logMessage       varchar(Max) = ''

    If Exists(Select ConversacionID From MsjChatConversacion Where ConversacionID = @ConversacionID)
    Begin

		/****************************************************************************/
		/* Log */

		Exec	@isChangeBeLogged	=   Sistema_Log_Regla_Consultar_LogBit_U
				@UsuarioID				=	@UserIDForLog,
				@TablaNombre		=   @TablaNombreIDForLog

		if @isChangeBeLogged = 1

		Begin

			declare 	@ConversacionID_ int
			declare 	@Nombre_ int

			Select 	@ConversacionID_ = ConversacionID,
					@Nombre_ = Nombre
			From MsjChatConversacion 
			Where ConversacionID = @ConversacionID
		
			if @ConversacionID != @ConversacionID_ set @logMessage = Concat(@logMessage, 'ConversacionID::', @ConversacionID_, ':', @ConversacionID, ';')
			if @Nombre != @Nombre_ set @logMessage = Concat(@logMessage, 'Nombre::', @Nombre_, ':', @Nombre, ';')

			 Print @logMessage
			
		End
		/* Log */
		/****************************************************************************/


        Update  MsjChatConversacion
        Set     Nombre = @Nombre
        Where   ConversacionID = @ConversacionID


		/****************************************************************************/
		/* Log */
		If @isChangeBeLogged = 1 And @@RowCount > 0 And Len(@logMessage) > 0

		Begin

			Execute 	 [dbo].[Sistema_Log_Guardar] @TablaNombre		= @TablaNombreIDForLog
													,@TablaID			= @ConversacionID
													,@TablaColumna1		= Null
													,@TablaColumna2		= Null
													,@Operacion			= 'Update'
													,@UsuarioID			= @UserIDForLog
													,@Descripcion		= @Descripcion
													,@Cambios			= @logMessage
													,@IpAddress			= @IpAddress
													,@HostName			= @HostName
		End
		/****************************************************************************/

    End
    Else
    Begin     
	
        Insert  Into MsjChatConversacion(
				Nombre
				)
        Values  (
				@Nombre
				)
        
        Set     @ConversacionID = SCOPE_IDENTITY()


		/****************************************************************************/
		/* Log */

		Exec	@isChangeBeLogged	=   Sistema_Log_Regla_Consultar_LogBit_C
				@UsuarioID				=	@UserIDForLog,
				@TablaNombre		=   @TablaNombreIDForLog

		If @isChangeBeLogged = 1 And @@RowCount > 0

			set @logMessage = Concat(@logMessage, 'ConversacionID::', '', ':', @ConversacionID, ';')
			set @logMessage = Concat(@logMessage, 'Nombre::', '', ':', @Nombre, ';')

			 Print @logMessage

		Begin

			Execute 	 [dbo].[Sistema_Log_Guardar] @TablaNombre		= @TablaNombreIDForLog
													,@TablaID			= @ConversacionID
													,@TablaColumna1		= Null
													,@TablaColumna2		= Null
													,@Operacion			= 'Insert'
													,@UsuarioID			= @UserIDForLog
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
        @ConversacionID as ConversacionID