USE [Cinema_DB]
GO
/****** Object:  Table [dbo].[Actors]    Script Date: 22.05.2025 2:26:48 ******/
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
	[CountryId] [smallint] NOT NULL,
 CONSTRAINT [PK_Actors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bookings]    Script Date: 22.05.2025 2:26:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bookings](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SessionId] [bigint] NULL,
	[SeatId] [int] NOT NULL,
	[SaleDateTime] [datetime] NOT NULL,
	[ExpiresDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 22.05.2025 2:26:48 ******/
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
/****** Object:  Table [dbo].[FilmActors]    Script Date: 22.05.2025 2:26:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FilmActors](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FilmId] [int] NOT NULL,
	[ActorId] [bigint] NOT NULL,
	[Role] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_FilmActors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FilmGenres]    Script Date: 22.05.2025 2:26:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FilmGenres](
	[FilmId] [int] NOT NULL,
	[GenreId] [tinyint] NOT NULL,
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_FilmGenres] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FilmProducingCompanies]    Script Date: 22.05.2025 2:26:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FilmProducingCompanies](
	[FilmId] [int] NOT NULL,
	[ProducingCompanyId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Films]    Script Date: 22.05.2025 2:26:48 ******/
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
/****** Object:  Table [dbo].[Genres]    Script Date: 22.05.2025 2:26:48 ******/
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
/****** Object:  Table [dbo].[Halls]    Script Date: 22.05.2025 2:26:48 ******/
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
/****** Object:  Table [dbo].[Posts]    Script Date: 22.05.2025 2:26:48 ******/
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
/****** Object:  Table [dbo].[ProducingCompanies]    Script Date: 22.05.2025 2:26:48 ******/
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
/****** Object:  Table [dbo].[Seats]    Script Date: 22.05.2025 2:26:48 ******/
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
/****** Object:  Table [dbo].[Sessions]    Script Date: 22.05.2025 2:26:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sessions](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[StartDateTime] [datetime] NULL,
	[EndDateTime] [datetime] NULL,
	[FilmId] [int] NOT NULL,
	[Price] [decimal](9, 2) NOT NULL,
	[HallId] [smallint] NOT NULL,
 CONSTRAINT [PK_Sessions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 22.05.2025 2:26:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[SessionId] [bigint] NOT NULL,
	[Price] [decimal](9, 2) NOT NULL,
	[SeatId] [int] NOT NULL,
	[SaleDateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Workers]    Script Date: 22.05.2025 2:26:48 ******/
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
	[Salary] [decimal](12, 2) NOT NULL,
	[Responsibilities] [nvarchar](max) NULL,
	[Requirements] [nvarchar](max) NULL,
	[Email] [nvarchar](100) NULL,
	[Password] [nvarchar](100) NULL,
 CONSTRAINT [PK_Workers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Actors] ON 

INSERT [dbo].[Actors] ([Id], [FirstName], [LastName], [MiddleName], [BirthDate], [CountryId]) VALUES (1, N'Леонардо', N'Ди Каприо', NULL, CAST(N'1974-11-11' AS Date), 2)
INSERT [dbo].[Actors] ([Id], [FirstName], [LastName], [MiddleName], [BirthDate], [CountryId]) VALUES (2, N'Уилл', N'Смит', NULL, CAST(N'1968-09-25' AS Date), 2)
INSERT [dbo].[Actors] ([Id], [FirstName], [LastName], [MiddleName], [BirthDate], [CountryId]) VALUES (3, N'Данила', N'Козловский', N'Валерьевич', CAST(N'1985-05-03' AS Date), 1)
INSERT [dbo].[Actors] ([Id], [FirstName], [LastName], [MiddleName], [BirthDate], [CountryId]) VALUES (4, N'Кейт', N'Уинслет', N'', CAST(N'1975-10-05' AS Date), 2)
INSERT [dbo].[Actors] ([Id], [FirstName], [LastName], [MiddleName], [BirthDate], [CountryId]) VALUES (6, N'Александр', N'Петров', N'Андреевич', CAST(N'1989-01-25' AS Date), 1)
INSERT [dbo].[Actors] ([Id], [FirstName], [LastName], [MiddleName], [BirthDate], [CountryId]) VALUES (8, N'Амитабх', N'Баччан', N'', CAST(N'1942-10-11' AS Date), 3)
SET IDENTITY_INSERT [dbo].[Actors] OFF
GO
SET IDENTITY_INSERT [dbo].[Bookings] ON 

INSERT [dbo].[Bookings] ([Id], [SessionId], [SeatId], [SaleDateTime], [ExpiresDateTime]) VALUES (1, 1, 37, CAST(N'2025-05-21T03:17:34.017' AS DateTime), CAST(N'2025-05-22T03:17:34.017' AS DateTime))
INSERT [dbo].[Bookings] ([Id], [SessionId], [SeatId], [SaleDateTime], [ExpiresDateTime]) VALUES (2, 1, 66, CAST(N'2025-05-21T03:19:05.490' AS DateTime), CAST(N'2025-05-22T03:19:05.490' AS DateTime))
INSERT [dbo].[Bookings] ([Id], [SessionId], [SeatId], [SaleDateTime], [ExpiresDateTime]) VALUES (3, 11, 91, CAST(N'2025-05-21T03:42:02.347' AS DateTime), CAST(N'2025-05-22T03:42:02.347' AS DateTime))
INSERT [dbo].[Bookings] ([Id], [SessionId], [SeatId], [SaleDateTime], [ExpiresDateTime]) VALUES (4, 11, 92, CAST(N'2025-05-21T03:43:13.677' AS DateTime), CAST(N'2025-05-22T03:43:13.677' AS DateTime))
INSERT [dbo].[Bookings] ([Id], [SessionId], [SeatId], [SaleDateTime], [ExpiresDateTime]) VALUES (5, 11, 93, CAST(N'2025-05-21T03:43:46.610' AS DateTime), CAST(N'2025-05-22T03:43:46.610' AS DateTime))
INSERT [dbo].[Bookings] ([Id], [SessionId], [SeatId], [SaleDateTime], [ExpiresDateTime]) VALUES (6, 1, 24, CAST(N'2025-05-22T01:11:58.377' AS DateTime), CAST(N'2025-05-23T01:11:58.377' AS DateTime))
SET IDENTITY_INSERT [dbo].[Bookings] OFF
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([Id], [Name]) VALUES (1, N'Россия')
INSERT [dbo].[Countries] ([Id], [Name]) VALUES (2, N'США')
INSERT [dbo].[Countries] ([Id], [Name]) VALUES (3, N'Индия')
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
SET IDENTITY_INSERT [dbo].[FilmActors] ON 

INSERT [dbo].[FilmActors] ([Id], [FilmId], [ActorId], [Role]) VALUES (1, 3, 3, N'Алексей Карпушин, капитан, спасатель, пожарный')
INSERT [dbo].[FilmActors] ([Id], [FilmId], [ActorId], [Role]) VALUES (3, 5, 1, N'Джек Доусон')
INSERT [dbo].[FilmActors] ([Id], [FilmId], [ActorId], [Role]) VALUES (4, 5, 4, N'Роуз Дьюитт Бьюкейтер')
INSERT [dbo].[FilmActors] ([Id], [FilmId], [ActorId], [Role]) VALUES (17, 17, 2, N' ')
INSERT [dbo].[FilmActors] ([Id], [FilmId], [ActorId], [Role]) VALUES (10005, 6, 8, N' ')
SET IDENTITY_INSERT [dbo].[FilmActors] OFF
GO
SET IDENTITY_INSERT [dbo].[FilmGenres] ON 

INSERT [dbo].[FilmGenres] ([FilmId], [GenreId], [Id]) VALUES (3, 1, 1)
INSERT [dbo].[FilmGenres] ([FilmId], [GenreId], [Id]) VALUES (3, 2, 2)
INSERT [dbo].[FilmGenres] ([FilmId], [GenreId], [Id]) VALUES (3, 1, 3)
INSERT [dbo].[FilmGenres] ([FilmId], [GenreId], [Id]) VALUES (3, 2, 4)
INSERT [dbo].[FilmGenres] ([FilmId], [GenreId], [Id]) VALUES (5, 7, 5)
INSERT [dbo].[FilmGenres] ([FilmId], [GenreId], [Id]) VALUES (5, 5, 6)
INSERT [dbo].[FilmGenres] ([FilmId], [GenreId], [Id]) VALUES (17, 6, 9)
INSERT [dbo].[FilmGenres] ([FilmId], [GenreId], [Id]) VALUES (17, 4, 10)
INSERT [dbo].[FilmGenres] ([FilmId], [GenreId], [Id]) VALUES (6, 5, 10007)
SET IDENTITY_INSERT [dbo].[FilmGenres] OFF
GO
SET IDENTITY_INSERT [dbo].[Films] ON 

INSERT [dbo].[Films] ([Id], [Title], [Duration], [Description], [AgeRestriction]) VALUES (3, N'Чернобыль', 136, N'После аварии на Чернобыльской АЭС молодой пожарный Алексей присоединяется к группе ликвидаторов, направленных на устранение последствий катастрофы.', 12)
INSERT [dbo].[Films] ([Id], [Title], [Duration], [Description], [AgeRestriction]) VALUES (5, N'Титаник', 194, N'Девушка из высшего общества Роза собирается выйти замуж за молодого нувориша Каледона. Местом свадьбы назначили Америку, куда и отправляется «Титаник». Во время плавания Роза знакомится с простым парнем Джеком, который плывёт на нижней палубе, выиграв билет на лайнер в карты. Невзирая на все помехи, включая их классовое неравенство, отношения между Розой и Джеком стремительно начинают набирать обороты. ', 12)
INSERT [dbo].[Films] ([Id], [Title], [Duration], [Description], [AgeRestriction]) VALUES (6, N'Никогда не говори «Прощай»', 193, N'Дэв Саран (Шахрух Хан) — успешный футболист, но его карьера неожиданно заканчивается после травмы ноги. В тот день, когда это произошло, он встретил девушку Майю (Рани Мукерджи) накануне её свадебной церемонии, она не хочет выходить замуж и собирается сбежать, но Дэв её убеждает, что бы она этого не делала.', 16)
INSERT [dbo].[Films] ([Id], [Title], [Duration], [Description], [AgeRestriction]) VALUES (17, N'Я, робот', 115, N'2035 год. Роботы стали привычной частью быта. Однако ряд консервативно настроенных людей, среди которых полицейский Дел Спунер, не доверяют новым помощникам и видят в них угрозу. Однажды Спунер выезжает на место гибели давнего знакомого, профессора Альфреда Лэннинга, который был ведущим конструктором и теоретиком корпорации U.S. Robotics. Директор компании Лоуренс Робертсон считает, что Лэннинг просто покончил с собой, выбросившись из окна. Однако у Спунера есть сомнения в правдоподобности данной версии. Вместе со специалистом по психологии позитронных роботов Сьюзан Кэлвин он вскоре обнаруживает в лаборатории Лэннинга особенного робота, который вопреки второму закону робототехники игнорирует приказы человека и принимает собственные осознанные решения.', 12)
SET IDENTITY_INSERT [dbo].[Films] OFF
GO
SET IDENTITY_INSERT [dbo].[Genres] ON 

INSERT [dbo].[Genres] ([Id], [Name], [Description]) VALUES (1, N'Историческая драма', N'Фильм, в котором события разворачиваются на фоне реальных исторических периодов или личностей, сочетая драматический сюжет с достоверными деталями эпохи. Часто затрагивает важные социальные, политические или личные конфликты, показывая их через призму судеб героев.')
INSERT [dbo].[Genres] ([Id], [Name], [Description]) VALUES (2, N'Катастрофа', N'Фильм, герои которого попали в катастрофу и пытаются спастись. Этот жанр фильма имеет надвигающуюся или продолжающуюся катастрофу в качестве основного сюжетного предмета в своей основе и в основном течении сюжетной линии')
INSERT [dbo].[Genres] ([Id], [Name], [Description]) VALUES (3, N'Приключения', N'Фильм, где герои отправляются в рискованные экспедиции, преодолевают неожиданные препятствия и исследуют неизведанные территории. Основной акцент сделан на динамике путешествий, поиске сокровищ или выполнении миссий, часто с элементами экзотических локаций и ярких визуальных открытий.')
INSERT [dbo].[Genres] ([Id], [Name], [Description]) VALUES (4, N'Триллер', N'Фильм, построенный на напряжении и постоянном ожидании неожиданного поворота событий. Зритель оказывается втянут в психологическую игру, где угроза может исходить как от внешних врагов, так и из внутренних конфликтов персонажей, а кульминация часто сопровождается шокирующей развязкой.')
INSERT [dbo].[Genres] ([Id], [Name], [Description]) VALUES (5, N'Драма', N'Фильм, фокусирующийся на глубоком эмоциональном развитии персонажей и их межличностных отношениях. Сюжет вращается вокруг моральных дилемм, внутренних переживаний и социальных конфликтов, раскрывая человеческую природу через реалистичные или метафорические ситуации.')
INSERT [dbo].[Genres] ([Id], [Name], [Description]) VALUES (6, N'Боевик', N'Фильм с интенсивными сценами борьбы, погонями и визуально эффектными столкновениями. Персонажи часто сталкиваются с физическими испытаниями, где скорость, стратегия и применение различных видов оружия играют ключевую роль в развитии сюжета.')
INSERT [dbo].[Genres] ([Id], [Name], [Description]) VALUES (7, N'Романтический фильм', N'Фильм, где центральной темой является развитие чувств между персонажами — от первого знакомства до преодоления препятствий на пути к отношениям. Акцент делается на эмоциональной химии, диалогах и ситуациях, подчеркивающих ценность любви и человеческой близости.')
SET IDENTITY_INSERT [dbo].[Genres] OFF
GO
SET IDENTITY_INSERT [dbo].[Halls] ON 

INSERT [dbo].[Halls] ([Id], [Name], [RowsCount], [SeatsCount]) VALUES (2, N'Зал №1', 9, 90)
INSERT [dbo].[Halls] ([Id], [Name], [RowsCount], [SeatsCount]) VALUES (3, N'Зал №2', 4, 20)
SET IDENTITY_INSERT [dbo].[Halls] OFF
GO
SET IDENTITY_INSERT [dbo].[Posts] ON 

INSERT [dbo].[Posts] ([Id], [Name]) VALUES (1, N'Уборщик')
INSERT [dbo].[Posts] ([Id], [Name]) VALUES (4, N'Администратор')
SET IDENTITY_INSERT [dbo].[Posts] OFF
GO
SET IDENTITY_INSERT [dbo].[ProducingCompanies] ON 

INSERT [dbo].[ProducingCompanies] ([Id], [Name], [CountryId]) VALUES (1, N'Централ Партнершип', 1)
INSERT [dbo].[ProducingCompanies] ([Id], [Name], [CountryId]) VALUES (2, N'Кинопрайм', 1)
INSERT [dbo].[ProducingCompanies] ([Id], [Name], [CountryId]) VALUES (3, N'ДК Интертеймент', 1)
SET IDENTITY_INSERT [dbo].[ProducingCompanies] OFF
GO
SET IDENTITY_INSERT [dbo].[Seats] ON 

INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (1, 1, 1, 1, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (2, 1, 2, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (3, 1, 3, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (4, 1, 4, 1, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (5, 1, 5, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (6, 1, 6, 1, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (7, 1, 7, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (8, 1, 8, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (9, 1, 9, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (10, 1, 10, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (11, 2, 1, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (12, 2, 2, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (13, 2, 3, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (14, 2, 4, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (15, 2, 5, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (16, 2, 6, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (17, 2, 7, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (18, 2, 8, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (19, 2, 9, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (20, 2, 10, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (21, 3, 1, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (22, 3, 2, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (23, 3, 3, 1, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (24, 3, 4, 1, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (25, 3, 5, 1, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (26, 3, 6, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (27, 3, 7, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (28, 3, 8, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (29, 3, 9, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (30, 3, 10, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (31, 4, 1, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (32, 4, 2, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (33, 4, 3, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (34, 4, 4, 1, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (35, 4, 5, 1, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (36, 4, 6, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (37, 4, 7, 1, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (38, 4, 8, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (39, 4, 9, 1, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (40, 4, 10, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (41, 5, 1, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (42, 5, 2, 1, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (43, 5, 3, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (44, 5, 4, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (45, 5, 5, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (46, 5, 6, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (47, 5, 7, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (48, 5, 8, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (49, 5, 9, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (50, 5, 10, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (51, 6, 1, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (52, 6, 2, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (53, 6, 3, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (54, 6, 4, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (55, 6, 5, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (56, 6, 6, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (57, 6, 7, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (58, 6, 8, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (59, 6, 9, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (60, 6, 10, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (61, 7, 1, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (62, 7, 2, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (63, 7, 3, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (64, 7, 4, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (65, 7, 5, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (66, 7, 6, 1, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (67, 7, 7, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (68, 7, 8, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (69, 7, 9, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (70, 7, 10, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (71, 8, 1, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (72, 8, 2, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (73, 8, 3, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (74, 8, 4, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (75, 8, 5, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (76, 8, 6, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (77, 8, 7, 1, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (78, 8, 8, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (79, 8, 9, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (80, 8, 10, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (81, 9, 1, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (82, 9, 2, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (83, 9, 3, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (84, 9, 4, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (85, 9, 5, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (86, 9, 6, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (87, 9, 7, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (88, 9, 8, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (89, 9, 9, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (90, 9, 10, 0, 2)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (91, 1, 1, 1, 3)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (92, 1, 2, 1, 3)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (93, 1, 3, 1, 3)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (94, 1, 4, 0, 3)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (95, 1, 5, 0, 3)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (96, 2, 1, 0, 3)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (97, 2, 2, 0, 3)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (98, 2, 3, 0, 3)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (99, 2, 4, 0, 3)
GO
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (100, 2, 5, 0, 3)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (101, 3, 1, 0, 3)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (102, 3, 2, 0, 3)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (103, 3, 3, 1, 3)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (104, 3, 4, 0, 3)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (105, 3, 5, 0, 3)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (106, 4, 1, 0, 3)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (107, 4, 2, 0, 3)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (108, 4, 3, 0, 3)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (109, 4, 4, 0, 3)
INSERT [dbo].[Seats] ([Id], [RowNumber], [SeatNumber], [IsOccupied], [HallId]) VALUES (110, 4, 5, 0, 3)
SET IDENTITY_INSERT [dbo].[Seats] OFF
GO
SET IDENTITY_INSERT [dbo].[Sessions] ON 

INSERT [dbo].[Sessions] ([Id], [StartDateTime], [EndDateTime], [FilmId], [Price], [HallId]) VALUES (1, CAST(N'2025-10-10T20:30:00.000' AS DateTime), CAST(N'2025-10-10T22:46:00.000' AS DateTime), 3, CAST(400.00 AS Decimal(9, 2)), 2)
INSERT [dbo].[Sessions] ([Id], [StartDateTime], [EndDateTime], [FilmId], [Price], [HallId]) VALUES (11, CAST(N'2025-06-19T15:10:00.000' AS DateTime), CAST(N'2025-06-19T17:05:00.000' AS DateTime), 17, CAST(550.00 AS Decimal(9, 2)), 3)
SET IDENTITY_INSERT [dbo].[Sessions] OFF
GO
SET IDENTITY_INSERT [dbo].[Tickets] ON 

INSERT [dbo].[Tickets] ([Id], [SessionId], [Price], [SeatId], [SaleDateTime]) VALUES (1, 1, CAST(400.00 AS Decimal(9, 2)), 1, CAST(N'2025-10-09T00:00:00.000' AS DateTime))
INSERT [dbo].[Tickets] ([Id], [SessionId], [Price], [SeatId], [SaleDateTime]) VALUES (2, 1, CAST(400.00 AS Decimal(9, 2)), 77, CAST(N'2025-04-25T13:56:56.810' AS DateTime))
INSERT [dbo].[Tickets] ([Id], [SessionId], [Price], [SeatId], [SaleDateTime]) VALUES (10, 1, CAST(400.00 AS Decimal(9, 2)), 34, CAST(N'2025-05-21T03:40:06.470' AS DateTime))
INSERT [dbo].[Tickets] ([Id], [SessionId], [Price], [SeatId], [SaleDateTime]) VALUES (11, 1, CAST(400.00 AS Decimal(9, 2)), 35, CAST(N'2025-05-21T03:41:41.223' AS DateTime))
INSERT [dbo].[Tickets] ([Id], [SessionId], [Price], [SeatId], [SaleDateTime]) VALUES (12, 11, CAST(550.00 AS Decimal(9, 2)), 103, CAST(N'2025-05-21T12:27:24.833' AS DateTime))
INSERT [dbo].[Tickets] ([Id], [SessionId], [Price], [SeatId], [SaleDateTime]) VALUES (13, 1, CAST(400.00 AS Decimal(9, 2)), 42, CAST(N'2025-05-21T22:59:47.403' AS DateTime))
INSERT [dbo].[Tickets] ([Id], [SessionId], [Price], [SeatId], [SaleDateTime]) VALUES (14, 1, CAST(400.00 AS Decimal(9, 2)), 25, CAST(N'2025-05-22T01:10:43.100' AS DateTime))
SET IDENTITY_INSERT [dbo].[Tickets] OFF
GO
SET IDENTITY_INSERT [dbo].[Workers] ON 

INSERT [dbo].[Workers] ([Id], [FirstName], [LastName], [MiddleName], [BirthDate], [Gender], [Address], [PhoneNumber], [PassportData], [PostId], [Salary], [Responsibilities], [Requirements], [Email], [Password]) VALUES (1, N'Иван', N'Иванов', N'Иванович', CAST(N'2006-09-23' AS Date), N'M', N'г. Москва пер. Печатников д. 16 кв. 1', N'+7 922 492 48 43', N'6520123432', 1, CAST(3500000.00 AS Decimal(12, 2)), N'Уборка помещений после проведения сеанса', N'Высшее техническое образование.', NULL, NULL)
INSERT [dbo].[Workers] ([Id], [FirstName], [LastName], [MiddleName], [BirthDate], [Gender], [Address], [PhoneNumber], [PassportData], [PostId], [Salary], [Responsibilities], [Requirements], [Email], [Password]) VALUES (2, N'Александр', N'Игнатьев', N'Дмитриевич', CAST(N'1999-06-30' AS Date), N'M', N'г. Москва пер. Большой Афанасьевский д. 28 кв 145', N'+7 982 321 44 34', N'4584234133', 4, CAST(12000000.00 AS Decimal(12, 2)), N'Редактирование информации о фильмах и сотрудниках. Предоставлять ежедневный отчёт о продажах.', N'Ответственность и дисциплинированность. Навыки работы с отчётностью и аналитикой продаж', N'ignatiev@yandex.ru', N'Film2025!')
INSERT [dbo].[Workers] ([Id], [FirstName], [LastName], [MiddleName], [BirthDate], [Gender], [Address], [PhoneNumber], [PassportData], [PostId], [Salary], [Responsibilities], [Requirements], [Email], [Password]) VALUES (4, N'Ярослав', N'Кожевников', N'Петрович', CAST(N'1970-06-11' AS Date), N'М', N'Ул. Пушкина д.123 кв.434', N'89224564390', N'3412456783', 1, CAST(34500.90 AS Decimal(12, 2)), N'Мыть туалеты', N'Своя швабра', N'Kozhe@gmail.com', N'iouq2wey3')
SET IDENTITY_INSERT [dbo].[Workers] OFF
GO
ALTER TABLE [dbo].[Actors]  WITH CHECK ADD  CONSTRAINT [FK_Actors_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[Actors] CHECK CONSTRAINT [FK_Actors_Countries]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Seats] FOREIGN KEY([SeatId])
REFERENCES [dbo].[Seats] ([Id])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Seats]
GO
ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Sessions] FOREIGN KEY([SessionId])
REFERENCES [dbo].[Sessions] ([Id])
GO
ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Sessions]
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
ALTER TABLE [dbo].[Sessions]  WITH CHECK ADD  CONSTRAINT [FK_Sessions_Halls] FOREIGN KEY([HallId])
REFERENCES [dbo].[Halls] ([Id])
GO
ALTER TABLE [dbo].[Sessions] CHECK CONSTRAINT [FK_Sessions_Halls]
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
