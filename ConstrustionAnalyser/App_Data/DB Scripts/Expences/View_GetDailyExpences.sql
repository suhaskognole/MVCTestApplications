Create Procedure [dbo].[GetDailyExpences]  
as  
begin  
 
SELECT
	   [DailyExpencesId]
      ,[ExpencesAmount]
      ,[ExpenceDescription]
      ,[ExpenceDate]
      ,[Remark]
 
  FROM [dbo].[Tbl_DailyExpences]

End
