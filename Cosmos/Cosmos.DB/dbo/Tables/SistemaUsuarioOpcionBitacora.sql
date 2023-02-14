CREATE TABLE [dbo].[SistemaUsuarioOpcionBitacora] (
    [UsuarioOpcionBitacoraID] INT      IDENTITY (1, 1) NOT NULL,
    [SegUsuarioID]            INT      NOT NULL,
    [Fecha]                   DATETIME NOT NULL,
    [EmpresaID]               INT      NOT NULL,
    [ModuloID]                INT      NOT NULL,
    [OpcionID]                INT      NOT NULL,
    CONSTRAINT [PK_SistemaUsuarioOpcionBitacora] PRIMARY KEY CLUSTERED ([UsuarioOpcionBitacoraID] ASC),
    CONSTRAINT [FK_SistemaUsuarioOpcionBitacora_SistemaEmpresa] FOREIGN KEY ([EmpresaID]) REFERENCES [dbo].[SistemaEmpresa] ([EmpresaID]),
    CONSTRAINT [FK_SistemaUsuarioOpcionBitacora_SistemaModulo] FOREIGN KEY ([ModuloID]) REFERENCES [dbo].[SistemaModulo] ([ModuloID]),
    CONSTRAINT [FK_SistemaUsuarioOpcionBitacora_SistemaOpcion] FOREIGN KEY ([OpcionID]) REFERENCES [dbo].[SistemaOpcion] ([OpcionID])
);



