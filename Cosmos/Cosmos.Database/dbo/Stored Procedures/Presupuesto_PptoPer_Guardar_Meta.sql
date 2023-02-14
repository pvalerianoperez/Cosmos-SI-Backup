CREATE PROCEDURE [dbo].[Presupuesto_PptoPer_Guardar_Meta]
	@PptoDetID int,
	@ImporteTotal float,
	@IngresoEgreso varchar(1)
AS
	DECLARE @PeriodosCount float = 0;
	IF @IngresoEgreso = 'E' 
	BEGIN
		SELECT @PeriodosCount = Count(0) FROM PptoPerEgr WHERE PptoDetEgrID = @PptoDetID;
		UPDATE PptoPerEgr
		SET ImporteMeta = @ImporteTotal/@PeriodosCount
		WHERE @PptoDetID = PptoDetEgrID;
	END
	ELSE
	BEGIN
		SELECT @PeriodosCount = Count(0) FROM PptoPerIng WHERE PptoDetIngID = @PptoDetID;
		UPDATE PptoPerIng
		SET ImporteMeta = @ImporteTotal/@PeriodosCount
		WHERE @PptoDetID = PptoDetIngID;
	END
RETURN 0