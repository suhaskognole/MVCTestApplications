Create Procedure [USP_InsertDailyExpenceDetails]
(  
   @Amount float,  
   @Description nvarchar (250),  
   @Date datetime,  
   @Remark nvarchar (250)  
)  
As 
Begin
INSERT INTO [dbo].[Tbl_DailyExpences]
           (
		    [ExpencesAmount]
           ,[ExpenceDescription]
           ,[ExpenceDate]
           ,[Remark]
		   )
     VALUES
           (
		   @Amount
           ,@Description
           ,@Date
           ,@Remark
		   )
END

