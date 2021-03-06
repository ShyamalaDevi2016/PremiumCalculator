use master
GO
/****** Object:  Database [TALDB]    Script Date: 10/23/2020 9:22:59 AM ******/
CREATE DATABASE [TALDB] 
 GO
USE [TALDB]
GO
/****** Object:  Table [dbo].[OccupationRating]    Script Date: 10/23/2020 9:22:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OccupationRating](
	[OccupationId] [int] IDENTITY(1,1) NOT NULL,
	[RatingId] [int] NOT NULL,
	[OccupationName] [varchar](20) NOT NULL,
 CONSTRAINT [PK_OccupationRating] PRIMARY KEY CLUSTERED 
(
	[OccupationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RatingMaster]    Script Date: 10/23/2020 9:22:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RatingMaster](
	[RatingId] [int] IDENTITY(1,1) NOT NULL,
	[RatingName] [varchar](20) NOT NULL,
	[Factor] [decimal](10, 2) NOT NULL,
 CONSTRAINT [PK_RatingMaster] PRIMARY KEY CLUSTERED 
(
	[RatingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[OccupationRating]  WITH CHECK ADD  CONSTRAINT [FK_OccupationRating_RatingMaster] FOREIGN KEY([RatingId])
REFERENCES [dbo].[RatingMaster] ([RatingId])
GO
ALTER TABLE [dbo].[OccupationRating] CHECK CONSTRAINT [FK_OccupationRating_RatingMaster]
GO




GO
INSERT INTO RatingMaster 
SELECT 'Professional' ,1.0
UNION
SELECT 'White Collar',1.25
UNION
SELECT 'Light Manual',1.50
UNION
SELECT 'Heavy Manual',1.75
GO



GO
INSERT INTO [dbo].[OccupationRating]
SELECT 2,'Cleaner'
UNION
SELECT 3,'Doctor'
UNION
SELECT 4,'Author'
UNION
SELECT 1,'Farmer'
UNION
SELECT 1,'Mechanic'
UNION
SELECT 2,'Florist'