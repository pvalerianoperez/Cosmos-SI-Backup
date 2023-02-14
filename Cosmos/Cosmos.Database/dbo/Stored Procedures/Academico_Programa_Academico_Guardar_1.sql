CREATE PROCEDURE [dbo].[Academico_Programa_Academico_Guardar]

    @ProgramaAcademicoID    INT,
    @ProgramaAcademicoClave VARCHAR (6),
    @Nombre           VARCHAR (80),
    @NombreCorto      VARCHAR (15),
    @ExtraTexto1      VARCHAR (500),
    @ExtraTexto2      VARCHAR (500),
    @ExtraTexto3      VARCHAR (500),
    @ExtraFecha1      DATETIME,
    @ExtraFecha2      DATETIME

AS
SET NOCOUNT ON 

DECLARE @Errores bit, @Mensaje nvarchar(300)

BEGIN TRANSACTION 
BEGIN TRY
    IF EXISTS(SELECT ProgramaAcademicoID FROM AcProgramaAcademico WHERE ProgramaAcademicoID = @ProgramaAcademicoID)
    BEGIN
        UPDATE  AcProgramaAcademico
        SET     
				@ProgramaAcademicoClave = @ProgramaAcademicoClave,
				Nombre           = @Nombre,
				NombreCorto      = @NombreCorto,
				ExtraTexto1      = @ExtraTexto1,
				ExtraTexto2      = @ExtraTexto2,
				ExtraTexto3		 = @ExtraTexto3,
				ExtraFecha1		 = @ExtraFecha1,
				ExtraFecha2		 = @ExtraFecha2
        WHERE   ProgramaAcademicoID	 = ProgramaAcademicoID
    END
    ELSE
    BEGIN        
        INSERT  INTO AcProgramaAcademico(
				ProgramaAcademicoClave,
				Nombre,
				NombreCorto,
				ExtraTexto1,
				ExtraTexto2,
				ExtraTexto3,
				ExtraFecha1,
				ExtraFecha2
				)
        VALUES  (
				@ProgramaAcademicoClave,
				@Nombre,
				@NombreCorto,
				@ExtraTexto1,
				@ExtraTexto2,
				@ExtraTexto3,
				@ExtraFecha1,
				@ExtraFecha2
				)
        
        SET     @ProgramaAcademicoID = SCOPE_IDENTITY()
    END
    COMMIT TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
    SELECT @Errores = 1, @Mensaje = ERROR_MESSAGE()
END CATCH 

SELECT  COALESCE(@Errores, 0) as Errores, 
        COALESCE(@Mensaje, '') as Mensaje,
        @ProgramaAcademicoID as ProgramaAcademicoID