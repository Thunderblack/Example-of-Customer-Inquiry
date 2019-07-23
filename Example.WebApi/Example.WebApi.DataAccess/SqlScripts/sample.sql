USE [EXAMPLEDEV01]
GO

INSERT [dbo].[Customers] ([customerID], [email], [customerName], [mobile], [status], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (90019981, N'user1@domain.com', N'John Rotaminary', N'0810000001', N'Active', CAST(N'2019-07-22T22:48:17.1278064' AS DateTime2), N'Anonymous', NULL, NULL)
GO
INSERT [dbo].[Customers] ([customerID], [email], [customerName], [mobile], [status], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (90019982, N'user2@domain.com', N'Amanda PickNiSon', N'0810000002', N'Active', CAST(N'2019-07-22T22:48:46.2159774' AS DateTime2), N'Anonymous', NULL, NULL)
GO
INSERT [dbo].[Customers] ([customerID], [email], [customerName], [mobile], [status], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (90019983, N'user3@domain.com', N'StenMill Tedsido', N'0810000003', N'Active', CAST(N'2019-07-22T22:48:58.7078831' AS DateTime2), N'Anonymous', NULL, NULL)
GO
INSERT [dbo].[Customers] ([customerID], [email], [customerName], [mobile], [status], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (90019984, N'user4@domain.com', N'Sizzler Miller', N'0810000004', N'Active', CAST(N'2019-07-23T00:01:09.1255123' AS DateTime2), N'Anonymous', NULL, NULL)
GO

SET IDENTITY_INSERT [dbo].[Transactions] ON 
GO
INSERT [dbo].[Transactions] ([id], [date], [amount], [currency], [customerID], [status], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (1, CAST(N'2019-07-22T09:00:00.0000000' AS DateTime2), CAST(2000.00 AS Numeric(15, 2)), N'USD', 90019981, N'Success', CAST(N'2019-07-22T22:49:11.9279769' AS DateTime2), N'Anonymous', NULL, NULL)
GO
INSERT [dbo].[Transactions] ([id], [date], [amount], [currency], [customerID], [status], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (2, CAST(N'2019-07-22T09:05:11.0000000' AS DateTime2), CAST(100.00 AS Numeric(15, 2)), N'USD', 90019981, N'Failed', CAST(N'2019-07-22T22:49:47.6684437' AS DateTime2), N'Anonymous', NULL, NULL)
GO
INSERT [dbo].[Transactions] ([id], [date], [amount], [currency], [customerID], [status], [CreatedDate], [CreatedBy], [UpdatedDate], [UpdatedBy]) VALUES (3, CAST(N'2019-07-22T18:30:55.0000000' AS DateTime2), CAST(5800.50 AS Numeric(15, 2)), N'THB', 90019981, N'Failed', CAST(N'2019-07-22T22:50:24.3295561' AS DateTime2), N'Anonymous', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Transactions] OFF
GO
