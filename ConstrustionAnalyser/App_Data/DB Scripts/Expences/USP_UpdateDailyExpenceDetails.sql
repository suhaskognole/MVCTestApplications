
Create procedure USP_UpdateDailyExpenceDetails
(  
   @Amount float,  
   @Description nvarchar (250),  
   @Date datetime,  
   @Remark nvarchar (250),
   @ExpenceId Int,
   @UpdateCondition  nvarchar (1000)
)  
AS
Begin
UPDATE [dbo].[Tbl_DailyExpences]

   SET [ExpencesAmount] = @Amount
      ,[ExpenceDescription] = @Description
      ,[ExpenceDate] = @Date
      ,[Remark] = @Remark
	where [DailyExpencesId] = @ExpenceId + 'And '+ @UpdateCondition

 End


