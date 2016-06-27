
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/24/2016 22:58:36
-- Generated from EDMX file: C:\Users\HL\Documents\Visual Studio 2013\Projects\Orders\Orders\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Report];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Order_Accounting]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_Order_Accounting];
GO
IF OBJECT_ID(N'[dbo].[FK_Order_Clients]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_Order_Clients];
GO
IF OBJECT_ID(N'[dbo].[FK_Order_Dispatch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_Order_Dispatch];
GO
IF OBJECT_ID(N'[dbo].[FK_Order_Divisions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_Order_Divisions];
GO
IF OBJECT_ID(N'[dbo].[FK_Order_JobStatus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_Order_JobStatus];
GO
IF OBJECT_ID(N'[dbo].[FK_Order_PMS]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_Order_PMS];
GO
IF OBJECT_ID(N'[dbo].[FK_Order_Priority]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_Order_Priority];
GO
IF OBJECT_ID(N'[dbo].[FK_Order_Requests]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_Order_Requests];
GO
IF OBJECT_ID(N'[dbo].[FK_Order_Technician]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_Order_Technician];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderAssets_Assets]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderMaterials] DROP CONSTRAINT [FK_OrderAssets_Assets];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderAssets_Order]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderMaterials] DROP CONSTRAINT [FK_OrderAssets_Order];
GO
IF OBJECT_ID(N'[dbo].[FK_Paids_Order]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Paids] DROP CONSTRAINT [FK_Paids_Order];
GO
IF OBJECT_ID(N'[dbo].[FK_Totals_Order]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Totals] DROP CONSTRAINT [FK_Totals_Order];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Accounting]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounting];
GO
IF OBJECT_ID(N'[dbo].[Clients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clients];
GO
IF OBJECT_ID(N'[dbo].[Dispatch]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dispatch];
GO
IF OBJECT_ID(N'[dbo].[Divisions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Divisions];
GO
IF OBJECT_ID(N'[dbo].[JobStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobStatus];
GO
IF OBJECT_ID(N'[dbo].[Material]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Material];
GO
IF OBJECT_ID(N'[dbo].[Order]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Order];
GO
IF OBJECT_ID(N'[dbo].[OrderMaterials]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderMaterials];
GO
IF OBJECT_ID(N'[dbo].[Paids]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Paids];
GO
IF OBJECT_ID(N'[dbo].[PMS]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PMS];
GO
IF OBJECT_ID(N'[dbo].[Priority]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Priority];
GO
IF OBJECT_ID(N'[dbo].[Requests]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Requests];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Technician]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Technician];
GO
IF OBJECT_ID(N'[dbo].[Totals]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Totals];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Accounting'
CREATE TABLE [dbo].[Accounting] (
    [id] int IDENTITY(1,1) NOT NULL,
    [inv] nchar(20)  NULL,
    [chk] nchar(20)  NULL,
    [amtPaid] float  NULL,
    [invAmt] float  NULL,
    [disc] float  NULL
);
GO

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] varchar(max)  NOT NULL
);
GO

-- Creating table 'Dispatch'
CREATE TABLE [dbo].[Dispatch] (
    [id] int IDENTITY(1,1) NOT NULL,
    [vendor] nchar(60)  NULL,
    [dispatcher] nchar(60)  NULL,
    [phone] nchar(40)  NULL,
    [fax] nchar(40)  NULL,
    [email] varchar(max)  NULL,
    [tech] nchar(40)  NULL
);
GO

-- Creating table 'Divisions'
CREATE TABLE [dbo].[Divisions] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] varchar(max)  NOT NULL
);
GO

-- Creating table 'JobStatus'
CREATE TABLE [dbo].[JobStatus] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] varchar(max)  NOT NULL
);
GO

-- Creating table 'Material'
CREATE TABLE [dbo].[Material] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] varchar(max)  NOT NULL
);
GO

-- Creating table 'Order'
CREATE TABLE [dbo].[Order] (
    [number] nchar(50)  NULL,
    [id] int IDENTITY(1,1) NOT NULL,
    [divisionId] int  NULL,
    [clientId] int  NULL,
    [priorityId] int  NULL,
    [requestId] int  NULL,
    [poNumber] nchar(20)  NULL,
    [nte] nchar(20)  NULL,
    [jobSite] nchar(20)  NULL,
    [phone] nchar(40)  NULL,
    [jobSiteContact] varchar(max)  NULL,
    [adress] varchar(max)  NULL,
    [city] nchar(40)  NULL,
    [stateZip] nchar(40)  NULL,
    [siteRegion] nchar(40)  NULL,
    [problemType] varchar(max)  NULL,
    [woDate] datetime  NULL,
    [requestedBy] nchar(80)  NULL,
    [jobstatusId] int  NULL,
    [dispatchedBy] nchar(80)  NULL,
    [datePromised] datetime  NULL,
    [dateCompleted] datetime  NULL,
    [laborHours] float  NULL,
    [vendor] varchar(max)  NULL,
    [techPhone] nchar(40)  NULL,
    [fax] nchar(40)  NULL,
    [jobdescription] varchar(max)  NULL,
    [dispatchId] int  NULL,
    [pmsId] int  NULL,
    [accountingId] int  NULL,
    [technicianId] int  NULL,
    [labor] nchar(40)  NULL,
    [notes] varchar(max)  NULL
);
GO

-- Creating table 'Paids'
CREATE TABLE [dbo].[Paids] (
    [id] int IDENTITY(1,1) NOT NULL,
    [date] datetime  NULL,
    [inv] nchar(50)  NULL,
    [chk] nchar(50)  NULL,
    [amtPaid] float  NULL,
    [invAmt] float  NULL,
    [orderId] int  NULL
);
GO

-- Creating table 'PMS'
CREATE TABLE [dbo].[PMS] (
    [id] int IDENTITY(1,1) NOT NULL,
    [ecoDispatch] nchar(40)  NULL,
    [etaPromise] datetime  NULL,
    [techNTE] float  NULL,
    [dispatchDate] datetime  NULL,
    [dateComp] datetime  NULL
);
GO

-- Creating table 'Priority'
CREATE TABLE [dbo].[Priority] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] varchar(max)  NOT NULL
);
GO

-- Creating table 'Requests'
CREATE TABLE [dbo].[Requests] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] varchar(max)  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Technician'
CREATE TABLE [dbo].[Technician] (
    [id] int IDENTITY(1,1) NOT NULL,
    [obtainedSig] bit  NULL,
    [notesFromTech] varchar(max)  NULL,
    [exceededNTE] bit  NULL,
    [ProblemFound] varchar(max)  NULL,
    [multipleCheckInOut] varchar(max)  NULL
);
GO

-- Creating table 'Totals'
CREATE TABLE [dbo].[Totals] (
    [id] int IDENTITY(1,1) NOT NULL,
    [totalTechs] float  NULL,
    [totalHours] float  NULL,
    [trip] float  NULL,
    [totalLabor] float  NULL,
    [tax] float  NULL,
    [totalItems] float  NULL,
    [totalMaterials] float  NULL,
    [taxMaterials] float  NULL,
    [grandTotal] float  NULL,
    [totalDiscount] float  NULL,
    [toalThisPropsal] float  NULL,
    [orderid] int  NOT NULL
);
GO

-- Creating table 'OrderMaterials'
CREATE TABLE [dbo].[OrderMaterials] (
    [Material_id] int  NOT NULL,
    [Order_id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Accounting'
ALTER TABLE [dbo].[Accounting]
ADD CONSTRAINT [PK_Accounting]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Dispatch'
ALTER TABLE [dbo].[Dispatch]
ADD CONSTRAINT [PK_Dispatch]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Divisions'
ALTER TABLE [dbo].[Divisions]
ADD CONSTRAINT [PK_Divisions]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'JobStatus'
ALTER TABLE [dbo].[JobStatus]
ADD CONSTRAINT [PK_JobStatus]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Material'
ALTER TABLE [dbo].[Material]
ADD CONSTRAINT [PK_Material]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [PK_Order]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Paids'
ALTER TABLE [dbo].[Paids]
ADD CONSTRAINT [PK_Paids]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'PMS'
ALTER TABLE [dbo].[PMS]
ADD CONSTRAINT [PK_PMS]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Priority'
ALTER TABLE [dbo].[Priority]
ADD CONSTRAINT [PK_Priority]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Requests'
ALTER TABLE [dbo].[Requests]
ADD CONSTRAINT [PK_Requests]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [id] in table 'Technician'
ALTER TABLE [dbo].[Technician]
ADD CONSTRAINT [PK_Technician]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Totals'
ALTER TABLE [dbo].[Totals]
ADD CONSTRAINT [PK_Totals]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Material_id], [Order_id] in table 'OrderMaterials'
ALTER TABLE [dbo].[OrderMaterials]
ADD CONSTRAINT [PK_OrderMaterials]
    PRIMARY KEY CLUSTERED ([Material_id], [Order_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [accountingId] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [FK_Order_Accounting]
    FOREIGN KEY ([accountingId])
    REFERENCES [dbo].[Accounting]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_Accounting'
CREATE INDEX [IX_FK_Order_Accounting]
ON [dbo].[Order]
    ([accountingId]);
GO

-- Creating foreign key on [clientId] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [FK_Order_Clients]
    FOREIGN KEY ([clientId])
    REFERENCES [dbo].[Clients]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_Clients'
CREATE INDEX [IX_FK_Order_Clients]
ON [dbo].[Order]
    ([clientId]);
GO

-- Creating foreign key on [dispatchId] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [FK_Order_Dispatch]
    FOREIGN KEY ([dispatchId])
    REFERENCES [dbo].[Dispatch]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_Dispatch'
CREATE INDEX [IX_FK_Order_Dispatch]
ON [dbo].[Order]
    ([dispatchId]);
GO

-- Creating foreign key on [divisionId] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [FK_Order_Divisions]
    FOREIGN KEY ([divisionId])
    REFERENCES [dbo].[Divisions]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_Divisions'
CREATE INDEX [IX_FK_Order_Divisions]
ON [dbo].[Order]
    ([divisionId]);
GO

-- Creating foreign key on [jobstatusId] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [FK_Order_JobStatus]
    FOREIGN KEY ([jobstatusId])
    REFERENCES [dbo].[JobStatus]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_JobStatus'
CREATE INDEX [IX_FK_Order_JobStatus]
ON [dbo].[Order]
    ([jobstatusId]);
GO

-- Creating foreign key on [pmsId] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [FK_Order_PMS]
    FOREIGN KEY ([pmsId])
    REFERENCES [dbo].[PMS]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_PMS'
CREATE INDEX [IX_FK_Order_PMS]
ON [dbo].[Order]
    ([pmsId]);
GO

-- Creating foreign key on [priorityId] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [FK_Order_Priority]
    FOREIGN KEY ([priorityId])
    REFERENCES [dbo].[Priority]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_Priority'
CREATE INDEX [IX_FK_Order_Priority]
ON [dbo].[Order]
    ([priorityId]);
GO

-- Creating foreign key on [requestId] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [FK_Order_Requests]
    FOREIGN KEY ([requestId])
    REFERENCES [dbo].[Requests]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_Requests'
CREATE INDEX [IX_FK_Order_Requests]
ON [dbo].[Order]
    ([requestId]);
GO

-- Creating foreign key on [technicianId] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [FK_Order_Technician]
    FOREIGN KEY ([technicianId])
    REFERENCES [dbo].[Technician]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Order_Technician'
CREATE INDEX [IX_FK_Order_Technician]
ON [dbo].[Order]
    ([technicianId]);
GO

-- Creating foreign key on [orderId] in table 'Paids'
ALTER TABLE [dbo].[Paids]
ADD CONSTRAINT [FK_Paids_Order]
    FOREIGN KEY ([orderId])
    REFERENCES [dbo].[Order]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Paids_Order'
CREATE INDEX [IX_FK_Paids_Order]
ON [dbo].[Paids]
    ([orderId]);
GO

-- Creating foreign key on [orderid] in table 'Totals'
ALTER TABLE [dbo].[Totals]
ADD CONSTRAINT [FK_Totals_Order]
    FOREIGN KEY ([orderid])
    REFERENCES [dbo].[Order]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Totals_Order'
CREATE INDEX [IX_FK_Totals_Order]
ON [dbo].[Totals]
    ([orderid]);
GO

-- Creating foreign key on [Material_id] in table 'OrderMaterials'
ALTER TABLE [dbo].[OrderMaterials]
ADD CONSTRAINT [FK_OrderMaterials_Material]
    FOREIGN KEY ([Material_id])
    REFERENCES [dbo].[Material]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Order_id] in table 'OrderMaterials'
ALTER TABLE [dbo].[OrderMaterials]
ADD CONSTRAINT [FK_OrderMaterials_Order]
    FOREIGN KEY ([Order_id])
    REFERENCES [dbo].[Order]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderMaterials_Order'
CREATE INDEX [IX_FK_OrderMaterials_Order]
ON [dbo].[OrderMaterials]
    ([Order_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------