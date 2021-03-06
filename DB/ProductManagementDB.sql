USE [master]
GO
/****** Object:  Database [ProductManagementDB]    Script Date: 8/6/2015 1:12:04 PM ******/
CREATE DATABASE [ProductManagementDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProductManagementDB', FILENAME = N'E:\BASIS _SEIP - Practice (.NET)\Project Product Management App\ProductManagementApp\DB\ProductManagementDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ProductManagementDB_log', FILENAME = N'E:\BASIS _SEIP - Practice (.NET)\Project Product Management App\ProductManagementApp\DB\ProductManagementDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ProductManagementDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProductManagementDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProductManagementDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProductManagementDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProductManagementDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProductManagementDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProductManagementDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProductManagementDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProductManagementDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [ProductManagementDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProductManagementDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProductManagementDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProductManagementDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProductManagementDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProductManagementDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProductManagementDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProductManagementDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProductManagementDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProductManagementDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProductManagementDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProductManagementDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProductManagementDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProductManagementDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProductManagementDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProductManagementDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProductManagementDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProductManagementDB] SET  MULTI_USER 
GO
ALTER DATABASE [ProductManagementDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProductManagementDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProductManagementDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProductManagementDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [ProductManagementDB]
GO
/****** Object:  Table [dbo].[tbl_category]    Script Date: 8/6/2015 1:12:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_category](
	[category_id] [int] IDENTITY(1,1) NOT NULL,
	[category_code] [varchar](50) NULL,
	[category_name] [varchar](100) NULL,
 CONSTRAINT [PK_tbl_category] PRIMARY KEY CLUSTERED 
(
	[category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_product]    Script Date: 8/6/2015 1:12:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_product](
	[product_id] [int] IDENTITY(1,1) NOT NULL,
	[product_code] [varchar](50) NULL,
	[product_name] [varchar](100) NULL,
	[product_quantity] [int] NULL,
	[product_categoryId] [int] NOT NULL,
 CONSTRAINT [PK_tbl_product] PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_productSale]    Script Date: 8/6/2015 1:12:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_productSale](
	[sale_id] [int] IDENTITY(1,1) NOT NULL,
	[sale_productCode] [varchar](50) NOT NULL,
	[sale_productName] [varchar](100) NOT NULL,
	[sale_productQuantity] [int] NOT NULL,
 CONSTRAINT [PK_tbl_productSale] PRIMARY KEY CLUSTERED 
(
	[sale_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_user]    Script Date: 8/6/2015 1:12:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[full_name] [varchar](100) NULL,
	[email] [varchar](50) NULL,
	[mobile_number] [varchar](50) NULL,
	[user_name] [varchar](50) NULL,
	[password] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[view_productCategory]    Script Date: 8/6/2015 1:12:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[view_productCategory]
AS
SELECT c.category_name,p.product_id,p.product_code,p.product_name,p.product_quantity FROM tbl_product AS p
LEFT OUTER JOIN tbl_category AS c
ON p.product_categoryId = c.category_id;
GO
SET IDENTITY_INSERT [dbo].[tbl_category] ON 

INSERT [dbo].[tbl_category] ([category_id], [category_code], [category_name]) VALUES (1, N'101', N'Computer')
INSERT [dbo].[tbl_category] ([category_id], [category_code], [category_name]) VALUES (2, N'102', N'Mobile')
INSERT [dbo].[tbl_category] ([category_id], [category_code], [category_name]) VALUES (3, N'103', N'Electric')
INSERT [dbo].[tbl_category] ([category_id], [category_code], [category_name]) VALUES (5, N'104', N'Game')
INSERT [dbo].[tbl_category] ([category_id], [category_code], [category_name]) VALUES (1005, N'123', N'dfsdf')
INSERT [dbo].[tbl_category] ([category_id], [category_code], [category_name]) VALUES (2005, N'111', N'Laptop')
SET IDENTITY_INSERT [dbo].[tbl_category] OFF
SET IDENTITY_INSERT [dbo].[tbl_product] ON 

INSERT [dbo].[tbl_product] ([product_id], [product_code], [product_name], [product_quantity], [product_categoryId]) VALUES (1014, N'1014', N'Desktop', 8, 1)
INSERT [dbo].[tbl_product] ([product_id], [product_code], [product_name], [product_quantity], [product_categoryId]) VALUES (1015, N'1004', N'Laptop', 15, 1)
INSERT [dbo].[tbl_product] ([product_id], [product_code], [product_name], [product_quantity], [product_categoryId]) VALUES (1016, N'1234', N'Bike Game', 10, 5)
SET IDENTITY_INSERT [dbo].[tbl_product] OFF
SET IDENTITY_INSERT [dbo].[tbl_productSale] ON 

INSERT [dbo].[tbl_productSale] ([sale_id], [sale_productCode], [sale_productName], [sale_productQuantity]) VALUES (16, N'1001', N'Desktop', 2)
INSERT [dbo].[tbl_productSale] ([sale_id], [sale_productCode], [sale_productName], [sale_productQuantity]) VALUES (17, N'1003', N'Nokia', 3)
INSERT [dbo].[tbl_productSale] ([sale_id], [sale_productCode], [sale_productName], [sale_productQuantity]) VALUES (18, N'1003', N'Nokia', 5)
INSERT [dbo].[tbl_productSale] ([sale_id], [sale_productCode], [sale_productName], [sale_productQuantity]) VALUES (19, N'1003', N'Nokia', 5)
INSERT [dbo].[tbl_productSale] ([sale_id], [sale_productCode], [sale_productName], [sale_productQuantity]) VALUES (1018, N'1014', N'Desktop', 2)
INSERT [dbo].[tbl_productSale] ([sale_id], [sale_productCode], [sale_productName], [sale_productQuantity]) VALUES (1019, N'1014', N'Desktop', 10)
INSERT [dbo].[tbl_productSale] ([sale_id], [sale_productCode], [sale_productName], [sale_productQuantity]) VALUES (1020, N'1004', N'Laptop', 2)
INSERT [dbo].[tbl_productSale] ([sale_id], [sale_productCode], [sale_productName], [sale_productQuantity]) VALUES (1021, N'1004', N'Laptop', 2)
INSERT [dbo].[tbl_productSale] ([sale_id], [sale_productCode], [sale_productName], [sale_productQuantity]) VALUES (1022, N'1004', N'Laptop', 3)
SET IDENTITY_INSERT [dbo].[tbl_productSale] OFF
SET IDENTITY_INSERT [dbo].[tbl_user] ON 

INSERT [dbo].[tbl_user] ([id], [full_name], [email], [mobile_number], [user_name], [password]) VALUES (1, N'Md. Omar Faruk', N'faruk@gmail.com', N'01676457450', N'faruk', N'12345')
INSERT [dbo].[tbl_user] ([id], [full_name], [email], [mobile_number], [user_name], [password]) VALUES (2, N'UITS', N'uits@gmail.com', N'01812362303', N'uits', N'12345')
SET IDENTITY_INSERT [dbo].[tbl_user] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_tbl_category]    Script Date: 8/6/2015 1:12:04 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_tbl_category] ON [dbo].[tbl_category]
(
	[category_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_tbl_product]    Script Date: 8/6/2015 1:12:04 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_tbl_product] ON [dbo].[tbl_product]
(
	[product_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_tbl_user]    Script Date: 8/6/2015 1:12:04 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_tbl_user] ON [dbo].[tbl_user]
(
	[user_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_product]  WITH CHECK ADD  CONSTRAINT [FK_tbl_product_tbl_product] FOREIGN KEY([product_categoryId])
REFERENCES [dbo].[tbl_category] ([category_id])
GO
ALTER TABLE [dbo].[tbl_product] CHECK CONSTRAINT [FK_tbl_product_tbl_product]
GO
USE [master]
GO
ALTER DATABASE [ProductManagementDB] SET  READ_WRITE 
GO
