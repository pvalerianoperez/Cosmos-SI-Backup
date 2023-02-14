CREATE PROCEDURE [dbo].[Mensajeria_Comunica_ReporteEnvioMensaje_AddTableType]
	
	 @Cursor		int = 0
	,@TwoIntIDs		TableType_TwoIntIDs READONLY

AS

	INSERT INTO MsjComunicaReporteEnvioMensaje
	SELECT @Cursor, ReporteEnvioID, MensajeID
	FROM @TwoIntIDs

RETURN 0
