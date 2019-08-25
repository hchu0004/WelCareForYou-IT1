
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/25/2019 17:09:14
-- Generated from EDMX file: C:\Users\harry\source\repos\WelCareForYou-IT1\WelCareForYou-IT1\Models\BusinessModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BusinessDB];
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

-- Creating table 'Suburbs'
CREATE TABLE [dbo].[Suburbs] (
    [SuburbName] nvarchar(max)  NOT NULL,
    [AreaName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AgeGroup] nvarchar(max)  NOT NULL,
    [Gender] nvarchar(max)  NOT NULL,
    [NumOfRoom] int  NOT NULL,
    [Salary] int  NOT NULL,
    [SuburbSuburbName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Houses'
CREATE TABLE [dbo].[Houses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NumOfRoom] int  NOT NULL,
    [MediumPrice] int  NOT NULL,
    [HouseType] nvarchar(max)  NOT NULL,
    [SuburbSuburbName] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [SuburbName] in table 'Suburbs'
ALTER TABLE [dbo].[Suburbs]
ADD CONSTRAINT [PK_Suburbs]
    PRIMARY KEY CLUSTERED ([SuburbName] ASC);
GO

-- Creating primary key on [Id] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Houses'
ALTER TABLE [dbo].[Houses]
ADD CONSTRAINT [PK_Houses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [SuburbSuburbName] in table 'Houses'
ALTER TABLE [dbo].[Houses]
ADD CONSTRAINT [FK_SuburbHouse]
    FOREIGN KEY ([SuburbSuburbName])
    REFERENCES [dbo].[Suburbs]
        ([SuburbName])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SuburbHouse'
CREATE INDEX [IX_FK_SuburbHouse]
ON [dbo].[Houses]
    ([SuburbSuburbName]);
GO

-- Creating foreign key on [SuburbSuburbName] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [FK_SuburbClient]
    FOREIGN KEY ([SuburbSuburbName])
    REFERENCES [dbo].[Suburbs]
        ([SuburbName])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SuburbClient'
CREATE INDEX [IX_FK_SuburbClient]
ON [dbo].[Clients]
    ([SuburbSuburbName]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------