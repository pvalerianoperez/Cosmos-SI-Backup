CREATE TABLE [dbo].[AcRvoe] (
    [RvoeID]          INT          IDENTITY (1, 1) NOT NULL,
    [RvoeClave]       VARCHAR (6)  NULL,
    [Nombre]          VARCHAR (80) NULL,
    [NombreCorto]     VARCHAR (15) NULL,
    [Registro]        VARCHAR (50) NULL,
    [FechaExpedicion] DATETIME     NULL,
    CONSTRAINT [PK_Rvoe] PRIMARY KEY CLUSTERED ([RvoeID] ASC)
);

