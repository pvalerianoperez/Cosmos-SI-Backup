CREATE TABLE [dbo].[AuxGiroEmpresa] (
    [AuxGiroEmpresaID]    INT          IDENTITY (1, 1) NOT NULL,
    [AuxGiroEmpresaClave] VARCHAR (6)  NOT NULL,
    [Nombre]              VARCHAR (60) NOT NULL,
    [NombreCorto]         VARCHAR (20) NULL,
    CONSTRAINT [PK_AuxGiroEmpresaID] PRIMARY KEY CLUSTERED ([AuxGiroEmpresaID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_GiroEmpresa_GiroEmpresaClave]
    ON [dbo].[AuxGiroEmpresa]([AuxGiroEmpresaClave] ASC);

