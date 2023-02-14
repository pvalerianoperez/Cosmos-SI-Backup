CREATE TABLE [dbo].[CfgEsquemaImpuestoRetencionDetalle] (
    [CfgEsquemaImpuestoRetencionDetalleID] INT            IDENTITY (1, 1) NOT NULL,
    [CfgEsquemaImpuestoRetencionID]        INT            NOT NULL,
    [CfgImpuestoRetencionID]               INT            NOT NULL,
    [Porcentaje]                           DECIMAL (9, 6) NOT NULL,
    [Activo]                               CHAR (1)       NOT NULL,
    CONSTRAINT [PK_CfgEsquemaImpuestoRetencionDetalle] PRIMARY KEY CLUSTERED ([CfgEsquemaImpuestoRetencionDetalleID] ASC),
    CONSTRAINT [FK_CfgEsquemaImpuestoRetencionDetalle_CfgEsquemaImpuestoRetencion] FOREIGN KEY ([CfgEsquemaImpuestoRetencionID]) REFERENCES [dbo].[CfgEsquemaImpuestoRetencion] ([CfgEsquemaImpuestoRetencionID]),
    CONSTRAINT [FK_CfgEsquemaImpuestoRetencionDetalle_CfgImpuestoRetencion] FOREIGN KEY ([CfgImpuestoRetencionID]) REFERENCES [dbo].[CfgImpuestoRetencion] ([CfgImpuestoRetencionID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CfgEsquemaImpuestoRetencionDetalle]
    ON [dbo].[CfgEsquemaImpuestoRetencionDetalle]([CfgEsquemaImpuestoRetencionID] ASC, [CfgImpuestoRetencionID] ASC);

