CREATE TABLE [dbo].[AuxFormaPago] (
    [AuxFormaPagoID]    INT          IDENTITY (1, 1) NOT NULL,
    [Nombre]            VARCHAR (50) NULL,
    [NombreCorto]       VARCHAR (20) NULL,
    [AuxFormaPagoClave] VARCHAR (5)  NOT NULL,
    CONSTRAINT [PK_AuxFormaPago] PRIMARY KEY CLUSTERED ([AuxFormaPagoID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_AuxFormaPago_AuxFormaPagoClave]
    ON [dbo].[AuxFormaPago]([AuxFormaPagoClave] ASC);

