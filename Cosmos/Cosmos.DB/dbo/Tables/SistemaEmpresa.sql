CREATE TABLE [dbo].[SistemaEmpresa] (
    [EmpresaID]    INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]       VARCHAR (120) NOT NULL,
    [NombreCorto]  VARCHAR (20)  NOT NULL,
    [EmpresaClave] VARCHAR (6)   CONSTRAINT [DF_SistemaEmpresa_EmpresaClave] DEFAULT ('') NOT NULL,
    [EspPersonaID] INT           NOT NULL,
    CONSTRAINT [PK_SistemaEmpresa] PRIMARY KEY CLUSTERED ([EmpresaID] ASC)
);



