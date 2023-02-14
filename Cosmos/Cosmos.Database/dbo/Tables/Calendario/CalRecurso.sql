CREATE TABLE [dbo].[CalRecurso]
(
	[UniqueID]		INT NOT NULL PRIMARY KEY IDENTITY, 
    [RecursoID]		INT NOT NULL,
    [RecursoNombre] NVARCHAR (50)  NULL,
    [Color]			INT            NULL,
    [ImagenUrl]     NVARCHAR (300) NULL,
    [CampoPersonalizado1] NVARCHAR (MAX) NULL,
)
