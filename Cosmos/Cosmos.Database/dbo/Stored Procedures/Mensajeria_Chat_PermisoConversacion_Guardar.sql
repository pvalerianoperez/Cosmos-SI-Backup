
Create Procedure [dbo].[Mensajeria_Chat_PermisoConversacion_Guardar]

	 @PermisoConversacionID			int				= null
	,@PersmisoCoversacionNombre		int
	
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

    If Exists(Select PermisoConversacionID From MsjChatPermisoConversacion Where PermisoConversacionID = @PermisoConversacionID)
    Begin

		/****************************************************************************/
		/* Log */

		Exec	@isChangeBeLogged	=   Sistema_Log_Regla_Consultar_LogBit_U
				@UserID				=	@UserIDForLog,
				@TablaNombre		=   @TablaNombreIDForLog

		if @isChangeBeLogged = 1

		Begin

			declare 	@PermisoConversacionID_ int
			declare 	@PersmisoCoversacionNombre_ int

			Select 	@PermisoConversacionID_		= PermisoConversacionID,
					@PersmisoCoversacionNombre_		= PersmisoCoversacionNombre
			From MsjChatPermisoConversacion 
			Where PermisoConversacionID = @PermisoConversacionID
		
			if @PermisoConversacionID != @PermisoConversacionID_ set @logMessage = Concat(@logMessage, 'PermisoConversacionID::', @PermisoConversacionID_, ':', @PermisoConversacionID, ';')
			if @PersmisoCoversacionNombre != @PersmisoCoversacionNombre_ set @logMessage = Concat(@logMessage, 'PersmisoCoversacionNombre::', @PersmisoCoversacionNombre_, ':', @PersmisoCoversacionNombre, ';')
			
			 Print @logMessage
			
		End
		/* Log */
		/****************************************************************************/


        Update  MsjChatPermisoConversacion
        Set     PersmisoCoversacionNombre = @PersmisoCoversacionNombre
        Where   PermisoConversacionID = @PermisoConversacionID


		/****************************************************************************/
		/* Log */
		If @isChangeBeLogged = 1 And @@RowCount > 0 And Len(@logMessage) > 0

		Begin

			Execute 	 [dbo].[Sistema_Log_Guardar] @TablaNombre		= @TablaNombreIDForLog
													,@TablaID			= @PermisoConversacionID
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
	
        Insert  Into MsjChatPermisoConversacion (
				PersmisoCoversacionNombre
				)
        Values  (
				@PersmisoCoversacionNombre
				)
        
        Set     @PermisoConversacionID = SCOPE_IDENTITY()


		/****************************************************************************/
		/* Log */

		Exec	@isChangeBeLogged	=   Sistema_Log_Regla_Consultar_LogBit_C
				@UserID				=	@UserIDForLog,
				@TablaNombre		=   @TablaNombreIDForLog

		If @isChangeBeLogged = 1 And @@RowCount > 0

			set @logMessage = Concat(@logMessage, 'PermisoConversacionID::', '', ':', @PermisoConversacionID, ';')
			set @logMessage = Concat(@logMessage, 'PersmisoCoversacionNombre::', '', ':', @PersmisoCoversacionNombre, ';')

			 Print @logMessage

		Begin

			Execute 	 [dbo].[Sistema_Log_Guardar] @TablaNombre		= @TablaNombreIDForLog
													,@TablaID			= @PermisoConversacionID
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
        @PermisoConversacionID as PermisoConversacionID