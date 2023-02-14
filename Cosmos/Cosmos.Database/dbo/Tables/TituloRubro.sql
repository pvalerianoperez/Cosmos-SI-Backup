CREATE TABLE [dbo].[TituloRubro] (
    [TituloRubroID]           INT          IDENTITY (1, 1) NOT NULL,
    [TituloRubroClave]        VARCHAR (6)  NOT NULL,
    [Nombre]                  VARCHAR (60) NOT NULL,
    [NombreCorto]             VARCHAR (10) NOT NULL,
    [CalculoRemanente]        BIT          NOT NULL,
    [NaturalezaID]            INT          NOT NULL,
    [EmpresaID]               INT          NOT NULL,
    [CfgEjercicioOperativoID] INT          NOT NULL,
    [Ingreso_o_Egreso]        VARCHAR (1)  NOT NULL,
    CONSTRAINT [PK_TìtuloRubro] PRIMARY KEY CLUSTERED ([TituloRubroID] ASC),
    CONSTRAINT [CK_TìtuloRubro_Ingreso_o_Egreso] CHECK ([Ingreso_o_Egreso]='I' OR [Ingreso_o_Egreso]='E'),
    CONSTRAINT [FK_TìtuloRubro_CfgEjercicioOperativo] FOREIGN KEY ([CfgEjercicioOperativoID]) REFERENCES [dbo].[CfgEjercicioOperativo] ([CfgEjercicioOperativoID]),
    CONSTRAINT [FK_TìtuloRubro_Empresa] FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[SistemaEmpresa] ([EmpresaID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_TituloRubro_EmpresaID_TituloRubroClave]
    ON [dbo].[TituloRubro]([EmpresaID] ASC, [TituloRubroClave] ASC);

