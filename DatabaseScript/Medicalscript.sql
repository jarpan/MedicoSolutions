USE [master]
GO
/****** Object:  Database [MedicoSolutions]    Script Date: 12/05/2014 19:03:03 ******/
CREATE DATABASE [MedicoSolutions] ON  PRIMARY 
( NAME = N'MedicoSolutions', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\MedicoSolutions.mdf' , SIZE = 2304KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MedicoSolutions_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\MedicoSolutions_log.LDF' , SIZE = 576KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MedicoSolutions] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MedicoSolutions].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MedicoSolutions] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [MedicoSolutions] SET ANSI_NULLS OFF
GO
ALTER DATABASE [MedicoSolutions] SET ANSI_PADDING OFF
GO
ALTER DATABASE [MedicoSolutions] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [MedicoSolutions] SET ARITHABORT OFF
GO
ALTER DATABASE [MedicoSolutions] SET AUTO_CLOSE ON
GO
ALTER DATABASE [MedicoSolutions] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [MedicoSolutions] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [MedicoSolutions] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [MedicoSolutions] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [MedicoSolutions] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [MedicoSolutions] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [MedicoSolutions] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [MedicoSolutions] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [MedicoSolutions] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [MedicoSolutions] SET  ENABLE_BROKER
GO
ALTER DATABASE [MedicoSolutions] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [MedicoSolutions] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [MedicoSolutions] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [MedicoSolutions] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [MedicoSolutions] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [MedicoSolutions] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [MedicoSolutions] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [MedicoSolutions] SET  READ_WRITE
GO
ALTER DATABASE [MedicoSolutions] SET RECOVERY SIMPLE
GO
ALTER DATABASE [MedicoSolutions] SET  MULTI_USER
GO
ALTER DATABASE [MedicoSolutions] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [MedicoSolutions] SET DB_CHAINING OFF
GO
USE [MedicoSolutions]
GO
/****** Object:  Table [dbo].[Search_medicine]    Script Date: 12/05/2014 19:03:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Search_medicine](
	[Medicine_Name] [varchar](50) NULL,
	[Shop_name] [varchar](150) NULL,
	[Address] [varchar](200) NULL,
	[Phone_number] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Search_medicine] ([Medicine_Name], [Shop_name], [Address], [Phone_number]) VALUES (N'Crocin', N'Siddharth Medico', N'Krishna nagar', N'9560146687')
INSERT [dbo].[Search_medicine] ([Medicine_Name], [Shop_name], [Address], [Phone_number]) VALUES (N'Sumo', N'Vishal Medico', N'Noida', N'9999926075')
INSERT [dbo].[Search_medicine] ([Medicine_Name], [Shop_name], [Address], [Phone_number]) VALUES (N'Crocin', N'NehaMedico', N'Delhi', N'9810146945')
INSERT [dbo].[Search_medicine] ([Medicine_Name], [Shop_name], [Address], [Phone_number]) VALUES (N'Volini', N'Vashishta Agencies', N'Noida', N'9811145983')
INSERT [dbo].[Search_medicine] ([Medicine_Name], [Shop_name], [Address], [Phone_number]) VALUES (N'Stator10', N'Krishanchand Medico', N'Ghaziabad', N'9321391231')
INSERT [dbo].[Search_medicine] ([Medicine_Name], [Shop_name], [Address], [Phone_number]) VALUES (N'Disprin', N'Smath Medicos', N'Radheypuri', N'9312453244')
INSERT [dbo].[Search_medicine] ([Medicine_Name], [Shop_name], [Address], [Phone_number]) VALUES (N'Olsar', N'Jaycee Medicos', N'Noida', N'9832132255')
/****** Object:  Table [dbo].[mst_vendor]    Script Date: 12/05/2014 19:03:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [dbo].[mst_vendor](
	[vendor_id] [varchar](150) NOT NULL,
	[name] [varchar](50) NULL,
	[phno] [varchar](50) NULL,
	[address] [varchar](500) NULL,
	[email] [varchar](50) NULL,
	[dateOfvendorcreated] [datetime] NULL,
	[IsActive] [int] NULL,
 CONSTRAINT [PK_mst_vendor] PRIMARY KEY CLUSTERED 
(
	[vendor_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[mst_vendor] ([vendor_id], [name], [phno], [address], [email], [dateOfvendorcreated], [IsActive]) VALUES (N'635501365264385834', N'SnehilDistributors', N'9560146687', N'krishna nagar extn', N'abc@xyz.com', CAST(0x0000A3CC00000000 AS DateTime), 1)
INSERT [dbo].[mst_vendor] ([vendor_id], [name], [phno], [address], [email], [dateOfvendorcreated], [IsActive]) VALUES (N'635504856083938025', N'Tarun Verma', N'9876543210', N'Rohini', N'gautam@gmail.com', CAST(0x0000A2A500000000 AS DateTime), 1)
INSERT [dbo].[mst_vendor] ([vendor_id], [name], [phno], [address], [email], [dateOfvendorcreated], [IsActive]) VALUES (N'635509005590851088', N'Arpan Enterprises', N'9999926075', N'e-block,krishna nagar', N'jarpan@gmail.com', CAST(0x0000A3D600000000 AS DateTime), 1)
INSERT [dbo].[mst_vendor] ([vendor_id], [name], [phno], [address], [email], [dateOfvendorcreated], [IsActive]) VALUES (N'635509006218255714', N'Gautam Jain', N'9560146687', N'Sector 128,Noida', N'gautam@yahoo.com', CAST(0x0000A3DC00000000 AS DateTime), 1)
INSERT [dbo].[mst_vendor] ([vendor_id], [name], [phno], [address], [email], [dateOfvendorcreated], [IsActive]) VALUES (N'635509571526642913', N'Jaypee', N'9876543210', N'Noida', N'abc@xyz.com', CAST(0x0000A3DC00000000 AS DateTime), 1)
INSERT [dbo].[mst_vendor] ([vendor_id], [name], [phno], [address], [email], [dateOfvendorcreated], [IsActive]) VALUES (N'635532377736791133', N'JagdishMedicos', N'9999557957', N'E-Block,Krishna Nagar', N'jm@gmail.com', CAST(0x0000A3F600000000 AS DateTime), 1)
INSERT [dbo].[mst_vendor] ([vendor_id], [name], [phno], [address], [email], [dateOfvendorcreated], [IsActive]) VALUES (N'635532378775516644', N'MedicinePalace', N'9463285621', N'Sector 5,Noida', N'mdpl@yahoo.com', CAST(0x0000A3F400000000 AS DateTime), 1)
/****** Object:  Table [dbo].[mst_user]    Script Date: 12/05/2014 19:03:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[mst_user](
	[Email_id] [varchar](150) NOT NULL,
	[User_name] [varchar](50) NULL,
	[Date_registration] [datetime] NULL,
	[Password] [varchar](50) NULL,
	[IsActive] [int] NULL,
	[Phone_no] [varchar](50) NULL,
 CONSTRAINT [PK_mst_user] PRIMARY KEY CLUSTERED 
(
	[Email_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[mst_user] ([Email_id], [User_name], [Date_registration], [Password], [IsActive], [Phone_no]) VALUES (N'aakash@yahoo.in', N'Aakash', CAST(0x0000A3DB014B6CEC AS DateTime), N'1', 1, N'9213979525')
INSERT [dbo].[mst_user] ([Email_id], [User_name], [Date_registration], [Password], [IsActive], [Phone_no]) VALUES (N'admin@medicoSolution.in', N'Admin', CAST(0x0000A3DB014B6CEC AS DateTime), N'1', 2, N'0000000000')
INSERT [dbo].[mst_user] ([Email_id], [User_name], [Date_registration], [Password], [IsActive], [Phone_no]) VALUES (N'gautam.jain7494@gmail.com', N'gautam', CAST(0x0000A3D5018A2AA4 AS DateTime), N'EAWHCI', 1, N'9876543210')
INSERT [dbo].[mst_user] ([Email_id], [User_name], [Date_registration], [Password], [IsActive], [Phone_no]) VALUES (N'harsh@gmail.com', N'Harsh', CAST(0x0000A3F700FB2DF4 AS DateTime), N'IEICIN', 1, N'9717464694')
INSERT [dbo].[mst_user] ([Email_id], [User_name], [Date_registration], [Password], [IsActive], [Phone_no]) VALUES (N'jarpan@yahoo.in', N'Arpan', CAST(0x0000A3DB014AE4FC AS DateTime), N'1', 1, N'9999926075')
INSERT [dbo].[mst_user] ([Email_id], [User_name], [Date_registration], [Password], [IsActive], [Phone_no]) VALUES (N'kay@kay.com', N'Karikay', CAST(0x0000A3F800D4B584 AS DateTime), N'TQOSEE', 1, N'7838060047')
INSERT [dbo].[mst_user] ([Email_id], [User_name], [Date_registration], [Password], [IsActive], [Phone_no]) VALUES (N'shanky@hotmail.com', N'Shanky', CAST(0x0000A3DB014B4FA0 AS DateTime), N'ZGEFMZ', 1, N'9899579200')
INSERT [dbo].[mst_user] ([Email_id], [User_name], [Date_registration], [Password], [IsActive], [Phone_no]) VALUES (N'snehil@gmail.com', N'Snehil', CAST(0x0000A3DB014B269C AS DateTime), N'PDFANI', 1, N'9876542222')
INSERT [dbo].[mst_user] ([Email_id], [User_name], [Date_registration], [Password], [IsActive], [Phone_no]) VALUES (N'tarun@reddif.com', N'Tarun', CAST(0x0000A3DB014B6CEC AS DateTime), N'RNEPQJ', 1, N'9876543210')
INSERT [dbo].[mst_user] ([Email_id], [User_name], [Date_registration], [Password], [IsActive], [Phone_no]) VALUES (N'tarun7013@gmail.com', N'TarunVerma', CAST(0x0000A3F800D4637C AS DateTime), N'DOSQDC', 1, N'9811767223')
/****** Object:  Table [dbo].[mst_medicine_typeMaster]    Script Date: 12/05/2014 19:03:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[mst_medicine_typeMaster](
	[medicine_type_id] [int] IDENTITY(1,1) NOT NULL,
	[medicine_type] [varchar](50) NULL,
	[medicine_description] [varchar](150) NULL,
 CONSTRAINT [PK_mst_medicine_typeMaster] PRIMARY KEY CLUSTERED 
(
	[medicine_type_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[mst_medicine_typeMaster] ON
INSERT [dbo].[mst_medicine_typeMaster] ([medicine_type_id], [medicine_type], [medicine_description]) VALUES (1, N'Antibiotic', N'Antibiotic')
INSERT [dbo].[mst_medicine_typeMaster] ([medicine_type_id], [medicine_type], [medicine_description]) VALUES (2, N'Syrup', N'Syrup')
INSERT [dbo].[mst_medicine_typeMaster] ([medicine_type_id], [medicine_type], [medicine_description]) VALUES (3, N'Tranqulizer', N'Tranqulizer')
INSERT [dbo].[mst_medicine_typeMaster] ([medicine_type_id], [medicine_type], [medicine_description]) VALUES (4, N'Analgesic', N'Analgesic')
INSERT [dbo].[mst_medicine_typeMaster] ([medicine_type_id], [medicine_type], [medicine_description]) VALUES (5, N'Antiseptic', N'Antiseptic')
INSERT [dbo].[mst_medicine_typeMaster] ([medicine_type_id], [medicine_type], [medicine_description]) VALUES (6, N'Anabolic', N'Anabolic')
INSERT [dbo].[mst_medicine_typeMaster] ([medicine_type_id], [medicine_type], [medicine_description]) VALUES (7, N'Anaesthetic', N'Anaesthetic')
INSERT [dbo].[mst_medicine_typeMaster] ([medicine_type_id], [medicine_type], [medicine_description]) VALUES (8, N'Antidote', N'Antidote')
INSERT [dbo].[mst_medicine_typeMaster] ([medicine_type_id], [medicine_type], [medicine_description]) VALUES (9, N'Antiviral', N'Antiviral')
INSERT [dbo].[mst_medicine_typeMaster] ([medicine_type_id], [medicine_type], [medicine_description]) VALUES (10, N'Sedative', N'Sedative')
SET IDENTITY_INSERT [dbo].[mst_medicine_typeMaster] OFF
/****** Object:  Table [dbo].[mst_invoice_master]    Script Date: 12/05/2014 19:03:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[mst_invoice_master](
	[Invoice_id] [varchar](50) NOT NULL,
	[invoice_date] [datetime] NULL,
	[user_id] [varchar](50) NULL,
	[amount] [decimal](18, 2) NULL,
	[discount] [decimal](18, 2) NULL,
	[billAmount] [decimal](18, 2) NULL,
	[profit_per_bill] [decimal](18, 2) NULL,
 CONSTRAINT [PK_mst_invoice_master] PRIMARY KEY CLUSTERED 
(
	[Invoice_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[mst_invoice_master] ([Invoice_id], [invoice_date], [user_id], [amount], [discount], [billAmount], [profit_per_bill]) VALUES (N'635532504091681533', CAST(0x0000A3F7000B070C AS DateTime), N'jarpan@yahoo.in', CAST(1395.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(1367.10 AS Decimal(18, 2)), CAST(382.10 AS Decimal(18, 2)))
INSERT [dbo].[mst_invoice_master] ([Invoice_id], [invoice_date], [user_id], [amount], [discount], [billAmount], [profit_per_bill]) VALUES (N'635532505997240525', CAST(0x0000A3F7000BE5B4 AS DateTime), N'shanky@hotmail.com', CAST(1260.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(1234.80 AS Decimal(18, 2)), CAST(334.80 AS Decimal(18, 2)))
INSERT [dbo].[mst_invoice_master] ([Invoice_id], [invoice_date], [user_id], [amount], [discount], [billAmount], [profit_per_bill]) VALUES (N'635532507151966571', CAST(0x0000A3F7000C6DA4 AS DateTime), N'jarpan@yahoo.in', CAST(920.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(901.60 AS Decimal(18, 2)), CAST(281.60 AS Decimal(18, 2)))
INSERT [dbo].[mst_invoice_master] ([Invoice_id], [invoice_date], [user_id], [amount], [discount], [billAmount], [profit_per_bill]) VALUES (N'635532508828192446', CAST(0x0000A3F7000D3158 AS DateTime), N'snehil@gmail.com', CAST(504.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(498.96 AS Decimal(18, 2)), CAST(118.96 AS Decimal(18, 2)))
INSERT [dbo].[mst_invoice_master] ([Invoice_id], [invoice_date], [user_id], [amount], [discount], [billAmount], [profit_per_bill]) VALUES (N'635532903900057196', CAST(0x0000A3F700C20BC8 AS DateTime), N'snehil@gmail.com', CAST(395.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), CAST(391.05 AS Decimal(18, 2)), CAST(116.05 AS Decimal(18, 2)))
INSERT [dbo].[mst_invoice_master] ([Invoice_id], [invoice_date], [user_id], [amount], [discount], [billAmount], [profit_per_bill]) VALUES (N'635533030674898951', CAST(0x0000A3F700FC13A4 AS DateTime), N'harsh@gmail.com', CAST(1208.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(1183.84 AS Decimal(18, 2)), CAST(273.84 AS Decimal(18, 2)))
INSERT [dbo].[mst_invoice_master] ([Invoice_id], [invoice_date], [user_id], [amount], [discount], [billAmount], [profit_per_bill]) VALUES (N'635533797775870180', CAST(0x0000A3F800CFB82C AS DateTime), N'jarpan63@yahoo.in', CAST(780.00 AS Decimal(18, 2)), CAST(6.00 AS Decimal(18, 2)), CAST(733.20 AS Decimal(18, 2)), CAST(113.20 AS Decimal(18, 2)))
INSERT [dbo].[mst_invoice_master] ([Invoice_id], [invoice_date], [user_id], [amount], [discount], [billAmount], [profit_per_bill]) VALUES (N'635533800203729947', CAST(0x0000A3F800D0D4F0 AS DateTime), N'jarpan@yahoo.in', CAST(638.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(625.24 AS Decimal(18, 2)), CAST(215.24 AS Decimal(18, 2)))
INSERT [dbo].[mst_invoice_master] ([Invoice_id], [invoice_date], [user_id], [amount], [discount], [billAmount], [profit_per_bill]) VALUES (N'635533809950568103', CAST(0x0000A3F800D54B84 AS DateTime), N'tarun7013@gmail.com', CAST(1110.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), CAST(999.00 AS Decimal(18, 2)), CAST(169.00 AS Decimal(18, 2)))
INSERT [dbo].[mst_invoice_master] ([Invoice_id], [invoice_date], [user_id], [amount], [discount], [billAmount], [profit_per_bill]) VALUES (N'635533824093629048', CAST(0x0000A3F800DBC48C AS DateTime), N'jarpan@yahoo.in', CAST(722.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), CAST(707.56 AS Decimal(18, 2)), CAST(157.56 AS Decimal(18, 2)))
/****** Object:  Table [dbo].[mst_companyMaster]    Script Date: 12/05/2014 19:03:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[mst_companyMaster](
	[id_company] [int] IDENTITY(1,1) NOT NULL,
	[companyname] [varchar](150) NULL,
	[description] [varchar](150) NULL,
 CONSTRAINT [PK_mst_companyMaster] PRIMARY KEY CLUSTERED 
(
	[id_company] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[mst_companyMaster] ON
INSERT [dbo].[mst_companyMaster] ([id_company], [companyname], [description]) VALUES (10, N'Ranbaxy', N'Ranbaxy')
INSERT [dbo].[mst_companyMaster] ([id_company], [companyname], [description]) VALUES (11, N'Cipla', N'Cipla')
INSERT [dbo].[mst_companyMaster] ([id_company], [companyname], [description]) VALUES (12, N'Abbot', N'Abbot')
INSERT [dbo].[mst_companyMaster] ([id_company], [companyname], [description]) VALUES (13, N'Vedic', N'Vedic')
INSERT [dbo].[mst_companyMaster] ([id_company], [companyname], [description]) VALUES (14, N'Galaxo', N'Galaxo')
INSERT [dbo].[mst_companyMaster] ([id_company], [companyname], [description]) VALUES (15, N'BDH Industries Ltd', N'BDH Industries Ltd')
INSERT [dbo].[mst_companyMaster] ([id_company], [companyname], [description]) VALUES (16, N'Celestial Labs', N'Celestial Labs')
INSERT [dbo].[mst_companyMaster] ([id_company], [companyname], [description]) VALUES (17, N'Acme Industries', N'Acme Industries')
SET IDENTITY_INSERT [dbo].[mst_companyMaster] OFF
/****** Object:  Table [dbo].[medicine_master]    Script Date: 12/05/2014 19:03:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[medicine_master](
	[medicine_id] [varchar](150) NOT NULL,
	[medicine_name] [varchar](50) NULL,
	[mrp] [decimal](18, 2) NULL,
	[SuppliedBy] [varchar](150) NULL,
	[MedicineType] [int] NULL,
	[costprice] [decimal](18, 2) NULL,
	[Quantity] [int] NULL,
	[Batch_no] [varchar](150) NULL,
	[ExpiryDate] [datetime] NULL,
 CONSTRAINT [PK_medicine_master] PRIMARY KEY CLUSTERED 
(
	[medicine_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[medicine_master] ([medicine_id], [medicine_name], [mrp], [SuppliedBy], [MedicineType], [costprice], [Quantity], [Batch_no], [ExpiryDate]) VALUES (N'1', N'Sumo', CAST(50.00 AS Decimal(18, 2)), N'635501365264385834', 4, CAST(30.00 AS Decimal(18, 2)), 65, N'1000', CAST(0x0000A3F300000000 AS DateTime))
INSERT [dbo].[medicine_master] ([medicine_id], [medicine_name], [mrp], [SuppliedBy], [MedicineType], [costprice], [Quantity], [Batch_no], [ExpiryDate]) VALUES (N'2', N'Disprin', CAST(36.00 AS Decimal(18, 2)), N'635509005590851088', 4, CAST(20.00 AS Decimal(18, 2)), 59, N'1001', CAST(0x0000A41200000000 AS DateTime))
INSERT [dbo].[medicine_master] ([medicine_id], [medicine_name], [mrp], [SuppliedBy], [MedicineType], [costprice], [Quantity], [Batch_no], [ExpiryDate]) VALUES (N'3', N'Volini', CAST(79.00 AS Decimal(18, 2)), N'635509571526642913', 4, CAST(55.00 AS Decimal(18, 2)), 56, N'1002', CAST(0x0000A81D00000000 AS DateTime))
INSERT [dbo].[medicine_master] ([medicine_id], [medicine_name], [mrp], [SuppliedBy], [MedicineType], [costprice], [Quantity], [Batch_no], [ExpiryDate]) VALUES (N'4', N'Febutaz', CAST(79.00 AS Decimal(18, 2)), N'635504856083938025', 8, CAST(55.00 AS Decimal(18, 2)), 44, N'1003', CAST(0x0000A79200000000 AS DateTime))
INSERT [dbo].[medicine_master] ([medicine_id], [medicine_name], [mrp], [SuppliedBy], [MedicineType], [costprice], [Quantity], [Batch_no], [ExpiryDate]) VALUES (N'5', N'Stator10', CAST(72.00 AS Decimal(18, 2)), N'635532377736791133', 9, CAST(60.00 AS Decimal(18, 2)), 40, N'1004', CAST(0x0000A64400000000 AS DateTime))
INSERT [dbo].[medicine_master] ([medicine_id], [medicine_name], [mrp], [SuppliedBy], [MedicineType], [costprice], [Quantity], [Batch_no], [ExpiryDate]) VALUES (N'6', N'Olsar', CAST(105.00 AS Decimal(18, 2)), N'635509006218255714', 7, CAST(80.00 AS Decimal(18, 2)), 38, N'1005', CAST(0x0000A40A00000000 AS DateTime))
INSERT [dbo].[medicine_master] ([medicine_id], [medicine_name], [mrp], [SuppliedBy], [MedicineType], [costprice], [Quantity], [Batch_no], [ExpiryDate]) VALUES (N'7', N'Disprin', CAST(40.00 AS Decimal(18, 2)), N'635509005590851088', 4, CAST(22.00 AS Decimal(18, 2)), 50, N'1006', CAST(0x0000A57F00000000 AS DateTime))
INSERT [dbo].[medicine_master] ([medicine_id], [medicine_name], [mrp], [SuppliedBy], [MedicineType], [costprice], [Quantity], [Batch_no], [ExpiryDate]) VALUES (N'8', N'Olsar', CAST(150.00 AS Decimal(18, 2)), N'635504856083938025', 7, CAST(100.00 AS Decimal(18, 2)), 50, N'1007', CAST(0x0000A57700000000 AS DateTime))
/****** Object:  Table [dbo].[map_vendor_company]    Script Date: 12/05/2014 19:03:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[map_vendor_company](
	[map_vendor_company_id] [varchar](150) NOT NULL,
	[vendor_id] [varchar](150) NULL,
	[company_id] [varchar](150) NULL,
 CONSTRAINT [PK_map_vendor_company] PRIMARY KEY CLUSTERED 
(
	[map_vendor_company_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[map_vendor_company] ([map_vendor_company_id], [vendor_id], [company_id]) VALUES (N'635509005591631089', N'635509005590851088', N'10')
INSERT [dbo].[map_vendor_company] ([map_vendor_company_id], [vendor_id], [company_id]) VALUES (N'635509005591787089', N'635509005590851088', N'11')
INSERT [dbo].[map_vendor_company] ([map_vendor_company_id], [vendor_id], [company_id]) VALUES (N'635509006218567715', N'635509006218255714', N'12')
INSERT [dbo].[map_vendor_company] ([map_vendor_company_id], [vendor_id], [company_id]) VALUES (N'635509006704503448', N'635501365264385834', N'12')
INSERT [dbo].[map_vendor_company] ([map_vendor_company_id], [vendor_id], [company_id]) VALUES (N'635509006704659448', N'635501365264385834', N'13')
INSERT [dbo].[map_vendor_company] ([map_vendor_company_id], [vendor_id], [company_id]) VALUES (N'635509007139194577', N'635504856083938025', N'10')
INSERT [dbo].[map_vendor_company] ([map_vendor_company_id], [vendor_id], [company_id]) VALUES (N'635509571527266915', N'635509571526642913', N'10')
INSERT [dbo].[map_vendor_company] ([map_vendor_company_id], [vendor_id], [company_id]) VALUES (N'635509571527578915', N'635509571526642913', N'11')
INSERT [dbo].[map_vendor_company] ([map_vendor_company_id], [vendor_id], [company_id]) VALUES (N'635532377737201435', N'635532377736791133', N'16')
INSERT [dbo].[map_vendor_company] ([map_vendor_company_id], [vendor_id], [company_id]) VALUES (N'635532377737451620', N'635532377736791133', N'17')
INSERT [dbo].[map_vendor_company] ([map_vendor_company_id], [vendor_id], [company_id]) VALUES (N'635532378775786852', N'635532378775516644', N'15')
/****** Object:  Table [dbo].[map_invoice_details]    Script Date: 12/05/2014 19:03:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[map_invoice_details](
	[InvoiceDetail_id] [int] IDENTITY(1,1) NOT NULL,
	[Invoice_id] [varchar](50) NULL,
	[Medicine_name] [varchar](50) NULL,
	[Quantity] [varchar](50) NULL,
	[ExpiryDate] [datetime] NULL,
	[Particular_Amount] [decimal](18, 2) NULL,
 CONSTRAINT [PK_map_invoice_details] PRIMARY KEY CLUSTERED 
(
	[InvoiceDetail_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[map_invoice_details] ON
INSERT [dbo].[map_invoice_details] ([InvoiceDetail_id], [Invoice_id], [Medicine_name], [Quantity], [ExpiryDate], [Particular_Amount]) VALUES (14, N'635532504091681533', N'Febutaz', N'10', CAST(0x0000A79200000000 AS DateTime), CAST(790.00 AS Decimal(18, 2)))
INSERT [dbo].[map_invoice_details] ([InvoiceDetail_id], [Invoice_id], [Medicine_name], [Quantity], [ExpiryDate], [Particular_Amount]) VALUES (15, N'635532504091681533', N'Olsar', N'2', CAST(0x0000A40A00000000 AS DateTime), CAST(210.00 AS Decimal(18, 2)))
INSERT [dbo].[map_invoice_details] ([InvoiceDetail_id], [Invoice_id], [Medicine_name], [Quantity], [ExpiryDate], [Particular_Amount]) VALUES (16, N'635532504091681533', N'Volini', N'5', CAST(0x0000A81D00000000 AS DateTime), CAST(395.00 AS Decimal(18, 2)))
INSERT [dbo].[map_invoice_details] ([InvoiceDetail_id], [Invoice_id], [Medicine_name], [Quantity], [ExpiryDate], [Particular_Amount]) VALUES (17, N'635532505997240525', N'Disprin', N'15', CAST(0x0000A41200000000 AS DateTime), CAST(540.00 AS Decimal(18, 2)))
INSERT [dbo].[map_invoice_details] ([InvoiceDetail_id], [Invoice_id], [Medicine_name], [Quantity], [ExpiryDate], [Particular_Amount]) VALUES (18, N'635532505997240525', N'Stator10', N'10', CAST(0x0000A64400000000 AS DateTime), CAST(720.00 AS Decimal(18, 2)))
INSERT [dbo].[map_invoice_details] ([InvoiceDetail_id], [Invoice_id], [Medicine_name], [Quantity], [ExpiryDate], [Particular_Amount]) VALUES (19, N'635532507151966571', N'Olsar', N'4', CAST(0x0000A40A00000000 AS DateTime), CAST(420.00 AS Decimal(18, 2)))
INSERT [dbo].[map_invoice_details] ([InvoiceDetail_id], [Invoice_id], [Medicine_name], [Quantity], [ExpiryDate], [Particular_Amount]) VALUES (20, N'635532507151966571', N'Sumo', N'10', CAST(0x0000A3F300000000 AS DateTime), CAST(500.00 AS Decimal(18, 2)))
INSERT [dbo].[map_invoice_details] ([InvoiceDetail_id], [Invoice_id], [Medicine_name], [Quantity], [ExpiryDate], [Particular_Amount]) VALUES (21, N'635532508828192446', N'Disprin', N'4', CAST(0x0000A41200000000 AS DateTime), CAST(144.00 AS Decimal(18, 2)))
INSERT [dbo].[map_invoice_details] ([InvoiceDetail_id], [Invoice_id], [Medicine_name], [Quantity], [ExpiryDate], [Particular_Amount]) VALUES (22, N'635532508828192446', N'Stator10', N'5', CAST(0x0000A64400000000 AS DateTime), CAST(360.00 AS Decimal(18, 2)))
INSERT [dbo].[map_invoice_details] ([InvoiceDetail_id], [Invoice_id], [Medicine_name], [Quantity], [ExpiryDate], [Particular_Amount]) VALUES (26, N'635532903900057196', N'Febutaz', N'2', CAST(0x0000A79200000000 AS DateTime), CAST(158.00 AS Decimal(18, 2)))
INSERT [dbo].[map_invoice_details] ([InvoiceDetail_id], [Invoice_id], [Medicine_name], [Quantity], [ExpiryDate], [Particular_Amount]) VALUES (27, N'635532903900057196', N'Volini', N'3', CAST(0x0000A81D00000000 AS DateTime), CAST(237.00 AS Decimal(18, 2)))
INSERT [dbo].[map_invoice_details] ([InvoiceDetail_id], [Invoice_id], [Medicine_name], [Quantity], [ExpiryDate], [Particular_Amount]) VALUES (28, N'635533030674898951', N'Febutaz', N'2', CAST(0x0000A79200000000 AS DateTime), CAST(158.00 AS Decimal(18, 2)))
INSERT [dbo].[map_invoice_details] ([InvoiceDetail_id], [Invoice_id], [Medicine_name], [Quantity], [ExpiryDate], [Particular_Amount]) VALUES (29, N'635533030674898951', N'Olsar', N'10', CAST(0x0000A40A00000000 AS DateTime), CAST(1050.00 AS Decimal(18, 2)))
INSERT [dbo].[map_invoice_details] ([InvoiceDetail_id], [Invoice_id], [Medicine_name], [Quantity], [ExpiryDate], [Particular_Amount]) VALUES (30, N'635533797775870180', N'Olsar', N'4', CAST(0x0000A40A00000000 AS DateTime), CAST(420.00 AS Decimal(18, 2)))
INSERT [dbo].[map_invoice_details] ([InvoiceDetail_id], [Invoice_id], [Medicine_name], [Quantity], [ExpiryDate], [Particular_Amount]) VALUES (31, N'635533797775870180', N'Stator10', N'5', CAST(0x0000A64400000000 AS DateTime), CAST(360.00 AS Decimal(18, 2)))
INSERT [dbo].[map_invoice_details] ([InvoiceDetail_id], [Invoice_id], [Medicine_name], [Quantity], [ExpiryDate], [Particular_Amount]) VALUES (32, N'635533800203729947', N'Disprin', N'2', CAST(0x0000A41200000000 AS DateTime), CAST(72.00 AS Decimal(18, 2)))
INSERT [dbo].[map_invoice_details] ([InvoiceDetail_id], [Invoice_id], [Medicine_name], [Quantity], [ExpiryDate], [Particular_Amount]) VALUES (33, N'635533800203729947', N'Sumo', N'5', CAST(0x0000A3F300000000 AS DateTime), CAST(250.00 AS Decimal(18, 2)))
INSERT [dbo].[map_invoice_details] ([InvoiceDetail_id], [Invoice_id], [Medicine_name], [Quantity], [ExpiryDate], [Particular_Amount]) VALUES (34, N'635533800203729947', N'Febutaz', N'4', CAST(0x0000A79200000000 AS DateTime), CAST(316.00 AS Decimal(18, 2)))
INSERT [dbo].[map_invoice_details] ([InvoiceDetail_id], [Invoice_id], [Medicine_name], [Quantity], [ExpiryDate], [Particular_Amount]) VALUES (35, N'635533809950568103', N'Stator10', N'3', CAST(0x0000A64400000000 AS DateTime), CAST(216.00 AS Decimal(18, 2)))
INSERT [dbo].[map_invoice_details] ([InvoiceDetail_id], [Invoice_id], [Medicine_name], [Quantity], [ExpiryDate], [Particular_Amount]) VALUES (36, N'635533809950568103', N'Olsar', N'4', CAST(0x0000A40A00000000 AS DateTime), CAST(420.00 AS Decimal(18, 2)))
INSERT [dbo].[map_invoice_details] ([InvoiceDetail_id], [Invoice_id], [Medicine_name], [Quantity], [ExpiryDate], [Particular_Amount]) VALUES (37, N'635533809950568103', N'Volini', N'6', CAST(0x0000A81D00000000 AS DateTime), CAST(474.00 AS Decimal(18, 2)))
INSERT [dbo].[map_invoice_details] ([InvoiceDetail_id], [Invoice_id], [Medicine_name], [Quantity], [ExpiryDate], [Particular_Amount]) VALUES (38, N'635533824093629048', N'Stator10', N'2', CAST(0x0000A64400000000 AS DateTime), CAST(144.00 AS Decimal(18, 2)))
INSERT [dbo].[map_invoice_details] ([InvoiceDetail_id], [Invoice_id], [Medicine_name], [Quantity], [ExpiryDate], [Particular_Amount]) VALUES (39, N'635533824093629048', N'Febutaz', N'2', CAST(0x0000A79200000000 AS DateTime), CAST(158.00 AS Decimal(18, 2)))
INSERT [dbo].[map_invoice_details] ([InvoiceDetail_id], [Invoice_id], [Medicine_name], [Quantity], [ExpiryDate], [Particular_Amount]) VALUES (40, N'635533824093629048', N'Olsar', N'4', CAST(0x0000A40A00000000 AS DateTime), CAST(420.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[map_invoice_details] OFF
/****** Object:  Table [dbo].[Login_email]    Script Date: 12/05/2014 19:03:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login_email](
	[Login_email_id] [varchar](150) NULL,
	[Time] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Login_email] ([Login_email_id], [Time]) VALUES (N'admin@medicoSolutions.in', CAST(0x0000A3F800DCD91C AS DateTime))
INSERT [dbo].[Login_email] ([Login_email_id], [Time]) VALUES (N'admin@medicoSolution.in', CAST(0x0000A3F800DCE150 AS DateTime))
INSERT [dbo].[Login_email] ([Login_email_id], [Time]) VALUES (N'admin@medicoSolution.in', CAST(0x0000A3F800DCE984 AS DateTime))
/****** Object:  Table [dbo].[feedback1]    Script Date: 12/05/2014 19:03:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[feedback1](
	[message] [varchar](200) NULL,
	[email] [varchar](50) NOT NULL,
	[question1] [varchar](50) NULL,
	[question2] [varchar](50) NULL,
	[question3] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[feedback1] ([message], [email], [question1], [question2], [question3]) VALUES (N'', N'', N'Yes', N'Yes', N'Bad')
