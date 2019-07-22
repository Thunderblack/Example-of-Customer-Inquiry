IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Customers] (
    [customerID] bigint NOT NULL,
    [email] nvarchar(25) NOT NULL,
    [customerName] nvarchar(20) NOT NULL,
    [mobile] nvarchar(10) NOT NULL,
    [status] nvarchar(10) NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [CreatedBy] nvarchar(max) NOT NULL,
    [UpdatedDate] datetime2 NULL,
    [UpdatedBy] nvarchar(max) NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY ([customerID])
);

GO

CREATE TABLE [Transactions] (
    [id] bigint NOT NULL IDENTITY,
    [date] datetime2 NOT NULL,
    [amount] numeric(15,2) NOT NULL,
    [currency] nvarchar(3) NOT NULL,
    [customerID] bigint NOT NULL,
    [status] nvarchar(10) NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [CreatedBy] nvarchar(max) NOT NULL,
    [UpdatedDate] datetime2 NULL,
    [UpdatedBy] nvarchar(max) NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY ([id]),
    CONSTRAINT [FK_Transactions_Customers_customerID] FOREIGN KEY ([customerID]) REFERENCES [Customers] ([customerID]) ON DELETE CASCADE
);

GO

CREATE UNIQUE INDEX [IX_Customers_email] ON [Customers] ([email]);

GO

CREATE INDEX [IX_Transactions_customerID] ON [Transactions] ([customerID]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190722154715_InitialTable', N'2.1.11-servicing-32099');

GO

