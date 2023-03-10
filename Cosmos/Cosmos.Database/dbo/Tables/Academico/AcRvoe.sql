CREATE TABLE [dbo].[AcRvoe] (
    [RvoeID]          INT          NOT NULL IDENTITY,
    [RvoeClave]       VARCHAR (6)  NULL,
    [Nombre]          VARCHAR (80) NULL,
    [NombreCorto]     VARCHAR (15) NULL,
    [Registro]            VARCHAR (50) NULL,
    [FechaExpedicion] DATETIME     NULL,
    CONSTRAINT [PK_Rvoe] PRIMARY KEY CLUSTERED ([RvoeID] ASC)
);

