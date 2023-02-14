CREATE TABLE [dbo].[AuxPuesto] (
    [AuxPuestoID]     INT           IDENTITY (1, 1) NOT NULL,
    [AuxPuestoClave]  VARCHAR (8)   NOT NULL,
    [Nombre]          VARCHAR (60)  NOT NULL,
    [NombreCorto]     VARCHAR (20)  NULL,
    [Sueldo]          MONEY         NOT NULL,
    [BaseNeto]        CHAR (1)      NOT NULL,
    [Tipo]            CHAR (1)      NOT NULL,
    [Objetivo]        VARCHAR (250) NOT NULL,
    [ReqAcademicos]   VARCHAR (100) NOT NULL,
    [TiempoDesempeno] TINYINT       NOT NULL,
    [EmpresaID]       INT           NOT NULL,
    CONSTRAINT [PK_Auxpuestos] PRIMARY KEY CLUSTERED ([AuxPuestoID] ASC),
    CONSTRAINT [FK_AuxPuesto_SistemaEmpresa] FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[SistemaEmpresa] ([EmpresaID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Puesto_PuestoClave]
    ON [dbo].[AuxPuesto]([AuxPuestoClave] ASC);

