CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Фамилия] NCHAR(10) NULL, 
    [Имя] NCHAR(10) NULL, 
    [Отчество] NCHAR(10) NULL, 
    [Должность] NCHAR(10) NULL, 
    [Ученая степень] NCHAR(10) NULL, 
    [Нагрузка] NCHAR(10) NULL, 
    [Общественная работа] NCHAR(10) NULL, 
    [Совместительство] NCHAR(10) NULL, 
    [Заработная плата] NCHAR(10) NULL
)
