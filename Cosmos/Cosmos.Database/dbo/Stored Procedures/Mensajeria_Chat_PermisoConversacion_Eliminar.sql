
Create Procedure [dbo].[Mensajeria_Chat_PermisoConversacion_Eliminar]

	@PermisoConversacionID		int

	/************************************************/
	/* Campos para Log */
	,@UserIDForLog		int
	,@Descripcion		varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
	/************************************************/

As

Declare @TablaNombreIDForLog   nvarchar(100) = 'MsjChatPermisoConversacion'
Declare @Errores bit, @MensajeSistema nvarchar(300)

Begin Transaction 

Begin Try

	declare @isChangeBeLogged bit
	declare @logMessage       varchar(Max) = ''

	/****************************************************************************/
	/* Log */

	Exec	@isChangeBeLogged	=   Sistema_Log_Regla_Consultar_LogBit_D
			@UserID				=	@UserIDForLog,
			@TablaNombre		=   @TablaNombreIDForLog
	/****************************************************************************/

	Delete	MsjChatPermisoConversacion
	Where	PermisoConversacionID = @PermisoConversacionID 
	
	Commit Transaction
	
	Select @Errores = 0, @MensajeSistema = ''

	/****************************************************************************/
	/* Log */
	If @isChangeBeLogged = 1 And @@RowCount > 0 

	Begin

		Execute 	 [dbo].[Sistema_Log_Guardar] @TablaNombre		= @TablaNombreIDForLog
												,@TablaID			= @PermisoConversacionID
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
        @PermisoConversacionID as PermisoConversacionID