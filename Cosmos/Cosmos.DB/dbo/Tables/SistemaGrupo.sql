CREATE TABLE [dbo].[SistemaGrupo](
	[SistemaGrupoID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[ModuloID] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_SistemaGrupo] PRIMARY KEY CLUSTERED 
(
	[SistemaGrupoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[SistemaGrupo]  WITH CHECK ADD  CONSTRAINT [FK_SistemaGrupo_SistemaModulo] FOREIGN KEY([ModuloID])
REFERENCES [dbo].[SistemaModulo] ([ModuloID])
GO

ALTER TABLE [dbo].[SistemaGrupo] CHECK CONSTRAINT [FK_SistemaGrupo_SistemaModulo]
GO


