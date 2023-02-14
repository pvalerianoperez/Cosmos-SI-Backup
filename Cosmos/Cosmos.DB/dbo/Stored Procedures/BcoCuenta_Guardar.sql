-- =============================================
-- Author:      <Author, , Name>
-- Create Date: <Create Date, , >
-- Description: <Description, , >
-- =============================================
CREATE PROCEDURE [dbo].[BcoCuenta_Guardar]
@BcoCuentaID int,
@BcoSucursalID int,
@Clabe decimal(18,0),
@Cuenta decimal(18,0),
@Tarjeta decimal(16,0)
-- Parámetros para Bitácora
	,@UsuarioIBitacora			int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null
AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300) = '', @IDAActualizar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'CmpAnticipoDetalle',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@BcoCuentaID_ int = @BcoCuentaID,
		@BcoSucursalID_ int = 0,
		@Clabe_ decimal(18,0) = 0,
		@Cuenta_ decimal(18,0) = 0,
		@Tarjeta_ decimal(16,0) = 0

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @BcoCuentaID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		SELECT	@BcoCuentaID_ = IsNull(BcoCuentaID,0),
				@BcoSucursalID_  = IsNull(BcoSucursalID,0),
				@Clabe_		  = IsNull(Clabe,0),
				@Cuenta_	  = IsNull(Cuenta, 0),
				@Tarjeta_	  = IsNull(Tarjeta,0)
		   FROM	BcoCuenta WHERE BcoCuentaID = @IDAActualizar
		IF @@RowCount = 0
		SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar:', ' ', @IDAActualizar);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
/************* FIN COPY 1  *********************/
		BEGIN
			UPDATE	BcoCuenta
			SET		BcoSucursalID = @BcoSucursalID,
					Clabe = @Clabe,
					Cuenta = @Cuenta,
					Tarjeta = @Tarjeta
			WHERE	BcoCuentaID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO BcoCuenta(
					BcoSucursalID,
					Clabe,
					Cuenta,
					Tarjeta)
			VALUES  (
				    @BcoSucursalID,
					@Clabe,
					@Cuenta,
					@Tarjeta)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @BcoCuentaID > 0  SET @Operacion = 'Update' 	
						ELSE SET @Operacion = 'Create' 

			-- Revisa si el cambio debe ser guardado en Bitácora
			EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
					@UsuarioID			=	@UsuarioIBitacora,
					@TablaNombre		=   @TablaNombreIDBitacora,
					@Operacion			=	@Operacion

			-- Si el cambio debe guardarse, prepara variables de Bitácora y lo guarda
			IF @isChangeBeLogged = 1 
			BEGIN
				-- logMessage = Cambios efectuados
				SET @logMessage = Concat('BcoSucursalID::', @BcoSucursalID_, ':', @BcoSucursalID, ';')
				SET @logMessage = Concat(@logMessage, 'Clabe::', @Clabe_, ':', @Clabe, ';')
				SET @logMessage = Concat(@logMessage, 'Cuenta::', @Cuenta_, ':', @Cuenta, ';')
				SET @logMessage = Concat(@logMessage, 'Tarjeta::', @Tarjeta_, ':', @Tarjeta, ';')
				PRINT @logMessage
				-- Guarda en Bitácora
				EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreIDBitacora
														,@TablaID			= @IDAActualizar
														,@TablaColumna1		= ''
														,@TablaColumna2		= ''
														,@Operacion			= @Operacion
														,@UsuarioID			= @UsuarioIBitacora
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
-- Si hubo error los procesa y lo regresa
BEGIN CATCH
    SELECT @Errores = ERROR_NUMBER(), 
			@Mensaje = dbo.FDecodificaError(ERROR_NUMBER(), ERROR_MESSAGE(), ERROR_SEVERITY(), ERROR_STATE(), ERROR_PROCEDURE(), ERROR_LINE())
END CATCH 
IF (XACT_STATE()) = -1 ROLLBACK TRANSACTION;
IF (XACT_STATE()) = 1 COMMIT TRANSACTION;

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
		COALESCE(ERROR_SEVERITY(), 0) as Severidad,
		COALESCE(ERROR_STATE(), 0) as Estado,
		COALESCE(ERROR_PROCEDURE(), '') as ProcedimientoAlmacenado,
		COALESCE(ERROR_LINE(), 0) as Linea,
		@IDAActualizar as GuardarID