CREATE PROCEDURE [dbo].[CfgParamConfigUsuarioCosmos_Guardar]
		@CfgParamConfigUsuarioCosmosID int,
        @ComparteProveedor char(1),
		@TextoArea varchar(50),
		@TextoAreas varchar(50),
		@TextoAreaAlias varchar(15),
		@TextoAreasAlias varchar(15),
		@TextoAreaPrefijo varchar(5),
		@TextoAreasPrefijo varchar(5),
		@TextoCentroCosto varchar(50),
		@TextoCentrosCosto varchar(50),
		@TextoCentroCostoAlias varchar(15),
		@TextoCentrosCostoAlias varchar(15),
		@TextoCentroCostoPrefijo varchar(5),
		@TextoCentrosCostoPrefijo varchar(5),
		@TextoSucursal varchar(50),
		@TextoSucursales varchar(50),
		@TextoSucursalAlias varchar(15),
		@TextoSucursalesAlias varchar(15),
		@TextoSucursalPrefijo varchar(5),
		@TextoSucursalesPrefijo varchar(5)
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress				varchar(40)		= null
	,@HostName				varchar(50)		= null

AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(300) = '', @IDAActualizar int
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'CfgParamConfigUsuarioCosmos',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@ComparteProveedor_ char(1),
		@TextoArea_ varchar(50),
		@TextoAreas_ varchar(50),
		@TextoAreaAlias_ varchar(15),
		@TextoAreasAlias_  varchar(15),
		@TextoAreaPrefijo_ varchar(5),
		@TextoAreasPrefijo_ varchar(5),
		@TextoCentroCosto_ varchar(50),
		@TextoCentrosCosto_ varchar(50),
		@TextoCentroCostoAlias_ varchar(15),
		@TextoCentrosCostoAlias_  varchar(15),
		@TextoCentroCostoPrefijo_ varchar(5),
		@TextoCentrosCostoPrefijo_ varchar(5),
		@TextoSucursal_ varchar(50),
		@TextoSucursales_ varchar(50),
		@TextoSucursalAlias_  varchar(15),
		@TextoSucursalesAlias_ varchar(15),
		@TextoSucursalPrefijo_ varchar(5),
		@TextoSucursalesPrefijo_ varchar(5),
		@CfgParamConfigUsuarioCosmosID_ int = @CfgParamConfigUsuarioCosmosID

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @CfgParamConfigUsuarioCosmosID

	BEGIN
		SELECT	@ComparteProveedor_ = IsNull(ComparteProveedor ,''),
				@CfgParamConfigUsuarioCosmosID_ = IsNull(CfgParamConfigUsuarioCosmosID,0),
				@TextoArea_ = IsNull(TextoArea,''),
				@TextoAreas_ = IsNull(TextoAreas,''),
				@TextoAreaAlias_ = IsNull(TextoAreaAlias,''),
				@TextoAreasAlias_ = IsNull(TextoAreasAlias,''),
				@TextoAreaPrefijo_ = IsNull(TextoAreaPrefijo,''),
				@TextoAreasPrefijo_ = IsNull(TextoAreasPrefijo,''),
				@TextoCentroCosto_ = IsNull(TextoCentroCosto,''),
				@TextoCentrosCosto_ = IsNull(TextoCentrosCosto,''),
				@TextoCentroCostoAlias_ = IsNull(TextoCentroCostoAlias,''),
				@TextoCentrosCostoAlias_ = IsNull(TextoCentrosCostoAlias,''),
				@TextoCentroCostoPrefijo_ = IsNull(TextoCentroCostoPrefijo,''),
				@TextoCentrosCostoPrefijo_ = IsNull(TextoCentrosCostoPrefijo,''),
				@TextoSucursal_ = IsNull(TextoSucursal,''),
				@TextoSucursales_ = IsNull(TextoSucursales,''),
				@TextoSucursalAlias_ = IsNull(TextoSucursalAlias,''),
				@TextoSucursalesAlias_ = IsNull(TextoSucursalesAlias,''),
				@TextoSucursalPrefijo_ = IsNull(TextoSucursalPrefijo,''),
				@TextoSucursalesPrefijo_ = IsNull(TextoSucursalesPrefijo,'')
			FROM CfgParamConfigUsuarioCosmos WHERE CfgParamConfigUsuarioCosmosID = @IDAActualizar
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar:', ' ', @IDAActualizar);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN		
		IF @IDAActualizar > 0
		BEGIN
			UPDATE  CfgParamConfigUsuarioCosmos
			SET     ComparteProveedor = @ComparteProveedor,
					TextoArea = @TextoArea,
					TextoAreas = @TextoAreas,
					TextoAreaAlias = @TextoAreaAlias,
					TextoAreasAlias = @TextoAreasAlias,
					TextoAreaPrefijo = @TextoAreaPrefijo,
					TextoAreasPrefijo = @TextoAreasPrefijo,
					TextoCentroCosto = @TextoCentroCosto,
					TextoCentrosCosto = @TextoCentrosCosto,
					TextoCentroCostoAlias = @TextoCentroCostoAlias,
					TextoCentrosCostoAlias = @TextoCentrosCostoAlias,
					TextoCentroCostoPrefijo = @TextoCentroCostoPrefijo,
					TextoCentrosCostoPrefijo = @TextoCentrosCostoPrefijo,
					TextoSucursal = @TextoSucursal,
					TextoSucursales = @TextoSucursales,
					TextoSucursalAlias = @TextoSucursalAlias,
					TextoSucursalesAlias = @TextoSucursalesAlias,
					TextoSucursalPrefijo = @TextoSucursalPrefijo,
					TextoSucursalesPrefijo = @TextoSucursalesPrefijo
			WHERE   CfgParamConfigUsuarioCosmosID = @IDAActualizar
		END

		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			SET @Operacion = 'Update' 	
						 

			-- Revisa si el cambio debe ser guardado en Bitácora
			EXEC	@isChangeBeLogged	=   SistemaLogRegla_Consultar_LogBit
					@UsuarioID			=	@UsuarioIDBitacora,
					@TablaNombre		=   @TablaNombreIDBitacora,
					@Operacion			=	@Operacion

			-- Si el cambio debe guardarse, prepara variables de Bitácora y lo guarda
			IF @isChangeBeLogged = 1 
			BEGIN
				-- logMessage = Cambios efectuados
				SET @logMessage = Concat('ComparteProveedor ::', @ComparteProveedor_ , ':', @ComparteProveedor , ';')

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