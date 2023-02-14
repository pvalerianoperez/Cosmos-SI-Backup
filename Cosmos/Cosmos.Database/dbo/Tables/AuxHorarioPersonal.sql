CREATE TABLE [dbo].[AuxHorarioPersonal] (
    [AuxHorarioPersonalID]    INT          IDENTITY (1, 1) NOT NULL,
    [AuxHorarioPersonalClave] VARCHAR (6)  NOT NULL,
    [EmpresaID]               INT          NOT NULL,
    [Nombre]                  VARCHAR (30) NOT NULL,
    [NombreCorto]             VARCHAR (10) NOT NULL,
    CONSTRAINT [PK_AuxHorarioPersonal] PRIMARY KEY CLUSTERED ([AuxHorarioPersonalID] ASC),
    CONSTRAINT [FK_HorarioPersonal_SistemaEmpresa] FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[SistemaEmpresa] ([EmpresaID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_HorarioPersonal_EmpresaID_HorarioPersonalClave]
    ON [dbo].[AuxHorarioPersonal]([EmpresaID] ASC, [AuxHorarioPersonalClave] ASC);

