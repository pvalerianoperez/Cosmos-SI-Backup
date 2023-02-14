CREATE TABLE [dbo].[PpalPersonal] (
    [PpalPersonalID]         INT          IDENTITY (1, 1) NOT NULL,
    [PpalPersonalClave]      VARCHAR (10) NOT NULL,
    [EmpresaID]              INT          NOT NULL,
    [AuxPuestoID]            INT          NOT NULL,
    [ReportaAPpalPersonalID] INT          NOT NULL,
    [PpalAreaID]             INT          NOT NULL,
    [PpalCentroCostoID]      INT          NOT NULL,
    [AuxHorarioPersonalID]   INT          NOT NULL,
    [CfgEstatusPersonalID]   INT          NOT NULL,
    [EspPersonaID]           INT          NOT NULL,
    CONSTRAINT [PK_PpalPersonal] PRIMARY KEY CLUSTERED ([PpalPersonalID] ASC),
    CONSTRAINT [FK_PpalPersonal_AuxHorarioPersonal] FOREIGN KEY ([AuxHorarioPersonalID]) REFERENCES [dbo].[AuxHorarioPersonal] ([AuxHorarioPersonalID]),
    CONSTRAINT [FK_PpalPersonal_AuxPuesto] FOREIGN KEY ([AuxPuestoID]) REFERENCES [dbo].[AuxPuesto] ([AuxPuestoID]),
    CONSTRAINT [FK_PpalPersonal_CfgEstatusPersonal] FOREIGN KEY ([CfgEstatusPersonalID]) REFERENCES [dbo].[CfgEstatusPersonal] ([CfgEstatusPersonalID]),
    CONSTRAINT [FK_PpalPersonal_Persona] FOREIGN KEY ([EspPersonaID]) REFERENCES [dbo].[EspPersona] ([EspPersonaID]),
    CONSTRAINT [FK_PpalPersonal_PpalArea] FOREIGN KEY ([PpalAreaID]) REFERENCES [dbo].[PpalArea] ([PpalAreaID]),
    CONSTRAINT [FK_PpalPersonal_PpalCentroCosto] FOREIGN KEY ([PpalCentroCostoID]) REFERENCES [dbo].[PpalCentroCosto] ([PpalCentroCostoID]),
    CONSTRAINT [FK_PpalPersonal_SistemaEmpresa] FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[SistemaEmpresa] ([EmpresaID])
);

