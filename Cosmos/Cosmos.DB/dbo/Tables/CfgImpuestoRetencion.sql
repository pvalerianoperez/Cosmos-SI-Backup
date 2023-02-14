CREATE TABLE [dbo].[CfgImpuestoRetencion] (
    [CfgImpuestoRetencionID]    INT          IDENTITY (1, 1) NOT NULL,
    [CfgImpuestoRetencionClave] VARCHAR (6)  NOT NULL,
    [Nombre]                    VARCHAR (60) NOT NULL,
    [NombreCorto]               VARCHAR (10) NOT NULL,
    [ImpuestoRetencion]         CHAR (1)     NOT NULL,
    CONSTRAINT [PK_CfgImpuestoRetencion] PRIMARY KEY CLUSTERED ([CfgImpuestoRetencionID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CfgImpuestoRetencionClave]
    ON [dbo].[CfgImpuestoRetencion]([CfgImpuestoRetencionClave] ASC);

