CREATE TABLE [dbo].[CalRecurso] (
    [UniqueID]            INT            IDENTITY (1, 1) NOT NULL,
    [RecursoID]           INT            NOT NULL,
    [RecursoNombre]       NVARCHAR (50)  NULL,
    [Color]               INT            NULL,
    [ImagenUrl]           NVARCHAR (300) NULL,
    [CampoPersonalizado1] NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([UniqueID] ASC)
);

