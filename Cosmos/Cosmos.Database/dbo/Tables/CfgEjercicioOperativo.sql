CREATE TABLE [dbo].[CfgEjercicioOperativo] (
    [CfgEjercicioOperativoID] INT          IDENTITY (1, 1) NOT NULL,
    [CfgEjercicioClave]       VARCHAR (4)  NOT NULL,
    [Nombre]                  VARCHAR (20) NOT NULL,
    [NombreCorto]             VARCHAR (10) NOT NULL,
    [EmpresaID]               INT          NOT NULL,
    CONSTRAINT [PK_CfgEjercicioOperativo] PRIMARY KEY CLUSTERED ([CfgEjercicioOperativoID] ASC),
    CONSTRAINT [FK_CfgEjercicioOperativo_SistemaEmpresa] FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[SistemaEmpresa] ([EmpresaID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_EjercicioOperativo_EmpresaID_EjercicioClave]
    ON [dbo].[CfgEjercicioOperativo]([EmpresaID] ASC, [CfgEjercicioClave] ASC);

