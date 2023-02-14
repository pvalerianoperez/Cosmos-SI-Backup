CREATE TABLE [dbo].[CoPartidaGeneral] (
    [CoPartidaGeneralID]         INT          IDENTITY (1, 1) NOT NULL,
    [PadreID]                    INT          NULL,
    [CoPartidaGeneralClave]      VARCHAR (5)  NOT NULL,
    [Nombre]                     VARCHAR (40) NOT NULL,
    [NombreCorto]                VARCHAR (10) NOT NULL,
    [PpalAreaIDInicio]           INT          DEFAULT ((0)) NOT NULL,
    [PpalConceptoEgresoIDInicio] INT          DEFAULT ((0)) NOT NULL,
    [AplicaIVA]                  CHAR (1)     NOT NULL,
    [CoTipoConstruccionID]       INT          NOT NULL,
    CONSTRAINT [PKCoPartidaGeneral] PRIMARY KEY CLUSTERED ([CoPartidaGeneralID] ASC),
    CONSTRAINT [FK_CoPartidaGeneral_ConceptoEgreso] FOREIGN KEY ([PpalConceptoEgresoIDInicio]) REFERENCES [dbo].[PpalConceptoEgreso] ([PpalConceptoEgresoID]),
    CONSTRAINT [FK_CoPartidaGeneral_CoPartidaGeneral] FOREIGN KEY ([PadreID]) REFERENCES [dbo].[CoPartidaGeneral] ([CoPartidaGeneralID]),
    CONSTRAINT [FK_CoPartidaGeneral_CoTipoConstruccion] FOREIGN KEY ([CoTipoConstruccionID]) REFERENCES [dbo].[CoTipoConstruccion] ([CoTipoConstruccionID]),
    CONSTRAINT [FK_CoPartidaGeneral_PpalArea] FOREIGN KEY ([PpalAreaIDInicio]) REFERENCES [dbo].[PpalArea] ([PpalAreaID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CoPartidaGeneral]
    ON [dbo].[CoPartidaGeneral]([CoPartidaGeneralClave] ASC);

