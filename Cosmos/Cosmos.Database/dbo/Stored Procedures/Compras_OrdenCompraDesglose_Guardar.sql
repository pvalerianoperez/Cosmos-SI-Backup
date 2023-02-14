

CREATE PROCEDURE Compras_OrdenCompraDesglose_Guardar
@ModificacionUsuarioID int = null,
@OrdenCompraDesgloseID int,
@OrdenCompraDetalleID int,
@RenglonID int,
@SucursalID int,
@CentroCostoID int,
@AreaID int,
@AlmacenID int,
@ConceptoEgresoID int,
@CuentaContableID int,
@Cantidad float,
@RequisicionDetalleID int
AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    IF EXISTS(SELECT OrdenCompraDesgloseID FROM OrdenCompraDesglose WHERE OrdenCompraDesgloseID = @OrdenCompraDesgloseID)
    BEGIN
        UPDATE  OrdenCompraDesglose
        SET     
                ModificacionUsuarioID = @ModificacionUsuarioID, 
                ModificacionFecha = GETDATE(),
                OrdenCompraDetalleID = @OrdenCompraDetalleID,
				RenglonID = @RenglonID,
				SucursalID = @SucursalID,
				CentroCostoID = @CentroCostoID,
				AreaID = @AreaID,
				AlmacenID = @AlmacenID,
				ConceptoEgresoID = @ConceptoEgresoID,
				CuentaContableID = @CuentaContableID,
				Cantidad = @Cantidad,
				RequisicionDetalleID = @RequisicionDetalleID
        WHERE   OrdenCompraDesgloseID = @OrdenCompraDesgloseID
    END
    ELSE
    BEGIN        
        INSERT  INTO OrdenCompraDesglose(
                AltaUsuarioID,
                AltaFecha,
                OrdenCompraDetalleID,
				RenglonID,
				SucursalID,
				CentroCostoID,
				AreaID,
				AlmacenID,
				ConceptoEgresoID,
				CuentaContableID,
				Cantidad,
				RequisicionDetalleID)
        VALUES  (
                @ModificacionUsuarioID,
                GETDATE(),
                @OrdenCompraDetalleID,
				@RenglonID,
				@SucursalID,
				@CentroCostoID,
				@AreaID,
				@AlmacenID,
				@ConceptoEgresoID,
				@CuentaContableID,
				@Cantidad,
				@RequisicionDetalleID)
        
        SET     @OrdenCompraDesgloseID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @OrdenCompraDesgloseID as OrdenCompraDesgloseID