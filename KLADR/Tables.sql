/*Скрипт создания таблиц для хранения КЛАДР */

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[tblKladrKladr](
	[District] [int] NOT NULL,
	[Region] [int] NOT NULL,
	[Country] [int] NOT NULL,
	[Settlement] [int] NOT NULL,
	[Name] [varchar](40) NULL,
	[Socr] [varchar](10) NULL,
	[PostIndex] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[District] ASC,
	[Region] ASC,
	[Country] ASC,
	[Settlement] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE TABLE [dbo].[tblKladrStreet](
	[District] [int] NOT NULL,
	[Region] [int] NOT NULL,
	[Country] [int] NOT NULL,
	[Settlement] [int] NOT NULL,
	[Street] [int] NOT NULL,
	[Name] [varchar](40) NULL,
	[Socr] [varchar](10) NULL,
	[PostIndex] [int] NOT NULL,
 CONSTRAINT [PK__tblKladr__CB5A47154282C7A2] PRIMARY KEY CLUSTERED 
(
	[District] ASC,
	[Region] ASC,
	[Country] ASC,
	[Settlement] ASC,
	[Street] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
CREATE TABLE [dbo].[tblKladrDoma](
	[District] [int] NOT NULL,
	[Region] [int] NOT NULL,
	[Country] [int] NOT NULL,
	[Settlement] [int] NOT NULL,
	[Street] [int] NOT NULL,
	[Building] [int] NOT NULL,
	[Name] [varchar](40) NOT NULL,
	[Korp] [varchar](10) NOT NULL,
	[Socr] [varchar](10) NOT NULL,
	[PostIndex] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[District] ASC,
	[Region] ASC,
	[Country] ASC,
	[Settlement] ASC,
	[Street] ASC,
	[Building] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO