

CREATE PROCEDURE [dbo].[PpalRepresentanteProveedor_Guardar]
@PpalRepresentanteProveedorID int,
@PpalProveedorID int,
@PersonaID int,
@ProfesionID int,
@CmpTipoRepresentanteProveedorID int,
@Predeterminado bit,
@Puesto varchar(60),
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
@NombreCorto varchar(25)
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora	varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(500) = '', @IDAActualizar int, @ClaveNoAsignado varchar(5)
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'PpalRepresentanteProveedor',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@PpalRepresentanteProveedorID_ int,
		@PpalProveedorID_ int,
		@PersonaID_ int,
		@ProfesionID_ int,
		@CmpTipoRepresentanteProveedorID_ int,
		@Predeterminado_ bit,
		@Puesto_ varchar(60)

SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @PpalRepresentanteProveedorID

	-- actualiza en Persona
	EXEC @PersonaID = [dbo].[EspPersona_Guardar] 
			@PersonaID = @PersonaID,
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
			@NombreCorto = @NombreCorto
			,@UsuarioIDBitacora = @UsuarioIDBitacora
			,@DescripcionBitacora		= @DescripcionBitacora
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
	 			@PpalProveedorID_ = IsNull(PpalProveedorID,0),
				@PersonaID_ = IsNull(EspPersonaID,0),
				@ProfesionID_ = IsNull(ProfesionID,0),
				@CmpTipoRepresentanteProveedorID_ = IsNull(CmpTipoRepresentanteProveedorID,0),
				@Predeterminado_ = IsNull(Predeterminado,0),
				@Puesto_ = IsNull(Puesto,'')
		   FROM	PpalRepresentanteProveedor WHERE PpalRepresentanteProveedorID = @IDAActualizar
		-- Si no se encontró registro a actualizar -> error
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar: ', @IDAActualizar);
		--No se permite cambiar Clave cuando es igual a @ClaveNoAsignado
		IF @PpalRepresentanteProveedorID_ = @ClaveNoAsignado and @PpalRepresentanteProveedorID <> @ClaveNoAsignado
			SELECT @Errores = 999996, @Mensaje = CONCAT('No es permitido cambiar la clave ', @ClaveNoAsignado);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
		BEGIN
			UPDATE  PpalRepresentanteProveedor
			SET     
					PpalProveedorID = @PpalProveedorID,
					EspPersonaID = @PersonaID,
					ProfesionID = @ProfesionID,
					CmpTipoRepresentanteProveedorID = @CmpTipoRepresentanteProveedorID,
					Predeterminado = @Predeterminado,
					Puesto = @Puesto
			WHERE   PpalRepresentanteProveedorID = @PpalRepresentanteProveedorID
		END
		ELSE
		BEGIN        
			INSERT  INTO PpalRepresentanteProveedor(
                
					PpalProveedorID,
					EspPersonaID,
					ProfesionID,
					CmpTipoRepresentanteProveedorID,
					Predeterminado,
					Puesto)
			VALUES  (
               
					@PpalProveedorID,
					@PersonaID,
					@ProfesionID,
					@CmpTipoRepresentanteProveedorID,
					@Predeterminado,
					@Puesto)
        
        SET     @PpalRepresentanteProveedorID = SCOPE_IDENTITY()
    END
		IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @PpalRepresentanteProveedorID_ > 0  SET @Operacion = 'Update' 	
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
				SET @logMessage = Concat(@logMessage, 'PersonaID::', @PersonaID_, ':', @PersonaID, ';')
				SET @logMessage = Concat(@logMessage, 'PpalProveedorID::', @PpalProveedorID_, ':', @PpalProveedorID, ';')
				SET @logMessage = Concat(@logMessage, 'ProfesionID::', @ProfesionID_, ':', @ProfesionID, ';')
				SET @logMessage = Concat(@logMessage, 'CmpTipoRepresentanteProveedorID::', @CmpTipoRepresentanteProveedorID_, ':', @CmpTipoRepresentanteProveedorID, ';')
				SET @logMessage = Concat(@logMessage, 'Preterminado::', @Predeterminado_, ':', @Predeterminado, ';')
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