exec [dbo].[GetDailyExpencesById] 1
(
  @Id Int=Null
 )
 AS
Begin
SELECT

	   [DailyExpencesId]

      ,[ExpencesAmount]

      ,[ExpenceDescription]

      ,[ExpenceDate]

      ,[Remark]

  FROM [dbo].[Tbl_DailyExpences]

Where DailyExpencesId=@Id


End
