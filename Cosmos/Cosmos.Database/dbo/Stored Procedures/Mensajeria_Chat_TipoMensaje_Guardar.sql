
Create Procedure [dbo].[Mensajeria_Chat_TipoMensaje_Guardar]

	--[TipoMensajeID] INT NOT NULL PRIMARY KEY IDENTITY, 
 --   [TipoNombre] CHAR(50) NOT NULL

	 @TipoMensajeID		int				= null
	,@TipoNombre		char(50)
	
	/************************************************/
	/* Campos para Log */
	,@UserIDForLog		int
	,@Descripcion		varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
	/************************************************/
As

Declare @TablaNombreIDForLog   nvarchar(100) = 'MsjChatTipoMensaje'
Declare @Errores bit, @MensajeSistema nvarchar(300)

Begin Transaction 

Begin Try

	declare @isChangeBeLogged bit
	declare @logMessage       varchar(Max) = ''

    If Exists(Select TipoMensajeID From MsjChatTipoMensaje Where TipoMensajeID = @TipoMensajeID)
    Begin

		/****************************************************************************/
		/* Log */

		Exec	@isChangeBeLogged	=   Sistema_Log_Regla_Consultar_LogBit_U
				@UserID				=	@UserIDForLog,
				@TablaNombre		=   @TablaNombreIDForLog

		if @isChangeBeLogged = 1

		Begin

			declare 	@TipoMensajeID_ int
			declare 	@TipoNombre_ int

			Select 	@TipoMensajeID_		= TipoMensajeID,
					@TipoNombre_		= TipoNombre
			From MsjChatTipoMensaje 
			Where TipoMensajeID = @TipoMensajeID
		
			if @TipoMensajeID != @TipoMensajeID_ set @logMessage = Concat(@logMessage, 'TipoMensajeID::', @TipoMensajeID_, ':', @TipoMensajeID, ';')
			if @TipoNombre != @TipoNombre_ set @logMessage = Concat(@logMessage, 'TipoNombre::', @TipoNombre_, ':', @TipoNombre, ';')

			 Print @logMessage
			
		End
		/* Log */
		/****************************************************************************/


        Update  MsjChatTipoMensaje
        Set     TipoNombre = @TipoNombre
        Where   TipoMensajeID = @TipoMensajeID


		/****************************************************************************/
		/* Log */
		If @isChangeBeLogged = 1 And @@RowCount > 0 And Len(@logMessage) > 0

		Begin

			Execute 	 [dbo].[Sistema_Log_Guardar] @TablaNombre		= @TablaNombreIDForLog
													,@TablaID			= @TipoMensajeID
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
	
        Insert  Into MsjChatTipoMensaje (
				TipoNombre
				)
        Values  (
				@TipoNombre
				)
        
        Set     @TipoMensajeID = SCOPE_IDENTITY()


		/****************************************************************************/
		/* Log */

		Exec	@isChangeBeLogged	=   Sistema_Log_Regla_Consultar_LogBit_C
				@UserID				=	@UserIDForLog,
				@TablaNombre		=   @TablaNombreIDForLog

		If @isChangeBeLogged = 1 And @@RowCount > 0

			set @logMessage = Concat(@logMessage, 'TipoMensajeID::', '', ':', @TipoMensajeID, ';')
			set @logMessage = Concat(@logMessage, 'TipoNombre::', '', ':', @TipoNombre, ';')

			 Print @logMessage

		Begin

			Execute 	 [dbo].[Sistema_Log_Guardar] @TablaNombre		= @TablaNombreIDForLog
													,@TablaID			= @TipoMensajeID
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
        @TipoMensajeID as TipoMensajeID