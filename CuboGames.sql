USE [CuboGames]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 22/11/2023 09:42:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[IdCategoria] [int] IDENTITY(1,1) NOT NULL,
	[TipoCategoria] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED 
(
	[IdCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Juegos]    Script Date: 22/11/2023 09:42:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Juegos](
	[IdJuego] [varchar](50) NOT NULL,
	[Nombre] [varchar](70) NOT NULL,
	[CantLikes] [int] NOT NULL,
	[fkUsuario] [int] NULL,
	[Descripcion] [varchar](200) NOT NULL,
	[FechaCreacion] [date] NOT NULL,
	[Imagen] [varchar](max) NOT NULL,
	[Precio] [int] NOT NULL,
	[fkCategoria] [int] NOT NULL,
 CONSTRAINT [PK_Juegos] PRIMARY KEY CLUSTERED 
(
	[IdJuego] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 22/11/2023 09:42:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Contraseña] [varchar](50) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categorias] ON 

INSERT [dbo].[Categorias] ([IdCategoria], [TipoCategoria]) VALUES (1, N'Deportes')
INSERT [dbo].[Categorias] ([IdCategoria], [TipoCategoria]) VALUES (2, N'Acción')
INSERT [dbo].[Categorias] ([IdCategoria], [TipoCategoria]) VALUES (3, N'Simulación')
INSERT [dbo].[Categorias] ([IdCategoria], [TipoCategoria]) VALUES (4, N'Arcade')
INSERT [dbo].[Categorias] ([IdCategoria], [TipoCategoria]) VALUES (5, N'Estrategia')
INSERT [dbo].[Categorias] ([IdCategoria], [TipoCategoria]) VALUES (6, N'Aventura')
SET IDENTITY_INSERT [dbo].[Categorias] OFF
GO
INSERT [dbo].[Juegos] ([IdJuego], [Nombre], [CantLikes], [fkUsuario], [Descripcion], [FechaCreacion], [Imagen], [Precio], [fkCategoria]) VALUES (N'1', N'EA FC 24', 25, NULL, N'Powered by Football™, EA SPORTS™ FC 24 acorta las distancias aún más con lo que sucede en la vida real gracias a los avances en la jugabilidad básica y a nuevas características innovadoras en todos ', CAST(N'2023-09-23' AS Date), N'https://http2.mlstatic.com/D_NQ_NP_838310-MLA72105170591_102023-O.webp', 70, 1)
INSERT [dbo].[Juegos] ([IdJuego], [Nombre], [CantLikes], [fkUsuario], [Descripcion], [FechaCreacion], [Imagen], [Precio], [fkCategoria]) VALUES (N'11', N'NFL 24', 3, NULL, N'El mejor juego de fútbol americano de EA Sports vuelve con Madden NFL 24, un simulador sobre el deporte de contacto. ', CAST(N'2023-08-15' AS Date), N'https://images.squarespace-cdn.com/content/v1/610c6ac52d9ef15f1ce71190/f41b7675-572a-4898-a739-1c502638eed9/madden24-1686171011636.jpg?format=500w', 10, 1)
INSERT [dbo].[Juegos] ([IdJuego], [Nombre], [CantLikes], [fkUsuario], [Descripcion], [FechaCreacion], [Imagen], [Precio], [fkCategoria]) VALUES (N'12', N'Counter-Strike: Global Offensive
', 35, NULL, N'Counter-Strike: Global Offensive (CS:GO) amplía el juego de acción por equipos del que fue pionera la franquicia cuando salió hace 19 años. CS:GO trae nuevos mapas, personajes, armas y modos de juego', CAST(N'2012-08-21' AS Date), N'https://i1.sndcdn.com/artworks-CElK1tN2STm9sEWq-ahdGNA-t500x500.jpg', 0, 2)
INSERT [dbo].[Juegos] ([IdJuego], [Nombre], [CantLikes], [fkUsuario], [Descripcion], [FechaCreacion], [Imagen], [Precio], [fkCategoria]) VALUES (N'2', N'NBA 2K24', 15, NULL, N'Experimenta la cultura del baloncesto en NBA 2K24. Disfruta da acción a raudales y de opciones ilimitadas de personalización de Mi JUGADOR en Mi CARRERA.
', CAST(N'2023-09-08' AS Date), N'https://cdn.prgloo.com/media/a278b12d05b748bb8f8d71499abd4bd2', 20, 1)
INSERT [dbo].[Juegos] ([IdJuego], [Nombre], [CantLikes], [fkUsuario], [Descripcion], [FechaCreacion], [Imagen], [Precio], [fkCategoria]) VALUES (N'3', N'ARK: Survival Evolved', 1, NULL, N'Varado en las costas de una isla misteriosa, debes aprender a sobrevivir. Usa tu astucia para matar o domar a las criaturas primigenias que vagan por la tierra y enfréntate a otros jugadores para sobr', CAST(N'2017-08-27' AS Date), N'https://i0.wp.com/dropthespotlight.com/wp-content/uploads/2018/06/ark2-1.jpg?fit=500%2C500&ssl=1', 3, 6)
INSERT [dbo].[Juegos] ([IdJuego], [Nombre], [CantLikes], [fkUsuario], [Descripcion], [FechaCreacion], [Imagen], [Precio], [fkCategoria]) VALUES (N'4', N'GTA V', 20, NULL, N'Explora a mundo abierto en el que los jugadores pueden controlar a un personaje en un ambiente urbano y realizar diversas actividades, como conducir vehículos, robar, luchar y realizar misiones', CAST(N'2013-09-17' AS Date), N'https://http2.mlstatic.com/D_NQ_NP_934761-MLA70519513209_072023-O.webp', 6, 2)
INSERT [dbo].[Juegos] ([IdJuego], [Nombre], [CantLikes], [fkUsuario], [Descripcion], [FechaCreacion], [Imagen], [Precio], [fkCategoria]) VALUES (N'5', N'Minecraft', 20, NULL, N'Comience a modelar el mundo a su gusto, destruir y construir, como si estuviesen jugando en una caja de arena', CAST(N'2011-11-18' AS Date), N'https://http2.mlstatic.com/D_NQ_NP_795067-MLA40176270744_122019-O.webp', 20, 3)
INSERT [dbo].[Juegos] ([IdJuego], [Nombre], [CantLikes], [fkUsuario], [Descripcion], [FechaCreacion], [Imagen], [Precio], [fkCategoria]) VALUES (N'6', N'Call Of Duty: Black Ops 2', 10, NULL, N'Empujando los límites de lo que los fanáticos esperan de la franquicia de entretenimiento que establece récords, Call of Duty®: Black Ops II impulsa a los jugadores a un futuro cercano de la Guerra Fr', CAST(N'2012-11-18' AS Date), N'https://i1.sndcdn.com/artworks-lfBn4j4EgHHQxSAl-WicbsA-t500x500.jpg', 20, 3)
INSERT [dbo].[Juegos] ([IdJuego], [Nombre], [CantLikes], [fkUsuario], [Descripcion], [FechaCreacion], [Imagen], [Precio], [fkCategoria]) VALUES (N'7', N'Valorant', 0, NULL, N'Juego de accion y aventura', CAST(N'2022-11-02' AS Date), N'https://i1.sndcdn.com/artworks-iGEge8XXu8561yRz-hzpMog-t500x500.jpg', 20, 2)
INSERT [dbo].[Juegos] ([IdJuego], [Nombre], [CantLikes], [fkUsuario], [Descripcion], [FechaCreacion], [Imagen], [Precio], [fkCategoria]) VALUES (N'8', N'God Of War 2018', 13, NULL, N'Han pasado años desde que Kratos tomó su venganza contra los Dioses Olímpicos. Habiendo sobrevivido la pelea final contra su padre Zeus, Kratos vive ahora con su joven hijo Atreus en el mundo de los D', CAST(N'2018-04-20' AS Date), N'https://i1.sndcdn.com/artworks-xTsiNl3IkGdvjvqZ-5yDjsg-t500x500.jpg', 50, 2)
INSERT [dbo].[Juegos] ([IdJuego], [Nombre], [CantLikes], [fkUsuario], [Descripcion], [FechaCreacion], [Imagen], [Precio], [fkCategoria]) VALUES (N'9', N'Fortnite', 15, NULL, N'Crea, juega y combate gratis con amigos en Fortnite. Sé la última persona en pie en Batalla campal y Cero construcción, disfruta de un concierto o un evento en linea con tus amigos', CAST(N'2017-07-21' AS Date), N'https://http2.mlstatic.com/D_NQ_NP_623474-MLA43429871086_092020-O.webp', 0, 1)
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([IdUsuario], [Contraseña], [Nombre]) VALUES (5, N'1234', N'LeoK')
INSERT [dbo].[Usuarios] ([IdUsuario], [Contraseña], [Nombre]) VALUES (6, N'123', N'Alexis')
INSERT [dbo].[Usuarios] ([IdUsuario], [Contraseña], [Nombre]) VALUES (7, N'pepe', N'Alote')
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[Juegos]  WITH CHECK ADD  CONSTRAINT [FK_Juegos_Categorias] FOREIGN KEY([fkCategoria])
REFERENCES [dbo].[Categorias] ([IdCategoria])
GO
ALTER TABLE [dbo].[Juegos] CHECK CONSTRAINT [FK_Juegos_Categorias]
GO
ALTER TABLE [dbo].[Juegos]  WITH CHECK ADD  CONSTRAINT [FK_Juegos_Usuarios] FOREIGN KEY([fkUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Juegos] CHECK CONSTRAINT [FK_Juegos_Usuarios]
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarLikesJuego]    Script Date: 22/11/2023 09:42:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ActualizarLikesJuego]
    @IdJuego VARCHAR(50),
    @CantLikes INT
AS
BEGIN
    UPDATE Juegos
    SET CantLikes = CantLikes + @CantLikes
    WHERE IdJuego = @IdJuego;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_AgregarJuego]    Script Date: 22/11/2023 09:42:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AgregarJuego]
    @Nombre VARCHAR(70),
    @CantLikes INT,
    @Descripcion VARCHAR(200),
    @FechaCreacion DATE,
    @Imagen VARCHAR(MAX),
    @Precio INT,
    @fkCategoria INT
AS
BEGIN
    INSERT INTO Juegos (Nombre, CantLikes, Descripcion, FechaCreacion, Imagen, Precio, fkCategoria)
    VALUES (@Nombre, @CantLikes, @Descripcion, @FechaCreacion, @Imagen, @Precio, @fkCategoria);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_AgregarUsuario]    Script Date: 22/11/2023 09:42:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AgregarUsuario]
    @Contraseña VARCHAR(50),
    @Nombre VARCHAR(50)
AS
BEGIN
    INSERT INTO Usuarios (Contraseña, Nombre)
    VALUES (@Contraseña, @Nombre);
END
GO
