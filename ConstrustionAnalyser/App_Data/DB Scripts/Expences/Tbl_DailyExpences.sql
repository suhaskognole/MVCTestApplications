
CREATE TABLE [dbo].[Tbl_DailyExpences]
(
	[DailyExpencesId] [int] IDENTITY(1,1) NOT NULL,
	[ExpencesAmount] [float] NULL,
	[ExpenceDescription] [nvarchar](250) NULL,
	[ExpenceDate] [datetime] NULL,
	[Remark] [nvarchar](250) NULL
)
ON [PRIMARY]



