CREATE PROCEDURE [dbo].[CmpAnticipoEncabezado_Guardar]
@CmpAnticipoEncabezadoID int,
@PpalSucursalID int,
@TipoDocumentoID int,
@PpalSerieID int,
@Folio int,
@PpalProveedorID int,
@CmpTipoMovimientoProveedorID int,
@PpalPersonalID int,
@Fecha datetime,
@Referencia varchar(50),
@Concepto varchar(100),
@Importe float,
@BcoMovimientoID int
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300) = ''
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'CmpAnticipoEncabezado', @IDAActualizar int,
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@CmpAnticipoEncabezadoID_ int = @CmpAnticipoEncabezadoID,
		@PpalSucursalID_ int = 0,
		@TipoDocumentoID_ int = 0,
		@PpalSerieID_ int = 0,
		@Folio_ int = 0,
		@PpalProveedorID_ int = 0,
		@CmpTipoMovimientoProveedorID_ int = 0, 
		@PpalPersonalID_ int = 0,
		@Fecha_ datetime = 0,
		@Referencia_ varchar(50) = '',
		@Concepto_ varchar(100) = '',
		@Importe_ float = 0.0 ,
		@BcoMovimientoID_ int = 0

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION
	 
	SET @IDAActualizar = @CmpAnticipoEncabezadoID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		SELECT	@PpalSucursalID_  = IsNull(PpalSucursalID,0),
				@TipoDocumentoID_ = IsNull(TipoDocumentoID,0),
				@PpalSerieID_ = IsNull(PpalSerieID,0),
				@Folio_ = IsNull(Folio,0),
				@PpalProveedorID_  = IsNull(PpalProveedorID,0),
				@CmpTipoMovimientoProveedorID_ = IsNull(CmpTipoMovimientoProveedorID,0),
				@PpalPersonalID_ = IsNull(PpalPersonalID,0),
				@Fecha_ = IsNull(Fecha,0),
				@Referencia_ = ISNull(Referencia,''),
				@Concepto_ = IsNull(Concepto,''),
				@Importe_ = ISNULL(Importe, 0),
				@BcoMovimientoID = IsNull(BcoMovimientoID,0)
		   FROM	CmpAnticipoEncabezado WHERE CmpAnticipoEncabezadoID = @IDAActualizar
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar:', ' ', @IDAActualizar);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
		BEGIN
			UPDATE  CmpAnticipoEncabezado
			SET     PpalSucursalID = @PpalSucursalID,
					TipoDocumentoID = @TipoDocumentoID,
					PpalSerieID  = @PpalSerieID,
					Folio = @Folio,
					PpalProveedorID = @PpalProveedorID,
					CmpTipoMovimientoProveedorID = @CmpTipoMovimientoProveedorID,
					PpalPersonalID = @PpalPersonalID,
					Fecha = @Fecha,
					Referencia = @Referencia,
					Concepto = @Concepto,
					BcoMovimientoID = @BcoMovimientoID
			WHERE   CmpAnticipoEncabezadoID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO CmpAnticipoEncabezado(
					PpalSucursalID,
					TipoDocumentoID,
					PpalSerieID,
					Folio,
					PpalProveedorID,
					CmpTipoMovimientoProveedorID,
					PpalPersonalID,
					Fecha,
					Referencia,
					Concepto,
					BcoMovimientoID)
			VALUES  (
					@PpalSucursalID,
					@TipoDocumentoID,
					@PpalSerieID,
					@Folio,
					@PpalProveedorID,
					@CmpTipoMovimientoProveedorID,
					@PpalPersonalID,
					@Fecha,
					@Referencia,
					@Concepto,
					@BcoMovimientoID)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @CmpAnticipoEncabezadoID_ > 0  SET @Operacion = 'Update' 	
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
				SET @logMessage = Concat('CmpAnticipoEncabezadoID::', @CmpAnticipoEncabezadoID_, ':', @CmpAnticipoEncabezadoID, ';')
				SET @logMessage = Concat(@logMessage, 'PpalSucursalID::', @PpalSucursalID_, ':', @PpalSucursalID, ';')
				SET @logMessage = Concat(@logMessage, 'TipoDocumentoID::', @TipoDocumentoID_, ':', @TipoDocumentoID, ';')
				SET @logMessage = Concat(@logMessage, 'SerieID::', @PpalSerieID_, ':', @PpalSerieID, ';')
				SET @logMessage = Concat('Folio::', @Folio_, ':', @Folio, ';')
				SET @logMessage = Concat('PpalProveedorID::', @PpalProveedorID_, ':', @PpalProveedorID, ';')
				SET @logMessage = Concat(@logMessage, 'CmpTipoMovimientoProveedorID::', @CmpTipoMovimientoProveedorID_, ':', @CmpTipoMovimientoProveedorID, ';')
				SET @logMessage = Concat(@logMessage, 'PpalPersonalID::', @PpalPersonalID_, ':', @PpalPersonalID, ';')
				SET @logMessage = Concat(@logMessage, 'Fecha::', @Fecha_, ':', @Fecha, ';')
				SET @logMessage = Concat('Referencia::', @Referencia_, ':', @Referencia, ';')
				SET @logMessage = Concat('Concepto::', @Concepto_, ':', @Concepto, ';')
				SET @logMessage = Concat(@logMessage, 'BcoMovimientoID::', @BcoMovimientoID_, ':', @BcoMovimientoID, ';')
				PRINT @logMessage
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