CREATE PROCEDURE [dbo].[Mensajeria_Chat_Mensaje_Eliminar]

	@MensajeID int
	
	/************************************************/
	/* Campos para Log */
	,@UserIDForLog		int
	,@Descripcion		varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
	/************************************************/

As

Declare @Errores bit, @MensajeSistema nvarchar(300)

Begin Transaction 

Begin Try

	declare @isChangeBeLogged bit
	declare @logMessage       varchar(Max) = ''

	/****************************************************************************/
	/* Log */

	Exec	@isChangeBeLogged	=   Sistema_Log_Regla_Consultar_LogBit_D
			@UserID				=	@UserIDForLog,
			@TablaNombre		=  'MsjChatMensaje'
	/****************************************************************************/

	Update MsjChatMensaje
	Set Borrado = GetUTCDate()
	Where MensajeID = @MensajeID    
	
	Commit Transaction
	
	Select @Errores = 0, @MensajeSistema = ''

	/****************************************************************************/
	/* Log */
	If @isChangeBeLogged = 1 And @@RowCount > 0 

	Begin

		Execute 	 [dbo].[Sistema_Log_Guardar] @TablaNombre		= 'MsjChatMensaje'
												,@TablaID			= @MensajeID
												,@TablaColumna1		= Null
												,@TablaColumna2		= Null
												,@Operacion			= 'Delete'
												,@UserID			= @UserIDForLog
												,@Descripcion		= @Descripcion
												,@Cambios			= @logMessage
												,@IpAddress			= @IpAddress
												,@HostName			= @HostName
	End
	/****************************************************************************/

End Try
Begin Catch
    RollBack Transaction
    Select @Errores = 1, @MensajeSistema = ERROR_MESSAGE()
End Catch 

Select  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@MensajeSistema, '') as Mensaje,
        @MensajeID as MensajeID