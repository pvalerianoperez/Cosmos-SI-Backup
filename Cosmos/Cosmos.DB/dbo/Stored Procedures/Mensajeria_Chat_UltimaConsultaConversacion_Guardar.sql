﻿
CREATE Procedure [dbo].[Mensajeria_Chat_UltimaConsultaConversacion_Guardar]

	 @UsuarioID				int
	,@ConversacionID		int
	,@UltimaConsulta		datetime = SysUtcDateTime
	
	/************************************************/
	/* Campos para Log */
	,@UserIDForLog		int
	,@Descripcion		varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
	/************************************************/
As

Declare @TablaNombreIDForLog   nvarchar(100) = 'MsjChatUltimaConsultaConversacion'
Declare @Errores bit, @MensajeSistema nvarchar(300)

Begin Transaction 

Begin Try

	declare @isChangeBeLogged bit
	declare @logMessage       varchar(Max) = ''

    If Exists(Select UsuarioID From MsjChatUltimaConsultaConversacion Where UsuarioID = @UsuarioID And ConversacionID = @ConversacionID)
    Begin

		/****************************************************************************/
		/* Log */

		Exec	@isChangeBeLogged	=   Sistema_Log_Regla_Consultar_LogBit_U
				@UsuarioID				=	@UserIDForLog,
				@TablaNombre		=   @TablaNombreIDForLog

		if @isChangeBeLogged = 1

		Begin

			declare 	@UsuarioID_ int
			declare 	@ConversacionID_ int
			declare 	@UltimaConsulta_ datetime

			Select 	@UltimaConsulta_		= UltimaConsulta
			From	MsjChatUltimaConsultaConversacion 
			Where	UsuarioID = @UsuarioID And 
					ConversacionID = @ConversacionID
		
			if @UltimaConsulta != @UltimaConsulta_ set @logMessage = Concat(@logMessage, 'UltimaConsulta::', @UltimaConsulta_, ':', @UltimaConsulta, ';')

			 Print @logMessage
			
		End
		/* Log */
		/****************************************************************************/


        Update  MsjChatUltimaConsultaConversacion
        Set     UltimaConsulta = @UltimaConsulta
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
	
        Insert  Into MsjChatUltimaConsultaConversacion (
				 UsuarioID
				,ConversacionID
				,UltimaConsulta
				)
        Values  (
				 @UsuarioID
				,@ConversacionID
				,@UltimaConsulta
				)
        
        Set     @UsuarioID = SCOPE_IDENTITY()


		/****************************************************************************/
		/* Log */

		Exec	@isChangeBeLogged	=   Sistema_Log_Regla_Consultar_LogBit_C
				@UsuarioID				=	@UserIDForLog,
				@TablaNombre		=   @TablaNombreIDForLog

		If @isChangeBeLogged = 1 And @@RowCount > 0

			set @logMessage = Concat(@logMessage, 'UsuarioID::', '', ':', @UsuarioID, ';')
			set @logMessage = Concat(@logMessage, 'ConversacionID::', '', ':', @ConversacionID, ';')
			set @logMessage = Concat(@logMessage, 'UltimaConsulta::', '', ':', @UltimaConsulta, ';')

			 Print @logMessage

		Begin

			Execute 	 [dbo].[Sistema_Log_Guardar] @TablaNombre		= @TablaNombreIDForLog
													,@TablaID			= Null
													,@TablaColumna1		= @UsuarioID
													,@TablaColumna2		= @ConversacionID
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
        @UsuarioID as UsuarioID