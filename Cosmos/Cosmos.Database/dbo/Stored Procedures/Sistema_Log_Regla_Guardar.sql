CREATE PROCEDURE [dbo].[Sistema_Log_Regla_Guardar]

	 @SistemaLogReglaID int			= null
    ,@UserID			int			= 0
    ,@TablaNombre		varchar(50)
    ,@C					Bit			= 0
    ,@R					Bit			= 0
    ,@U					Bit			= 0
    ,@D					Bit			= 0

	/************************************************/
	/* Campos para Log */
	,@UserIDForLog		int
	,@Descripcion		varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
	/************************************************/
As

Declare @TablaNombreIDForLog   nvarchar(100) = 'SistemaLogRegla'
Declare @Errores bit, @Mensaje nvarchar(300)

Begin Transaction 

Begin Try

	declare @isChangeBeLogged bit
	declare @logMessage       varchar(Max) = ''

    If Exists(Select SistemaLogReglaID From SistemaLogRegla Where SistemaLogReglaID = @SistemaLogReglaID)
    Begin

		/****************************************************************************/
		/* Log */

		Exec	@isChangeBeLogged	=   Sistema_Log_Regla_Consultar_LogBit_U
				@UserID				=	@UserIDForLog,
				@TablaNombre		=   @TablaNombreIDForLog

		if @isChangeBeLogged = 1

		Begin

		   Declare @UserID_				int			= 0
		   Declare @TablaNombre_		varchar(50)
		   Declare @C_					Bit			= 0
		   Declare @R_					Bit			= 0
		   Declare @U_					Bit			= 0
		   Declare @D_					Bit			= 0

			Select 	 @UserID_ = UserID
					,@TablaNombre_ = TablaNombre
					,@C_ = C
					,@R_ = R
					,@U_ = U
					,@D_ = D
			From SistemaLogRegla 
			Where SistemaLogReglaID = @SistemaLogReglaID
		
			if @UserID != @UserID_			 set @logMessage = Concat(@logMessage, 'UserID::', @UserID_, ':', @UserID, ';')
			if @TablaNombre != @TablaNombre_ set @logMessage = Concat(@logMessage, 'TablaNombre::', @TablaNombre_, ':', @TablaNombre, ';')
			if @C != @C_					 set @logMessage = Concat(@logMessage, 'C::', @C_, ':', @C, ';')
			if @R != @R_					 set @logMessage = Concat(@logMessage, 'R::', @R_, ':', @R, ';')
			if @U != @U_					 set @logMessage = Concat(@logMessage, 'U::', @U_, ':', @U, ';')
			if @D != @D_					 set @logMessage = Concat(@logMessage, 'D::', @D_, ':', @D, ';')

			 Print @logMessage
			
		End
		/* Log */
		/****************************************************************************/


        Update  SistemaLogRegla
        Set      UserID				= @UserID
				,TablaNombre		= @TablaNombre
				,C					= @C
				,R					= @R
				,U					= @U
				,D					= @D
        Where   SistemaLogReglaID	= @SistemaLogReglaID


		/****************************************************************************/
		/* Log */
		If @isChangeBeLogged = 1 And @@RowCount > 0 And Len(@logMessage) > 0

		Begin

			Execute 	 [dbo].[Sistema_Log_Guardar] @TablaNombre		= @TablaNombreIDForLog
													,@TablaID			= @SistemaLogReglaID
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
	
        Insert  Into SistemaLogRegla (
				 UserID
				,TablaNombre
				,C
				,R
				,U
				,D
				)
        Values  (
				 @UserID
				,@TablaNombre
				,@C
				,@R
				,@U
				,@D
				)

        Set     @SistemaLogReglaID = SCOPE_IDENTITY()


		/****************************************************************************/
		/* Log */

		Exec	@isChangeBeLogged	=   Sistema_Log_Regla_Consultar_LogBit_C
				@UserID				=	@UserIDForLog,
				@TablaNombre		=   @TablaNombreIDForLog

		If @isChangeBeLogged = 1 And @@RowCount > 0

			set @logMessage = Concat(@logMessage, 'UserID::', '', ':',      @UserID, ';')
			set @logMessage = Concat(@logMessage, 'TablaNombre::', '', ':', @TablaNombre, ';')
			set @logMessage = Concat(@logMessage, 'C::', '', ':', @C, ';')
			set @logMessage = Concat(@logMessage, 'R::', '', ':', @R, ';')
			set @logMessage = Concat(@logMessage, 'U::', '', ':', @U, ';')
			set @logMessage = Concat(@logMessage, 'D::', '', ':', @D, ';')

			Print @logMessage

		Begin

			Execute 	 [dbo].[Sistema_Log_Guardar] @TablaNombre		= @TablaNombreIDForLog
													,@TablaID			= @SistemaLogReglaID
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
    Select @Errores = 1, @Mensaje = ERROR_MESSAGE()
End Catch 

Select  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @SistemaLogReglaID as SistemaLogReglaID