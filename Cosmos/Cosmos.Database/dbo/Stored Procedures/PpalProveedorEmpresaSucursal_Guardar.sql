

CREATE PROCEDURE [dbo].[PpalProveedorEmpresaSucursal_Guardar]
@ModificacionUsuarioID int = null,
@PpalProveedorEmpresaSucursalID int,
@PpalSucursalID int,
@PpalProveedorID int,
@PpalProveedorClave varchar(10),
@Activo bit,
@EmpresaID int

AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    IF EXISTS(SELECT PpalProveedorEmpresaSucursalID FROM PpalProveedorEmpresaSucursal WHERE PpalProveedorEmpresaSucursalID = @PpalProveedorEmpresaSucursalID)
    BEGIN
        UPDATE  PpalProveedorEmpresaSucursal
        SET     
                
                PpalSucursalID = @PpalSucursalID,
				PpalProveedorID = @PpalProveedorID,
				PpalProveedorClave = @PpalProveedorClave,
				Activo = @Activo,
				EmpresaID = @EmpresaID
        WHERE   PpalProveedorEmpresaSucursalID = @PpalProveedorEmpresaSucursalID
    END
    ELSE
    BEGIN        
        INSERT  INTO PpalProveedorEmpresaSucursal(
                
                PpalSucursalID,
				PpalProveedorID,
				PpalProveedorClave,
				Activo,
				EmpresaID)
        VALUES  (
               
                @PpalSucursalID,
				@PpalProveedorID,
				@PpalProveedorClave,
				@Activo,
				@EmpresaID)
        
        SET     @PpalProveedorEmpresaSucursalID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @PpalProveedorEmpresaSucursalID as ProveedorEmpresaSucursalID