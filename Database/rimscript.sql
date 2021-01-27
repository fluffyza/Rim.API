USE [master]
GO
/****** Object:  Database [Rim]    Script Date: 2021/01/27 23:39:58 ******/
CREATE DATABASE [Rim]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Rim', FILENAME = N'[MDF TARGET]\Rim.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Rim_log', FILENAME = N'[LDF TARGET]\Rim_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Rim] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Rim].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Rim] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Rim] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Rim] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Rim] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Rim] SET ARITHABORT OFF 
GO
ALTER DATABASE [Rim] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Rim] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Rim] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Rim] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Rim] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Rim] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Rim] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Rim] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Rim] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Rim] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Rim] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Rim] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Rim] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Rim] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Rim] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Rim] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Rim] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Rim] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Rim] SET  MULTI_USER 
GO
ALTER DATABASE [Rim] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Rim] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Rim] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Rim] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Rim] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Rim] SET QUERY_STORE = OFF
GO
USE [Rim]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 2021/01/27 23:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [int] NOT NULL,
	[OrderAddress] [nvarchar](250) NOT NULL,
	[OrderRecipient] [nvarchar](250) NOT NULL,
	[OrderCompleted] [bit] NOT NULL,
	[OrderCancelled] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 2021/01/27 23:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProductGuid] [uniqueidentifier] NOT NULL,
	[ProductTitle] [nvarchar](250) NOT NULL,
	[ProductPrice] [float] NOT NULL,
	[StockCount] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([Id], [ProductId], [OrderAddress], [OrderRecipient], [OrderCompleted], [OrderCancelled], [IsActive]) VALUES (6, 14, N'Address 1', N'Name', 0, 0, 1)
INSERT [dbo].[Order] ([Id], [ProductId], [OrderAddress], [OrderRecipient], [OrderCompleted], [OrderCancelled], [IsActive]) VALUES (7, 11, N'Address 2', N'Name 2', 0, 0, 1)
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [ProductGuid], [ProductTitle], [ProductPrice], [StockCount], [IsActive]) VALUES (11, N'922956ae-d210-41f2-969f-37d54a63c4cf', N'Product 1', 20, 3, 1)
INSERT [dbo].[Product] ([Id], [ProductGuid], [ProductTitle], [ProductPrice], [StockCount], [IsActive]) VALUES (12, N'af81a68f-d404-48ae-8109-1e375609aa0e', N'Product 2', 30, 6, 1)
INSERT [dbo].[Product] ([Id], [ProductGuid], [ProductTitle], [ProductPrice], [StockCount], [IsActive]) VALUES (13, N'ae8b2e1b-bb10-42bd-96b3-d56882aa9d65', N'Product 3', 20, 6, 1)
INSERT [dbo].[Product] ([Id], [ProductGuid], [ProductTitle], [ProductPrice], [StockCount], [IsActive]) VALUES (14, N'3c7bbfa0-cb34-49ab-9eec-45ee8dd06d64', N'Product 4', 4, 21, 1)
SET IDENTITY_INSERT [dbo].[Product] OFF
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Product_Order] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Product_Order]
GO
USE [master]
GO
ALTER DATABASE [Rim] SET  READ_WRITE 
GO
