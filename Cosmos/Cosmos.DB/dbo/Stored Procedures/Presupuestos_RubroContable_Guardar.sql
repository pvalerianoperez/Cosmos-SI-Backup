CREATE PROCEDURE [dbo].[Presupuestos_RubroContable_Guardar]
	@RubroContableID int,
	@TituloRubroID int,
	@Nombre varchar(60),
	@NombreCorto varchar(10),
	@PpalCuentaContableID int = null,
    @Usuario int
AS
	DECLARE @Errores bit, @Mensaje nvarchar(300)
	BEGIN TRANSACTION 
    BEGIN TRY
    IF EXISTS(SELECT TituloRubroID FROM RubroContable WHERE RubroContableID = @RubroContableID)
    BEGIN
        UPDATE  RubroContable
        SET     
                TituloRubroID = @TituloRubroID,
                Nombre = @Nombre, 
                NombreCorto = @NombreCorto,
                PpalCuentaContableID = @PpalCuentaContableID
                
        WHERE   RubroContableID = @RubroContableID
    END
    ELSE
    BEGIN        
        INSERT  INTO RubroContable(
                TituloRubroID,
                Nombre,
                NombreCorto,
                PpalCuentaContableID
                )
        VALUES  (
                @TituloRubroID,
                @Nombre, 
                @NombreCorto,
                @PpalCuentaContableID
               )
        
        SET     @RubroContableID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @RubroContableID as RubroContableID
RETURN 0