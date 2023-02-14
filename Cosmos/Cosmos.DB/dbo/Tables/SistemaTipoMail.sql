CREATE TABLE [dbo].[SistemaTipoMail] (
    [SistemaTipoMailID]    INT          IDENTITY (1, 1) NOT NULL,
    [SistemaTipoMailClave] VARCHAR (10) NOT NULL,
    [Nombre]               VARCHAR (30) NOT NULL,
    [NombreCorto]          VARCHAR (10) NOT NULL,
    [Estatus]              BIT          NOT NULL,
    CONSTRAINT [PK_SistemaTipoMail] PRIMARY KEY CLUSTERED ([SistemaTipoMailID] ASC)
);




GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_SistemaTipoMail_TipoMailClave]
    ON [dbo].[SistemaTipoMail]([SistemaTipoMailClave] ASC);

