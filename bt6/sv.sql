USE [sinhvien]
GO
/****** Object:  Table [dbo].[Faculty]    Script Date: 18/12/2024 11:25:04 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculty](
	[FacultyID] [int] NOT NULL,
	[FacultyName] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 18/12/2024 11:25:04 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentID] [nvarchar](50) NOT NULL,
	[FullName] [nvarchar](200) NOT NULL,
	[AverageScore] [float] NOT NULL,
	[FacultyID] [int] NULL
) ON [PRIMARY]
GO
