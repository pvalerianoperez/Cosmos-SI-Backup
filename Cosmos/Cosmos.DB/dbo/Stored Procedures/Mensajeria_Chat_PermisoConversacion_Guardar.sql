
CREATE Procedure [dbo].[Mensajeria_Chat_PermisoConversacion_Guardar]

	 @PermisoConversacionID			int				= null
	,@Nombre		int
	
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

		Exec	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
				@UsuarioID				=	@UserIDForLog,
				@TablaNombre		=   @TablaNombreIDForLog

		if @isChangeBeLogged = 1

		Begin

			declare 	@PermisoConversacionID_ int
			declare 	@Nombre_ int

			Select 	@PermisoConversacionID_		= PermisoConversacionID,
					@Nombre_		= Nombre
			From MsjChatPermisoConversacion 
			Where PermisoConversacionID = @PermisoConversacionID
		
			if @PermisoConversacionID != @PermisoConversacionID_ set @logMessage = Concat(@logMessage, 'PermisoConversacionID::', @PermisoConversacionID_, ':', @PermisoConversacionID, ';')
			if @Nombre != @Nombre_ set @logMessage = Concat(@logMessage, 'PersmisoCoversacionNombre::', @Nombre_, ':', @Nombre, ';')
			
			 Print @logMessage
			
		End
		/* Log */
		/****************************************************************************/


        Update  MsjChatPermisoConversacion
        Set     Nombre = @Nombre
        Where   PermisoConversacionID = @PermisoConversacionID


		/****************************************************************************/
		/* Log */
		If @isChangeBeLogged = 1 And @@RowCount > 0 And Len(@logMessage) > 0

		Begin

			Execute 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreIDForLog
													,@TablaID			= @PermisoConversacionID
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
	
        Insert  Into MsjChatPermisoConversacion (
				Nombre
				)
        Values  (
				@Nombre
				)
        
        Set     @PermisoConversacionID = SCOPE_IDENTITY()


		/****************************************************************************/
		/* Log */

		Exec	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
				@UsuarioID				=	@UserIDForLog,
				@TablaNombre		=   @TablaNombreIDForLog

		If @isChangeBeLogged = 1 And @@RowCount > 0

			set @logMessage = Concat(@logMessage, 'PermisoConversacionID::', '', ':', @PermisoConversacionID, ';')
			set @logMessage = Concat(@logMessage, 'PersmisoCoversacionNombre::', '', ':', @Nombre, ';')

			 Print @logMessage

		Begin

			Execute 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreIDForLog
													,@TablaID			= @PermisoConversacionID
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
        @PermisoConversacionID as PermisoConversacionID