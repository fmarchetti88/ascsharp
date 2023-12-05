-- Creazione database
IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'CorsoAssoSW')
  BEGIN
    CREATE DATABASE [CorsoAssoSW]
  END
GO
	USE [CorsoAssoSW]
GO

-- Creazione tabella dei Clienti
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Customers' and xtype='U')
BEGIN
    CREATE TABLE [Customers] (
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[BusinessName] NVARCHAR(100) NOT NULL, -- Ragione sociale
		[VatCode] NVARCHAR(12), -- Partita IVA
		[FiscalCode] NVARCHAR(20), -- Codice Fiscale
		[Address] NVARCHAR(255),
		[Telephone] NVARCHAR(20),
		[Email] NVARCHAR(50),
		CONSTRAINT [PK_Customers_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END

-- Creazione tabella degli Prodotti
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Products' and xtype='U')
BEGIN
    CREATE TABLE [Products] (
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Code] NVARCHAR(50) NOT NULL,
		[Description] NVARCHAR(255) NOT NULL,
		[Price] DECIMAL(10, 2),
		[QuantityWarehouse] INT NOT NULL DEFAULT(0),
		CONSTRAINT [PK_Products_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END

-- Creazione tabella testata Ordini
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Orders' and xtype='U')
BEGIN
    CREATE TABLE [Orders] (
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[OrderPlaced] [datetime] NOT NULL,
		[OrderFulfilled] [datetime] NULL,	
		[IdCustomer] [int] NOT NULL,
		CONSTRAINT [PK_Orders_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[Orders]  WITH CHECK ADD CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([IDCustomer])
	REFERENCES [dbo].[Customers] ([Id])
END

-- Creazione tabella dettaglio Ordini
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='OrderDetails' and xtype='U')
BEGIN
    CREATE TABLE [OrderDetails] (
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Quantity] [int] NOT NULL,
		[IdOrder] [int] NOT NULL,
		[IdProduct] [int] NOT NULL,
		CONSTRAINT [PK_OrderDetails_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
		WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY([IdOrder])
	REFERENCES [dbo].[Orders] ([Id])

	ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD CONSTRAINT [FK_OrderDetails_Products] FOREIGN KEY([IdProduct])
	REFERENCES [dbo].[Products] ([Id])
END