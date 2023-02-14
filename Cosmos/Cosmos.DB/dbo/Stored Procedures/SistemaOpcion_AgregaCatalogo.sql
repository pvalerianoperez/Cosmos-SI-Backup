

CREATE PROCEDURE [dbo].[SistemaOpcion_AgregaCatalogo]
@ModuloNombre nvarchar(50),
@OpcionNombre nvarchar(50), 
@OpcionURL nvarchar(150)
AS
SET NOCOUNT ON 

DECLARE @ModuloID int, @OpcionCatalogosID int, @OpcionID int
--DECLARE @ModuloNombre nvarchar(50), @OpcionNombre nvarchar(50), @OpcionURL nvarchar(150)
--SET @ModuloNombre = 'Compras'

SELECT @ModuloID = ModuloID FROM SistemaModulo WHERE Nombre = @ModuloNombre
SET @ModuloID = COALESCE(@ModuloID, 0)
IF @ModuloID = 0
BEGIN
	INSERT INTO SistemaModulo(Nombre)VALUES(@ModuloNombre)
	SET @ModuloID = SCOPE_IDENTITY();
END
SELECT @OpcionCatalogosID = OpcionID FROM SistemaOpcion WHERE ModuloID = @ModuloID AND Nombre = 'Catálogos'
SET @OpcionCatalogosID = COALESCE(@OpcionCatalogosID, 0)
IF @OpcionCatalogosID = 0
BEGIN
	INSERT INTO SistemaOpcion(ModuloID, Nombre, Activo, Protegido, VisibleMenu)VALUES(@ModuloID, 'Catálogos', 1, 1, 1)
	SET @OpcionCatalogosID = SCOPE_IDENTITY();
END
SELECT @OpcionID = OpcionID FROM SistemaOpcion WHERE PadreID = @OpcionCatalogosID AND Nombre = @OpcionNombre
SET @OpcionID = COALESCE(@OpcionID, 0)
IF @OpcionID = 0
BEGIN
	INSERT INTO SistemaOpcion(ModuloID, PadreID, Nombre, RecursoWebsite, Activo, Protegido, VisibleMenu)
	VALUES(@ModuloID, @OpcionCatalogosID, @OpcionNombre, @OpcionURL, 1, 1, 1)
	SET @OpcionID = SCOPE_IDENTITY();
END
ELSE
BEGIN
	UPDATE	SistemaOpcion
	SET		RecursoWebsite = @OpcionURL, 
			ModuloID = @ModuloID
	WHERE	OpcionID = @OpcionID
END

IF NOT EXISTS(SELECT OpcionID FROM SistemaOpcionTipoOpcion WHERE OpcionID = @OpcionID AND TipoOpcionID = 1)
BEGIN
	INSERT INTO SistemaOpcionTipoOpcion(OpcionID, TipoOpcionID) VALUES(@OpcionID, 1)
END

SET NOCOUNT OFF