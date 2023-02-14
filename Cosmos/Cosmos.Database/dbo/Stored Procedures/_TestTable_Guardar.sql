
Create Procedure [dbo].[_TestTable_Guardar]

	 @Column_1		int				= null
	,@Column_2		int
	,@Column_3		int
	,@Column_4		int
	,@Column_5		int
	,@Column_6		int
	,@Column_7		int
	,@Column_8		int
	,@Column_9		int
	,@Column_A		int
	,@Column_B		int
	,@Column_C		int
	,@Column_D		int
	,@Column_E		int
	
	/************************************************/
	/* Campos para Log */
	,@UserIDForLog		int
	,@Descripcion		varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
	/************************************************/
As

Declare @TablaNombreIDForLog   nvarchar(100) = 'TestTable'
Declare @Errores bit, @MensajeSistema nvarchar(300)

Begin Transaction 

Begin Try

	declare @isChangeBeLogged bit
	declare @logMessage       varchar(Max) = ''

    If Exists(Select Column_1 From TestTable Where Column_1 = @Column_1)
    Begin

		/****************************************************************************/
		/* Log */

		Exec	@isChangeBeLogged	=   Sistema_Log_Regla_Consultar_LogBit_U
				@UserID				=	@UserIDForLog,
				@TablaNombre		=   @TablaNombreIDForLog

		if @isChangeBeLogged = 1

		Begin

			declare 	@Column_1_ int
			declare 	@Column_2_ int
			declare 	@Column_3_ int
			declare 	@Column_4_ int
			declare 	@Column_5_ int
			declare 	@Column_6_ int
			declare 	@Column_7_ int
			declare 	@Column_8_ int
			declare 	@Column_9_ int
			declare 	@Column_A_ int
			declare 	@Column_B_ int
			declare 	@Column_C_ int
			declare 	@Column_D_ int
			declare 	@Column_E_ int

			Select 	 @Column_1_		= Column_1
					,@Column_2_		= Column_2
					,@Column_3_		= Column_3
					,@Column_4_		= Column_4
					,@Column_5_		= Column_5
					,@Column_6_		= Column_6
					,@Column_7_		= Column_7
					,@Column_8_		= Column_8
					,@Column_9_		= Column_9
					,@Column_A_		= Column_A
					,@Column_B_		= Column_B
					,@Column_C_		= Column_C
					,@Column_D_		= Column_D
					,@Column_E_		= Column_E
			From TestTable 
			Where Column_1 = @Column_1
		
			if @Column_1 != @Column_1_ set @logMessage = Concat(@logMessage, 'Column_1::', @Column_1_, ':', @Column_1, ';')
			if @Column_2 != @Column_2_ set @logMessage = Concat(@logMessage, 'Column_2::', @Column_2_, ':', @Column_2, ';')
			if @Column_3 != @Column_3_ set @logMessage = Concat(@logMessage, 'Column_3::', @Column_3_, ':', @Column_3, ';')
			if @Column_4 != @Column_4_ set @logMessage = Concat(@logMessage, 'Column_4::', @Column_4_, ':', @Column_4, ';')
			if @Column_5 != @Column_5_ set @logMessage = Concat(@logMessage, 'Column_5::', @Column_5_, ':', @Column_5, ';')
			if @Column_6 != @Column_6_ set @logMessage = Concat(@logMessage, 'Column_6::', @Column_6_, ':', @Column_6, ';')
			if @Column_7 != @Column_7_ set @logMessage = Concat(@logMessage, 'Column_7::', @Column_7_, ':', @Column_7, ';')
			if @Column_8 != @Column_8_ set @logMessage = Concat(@logMessage, 'Column_8::', @Column_8_, ':', @Column_8, ';')
			if @Column_9 != @Column_9_ set @logMessage = Concat(@logMessage, 'Column_9::', @Column_9_, ':', @Column_9, ';')
			if @Column_A != @Column_A_ set @logMessage = Concat(@logMessage, 'Column_A::', @Column_A_, ':', @Column_A, ';')
			if @Column_B != @Column_B_ set @logMessage = Concat(@logMessage, 'Column_B::', @Column_B_, ':', @Column_B, ';')
			if @Column_C != @Column_C_ set @logMessage = Concat(@logMessage, 'Column_C::', @Column_C_, ':', @Column_C, ';')
			if @Column_D != @Column_D_ set @logMessage = Concat(@logMessage, 'Column_D::', @Column_D_, ':', @Column_D, ';')
			if @Column_E != @Column_E_ set @logMessage = Concat(@logMessage, 'Column_E::', @Column_E_, ':', @Column_E, ';')

			 Print @logMessage
			
		End
		/* Log */
		/****************************************************************************/


        Update  TestTable
        Set      Column_2 = @Column_2
				,Column_3 = @Column_3
				,Column_4 = @Column_4
				,Column_5 = @Column_5
				,Column_6 = @Column_6
				,Column_7 = @Column_7
				,Column_8 = @Column_8
				,Column_9 = @Column_9
				,Column_A = @Column_A
				,Column_B = @Column_B
				,Column_C = @Column_C
				,Column_D = @Column_D
				,Column_E = @Column_E
        Where   Column_1 = @Column_1


		/****************************************************************************/
		/* Log */
		If @isChangeBeLogged = 1 And @@RowCount > 0 And Len(@logMessage) > 0

		Begin

			Execute 	 [dbo].[Sistema_Log_Guardar] @TablaNombre		= @TablaNombreIDForLog
													,@TablaID			= @Column_1
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
	
        Insert  Into TestTable (
				 Column_2
				,Column_3
				,Column_4
				,Column_5
				,Column_6
				,Column_7
				,Column_8
				,Column_9
				,Column_A
				,Column_B
				,Column_C
				,Column_D
				,Column_E
				)
        Values  (
				 @Column_2
				,@Column_3
				,@Column_4
				,@Column_5
				,@Column_6
				,@Column_7
				,@Column_8
				,@Column_9
				,@Column_A
				,@Column_B
				,@Column_C
				,@Column_D
				,@Column_E
				)
        
        Set     @Column_1 = SCOPE_IDENTITY()


		/****************************************************************************/
		/* Log */

		Exec	@isChangeBeLogged	=   Sistema_Log_Regla_Consultar_LogBit_C
				@UserID				=	@UserIDForLog,
				@TablaNombre		=   @TablaNombreIDForLog

		If @isChangeBeLogged = 1 And @@RowCount > 0

			set @logMessage = Concat(@logMessage, 'Column_1::', '', ':', @Column_1, ';')
			set @logMessage = Concat(@logMessage, 'Column_2::', '', ':', @Column_2, ';')
			set @logMessage = Concat(@logMessage, 'Column_3::', '', ':', @Column_3, ';')
			set @logMessage = Concat(@logMessage, 'Column_4::', '', ':', @Column_4, ';')
			set @logMessage = Concat(@logMessage, 'Column_5::', '', ':', @Column_5, ';')
			set @logMessage = Concat(@logMessage, 'Column_6::', '', ':', @Column_6, ';')
			set @logMessage = Concat(@logMessage, 'Column_7::', '', ':', @Column_7, ';')
			set @logMessage = Concat(@logMessage, 'Column_8::', '', ':', @Column_8, ';')
			set @logMessage = Concat(@logMessage, 'Column_9::', '', ':', @Column_9, ';')
			set @logMessage = Concat(@logMessage, 'Column_A::', '', ':', @Column_A, ';')
			set @logMessage = Concat(@logMessage, 'Column_B::', '', ':', @Column_B, ';')
			set @logMessage = Concat(@logMessage, 'Column_C::', '', ':', @Column_C, ';')
			set @logMessage = Concat(@logMessage, 'Column_D::', '', ':', @Column_D, ';')
			set @logMessage = Concat(@logMessage, 'Column_E::', '', ':', @Column_E, ';')

			 Print @logMessage

		Begin

			Execute 	 [dbo].[Sistema_Log_Guardar] @TablaNombre		= @TablaNombreIDForLog
													,@TablaID			= @Column_1
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
        @Column_1 as Column_1