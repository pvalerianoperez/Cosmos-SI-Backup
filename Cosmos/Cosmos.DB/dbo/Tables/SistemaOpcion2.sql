CREATE TABLE [dbo].[SistemaOpcion2] (
    [OpcionID]       INT            IDENTITY (1, 1) NOT NULL,
    [ModuloID]       INT            NOT NULL,
    [PadreID]        INT            NULL,
    [Nombre]         NVARCHAR (50)  NOT NULL,
    [NombreCorto]    NVARCHAR (20)  NOT NULL,
    [RecursoWebsite] NVARCHAR (150) NOT NULL,
    [Activo]         BIT            CONSTRAINT [DF_SistemaOpcion2_Activo] DEFAULT ((1)) NOT NULL,
    [Protegido]      BIT            CONSTRAINT [DF_SistemaOpcion2_Protegido] DEFAULT ((1)) NOT NULL,
    [Popup]          BIT            CONSTRAINT [DF_SistemaOpcion2_Popup] DEFAULT ((0)) NOT NULL,
    [VisibleMenu]    BIT            CONSTRAINT [DF_SistemaOpcion2_VisibleMenu] DEFAULT ((1)) NOT NULL,
    [Icono]          NVARCHAR (50)  NOT NULL,
    [Orden]          SMALLINT       NOT NULL,
    CONSTRAINT [PK_SistemaOpcion2] PRIMARY KEY CLUSTERED ([OpcionID] ASC),
    CONSTRAINT [FK_SistemaOpcion2_SistemaModulo] FOREIGN KEY ([ModuloID]) REFERENCES [dbo].[SistemaModulo] ([ModuloID])
);

