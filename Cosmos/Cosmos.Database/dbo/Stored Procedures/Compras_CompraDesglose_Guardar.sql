

CREATE PROCEDURE Compras_CompraDesglose_Guardar
@ModificacionUsuarioID int = null,
@CompraDesgloseID int,
@CompraDetalleID int,
@RenglonID int,
@SucursalID int,
@CentroCostoID int,
@AreaID int,
@AlmacenID int,
@ConceptoEgresoID int,
@CuentaContableID int,
@Cantidad float,
@OrdenCompraDetalleID int
AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    IF EXISTS(SELECT CompraDesgloseID FROM CompraDesglose WHERE CompraDesgloseID = @CompraDesgloseID)
    BEGIN
        UPDATE  CompraDesglose
        SET     
                ModificacionUsuarioID = @ModificacionUsuarioID, 
                ModificacionFecha = GETDATE(),
                CompraDetalleID = @CompraDetalleID,
				RenglonID = @RenglonID,
				SucursalID = @SucursalID,
				CentroCostoID = @CentroCostoID,
				AreaID = @AreaID,
				AlmacenID = @AlmacenID,
				ConceptoEgresoID = @ConceptoEgresoID,
				CuentaContableID = @CuentaContableID,
				Cantidad = @Cantidad,
				OrdenCompraDetalleID = @OrdenCompraDetalleID
        WHERE   CompraDesgloseID = @CompraDesgloseID
    END
    ELSE
    BEGIN        
        INSERT  INTO CompraDesglose(
                AltaUsuarioID,
                AltaFecha,
                CompraDetalleID,
				RenglonID,
				SucursalID,
				CentroCostoID,
				AreaID,
				AlmacenID,
				ConceptoEgresoID,
				CuentaContableID,
				Cantidad,
				OrdenCompraDetalleID)
        VALUES  (
                @ModificacionUsuarioID,
                GETDATE(),
                @CompraDetalleID,
				@RenglonID,
				@SucursalID,
				@CentroCostoID,
				@AreaID,
				@AlmacenID,
				@ConceptoEgresoID,
				@CuentaContableID,
				@Cantidad,
				@OrdenCompraDetalleID)
        
        SET     @CompraDesgloseID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @CompraDesgloseID as CompraDesgloseID