

CREATE PROCEDURE [dbo].[PpalContactoPersonalMail_Guardar]
@PpalContactoPersonalMailID int,
@PpalContactoPersonalID int,
@Email varchar(100),
@Predeterminado bit,
@Comentarios varchar(100),
@TipoMailID int
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null
AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300), @IDAActualizar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'PpalContactoPersonalMail',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE @PpalContactoPersonalMailID_		int = @PpalContactoPersonalMailID,
		@PpalContactoPersonalID_			int = @PpalContactoPersonalID,
		@Email_								varchar(100) = '',
		@Predeterminado_					bit = 0,
		@Comentarios_						varchar(100) = '',
		@TipoMailID_						int = 0
		
BEGIN TRANSACTION 
BEGIN TRY
	SET @IDAActualizar = @PpalContactoPersonalID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		SELECT	@PpalContactoPersonalMailID_		=	IsNull(PpalContactoPersonalMailID,0),
				@PpalContactoPersonalID_			= ISNULL(PpalContactoPersonalID, 0),
	 			@Email_								=	IsNull(Email,''),
				@Predeterminado_					=	IsNull(Predeterminado,''),
				@Comentarios_						=	IsNull(Comentarios,0),
				@TipoMailID_						= ISNULL(CfgTipoMailID, 0)
		   FROM	PpalContactoPersonalMail WHERE PpalContactoPersonalID = @IDAActualizar
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a actualizar:', ' ', @IDAActualizar);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
		BEGIN
			UPDATE  PpalContactoPersonalMail
				SET     PpalContactoPersonalID = @PpalContactoPersonalID,
						Email = @Email,
						Predeterminado = @Predeterminado,
						Comentarios = @Comentarios,
						CfgTipoMailID = @TipoMailID
				WHERE   PpalContactoPersonalMailID = @PpalContactoPersonalMailID
		END
		ELSE
		BEGIN        
			INSERT  INTO PpalContactoPersonalMail(
							PpalContactoPersonalID,
							Email,
							Predeterminado,
							Comentarios,
							CfgTipoMailID)
					VALUES  (
							@PpalContactoPersonalID,
							@Email,
							@Predeterminado,
							@Comentarios,
							@TipoMailID)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @PpalContactoPersonalID > 0  SET @Operacion = 'Update' 	
						ELSE SET @Operacion = 'Create' 

			-- Revisa si el cambio debe ser guardado en Bitácora
			EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
					@UsuarioID			=	@UsuarioIDBitacora,
					@TablaNombre		=   @TablaNombreIDBitacora,
					@Operacion			=	@Operacion

			-- Si el cambio debe guardarse, prepara variables de Bitácora y lo guarda
			IF @isChangeBeLogged = 1 
			BEGIN
				-- logMessage = Cambios efectuados
				SET @logMessage = Concat('PpalContactoPersonalID::', @PpalContactoPersonalID_, ':', @PpalContactoPersonalID, ';')
				-- Guarda en Bitácora
				EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreIDBitacora
														,@TablaID			= @IDAActualizar
														,@TablaColumna1		= ''
														,@TablaColumna2		= ''
														,@Operacion			= @Operacion
														,@UsuarioID			= @UsuarioIDBitacora
														,@Descripcion		= @DescripcionBitacora
														,@Cambios			= @logMessage
														,@IpAddress			= @IpAddress
														,@HostName			= @HostName
			END
		END
		-- Fin de proceso sin errores -> COMMIT
		COMMIT TRANSACTION
	END
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @PpalContactoPersonalMailID as PpalContactoPersonalMailID