CREATE TABLE [dbo].[Prepodat] (
    [Id]                   INT           IDENTITY (1, 1) NOT NULL,
    [Фамилия]              NVARCHAR (50) NULL,
    [Имя]                  NVARCHAR (50) NULL,
    [Отчество]             NVARCHAR (50) NULL,
    [Должность]            NVARCHAR (50) NULL,
    [Ученая_степень]       NVARCHAR (50) NULL,
    [Нагрузка]             NVARCHAR (50) NULL,
    [Совместительство]     NVARCHAR (50) NULL,
    [Заработная_плата]     INT           NULL,
    [Предмет_преподавания] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

