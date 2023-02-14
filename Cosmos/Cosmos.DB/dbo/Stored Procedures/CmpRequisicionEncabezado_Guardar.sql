

CREATE PROCEDURE [dbo].[CmpRequisicionEncabezado_Guardar]
@CmpRequisicionEncabezadoID int,
@TipoDocumentoID int,
@PpalSerieID int,
@PpalSucursalID int,
@Folio int,
@Fecha datetime,
@Referencia varchar(50),
@PersonalID int,
@PpalCentroCostoID int,
@PpalAreaID int,
@Concepto varchar(100),
@EstatusDocumentoID int,
@ExplosionID int

-- Parámetros para Bitácora
	,@UsuarioIDBitcora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300) = '', @IDAActualizar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'CmpRequisicionEncabezado',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@TipoDocumentoID_ int = 0,
		@SerieID_ int = 0,
		@SucursalID_ int = 0,
		@Folio_ int = 0,
		@Fecha_ datetime = 0,
		@Referencia_ varchar(50) = '',
		@PersonalID_ int = 0,
		@CentroCostoID_ int = 0,
		@AreaID_ int = 0,
		@Concepto_ varchar(100) = '',
		@EstatusDocumentoID_ int = 0,
		@ExplosionID_ int = 0,
		@CmpRequisicionEncabezadoID_ int = @CmpRequisicionEncabezadoID

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @CmpRequisicionEncabezadoID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		SELECT	@TipoDocumentoID_ = IsNull(TipoDocumentoID,0),
				@SerieID_ = IsNull(PpalSerieID,0),
				@Folio_ = IsNull(Folio,0),
				@Fecha_ = IsNull(Fecha,0),
				@Referencia_ = IsNull(Referencia,''),
				@Referencia_ = IsNull(Referencia,0),
				@CentroCostoID_ = IsNull(PpalCentroCostoID,0),
				@AreaID_ = IsNull(PpalAreaID,0),
				@Concepto_ = IsNull(Concepto,''),
				@EstatusDocumentoID_ = IsNull(CfgEstatusDocumentoID,0),
				@ExplosionID_ = IsNull(ExplosionID,0),
				@CmpRequisicionEncabezadoID_ = IsNull(CmpRequisicionEncabezadoID,0)
		   FROM	CmpRequisicionEncabezado WHERE CmpRequisicionEncabezadoID = @IDAActualizar
		IF @@RowCount = 0
	SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar:', ' ', @IDAActualizar);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
		BEGIN
			UPDATE  CmpRequisicionEncabezado
			SET     TipoDocumentoID = @TipoDocumentoID,
					PpalSerieID = @PpalSerieID,
					PpalSucursalID = @PpalSucursalID,
					Folio = @Folio,
					Fecha = @Fecha,
					Referencia = @Referencia,
					PpalPersonalID = @PersonalID,
					PpalCentroCostoID = @PpalCentroCostoID,
					PpalAreaID = @PpalAreaID,
					Concepto = @Concepto,
					CfgEstatusDocumentoID = @EstatusDocumentoID,
					ExplosionID = @ExplosionID
			WHERE   CmpRequisicionEncabezadoID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO CmpRequisicionEncabezado(
					TipoDocumentoID,
					PpalSerieID,
					PpalSucursalID,
					Folio,
					Fecha,
					Referencia,
					PpalPersonalID,
					PpalCentroCostoID,
					PpalAreaID,
					Concepto,
					CfgEstatusDocumentoID,
					ExplosionID)
			VALUES  (
					@TipoDocumentoID,
					@PpalSerieID,
					@PpalSucursalID,
					@Folio,
					@Fecha,
					@Referencia,
					@PersonalID,
					@PpalCentroCostoID,
					@PpalAreaID,
					@Concepto,
					@EstatusDocumentoID,
					@ExplosionID)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @CmpRequisicionEncabezadoID_ > 0  SET @Operacion = 'Update' 	
						ELSE SET @Operacion = 'Create' 

			-- Revisa si el cambio debe ser guardado en Bitácora
			EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
					@UsuarioID			=	@UsuarioIDBitcora,
					@TablaNombre		=   @TablaNombreIDBitacora,
					@Operacion			=	@Operacion

			-- Si el cambio debe guardarse, prepara variables de Bitácora y lo guarda
			IF @isChangeBeLogged = 1 
			BEGIN
				-- logMessage = Cambios efectuados
				SET @logMessage = Concat('TipoDocumentoID::', @TipoDocumentoID_, ':', @TipoDocumentoID, ';')
				SET @logMessage = Concat(@logMessage, 'SerieID::', @SerieID_, ':', @PpalSerieID, ';')
				SET @logMessage = Concat(@logMessage, 'SucursalID::', @SucursalID_, ':', @PpalSucursalID, ';')
				SET @logMessage = Concat(@logMessage, 'Folio::', @Folio_, ':', @Folio, ';')
				SET @logMessage = Concat('Referencia::', @Referencia_, ':', @Referencia, ';')
				SET @logMessage = Concat('PersonalID::', @PersonalID_, ':', @PersonalID, ';')
				SET @logMessage = Concat(@logMessage, 'PpalCentroCostoID::', @CentroCostoID_, ':', @PpalCentroCostoID, ';')
				SET @logMessage = Concat(@logMessage, 'PpalAreaID::', @AreaID_, ':', @PpalAreaID, ';')
				SET @logMessage = Concat(@logMessage, 'Concepto::', @Concepto_, ':', @Concepto, ';')
				SET @logMessage = Concat('EstatusDocumentoID::', @EstatusDocumentoID_, ':', @EstatusDocumentoID, ';')
				SET @logMessage = Concat('ExplosionID ::', @ExplosionID_, ':', @ExplosionID , ';')
				PRINT @logMessage
				-- Guarda en Bitácora
				EXEC 	 [dbo].[SistemaLog_Guardar] @TablaNombre		= @TablaNombreIDBitacora
														,@TablaID			= @IDAActualizar
														,@TablaColumna1		= ''
														,@TablaColumna2		= ''
														,@Operacion			= @Operacion
														,@UsuarioID			= @UsuarioIDBitcora
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