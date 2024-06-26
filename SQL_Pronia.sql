USE [master]
GO
/****** Object:  Database [Pronia_BB103]    Script Date: 11/22/2023 3:17:35 AM ******/
CREATE DATABASE [Pronia_BB103]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Pronia_BB103', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\Pronia_BB103.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Pronia_BB103_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER01\MSSQL\DATA\Pronia_BB103_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Pronia_BB103] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Pronia_BB103].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Pronia_BB103] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Pronia_BB103] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Pronia_BB103] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Pronia_BB103] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Pronia_BB103] SET ARITHABORT OFF 
GO
ALTER DATABASE [Pronia_BB103] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Pronia_BB103] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Pronia_BB103] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Pronia_BB103] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Pronia_BB103] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Pronia_BB103] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Pronia_BB103] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Pronia_BB103] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Pronia_BB103] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Pronia_BB103] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Pronia_BB103] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Pronia_BB103] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Pronia_BB103] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Pronia_BB103] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Pronia_BB103] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Pronia_BB103] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Pronia_BB103] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Pronia_BB103] SET RECOVERY FULL 
GO
ALTER DATABASE [Pronia_BB103] SET  MULTI_USER 
GO
ALTER DATABASE [Pronia_BB103] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Pronia_BB103] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Pronia_BB103] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Pronia_BB103] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Pronia_BB103] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Pronia_BB103] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Pronia_BB103', N'ON'
GO
ALTER DATABASE [Pronia_BB103] SET QUERY_STORE = ON
GO
ALTER DATABASE [Pronia_BB103] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Pronia_BB103]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/22/2023 3:17:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 11/22/2023 3:17:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Colors]    Script Date: 11/22/2023 3:17:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Colors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Colors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 11/22/2023 3:17:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ImageUrl] [nvarchar](max) NOT NULL,
	[IsPrimary] [bit] NOT NULL,
	[ProductId] [int] NOT NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductColors]    Script Date: 11/22/2023 3:17:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductColors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[ColorId] [int] NOT NULL,
 CONSTRAINT [PK_ProductColors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 11/22/2023 3:17:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[ProductCode] [nvarchar](max) NOT NULL,
	[Price] [float] NOT NULL,
	[CategoryId] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductSize]    Script Date: 11/22/2023 3:17:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductSize](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[SizeId] [int] NOT NULL,
 CONSTRAINT [PK_ProductSize] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductTag]    Script Date: 11/22/2023 3:17:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductTag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[TagId] [int] NOT NULL,
 CONSTRAINT [PK_ProductTag] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shippers]    Script Date: 11/22/2023 3:17:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shippers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[IconUrl] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Shippers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sizes]    Script Date: 11/22/2023 3:17:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sizes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Sizes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sliders]    Script Date: 11/22/2023 3:17:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sliders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Offer] [int] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[ImageUrl] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Sliders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tags]    Script Date: 11/22/2023 3:17:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231119163318_createDatabase', N'7.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231119164803_createColorsTable', N'7.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231119164842_createSizesTable', N'7.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231119164929_createCategoriesTable', N'7.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231119165004_createTagsTable', N'7.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231119165657_createProductTable', N'7.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231119170837_createPrdColorsTable', N'7.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231119202455_createSlidersTable', N'7.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231121162857_createShippingTable', N'7.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231121163111_updateShippingTable', N'7.0.14')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231121223442_updateCategoryAndShippersAndTagsTables', N'7.0.14')
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name]) VALUES (1, N'Annuals')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (2, N'Perennials')
INSERT [dbo].[Categories] ([Id], [Name]) VALUES (3, N'Cactus')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Colors] ON 

