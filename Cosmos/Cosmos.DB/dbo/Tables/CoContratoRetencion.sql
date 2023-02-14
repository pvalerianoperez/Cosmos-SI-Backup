CREATE TABLE [dbo].[CoContratoRetencion] (
    [CoContratoRetencionID]         INT            IDENTITY (1, 1) NOT NULL,
    [CoContratoRetencionClave]      VARCHAR (10)   NOT NULL,
    [Nombre]                        VARCHAR (50)   NOT NULL,
    [NombreCorto]                   VARCHAR (10)   NOT NULL,
    [CoContratoID]                  INT            NOT NULL,
    [TipoRetencion]                 CHAR (1)       NOT NULL,
    [Porcentaje]                    DECIMAL (5, 2) NOT NULL,
    [EstimacionInicialAmortizacion] SMALLINT       NOT NULL,
    [EstimacionFinalAmortizacion]   SMALLINT       NOT NULL,
    [TipoAmortizacion]              CHAR (1)       NOT NULL,
    [PorcentajeInicialAmortizacion] DECIMAL (5, 2) NOT NULL,
    [PorcentajeFinalAmortizacion]   DECIMAL (5, 2) NOT NULL,
    CONSTRAINT [PK_CoContratoRetencion] PRIMARY KEY CLUSTERED ([CoContratoRetencionID] ASC),
    CONSTRAINT [FK_CoContratoRetencion_CoContrato] FOREIGN KEY ([CoContratoID]) REFERENCES [dbo].[CoContrato] ([CoContratoID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CoContratoRetencion_CoContratoID_CoContratoRetencionClave]
    ON [dbo].[CoContratoRetencion]([CoContratoID] ASC, [CoContratoRetencionClave] ASC);

