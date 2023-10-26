USE [Wanderlust]
GO
/****** Object:  Table [dbo].[Pais]    Script Date: 26/10/2023 15:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pais](
	[ID_Pais] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Pais] PRIMARY KEY CLUSTERED 
(
	[ID_Pais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 26/10/2023 15:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[ID_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[usuario] [varchar](50) NOT NULL,
	[email] [varchar](max) NOT NULL,
	[contraseña] [varchar](50) NOT NULL,
	[ID_Viaje] [int] NULL,
	[FechaNacimiento] [date] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Viajes]    Script Date: 26/10/2023 15:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Viajes](
	[ID_Viaje] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[precio] [int] NULL,
	[imagen] [varchar](max) NULL,
	[descripcion] [varchar](max) NULL,
	[puntaje] [int] NULL,
	[ID_Pais] [int] NULL,
 CONSTRAINT [PK_Viajes] PRIMARY KEY CLUSTERED 
(
	[ID_Viaje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Viajes_Elegidos]    Script Date: 26/10/2023 15:51:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Viajes_Elegidos](
	[ID_Viaje] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[precio] [int] NOT NULL,
	[imagen] [varchar](max) NULL,
	[descripcion] [varchar](max) NULL,
	[puntaje] [int] NOT NULL,
 CONSTRAINT [PK_Viajes_Elegidos] PRIMARY KEY CLUSTERED 
(
	[ID_Viaje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Pais] ON 

INSERT [dbo].[Pais] ([ID_Pais], [Nombre], [Descripcion]) VALUES (6, N'Argentina', N'País ubicado en América del Sur')
INSERT [dbo].[Pais] ([ID_Pais], [Nombre], [Descripcion]) VALUES (7, N'España', N'País ubicado en Europa')
INSERT [dbo].[Pais] ([ID_Pais], [Nombre], [Descripcion]) VALUES (8, N'Estados Unidos', N'País ubicado en América del Norte')
INSERT [dbo].[Pais] ([ID_Pais], [Nombre], [Descripcion]) VALUES (32, N'Brasil', N'País ubicado en América del Sur')
INSERT [dbo].[Pais] ([ID_Pais], [Nombre], [Descripcion]) VALUES (33, N'Israel', N'País ubicado en Asia')
INSERT [dbo].[Pais] ([ID_Pais], [Nombre], [Descripcion]) VALUES (34, N'Etiopia', N'País ubicado en Africa')
SET IDENTITY_INSERT [dbo].[Pais] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([ID_Usuario], [nombre], [usuario], [email], [contraseña], [ID_Viaje], [FechaNacimiento]) VALUES (1, N'Juan', N'juan', N'juan@gmail.com', N'98453', NULL, CAST(N'2007-08-07' AS Date))
INSERT [dbo].[Usuario] ([ID_Usuario], [nombre], [usuario], [email], [contraseña], [ID_Viaje], [FechaNacimiento]) VALUES (2, N'María', N'maria', N'maria@gmail.com', N'054345', NULL, CAST(N'2005-06-02' AS Date))
INSERT [dbo].[Usuario] ([ID_Usuario], [nombre], [usuario], [email], [contraseña], [ID_Viaje], [FechaNacimiento]) VALUES (3, N'Pedro', N'pedro', N'pedro@gmail.com', N'115443', NULL, CAST(N'1999-02-11' AS Date))
INSERT [dbo].[Usuario] ([ID_Usuario], [nombre], [usuario], [email], [contraseña], [ID_Viaje], [FechaNacimiento]) VALUES (4, N'Carlos', N'carlos', N'carlos@gmail.com', N'0984432', NULL, CAST(N'2003-06-06' AS Date))
INSERT [dbo].[Usuario] ([ID_Usuario], [nombre], [usuario], [email], [contraseña], [ID_Viaje], [FechaNacimiento]) VALUES (5, N'Juana', N'juana', N'juana@gmail.com', N'642679', NULL, CAST(N'1989-01-01' AS Date))
INSERT [dbo].[Usuario] ([ID_Usuario], [nombre], [usuario], [email], [contraseña], [ID_Viaje], [FechaNacimiento]) VALUES (6, N'Franco', N'franco', N'franco@gmail.com', N'9054854', NULL, CAST(N'2011-02-01' AS Date))
INSERT [dbo].[Usuario] ([ID_Usuario], [nombre], [usuario], [email], [contraseña], [ID_Viaje], [FechaNacimiento]) VALUES (7, N'Joaco', N'joaco123', N'joaco@gmail.com', N'joaco456', NULL, CAST(N'2000-07-03' AS Date))
INSERT [dbo].[Usuario] ([ID_Usuario], [nombre], [usuario], [email], [contraseña], [ID_Viaje], [FechaNacimiento]) VALUES (8, N'benicio', N'benicrack', N'beni8@gmail.com', N'ben655', NULL, CAST(N'1998-11-12' AS Date))
INSERT [dbo].[Usuario] ([ID_Usuario], [nombre], [usuario], [email], [contraseña], [ID_Viaje], [FechaNacimiento]) VALUES (9, N'matias', N'mati81', N'maticarp@gmail.com', N'mati999', NULL, CAST(N'1994-06-12' AS Date))
INSERT [dbo].[Usuario] ([ID_Usuario], [nombre], [usuario], [email], [contraseña], [ID_Viaje], [FechaNacimiento]) VALUES (10, N'ulises', N'uligenio', N'uli@gmail.com', N'river912', NULL, CAST(N'1991-12-10' AS Date))
INSERT [dbo].[Usuario] ([ID_Usuario], [nombre], [usuario], [email], [contraseña], [ID_Viaje], [FechaNacimiento]) VALUES (11, N'roni', N'atlanta31', N'ronichimi@gmail.com', N'atlroni55', NULL, CAST(N'2004-02-03' AS Date))
INSERT [dbo].[Usuario] ([ID_Usuario], [nombre], [usuario], [email], [contraseña], [ID_Viaje], [FechaNacimiento]) VALUES (12, N'nicole', N'nicky661', N'nicolebrun@gmail.com', N'nickygenia', NULL, CAST(N'2014-11-11' AS Date))
INSERT [dbo].[Usuario] ([ID_Usuario], [nombre], [usuario], [email], [contraseña], [ID_Viaje], [FechaNacimiento]) VALUES (13, N'Federico', N'fefi77', N'fedebider@gmail.com', N'feficapo', NULL, CAST(N'1988-01-04' AS Date))
INSERT [dbo].[Usuario] ([ID_Usuario], [nombre], [usuario], [email], [contraseña], [ID_Viaje], [FechaNacimiento]) VALUES (14, N'Facundo', N'facu717', N'facu@gmail.com', N'contraseña456', NULL, CAST(N'1974-01-01' AS Date))
INSERT [dbo].[Usuario] ([ID_Usuario], [nombre], [usuario], [email], [contraseña], [ID_Viaje], [FechaNacimiento]) VALUES (15, N'Thiago', N'Thiaguito1', N'tthiago@gmail.com', N'thiagooo3', NULL, CAST(N'1996-02-08' AS Date))
INSERT [dbo].[Usuario] ([ID_Usuario], [nombre], [usuario], [email], [contraseña], [ID_Viaje], [FechaNacimiento]) VALUES (16, N'Marcos', N'marquitoss', N'mmarcos@gmail.com', N'elmatador10', NULL, CAST(N'1998-12-12' AS Date))
INSERT [dbo].[Usuario] ([ID_Usuario], [nombre], [usuario], [email], [contraseña], [ID_Viaje], [FechaNacimiento]) VALUES (17, N'Ramiro', N'rama555', N'ramma@gmail.com', N'rammaa', NULL, CAST(N'2003-03-03' AS Date))
INSERT [dbo].[Usuario] ([ID_Usuario], [nombre], [usuario], [email], [contraseña], [ID_Viaje], [FechaNacimiento]) VALUES (18, N'Martin', N'tincho', N'martinn@gmail.com', N'tinchito1122', NULL, CAST(N'2008-06-09' AS Date))
INSERT [dbo].[Usuario] ([ID_Usuario], [nombre], [usuario], [email], [contraseña], [ID_Viaje], [FechaNacimiento]) VALUES (19, N'Ivan', N'ivocapo', N'ivan03@gmail.com', N'ivvann21', NULL, CAST(N'2001-01-07' AS Date))
INSERT [dbo].[Usuario] ([ID_Usuario], [nombre], [usuario], [email], [contraseña], [ID_Viaje], [FechaNacimiento]) VALUES (20, N'Lautaro', N'lauticabj', N'laucha@gmail.com', N'lauticrack', NULL, CAST(N'2006-01-01' AS Date))
INSERT [dbo].[Usuario] ([ID_Usuario], [nombre], [usuario], [email], [contraseña], [ID_Viaje], [FechaNacimiento]) VALUES (21, N'iair', N'iao98', N'iair@gmail.com', N'iaoiair', NULL, CAST(N'1993-09-08' AS Date))
INSERT [dbo].[Usuario] ([ID_Usuario], [nombre], [usuario], [email], [contraseña], [ID_Viaje], [FechaNacimiento]) VALUES (22, N'Tobias', N'tobb44', N'tobi@gmail.com', N'tobiAS', NULL, CAST(N'1992-05-04' AS Date))
INSERT [dbo].[Usuario] ([ID_Usuario], [nombre], [usuario], [email], [contraseña], [ID_Viaje], [FechaNacimiento]) VALUES (23, N'Sofia', N'sofigenia', N'sofii@gmail.com', N'SoFi1991', NULL, CAST(N'1990-04-03' AS Date))
INSERT [dbo].[Usuario] ([ID_Usuario], [nombre], [usuario], [email], [contraseña], [ID_Viaje], [FechaNacimiento]) VALUES (24, N'Mateo', N'Matecasla', N'mateociclon@gmail.com', N'SoyDelCiclon', NULL, CAST(N'1991-02-01' AS Date))
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET IDENTITY_INSERT [dbo].[Viajes_Elegidos] ON 

INSERT [dbo].[Viajes_Elegidos] ([ID_Viaje], [nombre], [precio], [imagen], [descripcion], [puntaje]) VALUES (1, N'La bomboners', 4999, N'https://i.pinimg.com/736x/dd/02/8d/dd028da298c2c954517c53041c34446d.jpg', N'
La Bombonera es el estadio de fútbol del Club Atlético Boca Juniors, ubicado en Buenos Aires, Argentina. Es uno de los estadios más emblemáticos del mundo, conocido por su atmósfera vibrante y su forma en forma de herradura.', 3)
INSERT [dbo].[Viajes_Elegidos] ([ID_Viaje], [nombre], [precio], [imagen], [descripcion], [puntaje]) VALUES (2, N'El monumental', 4699, N'https://bolavip.com/export/sites/lpm/img/2023/01/31/obras.jpg_976286741.jpg', N'El Monumental es el estadio de River Plate. Es el más grande de Argentina y Sudamérica, y ha sido sede de importantes partidos internacionales.', 9)
INSERT [dbo].[Viajes_Elegidos] ([ID_Viaje], [nombre], [precio], [imagen], [descripcion], [puntaje]) VALUES (3, N'Republica de mataderos', 9999, N'https://pbs.twimg.com/media/B1CKB5JIcAAde9C.jpg', N'Estadio hermoso y espectacular su estrcutura.Paseo imperdible.', 10)
INSERT [dbo].[Viajes_Elegidos] ([ID_Viaje], [nombre], [precio], [imagen], [descripcion], [puntaje]) VALUES (4, N'Cataratas del Iguazo', 12999, N'https://viajerosblog.com/wp-content/uploads/2012/09/cataratas-iguazu-agua.jpg', N'
Las Cataratas del Iguazú son un conjunto de cataratas que se encuentran en el río Iguazú, en la frontera entre Argentina y Brasil. Son una de las Siete Maravillas Naturales del Mundo y uno de los lugares turísticos más populares de América del Sur.', 8)
SET IDENTITY_INSERT [dbo].[Viajes_Elegidos] OFF
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Viajes_Elegidos] FOREIGN KEY([ID_Viaje])
REFERENCES [dbo].[Viajes_Elegidos] ([ID_Viaje])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK_Usuario_Viajes_Elegidos]
GO
ALTER TABLE [dbo].[Viajes]  WITH CHECK ADD  CONSTRAINT [FK_Viajes_Pais] FOREIGN KEY([ID_Pais])
REFERENCES [dbo].[Pais] ([ID_Pais])
GO
ALTER TABLE [dbo].[Viajes] CHECK CONSTRAINT [FK_Viajes_Pais]
GO
ALTER TABLE [dbo].[Viajes]  WITH CHECK ADD  CONSTRAINT [FK_Viajes_Viajes_Elegidos] FOREIGN KEY([ID_Viaje])
REFERENCES [dbo].[Viajes_Elegidos] ([ID_Viaje])
GO
ALTER TABLE [dbo].[Viajes] CHECK CONSTRAINT [FK_Viajes_Viajes_Elegidos]
GO
