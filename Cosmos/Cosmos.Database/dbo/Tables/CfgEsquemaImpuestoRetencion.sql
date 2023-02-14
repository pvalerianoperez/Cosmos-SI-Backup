CREATE TABLE [dbo].[CfgEsquemaImpuestoRetencion] (
    [CfgEsquemaImpuestoRetencionID]    INT          IDENTITY (1, 1) NOT NULL,
    [CfgEsquemaImpuestoRetencionClave] VARCHAR (3)  NOT NULL,
    [Nombre]                           VARCHAR (50) NOT NULL,
    [NombreCorto]                      VARCHAR (10) NOT NULL,
    CONSTRAINT [PK_CfgEsquemaImpuestoRetencion] PRIMARY KEY CLUSTERED ([CfgEsquemaImpuestoRetencionID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CfgEsquemaImpuestoRetencion]
    ON [dbo].[CfgEsquemaImpuestoRetencion]([CfgEsquemaImpuestoRetencionClave] ASC);

