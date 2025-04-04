USE [Cinema]
GO
/****** Object:  Table [dbo].[Actors]    Script Date: 31.03.2025 11:27:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actors](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[MiddleName] [nvarchar](max) NULL,
	[BirthDate] [date] NULL,
 CONSTRAINT [PK_Actors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 31.03.2025 11:27:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FilmActors]    Script Date: 31.03.2025 11:27:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FilmActors](
	[FilmId] [int] NOT NULL,
	[ActorId] [bigint] NOT NULL,
	[Role] [nvarchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FilmGenres]    Script Date: 31.03.2025 11:27:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FilmGenres](
	[FilmId] [int] NOT NULL,
	[GenreId] [tinyint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FilmProducingCompanies]    Script Date: 31.03.2025 11:27:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FilmProducingCompanies](
	[FilmId] [int] NOT NULL,
	[ProducingCompanyId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Films]    Script Date: 31.03.2025 11:27:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Films](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Duration] [smallint] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[AgeRestriction] [tinyint] NOT NULL,
 CONSTRAINT [PK_Films] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genres]    Script Date: 31.03.2025 11:27:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genres](
	[Id] [tinyint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK_Genres] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Halls]    Script Date: 31.03.2025 11:27:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Halls](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[RowsCount] [smallint] NOT NULL,
	[SeatsCount] [int] NOT NULL,
 CONSTRAINT [PK_Halls] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posts]    Script Date: 31.03.2025 11:27:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProducingCompanies]    Script Date: 31.03.2025 11:27:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProducingCompanies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[CountryId] [smallint] NULL,
 CONSTRAINT [PK_ProducingCompanies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Seats]    Script Date: 31.03.2025 11:27:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Seats](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RowNumber] [smallint] NOT NULL,
	[SeatNumber] [int] NOT NULL,
	[IsOccupied] [bit] NOT NULL,
	[HallId] [smallint] NOT NULL,
 CONSTRAINT [PK_Seats] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sessions]    Script Date: 31.03.2025 11:27:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sessions](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[StartDateTime] [datetime] NULL,
	[EndDateTime] [datetime] NULL,
	[FilmId] [int] NOT NULL,
 CONSTRAINT [PK_Sessions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 31.03.2025 11:27:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SessionId] [bigint] NOT NULL,
	[Price] [int] NOT NULL,
	[SeatId] [int] NOT NULL,
 CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Workers]    Script Date: 31.03.2025 11:27:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Workers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[MiddleName] [nvarchar](max) NULL,
	[BirthDate] [date] NOT NULL,
	[Gender] [nchar](1) NULL,
	[Address] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](16) NULL,
	[PassportData] [nchar](10) NOT NULL,
	[PostId] [int] NOT NULL,
	[Salary] [bigint] NOT NULL,
	[Responsibilities] [nvarchar](max) NULL,
	[Requirements] [nvarchar](max) NULL,
 CONSTRAINT [PK_Workers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Actors] ON 

INSERT [dbo].[Actors] ([Id], [FirstName], [LastName], [MiddleName], [BirthDate]) VALUES (1, N'Леонардо', N'Ди Каприо', NULL, CAST(N'1974-11-11' AS Date))
INSERT [dbo].[Actors] ([Id], [FirstName], [LastName], [MiddleName], [BirthDate]) VALUES (2, N'Уилл', N'Смит', NULL, CAST(N'1968-09-25' AS Date))
INSERT [dbo].[Actors] ([Id], [FirstName], [LastName], [MiddleName], [BirthDate]) VALUES (3, N'Данила', N'Козловский', N'Валерьевич', CAST(N'1985-05-03' AS Date))
SET IDENTITY_INSERT [dbo].[Actors] OFF
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([Id], [Name]) VALUES (1, N'Россия')
INSERT [dbo].[Countries] ([Id], [Name]) VALUES (2, N'США')
INSERT [dbo].[Countries] ([Id], [Name]) VALUES (3, N'Индия')
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
INSERT [dbo].[FilmActors] ([FilmId], [ActorId], [Role]) VALUES (3, 3, N'Алексей Карпушин, капитан, спасатель, пожарный')
GO
INSERT [dbo].[FilmGenres] ([FilmId], [GenreId]) VALUES (3, 1)
INSERT [dbo].[FilmGenres] ([FilmId], [GenreId]) VALUES (3, 2)
GO
SET IDENTITY_INSERT [dbo].[Films] ON 

INSERT [dbo].[Films] ([Id], [Title], [Duration], [Description], [AgeRestriction]) VALUES (3, N'Чернобыль', 136, N'После аварии на Чернобыльской АЭС молодой пожарный Алексей присоединяется к группе ликвидаторов, направленных на устранение последствий катастрофы.', 12)
SET IDENTITY_INSERT [dbo].[Films] OFF
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([Id], [Name], [Description]) VALUES (1, N'Историческая драма', N'Фильм, в котором события разворачиваются на фоне реальных исторических периодов или личностей, сочетая драматический сюжет с достоверными деталями эпохи. Часто затрагивает важные социальные, политические или личные конфликты, показывая их через призму судеб героев.')
INSERT [dbo].[Genres] ([Id], [Name], [Description]) VALUES (2, N'Катастрофа', N'Фильм, герои которого попали в катастрофу и пытаются спастись. Этот жанр фильма имеет надвигающуюся или продолжающуюся катастрофу в качестве основного сюжетного предмета в своей основе и в основном течении сюжетной линии')
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
SET IDENTITY_INSERT [dbo].[Halls] ON 

INSERT [dbo].[Halls] ([Id], [Name], [RowsCount], [SeatsCount]) VALUES (2, N'Зал №1', 9, 99)
SET IDENTITY_INSERT [dbo].[Halls] OFF
GO
SET IDENTITY_INSERT [dbo].[Posts] ON 

INSERT [dbo].[Posts] ([Id], [Name]) VALUES (1, N'Уборщик')
SET IDENTITY_INSERT [dbo].[Posts] OFF
GO
SET IDENTITY_INSERT [dbo].[ProducingCompanies] ON 

INSERT [dbo].[ProducingCompanies] ([Id], [Name], [CountryId]) VALUES (1, N'Централ Партнершип', 1)
INSERT [dbo].[ProducingCompanies] ([Id], [Name], [CountryId]) VALUES (2, N'Кинопрайм', 1)
INSERT [dbo].[ProducingCompanies] ([Id], [Name], [CountryId]) VALUES (3, N'ДК Интертеймент', 1)
SET IDENTITY_INSERT [dbo].[ProducingCompanies] OFF
GO
SET IDENTITY_INSERT [dbo].[Seats] ON 

INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (1, 3, 3, 1, 2)
SET IDENTITY_INSERT [dbo].[Seats] OFF
GO
SET IDENTITY_INSERT [dbo].[Sessions] ON 

INSERT [dbo].[Sessions] ([Id], [StartDateTime], [EndDateTime], [FilmId]) VALUES (1, CAST(N'2025-10-10T20:30:00.000' AS DateTime), CAST(N'2025-10-10T22:46:00.000' AS DateTime), 3)
SET IDENTITY_INSERT [dbo].[Sessions] OFF
GO
SET IDENTITY_INSERT [dbo].[Tickets] ON 

INSERT [dbo].[Tickets] ([Id], [SessionId], [Price], [SeatId]) VALUES (1, 1, 40000, 1)
SET IDENTITY_INSERT [dbo].[Tickets] OFF
GO
SET IDENTITY_INSERT [dbo].[Workers] ON 

INSERT [dbo].[Workers] ([Id], [FirstName], [LastName], [MiddleName], [BirthDate], [Gender], [Address], [PhoneNumber], [PassportData], [PostId], [Salary], [Responsibilities], [Requirements]) VALUES (1, N'Иван', N'Иванов', N'Иванович', CAST(N'2006-09-23' AS Date), N'M', N'г. Москва пер. Печатников д. 16 кв. 1', N'+7 922 492 48 43', N'6520123432', 1, 3500000, N'Уборка помещений после проведения сеанса', N'Высшее техническое образование')
SET IDENTITY_INSERT [dbo].[Workers] OFF
GO
ALTER TABLE [dbo].[FilmActors]  WITH CHECK ADD  CONSTRAINT [FK_FilmActors_Actors] FOREIGN KEY([ActorId])
REFERENCES [dbo].[Actors] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FilmActors] CHECK CONSTRAINT [FK_FilmActors_Actors]
GO
ALTER TABLE [dbo].[FilmActors]  WITH CHECK ADD  CONSTRAINT [FK_FilmActors_Films] FOREIGN KEY([FilmId])
REFERENCES [dbo].[Films] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FilmActors] CHECK CONSTRAINT [FK_FilmActors_Films]
GO
ALTER TABLE [dbo].[FilmGenres]  WITH CHECK ADD  CONSTRAINT [FK_FilmGenres_Films] FOREIGN KEY([FilmId])
REFERENCES [dbo].[Films] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FilmGenres] CHECK CONSTRAINT [FK_FilmGenres_Films]
GO
ALTER TABLE [dbo].[FilmGenres]  WITH CHECK ADD  CONSTRAINT [FK_FilmGenres_Genres] FOREIGN KEY([GenreId])
REFERENCES [dbo].[Genres] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FilmGenres] CHECK CONSTRAINT [FK_FilmGenres_Genres]
GO
ALTER TABLE [dbo].[FilmProducingCompanies]  WITH CHECK ADD  CONSTRAINT [FK_FilmProducingCompanies_Films] FOREIGN KEY([FilmId])
REFERENCES [dbo].[Films] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FilmProducingCompanies] CHECK CONSTRAINT [FK_FilmProducingCompanies_Films]
GO
ALTER TABLE [dbo].[FilmProducingCompanies]  WITH CHECK ADD  CONSTRAINT [FK_FilmProducingCompanies_ProducingCompanies] FOREIGN KEY([ProducingCompanyId])
REFERENCES [dbo].[ProducingCompanies] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FilmProducingCompanies] CHECK CONSTRAINT [FK_FilmProducingCompanies_ProducingCompanies]
GO
ALTER TABLE [dbo].[ProducingCompanies]  WITH CHECK ADD  CONSTRAINT [FK_ProducingCompanies_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProducingCompanies] CHECK CONSTRAINT [FK_ProducingCompanies_Countries]
GO
ALTER TABLE [dbo].[Seats]  WITH CHECK ADD  CONSTRAINT [FK_Seats_Halls] FOREIGN KEY([HallId])
REFERENCES [dbo].[Halls] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Seats] CHECK CONSTRAINT [FK_Seats_Halls]
GO
ALTER TABLE [dbo].[Sessions]  WITH CHECK ADD  CONSTRAINT [FK_Sessions_Films] FOREIGN KEY([FilmId])
REFERENCES [dbo].[Films] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Sessions] CHECK CONSTRAINT [FK_Sessions_Films]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Seats] FOREIGN KEY([SeatId])
REFERENCES [dbo].[Seats] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Seats]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Sessions] FOREIGN KEY([SessionId])
REFERENCES [dbo].[Sessions] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Sessions]
GO
ALTER TABLE [dbo].[Workers]  WITH CHECK ADD  CONSTRAINT [FK_Workers_Posts] FOREIGN KEY([PostId])
REFERENCES [dbo].[Posts] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Workers] CHECK CONSTRAINT [FK_Workers_Posts]
GO
