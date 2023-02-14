CREATE PROCEDURE [dbo].[PpalProveedor_Guardar]
@PpalProveedorID int,
@EspPersonaID int,
@CmpTipoProveedorID int,
@AuxGiroEmpresaID int,
@AuxMedioContactoID int = 0,
@AuxVinculoID int = 0,
@AplicaRetenciones char(1) = '',

--Variables Persona ->
@FisicaMoral char(1),
@NombreComercial nvarchar(120),
@RazonSocial nvarchar(120),
@Nombre nvarchar(35),
@ApellidoPaterno nvarchar(30),
@ApellidoMaterno nvarchar(30),
@RFC nvarchar(13),
@CURP nvarchar(18),
@SexoID int = 0,
@FechaNacimiento datetime = null,
@CiudadNacimientoID int = 0,
@EstadoCivilID int = 0,
@CasadoCivil bit,
@CasadoIglesia bit,
@Iniciales varchar(6),
@SobreNombre varchar(25),
@NombreCorto varchar(25),
--Variables ProveedorEmpresaSucursal---->
--,@EmpresaID int = null,
--@SucursalID int = null,
@PpalProveedorClave varchar(10) = null
--@Estatus bit

-- Parámetros para Bitácora
	,@UsuarioIDBitacora	int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null

AS

--SET @FechaNacimiento = '20100217'

