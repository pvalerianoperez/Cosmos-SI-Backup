CREATE PROCEDURE [dbo].[Presupuestos_TituloRubro_Guardar]
	@TituloRubroID int,
    @TituloRubroClave varchar(6),
	@Nombre varchar(60),
	@NombreCorto varchar(10),
    @CalculoRemanente bit,
    @NaturalezaID int,
    @Usuario int = null,
	@EmpresaID int,
	@EjercicioOperativoID int,
	@Egreso_o_ingreso varchar
AS
	DECLARE @Errores bit, @Mensaje nvarchar(300)
	BEGIN TRANSACTION 
    BEGIN TRY
    IF EXISTS(SELECT TituloRubroID FROM TituloRubro WHERE TituloRubroID = @TituloRubroID)
    BEGIN
        UPDATE  TituloRubro
        SET     
                TituloRubroClave = @TituloRubroClave,
                Nombre = @Nombre, 
                NombreCorto = @NombreCorto,
                CalculoRemanente = @CalculoRemanente,
                NaturalezaID = @NaturalezaID,
                EmpresaID = @EmpresaID,
				CfgEjercicioOperativoID = @EjercicioOperativoID,
                Ingreso_o_Egreso = @Egreso_o_ingreso
        WHERE   TituloRubroID = @TituloRubroID
    END
    ELSE
    BEGIN        
        INSERT  INTO TituloRubro(
                TituloRubroClave,
                Nombre,
                NombreCorto,
                CalculoRemanente,
                NaturalezaID,
                EmpresaID,
				CfgEjercicioOperativoID,
				Ingreso_o_Egreso)
        VALUES  (
                @TituloRubroClave,
                @Nombre, 
                @NombreCorto,
                @CalculoRemanente,
                @NaturalezaID,
                @EmpresaID,
				@EjercicioOperativoID,
                @Egreso_o_ingreso)
        
        SET     @TituloRubroID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @TituloRubroID as TituloRubroID
RETURN 0