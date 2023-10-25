USE [Wanderlust]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 25/10/2023 12:01:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[ID_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[usuario] [varchar](50) NOT NULL,
	[edad] [int] NOT NULL,
	[email] [varchar](50) NOT NULL,
	[contraseña] [varchar](50) NOT NULL,
	[ID_Viaje] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Viajes]    Script Date: 25/10/2023 12:01:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Viajes](
	[ID_Viaje] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[lugar] [varchar](50) NOT NULL,
	[precio] [int] NOT NULL,
	[imagen] [varchar](50) NULL,
	[descripcion] [varchar](50) NULL,
	[puntaje] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Viajes] PRIMARY KEY CLUSTERED 
(
	[ID_Viaje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Viajes_Elegidos]    Script Date: 25/10/2023 12:01:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Viajes_Elegidos](
	[ID_Viaje] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[lugar] [varchar](50) NOT NULL,
	[precio] [int] NOT NULL,
	[imagen] [varchar](50) NULL,
	[descripcion] [varchar](50) NULL,
	[puntaje] [int] NOT NULL,
	[ID_Usuario] [int] NOT NULL,
 CONSTRAINT [PK_Viajes_Elegidos] PRIMARY KEY CLUSTERED 
(
	[ID_Viaje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Viajes]  WITH CHECK ADD  CONSTRAINT [FK_Viajes_Viajes_Elegidos] FOREIGN KEY([ID_Viaje])
REFERENCES [dbo].[Viajes_Elegidos] ([ID_Viaje])
GO
ALTER TABLE [dbo].[Viajes] CHECK CONSTRAINT [FK_Viajes_Viajes_Elegidos]
GO
ALTER TABLE [dbo].[Viajes_Elegidos]  WITH CHECK ADD  CONSTRAINT [FK_Viajes_Elegidos_Usuario] FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuario] ([ID_Usuario])
GO
ALTER TABLE [dbo].[Viajes_Elegidos] CHECK CONSTRAINT [FK_Viajes_Elegidos_Usuario]
GO
