

CREATE PROCEDURE [dbo].[PpalProveedorEmpresaSucursal_Eliminar]
@PpalProveedorEmpresaSucursalID int

AS
		DELETE
		FROM    PpalProveedorEmpresaSucursal
		WHERE   PpalProveedorEmpresaSucursalID = @PpalProveedorEmpresaSucursalID