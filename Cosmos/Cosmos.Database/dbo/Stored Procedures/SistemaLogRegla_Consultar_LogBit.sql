CREATE Procedure [dbo].[SistemaLogRegla_Consultar_LogBit]

	@UsuarioID		int,
	@TablaNombre	nvarchar(50),
	@Operacion		nvarchar(20) = 'prueba'

As

DECLARE	@C tinyInt,		@R tinyInt,		@U tinyInt,		@D tinyInt
BEGIN
	SET NOCOUNT ON;

	-- Lee el máximo de C, R, U y D para el (usuario indicado o todos los usuarios) y la (tabla indicada o todas las tablas)

	SELECT	@C = MAX(C), @R = MAX(R), @U = MAX(U), @D = MAX(D) FROM SegLogRegla
	 WHERE	(SegUsuarioID = @UsuarioID or SegUsuarioID is null) And 
			(TablaNombre = @TablaNombre or TablaNombre = '*')

	-- Si se encontró un permiso en la operación deseada, se regresa 1 y si no, se regresa 0
	IF	@C = 1 and @Operacion = 'Create' or
		@R = 1 and (@Operacion = 'Read' or @Operacion = 'List') or
		@U = 1 and @Operacion = 'Update' or
		@D = 1 and @Operacion = 'Delete'
		Return 1
	ELSE
		Return 0

END