CREATE TABLE [dbo].[CoTipoConstruccion] (
    [CoTipoConstruccionID]    INT          IDENTITY (1, 1) NOT NULL,
    [CoTipoConstruccionClave] VARCHAR (5)  NOT NULL,
    [Nombre]                  VARCHAR (50) NOT NULL,
    [NombreCorto]             VARCHAR (10) NOT NULL,
    CONSTRAINT [PK_CoTipoConstruccion] PRIMARY KEY CLUSTERED ([CoTipoConstruccionID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CoTipoConstruccion]
    ON [dbo].[CoTipoConstruccion]([CoTipoConstruccionClave] ASC);

