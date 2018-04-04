USE [DevTest]
GO

/****** Object:  Table [dbo].[PersonalInfo]    Script Date: 4/4/2018 3:29:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PersonalInfo](
	[PersonalInfoID] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nchar](100) NULL,
	[LastName] [nchar](100) NULL,
	[DateOfBirth] [datetime] NULL,
	[City] [nchar](50) NULL,
	[Country] [nchar](100) NULL,
	[MobileNo] [nchar](50) NULL,
	[NID] [nchar](100) NULL,
	[Email] [nchar](100) NULL,
	[Status] [tinyint] NULL,
 CONSTRAINT [PK_PersonalInfo] PRIMARY KEY CLUSTERED 
(
	[PersonalInfoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO






----truncate
truncate table PersonalInfo

---SQL loop insert
DECLARE @ID int;
SET @ID=0;
WHILE @ID < 25
BEGIN
	insert into PersonalInfo values('FirstName ' + CAST(@ID AS VARCHAR),
	'LastName ' + CAST(@ID AS VARCHAR),
	'12/12/1987','City ' + CAST(@ID AS VARCHAR),
	'Country ' + CAST(@ID AS VARCHAR),
	01723289239 + @ID,
	12344232131234 + @ID,
	'dev@gmail.com',
	1)
	SET @ID = @ID + 1;
END

