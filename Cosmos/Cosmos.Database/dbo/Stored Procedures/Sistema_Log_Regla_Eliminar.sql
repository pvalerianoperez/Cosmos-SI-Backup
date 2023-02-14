CREATE PROCEDURE [dbo].[Sistema_Log_Regla_Eliminar]

	@SistemaLogReglaID	int

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

    Begin

        Delete From SistemaLogRegla
        Where  SistemaLogReglaID	= @SistemaLogReglaID


		/****************************************************************************/
		/* Log */
		If @isChangeBeLogged = 1 And @@RowCount > 0

		Begin

			Execute 	 [dbo].[Sistema_Log_Guardar] @TablaNombre		= @TablaNombreIDForLog
													,@TablaID			= @SistemaLogReglaID
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