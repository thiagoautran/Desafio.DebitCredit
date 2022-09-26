DROP TABLE [Transaction]
DROP TABLE [Account]
DROP TABLE [Person]
DROP TABLE [Operation]

CREATE TABLE [dbo].[Person](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Person] ADD  CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([Id] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE TABLE [dbo].[Account](
	[Id] [uniqueidentifier] NOT NULL,
	[Agency] [int] NOT NULL,
	[AccountNumber] [int] NOT NULL,
	[CurrentAccountDigit] [int] NOT NULL,
	[Balance] [decimal](18, 0) NOT NULL,
	[PersonId] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account] ADD  CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED ([Id] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Person] FOREIGN KEY([PersonId]) REFERENCES [dbo].[Person] ([Id]) ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Person]
GO
CREATE TABLE [dbo].[Operation](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](100) NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Operation] ADD  CONSTRAINT [PK_Operation] PRIMARY KEY CLUSTERED ([Id] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE TABLE [dbo].[Transaction](
	[Id] [uniqueidentifier] NOT NULL,
	[Value] [decimal](18, 0) NOT NULL,
	[Date] [datetime] NOT NULL,
	[AccountId] [uniqueidentifier] NOT NULL,
	[OperationId] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Transaction] ADD  CONSTRAINT [PK_Transaction] PRIMARY KEY CLUSTERED ([Id] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_Account] FOREIGN KEY([AccountId]) REFERENCES [dbo].[Account] ([Id]) ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_Account]
GO
ALTER TABLE [dbo].[Transaction]  WITH CHECK ADD  CONSTRAINT [FK_Transaction_Operation] FOREIGN KEY([OperationId]) REFERENCES [dbo].[Operation] ([Id]) ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Transaction] CHECK CONSTRAINT [FK_Transaction_Operation]
GO
INSERT INTO [Conta].[dbo].[Person] VALUES ('53e822d9-9e6c-4299-bc38-f442acba5ca8', 'João')
GO
INSERT INTO [Conta].[dbo].[Account] VALUES ('53d9e5fe-6e61-4a7d-a9db-cf4f65e90de2', '1', '112233', '1', 0.0, '53e822d9-9e6c-4299-bc38-f442acba5ca8')
GO
INSERT INTO Operation VALUES ('337de2d3-7c8a-4ce1-9111-659030be2ce6', 'Debit')
GO
INSERT INTO Operation VALUES ('c4a126a2-332e-44f0-9c9e-78a9a6287b39', 'Credit')
GO