USE [SecurityDoorsApp]
GO

-- (!) NOTICE: Initialize UserIdentifier variable before use script

-- Declare the variable to be used
DECLARE @UserIdentifier NVARCHAR(450);
SET @UserIdentifier = N'4e6c6e49-eac6-4d5a-9fff-f87b20f99902'; 

--Insert into Cards table
INSERT [org].[Cards] ([UserId], [UniqueNumber], [Status], [Level], [ExpirationTime], [Comment]) VALUES (@UserIdentifier, N'001-03', 1, 6, CAST(N'2021-12-31' AS Date), NULL)
GO

--Insert into Doors table
GO
INSERT [org].[Doors] ([Name], [Description], [Status], [Level], [Comment]) VALUES (N'100', N'Main', 1, 1, NULL)
GO
INSERT [org].[Doors] ([Name], [Description], [Status], [Level], [Comment]) VALUES (N'101', N'Server', 1, 6, NULL)
GO

--Insert into DoorReaders table
INSERT [org].[DoorReaders] ([SerialNumber], [DoorId], [Type], [Comment]) VALUES (N'100-01', 1, 1, NULL)
GO
INSERT [org].[DoorReaders] ([SerialNumber], [DoorId], [Type], [Comment]) VALUES (N'100-02', 1, 2, NULL)
GO
INSERT [org].[DoorReaders] ([SerialNumber], [DoorId], [Type], [Comment]) VALUES (N'101-01', 2, 1, NULL)
GO
INSERT [org].[DoorReaders] ([SerialNumber], [DoorId], [Type], [Comment]) VALUES (N'101-02', 2, 2, NULL)
GO
