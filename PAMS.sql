USE [master]
GO
/****** Object:  Database [PAMS]    Script Date: 6/30/2025 6:12:01 AM ******/
CREATE DATABASE [PAMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PAMS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\PAMS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PAMS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\PAMS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PAMS] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PAMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PAMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PAMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PAMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PAMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PAMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [PAMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PAMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PAMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PAMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PAMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PAMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PAMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PAMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PAMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PAMS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PAMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PAMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PAMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PAMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PAMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PAMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PAMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PAMS] SET RECOVERY FULL 
GO
ALTER DATABASE [PAMS] SET  MULTI_USER 
GO
ALTER DATABASE [PAMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PAMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PAMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PAMS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PAMS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PAMS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PAMS', N'ON'
GO
ALTER DATABASE [PAMS] SET QUERY_STORE = ON
GO
ALTER DATABASE [PAMS] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PAMS]
GO
/****** Object:  Table [dbo].[Beneficiaries]    Script Date: 6/30/2025 6:12:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Beneficiaries](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 6/30/2025 6:12:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[id] [uniqueidentifier] NOT NULL,
	[name] [varchar](255) NULL,
	[type] [varchar](255) NULL,
	[StartDate] [date] NULL,
	[AllocatedAmount] [bigint] NULL,
	[BeneficiaryID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Projects]    Script Date: 6/30/2025 6:12:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Projects]
AS
SELECT        p.id AS [Project ID], p.name AS [Project Name], p.type AS [Project Type], p.StartDate AS [Project Start Date], p.AllocatedAmount, b.id AS [Beneficiarie ID], b.name AS [Beneficiarie Name]
FROM            dbo.Project AS p INNER JOIN
                         dbo.Beneficiaries AS b ON p.BeneficiaryID = b.id
GO
/****** Object:  Table [dbo].[Executors]    Script Date: 6/30/2025 6:12:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Executors](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentVouchers]    Script Date: 6/30/2025 6:12:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentVouchers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PaymentDate] [date] NULL,
	[amount] [bigint] NULL,
	[notes] [varchar](255) NULL,
	[ProjectID] [uniqueidentifier] NULL,
	[ExecutorID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReceiptVouchers]    Script Date: 6/30/2025 6:12:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReceiptVouchers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ReceiptDate] [date] NULL,
	[amount] [bigint] NULL,
	[notes] [varchar](255) NULL,
	[ProjectID] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Project] ADD  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[PaymentVouchers]  WITH CHECK ADD  CONSTRAINT [FK_exc] FOREIGN KEY([ExecutorID])
REFERENCES [dbo].[Executors] ([id])
GO
ALTER TABLE [dbo].[PaymentVouchers] CHECK CONSTRAINT [FK_exc]
GO
ALTER TABLE [dbo].[PaymentVouchers]  WITH CHECK ADD  CONSTRAINT [FK_project_PaymentVouchers] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([id])
GO
ALTER TABLE [dbo].[PaymentVouchers] CHECK CONSTRAINT [FK_project_PaymentVouchers]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_BEN] FOREIGN KEY([BeneficiaryID])
REFERENCES [dbo].[Beneficiaries] ([id])
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_BEN]
GO
ALTER TABLE [dbo].[ReceiptVouchers]  WITH CHECK ADD  CONSTRAINT [FK_project_ReceiptVouchers] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([id])
GO
ALTER TABLE [dbo].[ReceiptVouchers] CHECK CONSTRAINT [FK_project_ReceiptVouchers]
GO
ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [CHK_ProjectType] CHECK  (([type]='استثماري' OR [type]='تنفيذي'))
GO
ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [CHK_ProjectType]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "b"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 102
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "p"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 221
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Projects'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Projects'
GO
USE [master]
GO
ALTER DATABASE [PAMS] SET  READ_WRITE 
GO
