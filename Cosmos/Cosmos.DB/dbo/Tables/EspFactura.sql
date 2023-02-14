CREATE TABLE [dbo].[EspFactura] (
    [EspFacturaID]   INT             IDENTITY (1, 1) NOT NULL,
    [UUID]           VARCHAR (50)    NOT NULL,
    [RFC]            VARCHAR (20)    NOT NULL,
    [Serie]          VARCHAR (10)    NOT NULL,
    [Folio]          INT             NOT NULL,
    [Importe]        DECIMAL (18, 2) NOT NULL,
    [Fecha]          DATETIME        NOT NULL,
    [LinkXML]        VARCHAR (250)   NOT NULL,
    [LinkPDF]        VARCHAR (250)   NOT NULL,
    [EstatusFactura] CHAR (1)        NOT NULL,
    [MetodoPago]     VARCHAR (4)     NOT NULL,
    CONSTRAINT [PK_EspFactura] PRIMARY KEY CLUSTERED ([EspFacturaID] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_EspFactura_UUID]
    ON [dbo].[EspFactura]([UUID] ASC);

