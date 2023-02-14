

CREATE PROCEDURE [dbo].[EspDomicilio_Guardar]
@DomicilioID int,
@Calle varchar(50),
@NumeroExterior varchar(20),
@NumeroInterior varchar(20),
@EntreCalle1 varchar(40),
@EntreCalle2 varchar(40),
@CodigoPostal int,
@ColoniaID int,
@Coordenadas varchar(40) = null,
@CiudadID int,
@Observaciones varchar(100)
-- Parámetros para Bitácora
	,@UsuarioIDBitacora		int
	,@DescripcionBitacora		varchar(500)	= null
	,@IpAddress			varchar(40)		= null
	,@HostName			varchar(50)		= null
AS
-- Variables para manejo de Errores
DECLARE @Errores int = 0, @Mensaje nvarchar(500) = '', @IDAActualizar int, @ClaveNoAsignado varchar(5)
-- Variables para Bitácora
DECLARE @TablaNombreIDBitacora   nvarchar(100) = 'EspDomicilio',	
		@Operacion	nvarchar(20) = '', 
		@logMessage	varchar(Max) = '',
		@isChangeBeLogged bit
-- Variables para valores anteriores (Bitácora Update) 
DECLARE	@Calle_ varchar(50)='',
	 	@NumeroExterior_ varchar(20)='',
		@NumeroInterior_ varchar(20)='',
		@EntreCalle1_ varchar(40)='',
		@EntreCalle2_ varchar(40)='',
		@CodigoPostal_ int=0,
		@ColoniaID_ int=0,
		@Coordenadas_ varchar(40)='',
		@CiudadID_ int=0,
		@Observaciones_ varchar(100)='',
		@DomicilioID_ int = @DomicilioID
		 
SET NOCOUNT ON 
SET XACT_ABORT ON;
BEGIN TRY
	BEGIN TRANSACTION

	SET @IDAActualizar = @DomicilioID
	-- Si es UPDATE -> Lee valores anteriores de las columnas (Bitácora Update) 
	IF @IDAActualizar > 0
	BEGIN
		-- Lee ClaveNoAsignado de Parámetros Cosmos
		SELECT	@ClaveNoAsignado = IsNull(ClaveNoAsignado,'')
		  FROM	SistemaParamCosmos;
		-- Lee Valores anteriores para Bitácora
		SELECT	@Calle_ = IsNull(Calle,''),
	 			@NumeroExterior_ = IsNull(NumeroExterior,''),
				@NumeroInterior_ = IsNull(NumeroInterior,''),
				@EntreCalle1_ = IsNull(EntreCalle1,''),
				@EntreCalle2_ = IsNull(EntreCalle2,''),
				@CodigoPostal_ = IsNull(CodigoPostal,0),
				@ColoniaID_ = IsNull(EspColoniaID,0),
				@Coordenadas_ = IsNull(Coordenadas,''),
				@CiudadID_ = IsNull(EspCiudadID,0),
				@Observaciones_ = IsNull(Observaciones,''),
				@DomicilioID_ = IsNull(EspDomicilioID,0)
		   FROM	EspDomicilio WHERE EspDomicilioID = @IDAActualizar
		-- Si no se encontró registro a actualizar -> error
		IF @@RowCount = 0
			SELECT @Errores = 999999, @Mensaje = CONCAT('No se encontró el ID a Actualizar: ', @IDAActualizar);
		-- No se permite cambiar Clave cuando es igual a @ClaveNoAsignado
		--IF @PpalAreaClave_ = @ClaveNoAsignado and @PpalAreaClave <> @ClaveNoAsignado
		--	SELECT @Errores = 999996, @Mensaje = CONCAT('No es permitido cambiar la clave ', @ClaveNoAsignado);
	END
	-- Si no hubo error (es INSERT o es UPDATE y existe el registro)
	IF @Errores = 0
	BEGIN
		-- Si la llave existe hace UPDATE y si no, hace INSERT
		IF @IDAActualizar > 0
		BEGIN
			UPDATE  EspDomicilio
			SET     Calle =				@Calle,
					NumeroExterior =	@NumeroExterior,
					NumeroInterior =	@NumeroInterior,
					EntreCalle1 =		@EntreCalle1,
					EntreCalle2 =		@EntreCalle2,
					CodigoPostal =		@CodigoPostal,
					EspColoniaID =		@ColoniaID,
					Coordenadas =		@Coordenadas,
					EspCiudadID =		@CiudadID,
					Observaciones =		@Observaciones
			WHERE   EspDomicilioID =	@DomicilioID
		END
		ELSE
		BEGIN        
			INSERT  INTO EspDomicilio(
					Calle,
					NumeroExterior,
					NumeroInterior,
					EntreCalle1,
					EntreCalle2,
					CodigoPostal,
					EspColoniaID,
					Coordenadas,
					EspCiudadID,
					Observaciones)
			VALUES  (
					@Calle,
					@NumeroExterior,
					@NumeroInterior,
					@EntreCalle1,
					@EntreCalle2,
					@CodigoPostal,
					@ColoniaID,
					@Coordenadas,
					@CiudadID,
					@Observaciones)
        
			SET     @DomicilioID = SCOPE_IDENTITY()
    END
	IF @@RowCount > 0
		BEGIN
			/* Procesa Bitácora */
			-- Determina si fue UPDATE o INSERT
			IF @DomicilioID_ > 0  SET @Operacion = 'Update' 	
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
				SET @logMessage = Concat('Calle::', @Calle_, ':', @Calle, ';')
				SET @logMessage = Concat(@logMessage, 'NumeroExterior::', @NumeroExterior_, ':', @NumeroExterior, ';')
				SET @logMessage = Concat(@logMessage, 'NumeroInterior::', @NumeroInterior_, ':', @NumeroInterior, ';')
				SET @logMessage = Concat(@logMessage, 'EntreCalle1::', @EntreCalle1_, ':', @EntreCalle1, ';')
				SET @logMessage = Concat(@logMessage, 'EntreCalle2::', @EntreCalle2_, ':', @EntreCalle2, ';')

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
		@DomicilioID as GuardarID