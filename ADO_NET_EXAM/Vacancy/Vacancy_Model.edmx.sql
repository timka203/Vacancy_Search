
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/04/2020 11:43:33
-- Generated from EDMX file: C:\Users\Timur\source\repos\ADO_NET_EXAM\Vacancy\Vacancy_Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TestDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'VacancySet'
CREATE TABLE [dbo].[VacancySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CategoryId] int  NOT NULL,
    [title] nvarchar(max)  NOT NULL,
    [link] nvarchar(max)  NOT NULL,
    [description] nvarchar(max)  NOT NULL,
    [pubDate] nvarchar(max)  NOT NULL,
    [guid] nvarchar(max)  NOT NULL,
    [author] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CategorySet'
CREATE TABLE [dbo].[CategorySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Category_Name] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'VacancySet'
ALTER TABLE [dbo].[VacancySet]
ADD CONSTRAINT [PK_VacancySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CategorySet'
ALTER TABLE [dbo].[CategorySet]
ADD CONSTRAINT [PK_CategorySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CategoryId] in table 'VacancySet'
ALTER TABLE [dbo].[VacancySet]
ADD CONSTRAINT [FK_CategoryVacancy]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[CategorySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryVacancy'
CREATE INDEX [IX_FK_CategoryVacancy]
ON [dbo].[VacancySet]
    ([CategoryId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------