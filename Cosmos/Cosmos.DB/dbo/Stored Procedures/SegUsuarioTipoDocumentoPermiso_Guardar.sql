

CREATE PROCEDURE [dbo].[SegUsuarioTipoDocumentoPermiso_Guardar]
@SegUsuarioTipoDocumentoPermisoID int,
@SegUsuarioID int,
@TipoDocumentoID int,
@PpalCentroCostoID int = 0,
@PpalAreaID int = 0,
@EmpresaID int = 0,
@AlmacenID int = 0,
@PpalSucursalID int = 0,
@Preautoriza bit,
@PreautorizarMonto money,
@Autoriza bit,
@AutorizarMonto money
-- Parámetros para Bitácora
	,@UsuarioIDBitacora			int
	,@DescripcionBitacora		varchar(500)	= null
	,@IpAddress					varchar(40)		= null
	,@HostName					varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300) = '', @IDAActualizar int, @ClaveNoAsignado varchar(5)
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'SegUsuarioTipoDocumentoPermiso',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@SegUsuarioID_ int = 0,
		@TipoDocumentoID_ int = 0,
		@PpalCentroCostoID_ int = 0,
		@PpalAreaID_ int = 0,
		@EmpresaID_ int = 0,
		@AlmacenID_ int = 0,
		@PpalSucursalID_ int = 0,
		@Preautoriza_ bit = 0,
		@PreautorizarMonto_ money = 0,
		@Autoriza_ bit = 0,
		@AutorizarMonto_ money = 0,
		@SegUsuarioTipoDocumentoPermisoID_ int = @SegUsuarioTipoDocumentoPermisoID

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @SegUsuarioTipoDocumentoPermisoID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		-- Lee Valores anteriores para Bitácora
		SELECT	@SegUsuarioID_ = IsNull(SegUsuarioID,0),
				@TipoDocumentoID_ = IsNull(TipoDocumentoID,0),
				@PpalCentroCostoID_ = IsNull(PpalCentroCostoID,0),
				@PpalAreaID_ = IsNull(PpalAreaID,0),
				@EmpresaID_ = IsNull(EmpresaID,0),
				@AlmacenID_ = IsNull(PpalAlmacenID,0),
				@PpalSucursalID_ = IsNull(PpalSucursalID,0),
				@Preautoriza_ = IsNull(Preautoriza,0),
				@PreautorizarMonto_ = IsNull(PreautorizarMonto,0),
				@Autoriza_ = IsNull(Autoriza,0),
				@AutorizarMonto_ = IsNull(AutorizarMonto,0),
				@SegUsuarioTipoDocumentoPermisoID_ = IsNull(SegUsuarioTipoDocumentoPermisoID,0)
		   FROM	SegUsuarioTipoDocumentoPermiso WHERE SegUsuarioTipoDocumentoPermisoID = @IDAActualizar
		-- Si no se encontró registro a actualizar -> error
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar: ', @IDAActualizar);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
		BEGIN
			UPDATE  SegUsuarioTipoDocumentoPermiso
			SET		SegUsuarioID = @SegUsuarioID,
					TipoDocumentoID = @TipoDocumentoID,
					PpalCentroCostoID = @PpalCentroCostoID,
					PpalAreaID = @PpalAreaID,
					EmpresaID = @EmpresaID,
					PpalAlmacenID = @AlmacenID,
					PpalSucursalID = @PpalSucursalID,
					Preautoriza = @Preautoriza,
					PreautorizarMonto = @PreautorizarMonto,
					Autoriza = @Autoriza,
					AutorizarMonto = @AutorizarMonto
			WHERE   SegUsuarioTipoDocumentoPermisoID = @IDAActualizar
		END
		ELSE
		BEGIN        
			INSERT  INTO SegUsuarioTipoDocumentoPermiso(
					SegUsuarioID,
					TipoDocumentoID,
					PpalCentroCostoID,
					PpalAreaID,
					EmpresaID,
					PpalAlmacenID,
					PpalSucursalID,
					Preautoriza,
					PreautorizarMonto,
					Autoriza,
					AutorizarMonto)
			VALUES  (
					@SegUsuarioID,
					@TipoDocumentoID,
					@PpalCentroCostoID,
					@PpalAreaID,
					@EmpresaID,
					@AlmacenID,
					@PpalSucursalID,
					@Preautoriza,
					@PreautorizarMonto,
					@Autoriza,
					@AutorizarMonto)
        
			SET     @IDAActualizar = SCOPE_IDENTITY()
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @SegUsuarioTipoDocumentoPermisoID_ > 0  SET @Operacion = 'Update' 	
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
				SET @logMessage = Concat(@logMessage,'SegUsuarioID::', @SegUsuarioID_, ':', @SegUsuarioID, ';')
				SET @logMessage = Concat(@logMessage, 'TipoDocumentoID::', @TipoDocumentoID_, ':', @TipoDocumentoID, ';')
				SET @logMessage = Concat(@logMessage, 'PpalCentroCostoID::', @PpalCentroCostoID_, ':', @PpalCentroCostoID, ';')
				SET @logMessage = Concat(@logMessage, 'PpalAreaID::', @PpalAreaID_, ':', @PpalAreaID, ';')
				SET @logMessage = Concat(@logMessage,'EmpresaID::', @EmpresaID_, ':', @EmpresaID, ';')
				SET @logMessage = Concat(@logMessage,'AlmacenID::', @AlmacenID_, ':', @AlmacenID, ';')
				SET @logMessage = Concat(@logMessage, 'PpalSucursalID::', @PpalSucursalID_, ':', @PpalSucursalID, ';')
				SET @logMessage = Concat(@logMessage, 'Preautoriza::', @Preautoriza_, ':', @Preautoriza, ';')
				SET @logMessage = Concat(@logMessage, 'PreautorizarMonto::', @PreautorizarMonto_, ':', @PreautorizarMonto, ';')
				SET @logMessage = Concat(@logMessage,'Autoriza::', @Autoriza_, ':', @Autoriza, ';')
				SET @logMessage = Concat(@logMessage,'AutorizarMonto::', @AutorizarMonto_, ':', @AutorizarMonto, ';')
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