INSERT [dbo].[Colors] ([Id], [Name]) VALUES (1, N'Black')
INSERT [dbo].[Colors] ([Id], [Name]) VALUES (2, N'Red')
INSERT [dbo].[Colors] ([Id], [Name]) VALUES (3, N'Pink')
INSERT [dbo].[Colors] ([Id], [Name]) VALUES (4, N'Yellow')
INSERT [dbo].[Colors] ([Id], [Name]) VALUES (5, N'Green')
INSERT [dbo].[Colors] ([Id], [Name]) VALUES (6, N'Purple')
INSERT [dbo].[Colors] ([Id], [Name]) VALUES (7, N'Blue')
INSERT [dbo].[Colors] ([Id], [Name]) VALUES (8, N'White')
SET IDENTITY_INSERT [dbo].[Colors] OFF
GO
SET IDENTITY_INSERT [dbo].[Image] ON 

INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (1, N'1-1.jpg', 1, 1)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (2, N'1-2.jpg', 0, 1)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (3, N'1-3.jpg', 0, 1)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (4, N'1-4.jpg', 0, 1)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (5, N'2-1.jpg', 1, 2)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (6, N'2-2.jpg', 0, 2)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (7, N'2-3.jpg', 0, 2)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (8, N'2-4.jpg', 0, 2)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (9, N'3-1.jpg', 1, 3)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (10, N'3-4.jpg', 0, 3)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (11, N'3-2.jpg', 0, 3)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (12, N'3-3.jpg', 0, 3)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (13, N'4-1.jpg', 1, 4)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (14, N'4-2.jpg', 0, 4)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (15, N'4-3.jpg', 0, 4)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (16, N'4-4.jpg', 0, 4)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (17, N'5-1.jpg', 1, 5)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (18, N'5-2.jpg', 0, 5)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (19, N'5-3.jpg', 0, 5)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (20, N'5-4.jpg', 0, 5)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (21, N'6-1.jpg', 1, 6)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (22, N'6-2.jpg', 0, 6)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (23, N'6-3.jpg', 0, 6)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (24, N'6-4.jpg', 0, 6)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (25, N'7-1.jpg', 1, 7)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (26, N'7-2.jpg', 0, 7)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (27, N'7-3.jpg', 0, 7)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (28, N'7-4.jpg', 0, 7)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (29, N'8-1.jpg', 1, 8)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (30, N'8-2.jpg', 0, 8)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (31, N'8-3.jpg', 0, 8)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (32, N'8-4.jpg', 0, 8)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (33, N'9-1.jpg', 1, 9)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (34, N'9-2.jpg', 0, 9)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (35, N'9-3.jpg', 0, 9)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (36, N'9-4.jpg', 0, 9)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (37, N'10-1.jpg', 1, 10)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (38, N'10-2.jpg', 0, 10)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (39, N'10-3.jpg', 0, 10)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (40, N'10-4.jpg', 0, 10)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (41, N'11-1.jpg', 1, 11)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (42, N'11-2.jpg', 0, 11)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (43, N'11-3.jpg', 0, 11)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (44, N'11-4.jpg', 0, 11)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (45, N'12-1.jpg', 1, 12)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (46, N'12-2.jpg', 0, 12)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (47, N'12-3.jpg', 0, 12)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (48, N'12-4.jpg', 0, 12)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (49, N'13-1.jpg', 1, 13)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (50, N'13-2.jpg', 0, 13)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (51, N'13-3.jpg', 0, 13)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (52, N'13-4.jpg', 0, 13)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (53, N'14-1.jpg', 1, 14)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (54, N'14-2.jpg', 0, 14)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (55, N'14-3.jpg', 0, 14)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (56, N'14-4.jpg', 0, 14)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (57, N'15-1.jpg', 1, 15)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (58, N'15-2.jpg', 0, 15)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (59, N'15-3.jpg', 0, 15)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (60, N'15-4.jpg', 0, 15)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (61, N'16-1.jpg', 1, 16)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (62, N'16-2.jpg', 0, 16)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (63, N'16-3.jpg', 0, 16)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (64, N'16-4.jpg', 0, 16)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (65, N'17-1.jpg', 1, 17)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (66, N'17-2.jpg', 0, 17)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (67, N'17-3.jpg', 0, 17)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (68, N'17-4.jpg', 0, 17)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (69, N'18-1.jpg', 1, 18)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (70, N'18-2.jpg', 0, 18)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (71, N'18-3.jpg', 0, 18)
INSERT [dbo].[Image] ([Id], [ImageUrl], [IsPrimary], [ProductId]) VALUES (72, N'18-4.jpg', 0, 18)
SET IDENTITY_INSERT [dbo].[Image] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductColors] ON 

INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (1, 1, 6)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (2, 1, 8)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (3, 2, 3)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (4, 2, 4)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (5, 2, 8)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (6, 3, 2)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (7, 3, 7)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (8, 3, 8)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (9, 4, 3)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (10, 4, 4)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (11, 4, 6)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (12, 5, 2)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (13, 5, 6)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (14, 5, 8)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (15, 6, 1)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (16, 6, 2)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (17, 6, 7)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (18, 6, 8)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (19, 7, 3)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (20, 7, 8)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (21, 8, 2)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (22, 8, 4)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (23, 8, 6)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (24, 9, 2)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (25, 9, 7)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (26, 10, 5)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (27, 10, 6)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (28, 10, 7)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (29, 11, 3)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (30, 11, 6)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (31, 11, 7)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (32, 11, 8)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (33, 12, 6)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (34, 13, 6)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (35, 13, 7)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (36, 14, 2)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (37, 14, 3)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (38, 14, 4)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (39, 14, 6)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (40, 14, 7)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (41, 14, 8)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (42, 15, 2)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (43, 16, 6)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (44, 16, 7)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (45, 17, 5)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (46, 17, 6)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (47, 18, 4)
INSERT [dbo].[ProductColors] ([Id], [ProductId], [ColorId]) VALUES (48, 18, 8)
SET IDENTITY_INSERT [dbo].[ProductColors] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Title], [Description], [ProductCode], [Price], [CategoryId]) VALUES (1, N'Calla Lily', N'Calla lilies come in a variety of different colors, from snow white to bright pink. They feature a beautiful trumpet shape with smooth, sword-like foliage.', N'CL-101', 14.9, 1)
INSERT [dbo].[Products] ([Id], [Title], [Description], [ProductCode], [Price], [CategoryId]) VALUES (2, N'Daisy', N'Daisies are a bright and fun flower. The petals come in a variety of colors, including white, blue, and lavender. Daisies feature a yellow central disc with a long stem.', N'DA-102', 15.2, 1)
INSERT [dbo].[Products] ([Id], [Title], [Description], [ProductCode], [Price], [CategoryId]) VALUES (3, N'Gardenia', N'Notable for their wax-like appearance and oval-shaped leaves, gardenia flowers range from pale yellow to creamy white. Gardenias are also known for their sweet scent.', N'GA-103', 19.3, 2)
INSERT [dbo].[Products] ([Id], [Title], [Description], [ProductCode], [Price], [CategoryId]) VALUES (4, N'Carnation', N'A double layer of petals with crinkly edges are the chief characteristics of carnations. They come in a wide variety of colors and can be dyed to practically any color and shade on earth.', N'CA-104', 43.2, 1)
INSERT [dbo].[Products] ([Id], [Title], [Description], [ProductCode], [Price], [CategoryId]) VALUES (5, N'Orchid', N'Orchid flowers include several notable features, including three petals, three sepals, and a single lip that extends, which is known as a labellum. Orchids also have a waxy tube-like structure in the center of the flower called a column.', N'OR-105', 31.5, 2)
INSERT [dbo].[Products] ([Id], [Title], [Description], [ProductCode], [Price], [CategoryId]) VALUES (6, N'Tulip', N'Tulips have ruffled petals with streaks of colors and are available in a variety of colors including pink, red, yellow, orange, purple, and white. There are a wide variety of types of tulips, and they are often cultivated to achieve different characteristics.', N'TU-106', 24.3, 2)
INSERT [dbo].[Products] ([Id], [Title], [Description], [ProductCode], [Price], [CategoryId]) VALUES (7, N'Peony', N'Peonies have large, wonderfully fragrant flowers, in colors including everything from purple and pink to darker shades of red. They have a short blooming season, which only lasts about a week or so.', N'PE-107', 48.3, 2)
INSERT [dbo].[Products] ([Id], [Title], [Description], [ProductCode], [Price], [CategoryId]) VALUES (8, N'Dahlia', N'In a rainbow of colors, dahlia flowers range from two-inch blooms to giant blossoms that measure up to 15 inches. Most types grow four to five feet tall.', N'DA-108', 21, 1)
INSERT [dbo].[Products] ([Id], [Title], [Description], [ProductCode], [Price], [CategoryId]) VALUES (9, N'Azalea', N'The leaves, size, and shape of azaleas vary greatly by variety, and they range in color from pink to red to salmon. Azaleas are flowering shrubs in the rhododendron family, but not all rhododendrons are azaleas.', N'AZ-109', 22.8, 2)
INSERT [dbo].[Products] ([Id], [Title], [Description], [ProductCode], [Price], [CategoryId]) VALUES (10, N'Chrysanthemum', N'Chrysanthemums are staples in fall gardens. They are best known for their bright flowers in every color of the rainbow and a full, dramatic display of blooms in a round semi-circle above the foliage.', N'CH-110', 11.1, 1)
INSERT [dbo].[Products] ([Id], [Title], [Description], [ProductCode], [Price], [CategoryId]) VALUES (11, N'Geranium', N'A classic garden plant, geranium flowers have five petals in white, pink, purple, or blue. They’re relatively easy to grow, so they’re a favorite of gardeners to plant in flower beds, along borders, and in containers.', N'GE-111', 72.3, 1)
INSERT [dbo].[Products] ([Id], [Title], [Description], [ProductCode], [Price], [CategoryId]) VALUES (12, N'Lavender', N'Lavender is known for its fragrance, medicinal properties, and beautiful bluish-purple color. it blooms in the summer months and is a favorite of bees and butterflies.', N'LA-112', 88.8, 2)
INSERT [dbo].[Products] ([Id], [Title], [Description], [ProductCode], [Price], [CategoryId]) VALUES (13, N'Iris', N'Iris flowers have an unusual, but beautiful appearance. The petals resemble a fleur-de-lis, with some petals standing straight up while others slope down atop long, erect stems.', N'IR-113', 32.5, 1)
INSERT [dbo].[Products] ([Id], [Title], [Description], [ProductCode], [Price], [CategoryId]) VALUES (14, N'Rose', N'Roses are perhaps the most popular cut flower for floral displays. They feature a tight coil of petals that range in color from white to tones of yellow, pink, and dark crimson and have a delightful fragrance.', N'RO-114', 41.7, 2)
INSERT [dbo].[Products] ([Id], [Title], [Description], [ProductCode], [Price], [CategoryId]) VALUES (15, N'Poppy', N'Bright red in color with big, showy flowers and feathery green foliage, poppies are a beautiful flower. Poppies are also commonly often worn on Memorial Day to honor fallen soldiers.', N'PO-115', 12.3, 1)
INSERT [dbo].[Products] ([Id], [Title], [Description], [ProductCode], [Price], [CategoryId]) VALUES (16, N'Crocus', N'Crocuses bloom bright and early in the spring (sometimes they even poke through the snow) and lead the way for other springtime flowers to emerge. They come in purple, blue, yellow, pink, and white and grow low to the ground.', N'CR-116', 34.2, 2)
INSERT [dbo].[Products] ([Id], [Title], [Description], [ProductCode], [Price], [CategoryId]) VALUES (17, N'Periwinkle', N'Periwinkle is often used by gardeners as an evergreen ground cover due to its dark green foliage. Its flowers are purple, blue, or white, depending on the variety.', N'PE-117', 28.3, 2)
INSERT [dbo].[Products] ([Id], [Title], [Description], [ProductCode], [Price], [CategoryId]) VALUES (18, N'Daffodil', N'Bright and fragrant flowers, daffodils bloom early in the spring. The blossoms feature six petals and a trumpet in the middle and are typically a combination of bright yellow and white.', N'DA-118', 18.8, 2)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductSize] ON 

INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (1, 1, 1)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (2, 1, 2)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (3, 2, 1)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (4, 2, 4)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (6, 3, 2)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (7, 3, 3)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (8, 4, 1)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (9, 4, 2)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (10, 4, 3)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (11, 5, 2)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (12, 5, 3)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (13, 6, 1)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (14, 6, 2)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (15, 7, 2)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (16, 8, 2)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (17, 8, 3)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (18, 9, 1)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (19, 9, 4)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (20, 10, 1)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (21, 10, 2)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (22, 10, 4)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (23, 11, 1)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (24, 11, 4)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (25, 12, 2)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (26, 12, 3)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (27, 13, 1)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (28, 13, 2)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (29, 14, 1)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (30, 14, 2)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (31, 14, 3)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (32, 14, 4)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (33, 15, 2)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (34, 15, 3)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (35, 16, 1)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (36, 16, 4)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (37, 17, 1)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (38, 17, 2)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (39, 18, 1)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (40, 18, 2)
INSERT [dbo].[ProductSize] ([Id], [ProductId], [SizeId]) VALUES (41, 18, 3)
SET IDENTITY_INSERT [dbo].[ProductSize] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductTag] ON 

INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (1, 1, 2)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (2, 1, 3)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (3, 2, 2)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (4, 2, 3)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (5, 3, 1)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (6, 3, 4)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (7, 4, 2)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (8, 4, 4)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (9, 5, 2)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (10, 5, 3)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (11, 6, 2)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (12, 6, 3)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (13, 7, 1)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (14, 7, 4)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (15, 8, 2)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (16, 8, 4)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (17, 9, 2)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (18, 9, 3)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (19, 10, 2)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (20, 10, 4)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (21, 11, 2)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (22, 11, 3)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (23, 12, 1)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (24, 12, 4)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (25, 13, 2)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (26, 13, 4)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (27, 14, 2)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (28, 14, 4)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (29, 15, 1)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (30, 15, 4)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (31, 16, 1)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (32, 16, 3)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (33, 17, 1)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (34, 17, 3)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (35, 18, 2)
INSERT [dbo].[ProductTag] ([Id], [ProductId], [TagId]) VALUES (36, 18, 3)
SET IDENTITY_INSERT [dbo].[ProductTag] OFF
GO
SET IDENTITY_INSERT [dbo].[Shippers] ON 

