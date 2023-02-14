CREATE TABLE [dbo].[CfgTipoHorario] (
    [CfgTipoHorarioID]    INT          IDENTITY (1, 1) NOT NULL,
    [CfgTipoHorarioClave] VARCHAR (10) NOT NULL,
    [Nombre]              VARCHAR (30) NOT NULL,
    [NombreCorto]         VARCHAR (10) NOT NULL,
    [EmpresaID]           INT          NOT NULL,
    [Homogeneo]           CHAR (1)     NOT NULL,
    CONSTRAINT [PK_CfgTipoHorario] PRIMARY KEY CLUSTERED ([CfgTipoHorarioID] ASC),
    CONSTRAINT [FK_CfgTipoHorario_SistemaEmpresa] FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[SistemaEmpresa] ([EmpresaID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_TipoHorario_EmpresaID_TipoHorarioClave]
    ON [dbo].[CfgTipoHorario]([EmpresaID] ASC, [CfgTipoHorarioClave] ASC);

