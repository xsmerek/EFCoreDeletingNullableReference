USE [master]
GO

CREATE DATABASE [EFCoreDeletingNullableReference]
GO

USE [EFCoreDeletingNullableReference]
GO

CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO

CREATE TABLE [dbo].[Company](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
    CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO

CREATE TABLE [dbo].[Car](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[PersonId] [int],
	[COmpanyId] [int],
    CONSTRAINT [PK_Car] PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO

ALTER TABLE [dbo].[Car] WITH CHECK ADD  CONSTRAINT [FK_Car_Person] FOREIGN KEY([PersonId]) REFERENCES [dbo].[Person] ([Id])
GO

ALTER TABLE [dbo].[Car] WITH CHECK ADD  CONSTRAINT [FK_Car_Company] FOREIGN KEY([CompanyId]) REFERENCES [dbo].[Company] ([Id])
GO

ALTER TABLE [dbo].[Car] CHECK CONSTRAINT [FK_Car_Person]
GO

ALTER TABLE [dbo].[Car] CHECK CONSTRAINT [FK_Car_Company]
GO

USE [master]
GO

ALTER DATABASE [EFCoreDeletingNullableReference] SET READ_WRITE 
GO

USE [EFCoreDeletingNullableReference]
GO

SET IDENTITY_INSERT [dbo].[Person] ON 
INSERT [dbo].[Person] ([Id], [Name]) VALUES (1, N'Jack')
SET IDENTITY_INSERT [dbo].[Person] OFF
GO

SET IDENTITY_INSERT [dbo].[Car] ON 
INSERT [dbo].[Car] ([Id], [Name], [PersonId], [CompanyId]) VALUES (1, N'Honda', 1, NULL)
SET IDENTITY_INSERT [dbo].[Car] OFF
GO