INSERT [dbo].[Shippers] ([Id], [Title], [Description], [IconUrl]) VALUES (1, N'Free Shipping', N'Capped at $319 per order', N'car.png')
INSERT [dbo].[Shippers] ([Id], [Title], [Description], [IconUrl]) VALUES (2, N'Safe Payment', N'With our payment gateway', N'card.png')
INSERT [dbo].[Shippers] ([Id], [Title], [Description], [IconUrl]) VALUES (3, N'Best Services', N'Friendly & Supper Services', N'service.png')
SET IDENTITY_INSERT [dbo].[Shippers] OFF
GO
SET IDENTITY_INSERT [dbo].[Sizes] ON 

INSERT [dbo].[Sizes] ([Id], [Name]) VALUES (1, N'Small')
INSERT [dbo].[Sizes] ([Id], [Name]) VALUES (2, N'Medium')
INSERT [dbo].[Sizes] ([Id], [Name]) VALUES (3, N'Big')
INSERT [dbo].[Sizes] ([Id], [Name]) VALUES (4, N'Mini')
SET IDENTITY_INSERT [dbo].[Sizes] OFF
GO
SET IDENTITY_INSERT [dbo].[Sliders] ON 

INSERT [dbo].[Sliders] ([Id], [Offer], [Title], [Description], [ImageUrl]) VALUES (1, 30, N'Daisy', N'--------', N'2-1.jpg')
INSERT [dbo].[Sliders] ([Id], [Offer], [Title], [Description], [ImageUrl]) VALUES (2, 21, N'Lavander', N'--------', N'12-3.jpg')
INSERT [dbo].[Sliders] ([Id], [Offer], [Title], [Description], [ImageUrl]) VALUES (3, 18, N'Rose', N'--------', N'14-2.jpg')
SET IDENTITY_INSERT [dbo].[Sliders] OFF
GO
SET IDENTITY_INSERT [dbo].[Tags] ON 

INSERT [dbo].[Tags] ([Id], [Name]) VALUES (1, N'Artificial')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (2, N'Natural')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (3, N'Bottom')
INSERT [dbo].[Tags] ([Id], [Name]) VALUES (4, N'Bouquet')
SET IDENTITY_INSERT [dbo].[Tags] OFF
GO
/****** Object:  Index [IX_Image_ProductId]    Script Date: 11/22/2023 3:17:35 AM ******/
CREATE NONCLUSTERED INDEX [IX_Image_ProductId] ON [dbo].[Image]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductColors_ColorId]    Script Date: 11/22/2023 3:17:35 AM ******/
CREATE NONCLUSTERED INDEX [IX_ProductColors_ColorId] ON [dbo].[ProductColors]
(
	[ColorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductColors_ProductId]    Script Date: 11/22/2023 3:17:35 AM ******/
CREATE NONCLUSTERED INDEX [IX_ProductColors_ProductId] ON [dbo].[ProductColors]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_CategoryId]    Script Date: 11/22/2023 3:17:35 AM ******/
CREATE NONCLUSTERED INDEX [IX_Products_CategoryId] ON [dbo].[Products]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductSize_ProductId]    Script Date: 11/22/2023 3:17:35 AM ******/
CREATE NONCLUSTERED INDEX [IX_ProductSize_ProductId] ON [dbo].[ProductSize]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductSize_SizeId]    Script Date: 11/22/2023 3:17:35 AM ******/
CREATE NONCLUSTERED INDEX [IX_ProductSize_SizeId] ON [dbo].[ProductSize]
(
	[SizeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductTag_ProductId]    Script Date: 11/22/2023 3:17:35 AM ******/
CREATE NONCLUSTERED INDEX [IX_ProductTag_ProductId] ON [dbo].[ProductTag]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ProductTag_TagId]    Script Date: 11/22/2023 3:17:35 AM ******/
CREATE NONCLUSTERED INDEX [IX_ProductTag_TagId] ON [dbo].[ProductTag]
(
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Shippers] ADD  DEFAULT (N'') FOR [IconUrl]
GO
ALTER TABLE [dbo].[Image]  WITH CHECK ADD  CONSTRAINT [FK_Image_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Image] CHECK CONSTRAINT [FK_Image_Products_ProductId]
GO
ALTER TABLE [dbo].[ProductColors]  WITH CHECK ADD  CONSTRAINT [FK_ProductColors_Colors_ColorId] FOREIGN KEY([ColorId])
REFERENCES [dbo].[Colors] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductColors] CHECK CONSTRAINT [FK_ProductColors_Colors_ColorId]
GO
ALTER TABLE [dbo].[ProductColors]  WITH CHECK ADD  CONSTRAINT [FK_ProductColors_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductColors] CHECK CONSTRAINT [FK_ProductColors_Products_ProductId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories_CategoryId]
GO
ALTER TABLE [dbo].[ProductSize]  WITH CHECK ADD  CONSTRAINT [FK_ProductSize_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductSize] CHECK CONSTRAINT [FK_ProductSize_Products_ProductId]
GO
ALTER TABLE [dbo].[ProductSize]  WITH CHECK ADD  CONSTRAINT [FK_ProductSize_Sizes_SizeId] FOREIGN KEY([SizeId])
REFERENCES [dbo].[Sizes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductSize] CHECK CONSTRAINT [FK_ProductSize_Sizes_SizeId]
GO
ALTER TABLE [dbo].[ProductTag]  WITH CHECK ADD  CONSTRAINT [FK_ProductTag_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductTag] CHECK CONSTRAINT [FK_ProductTag_Products_ProductId]
GO
ALTER TABLE [dbo].[ProductTag]  WITH CHECK ADD  CONSTRAINT [FK_ProductTag_Tags_TagId] FOREIGN KEY([TagId])
REFERENCES [dbo].[Tags] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ProductTag] CHECK CONSTRAINT [FK_ProductTag_Tags_TagId]
GO
USE [master]
GO
ALTER DATABASE [Pronia_BB103] SET  READ_WRITE 
GO
