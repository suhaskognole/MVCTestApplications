Create procedure USP_DelTblDailyExpences
(  
   @ExpencesId int  
)  
AS   
begin  
   Delete from Tbl_DailyExpences where DailyExpencesId=@ExpencesId  
End 
