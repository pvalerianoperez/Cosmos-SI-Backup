
CREATE  PROCEDURE [dbo].[Compras_Sucursal_Guardar]
@ModificacionUsuarioID int = null,
@SucursalID int,
@SucursalClave varchar(8),
@Nombre varchar(70),
@NombreCorto varchar(10),
@EmpresaID int,
@DomicilioID int =0

AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)
SET @DomicilioID = NULLIF(@DomicilioID, 0)

BEGIN TRANSACTION 
BEGIN TRY
    IF EXISTS(SELECT SucursalID FROM Sucursal WHERE SucursalID = @SucursalID)
    BEGIN
        UPDATE  Sucursal
        SET     
                ModificacionUsuarioID = @ModificacionUsuarioID, 
                ModificacionFecha = GETDATE(),
                SucursalClave = @SucursalClave,
				Nombre = @Nombre,
				NombreCorto = @NombreCorto,
				EmpresaID = @EmpresaID,
				DomicilioID = @DomicilioID
        WHERE   SucursalID = @SucursalID
    END
    ELSE
    BEGIN        
        INSERT  INTO Sucursal(
                AltaUsuarioID,
                AltaFecha,
                SucursalClave,
				Nombre,
				NombreCorto,
				EmpresaID,
				DomicilioID)
        VALUES  (
                @ModificacionUsuarioID,
                GETDATE(),
                @SucursalClave,
				@Nombre,
				@NombreCorto,
				@EmpresaID,
				@DomicilioID)
        
        SET     @SucursalID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @SucursalID as SucursalID