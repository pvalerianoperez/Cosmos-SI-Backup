
Create Procedure [dbo].[Mensajeria_Chat_Mensaje_Guardar]

	 @MensajeID			int			= null
    ,@UsuarioID			int
    ,@ConversacionID	int
    ,@TipoMensajeID		int
    ,@Mensaje			text
	
	/************************************************/
	/* Campos para Log */
	,@UserIDForLog		int
	,@Descripcion		varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
	/************************************************/
As

Declare @TablaNombreIDForLog   nvarchar(100) = 'MsjChatMensaje'
Declare @Errores bit, @MensajeSistema nvarchar(300)

Begin Transaction 

Begin Try

	declare @isChangeBeLogged bit
	declare @logMessage       varchar(Max) = ''

    If Exists(Select MensajeID From MsjChatMensaje Where MensajeID = @MensajeID)
    Begin

		/****************************************************************************/
		/* Log */

		Exec	@isChangeBeLogged	=   Sistema_Log_Regla_Consultar_LogBit_U
				@UserID				=	@UserIDForLog,
				@TablaNombre		=   @TablaNombreIDForLog

		if @isChangeBeLogged = 1

		Begin

			declare 	@MensajeID_			int
			declare 	@UsuarioID_			int
			declare 	@ConversacionID_	int
			declare 	@TipoMensajeID_		int
			declare 	@Mensaje_			nvarchar(Max)

			Select 	@MensajeID_				= MensajeID,
					@UsuarioID_				= UsuarioID,
					@ConversacionID_		= ConversacionID,
					@TipoMensajeID_			= TipoMensajeID,
					@Mensaje_				= Mensaje
			From MsjChatMensaje 
			Where MensajeID = @MensajeID
		
			if @MensajeID != @MensajeID_			set @logMessage = Concat(@logMessage, 'MensajeID::',		@MensajeID_, ':',		@MensajeID, ';')
			if @UsuarioID != @UsuarioID_			set @logMessage = Concat(@logMessage, 'UsuarioID::',		@UsuarioID_, ':',		@UsuarioID, ';')
			if @ConversacionID != @ConversacionID_	set @logMessage = Concat(@logMessage, 'ConversacionID::',	@ConversacionID_, ':',	@ConversacionID, ';')
			if @TipoMensajeID != @TipoMensajeID_	set @logMessage = Concat(@logMessage, 'TipoMensajeID::',	@TipoMensajeID_, ':',	@TipoMensajeID, ';')

			/* No se puede declarar una variable tipo Text */
			/* Y no se puede comprar una variable nvarchar(Max) con Text  */ 
			--if @Mensaje != @Mensaje_				set @logMessage = Concat(@logMessage, 'Mensaje::',			@Mensaje_, ':',			@Mensaje, ';')

			 Print @logMessage
			
		End
		/* Log */
		/****************************************************************************/


        Update  MsjChatMensaje
        Set     UsuarioID = @UsuarioID,
				ConversacionID = @ConversacionID,
				TipoMensajeID = @TipoMensajeID,
				Mensaje = @Mensaje
        Where   MensajeID = @MensajeID


		/****************************************************************************/
		/* Log */
		If @isChangeBeLogged = 1 And @@RowCount > 0 And Len(@logMessage) > 0

		Begin

			Execute 	 [dbo].[Sistema_Log_Guardar] @TablaNombre		= @TablaNombreIDForLog
													,@TablaID			= @MensajeID
													,@TablaColumna1		= Null
													,@TablaColumna2		= Null
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
	
        Insert  Into MsjChatMensaje (
				UsuarioID,
				ConversacionID,
				TipoMensajeID,
				Mensaje,
				Creado
				)
        Values  (
				@UsuarioID,
				@ConversacionID,
				@TipoMensajeID,
				@Mensaje,
				SysUTCDateTime()
				)
        
        Set     @MensajeID = SCOPE_IDENTITY()


		/****************************************************************************/
		/* Log */

		Exec	@isChangeBeLogged	=   Sistema_Log_Regla_Consultar_LogBit_C
				@UserID				=	@UserIDForLog,
				@TablaNombre		=   @TablaNombreIDForLog

		If @isChangeBeLogged = 1 And @@RowCount > 0

			set @logMessage = Concat(@logMessage, 'MensajeID::', '', ':',		@MensajeID, ';')
			set @logMessage = Concat(@logMessage, 'UsuarioID::', '', ':',		@UsuarioID, ';')
			set @logMessage = Concat(@logMessage, 'ConversacionID::', '', ':',	@ConversacionID, ';')
			set @logMessage = Concat(@logMessage, 'TipoMensajeID::', '', ':',	@TipoMensajeID, ';')
			set @logMessage = Concat(@logMessage, 'Mensaje::', '', ':',			@Mensaje, ';')

			 Print @logMessage

		Begin

			Execute 	 [dbo].[Sistema_Log_Guardar] @TablaNombre		= @TablaNombreIDForLog
													,@TablaID			= @MensajeID
													,@TablaColumna1		= Null
													,@TablaColumna2		= Null
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
        @MensajeID as MensajeID