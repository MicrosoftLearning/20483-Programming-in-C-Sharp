
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SchoolGradesDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Parents_diameterUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Parents] DROP CONSTRAINT [FK_Parents_diameterUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_Students_diameterUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Students] DROP CONSTRAINT [FK_Students_diameterUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_Teachers_diameterUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Teachers] DROP CONSTRAINT [FK_Teachers_diameterUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentGrade]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Grades] DROP CONSTRAINT [FK_StudentGrade];
GO
IF OBJECT_ID(N'[dbo].[FK_SubjectGrade]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Grades] DROP CONSTRAINT [FK_SubjectGrade];
GO
IF OBJECT_ID(N'[dbo].[FK_TeacherStudent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Students] DROP CONSTRAINT [FK_TeacherStudent];
GO
IF OBJECT_ID(N'[dbo].[FK_ParentStudent_Parent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ParentStudent] DROP CONSTRAINT [FK_ParentStudent_Parent];
GO
IF OBJECT_ID(N'[dbo].[FK_ParentStudent_Student]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ParentStudent] DROP CONSTRAINT [FK_ParentStudent_Student];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Grades]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Grades];
GO
IF OBJECT_ID(N'[dbo].[Parents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Parents];
GO
IF OBJECT_ID(N'[dbo].[Students]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Students];
GO
IF OBJECT_ID(N'[dbo].[Subjects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Subjects];
GO
IF OBJECT_ID(N'[dbo].[Teachers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Teachers];
GO
IF OBJECT_ID(N'[dbo].[ParentStudent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ParentStudent];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Grades'
CREATE TABLE [dbo].[Grades] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Assessment] nvarchar(max)  NOT NULL,
    [Comments] nvarchar(max)  NULL,
    [AssessmentDate] datetime  NOT NULL,
    [SubjectId] int  NOT NULL,
    [StudentUserId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Parents'
CREATE TABLE [dbo].[Parents] (
    [UserId] uniqueidentifier  NOT NULL,
    [FirstName] nvarchar(50)  NOT NULL,
    [LastName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Students'
CREATE TABLE [dbo].[Students] (
    [UserId] uniqueidentifier  NOT NULL,
    [FirstName] nvarchar(50)  NOT NULL,
    [LastName] nvarchar(50)  NOT NULL,
    [ImageName] nvarchar(max)  NOT NULL,
    [TeacherUserId] uniqueidentifier  NULL
);
GO

-- Creating table 'Subjects'
CREATE TABLE [dbo].[Subjects] (
    [Id] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Teachers'
CREATE TABLE [dbo].[Teachers] (
    [UserId] uniqueidentifier  NOT NULL,
    [FirstName] nvarchar(50)  NOT NULL,
    [LastName] nvarchar(50)  NOT NULL,
    [Class] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'ParentStudent'
CREATE TABLE [dbo].[ParentStudent] (
    [Parents_UserId] uniqueidentifier  NOT NULL,
    [Students_UserId] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Grades'
ALTER TABLE [dbo].[Grades]
ADD CONSTRAINT [PK_Grades]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserId] in table 'Parents'
ALTER TABLE [dbo].[Parents]
ADD CONSTRAINT [PK_Parents]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [UserId] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [PK_Students]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [Id] in table 'Subjects'
ALTER TABLE [dbo].[Subjects]
ADD CONSTRAINT [PK_Subjects]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserId] in table 'Teachers'
ALTER TABLE [dbo].[Teachers]
ADD CONSTRAINT [PK_Teachers]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [Parents_UserId], [Students_UserId] in table 'ParentStudent'
ALTER TABLE [dbo].[ParentStudent]
ADD CONSTRAINT [PK_ParentStudent]
    PRIMARY KEY NONCLUSTERED ([Parents_UserId], [Students_UserId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'Parents'
ALTER TABLE [dbo].[Parents]
ADD CONSTRAINT [FK_Parents_diameterUsers]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserId] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [FK_Students_diameterUsers]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserId] in table 'Teachers'
ALTER TABLE [dbo].[Teachers]
ADD CONSTRAINT [FK_Teachers_diameterUsers]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [StudentUserId] in table 'Grades'
ALTER TABLE [dbo].[Grades]
ADD CONSTRAINT [FK_StudentGrade]
    FOREIGN KEY ([StudentUserId])
    REFERENCES [dbo].[Students]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentGrade'
CREATE INDEX [IX_FK_StudentGrade]
ON [dbo].[Grades]
    ([StudentUserId]);
GO

-- Creating foreign key on [SubjectId] in table 'Grades'
ALTER TABLE [dbo].[Grades]
ADD CONSTRAINT [FK_SubjectGrade]
    FOREIGN KEY ([SubjectId])
    REFERENCES [dbo].[Subjects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SubjectGrade'
CREATE INDEX [IX_FK_SubjectGrade]
ON [dbo].[Grades]
    ([SubjectId]);
GO

-- Creating foreign key on [TeacherUserId] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [FK_TeacherStudent]
    FOREIGN KEY ([TeacherUserId])
    REFERENCES [dbo].[Teachers]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TeacherStudent'
CREATE INDEX [IX_FK_TeacherStudent]
ON [dbo].[Students]
    ([TeacherUserId]);
GO

-- Creating foreign key on [Parents_UserId] in table 'ParentStudent'
ALTER TABLE [dbo].[ParentStudent]
ADD CONSTRAINT [FK_ParentStudent_Parent]
    FOREIGN KEY ([Parents_UserId])
    REFERENCES [dbo].[Parents]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Students_UserId] in table 'ParentStudent'
ALTER TABLE [dbo].[ParentStudent]
ADD CONSTRAINT [FK_ParentStudent_Student]
    FOREIGN KEY ([Students_UserId])
    REFERENCES [dbo].[Students]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ParentStudent_Student'
CREATE INDEX [IX_FK_ParentStudent_Student]
ON [dbo].[ParentStudent]
    ([Students_UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------