-- Variables para manejo de Respuesta
DECLARE @Errores int = 0,						@Mensaje nvarchar(500) = '',			@IDAActualizar int,
		@ClaveNoAsignado varchar(5),			@TituloMensaje varchar(100) = '',		@ComparteProveedor char(1),
		@EmpresaID int = null,					@SucursalID int = null,
		@Estatus bit
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'PpalProveedor',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@PpalProveedorID_ int,
		@EspPersonaID_ int,
		@CmpTipoProveedorID_ int,
		@AuxGiroEmpresaID_ int,
		@AuxMedioContactoID_ int = 0,
		@AuxVinculoID_ int = 0,
		@AplicaRetenciones_ char(1) = '',
		@PpalProveedorClave_ varchar(10)

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @PpalProveedorID

	-- actualiza en Persona
	EXEC @EspPersonaID = [dbo].[EspPersona_Guardar]
			@EspPersonaID = @EspPersonaID,
			@FisicaMoral = @FisicaMoral,
			@NombreComercial= @NombreComercial,
			@RazonSocial = @RazonSocial,
			@Nombre = @Nombre,
			@ApellidoPaterno = @ApellidoPaterno,
			@ApellidoMaterno = @ApellidoMaterno,
			@RFC = @RFC,
			@CURP = @CURP,
			@SexoID = @SexoID,
			@FechaNacimiento = @FechaNacimiento,
			@CiudadNacimientoID = @CiudadNacimientoID,
			@EstadoCivilID = @EstadoCivilID,
			@CasadoCivil = @CasadoCivil,
			@CasadoIglesia = @CasadoIglesia,
			@Iniciales = @Iniciales,
			@SobreNombre = @SobreNombre,
			@NombreCorto = @NombreCorto,
			@EspDomicilioIDFacturacion = 2
			,@UsuarioIDBitacora		= @UsuarioIDBitacora
			,@DescripcionBitacora	= @DescripcionBitacora
			,@IpAddress			= @IpAddress	
			,@HostName			= @HostName
			
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		-- Lee ClaveNoAsignado de Parámetros Cosmos
		SELECT	@ClaveNoAsignado = IsNull(ClaveNoAsignado,'')
		  FROM	SistemaParamCosmos;
		-- Lee Valores anteriores para Bitácora
		SELECT	
	 			@EspPersonaID_ = IsNull(EspPersonaID,0),
				@CmpTipoProveedorID_ = IsNull(CmpTipoProveedorID,0),
				@AuxGiroEmpresaID_ = IsNull(AuxGiroEmpresaID,0),
				@AuxMedioContactoID_ = IsNull(AuxMedioContactoID,0),
				@AuxVinculoID_ = IsNull(AuxVinculoID,0),
				@AplicaRetenciones_ = IsNull(AplicaRetenciones,''),
				@PpalProveedorID_ = IsNull(PpalProveedorID,0),
				@PpalProveedorClave_ = (SELECT PpalProveedorClave 
												FROM PpalProveedorEmpresaSucursal
												WHERE PpalProveedorID = @IDAActualizar
												AND PpalSucursalID = @SucursalID AND EmpresaID = @EmpresaID)
		   FROM	PpalProveedor WHERE PpalProveedorID = @IDAActualizar
		-- Si no se encontró registro a actualizar -> error
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar: ', @IDAActualizar);
		-- No se permite cambiar Clave cuando es igual a @ClaveNoAsignado
		IF @PpalProveedorClave_ = @ClaveNoAsignado and @PpalProveedorClave <> @ClaveNoAsignado
			SELECT @Errores = 999996, @Mensaje = CONCAT('No es permitido cambiar la clave ', @ClaveNoAsignado);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
	    BEGIN
        
		    UPDATE  PpalProveedor
			SET                    
                EspPersonaID = @EspPersonaID,
				CmpTipoProveedorID = @CmpTipoProveedorID,
				AuxGiroEmpresaID = @AuxGiroEmpresaID,
				AuxMedioContactoID = @AuxMedioContactoID,
				AuxVinculoID = @AuxVinculoID,
				AplicaRetenciones = @AplicaRetenciones
			 WHERE   PpalProveedorID = @IDAActualizar
		END
		ELSE
		BEGIN     
		
			INSERT  INTO PpalProveedor(					
					EspPersonaID,
					CmpTipoProveedorID,
					AuxGiroEmpresaID,
					AuxMedioContactoID,
					AuxVinculoID,
					AplicaRetenciones)
			VALUES  (
					
					@EspPersonaID,
					@CmpTipoProveedorID,
					@AuxGiroEmpresaID,
					@AuxMedioContactoID,
					@AuxVinculoID,
					@AplicaRetenciones)
        
		    SET		@IDAActualizar = SCOPE_IDENTITY()
		END
		IF @@RowCount > 0
		BEGIN
			select @ComparteProveedor = ComparteProveedor from CfgParamConfigUsuarioCosmos
			IF @ComparteProveedor = 'G'
				BEGIN        
					IF @PpalProveedorID > 0
						UPDATE	PpalProveedorEmpresaSucursal
						SET		PpalProveedorClave = @PpalProveedorClave
						WHERE	PpalProveedorID = @IDAActualizar
					ELSE
						INSERT  INTO PpalProveedorEmpresaSucursal(           
								PpalSucursalID,
								PpalProveedorID,
								PpalProveedorClave,
								Activo,
								EmpresaID)
						VALUES  (               
								@SucursalID,
								@IDAActualizar,
								@PpalProveedorClave,
								1,
								@EmpresaID)
				END

			IF @ComparteProveedor = 'E'
				BEGIN        
				INSERT  INTO PpalProveedorEmpresaSucursal(
                
						PpalSucursalID,
						PpalProveedorID,
						PpalProveedorClave,
						Activo,
						EmpresaID)
				VALUES  (
               
						@SucursalID,
						@IDAActualizar,
						@PpalProveedorClave,
						1,
						@EmpresaID)
				END

			IF @ComparteProveedor = 'S'
				BEGIN        
				INSERT  INTO PpalProveedorEmpresaSucursal(
                
						PpalSucursalID,
						PpalProveedorID,
						PpalProveedorClave,
						Activo,
						EmpresaID)
				VALUES  (
               
						@SucursalID,
						@IDAActualizar,
						@PpalProveedorClave,
						1,
						@EmpresaID)
				END
			
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @PpalProveedorID_ > 0  SET @Operacion = 'Update' 	
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
				SET @logMessage = Concat(@logMessage, 'PersonaID::', @EspPersonaID_, ':', @EspPersonaID, ';')
				SET @logMessage = Concat(@logMessage, 'CmpTipoProveedorID::', @CmpTipoProveedorID_, ':', @CmpTipoProveedorID, ';')
				SET @logMessage = Concat(@logMessage, 'GiroEmpresaID::', @AuxGiroEmpresaID_, ':', @AuxGiroEmpresaID, ';')
				SET @logMessage = Concat(@logMessage, 'MedioContactoID::', @AuxMedioContactoID_, ':', @AuxMedioContactoID, ';')
				SET @logMessage = Concat(@logMessage, 'VinculoID::', @AuxVinculoID_, ':', @AuxVinculoID, ';')
				SET @logMessage = Concat(@logMessage, 'AplicaRetenciones::', @AplicaRetenciones_, ':', @AplicaRetenciones, ';')
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