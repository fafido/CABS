USE [Live]
GO

/****** Object:  StoredProcedure [dbo].[Proc_DailyBackup]    Script Date: 12/16/2020 9:18:38 AM ******/
SET ANSI_NULLS OFF
GO

SET QUOTED_IDENTIFIER OFF
GO



CREATE PROCEDURE [dbo].[Proc_DailyBackup]  AS

DECLARE @name VARCHAR(50) -- database name 
DECLARE @path VARCHAR(256) -- path for backup files 
DECLARE @fileName VARCHAR(256) -- filename for backup 
DECLARE @fileDate VARCHAR(20) -- used for file name

SET @path = 'D:\Backup\' 

SELECT @fileDate = CONVERT(VARCHAR, GETDATE(), 112)

DECLARE db_cursor CURSOR FOR 
SELECT name 
FROM master.dbo.sysdatabases 
WHERE name  NOT IN ('master','tempdb','model','msdb','ReportServer','ReportServerTempDB') 

OPEN db_cursor  
FETCH NEXT FROM db_cursor INTO @name  

WHILE @@FETCH_STATUS = 0  
BEGIN  
       SET @fileName = @path + @name + '_' + @fileDate + '.BAK' 
       BACKUP DATABASE @name TO DISK = @fileName 

       FETCH NEXT FROM db_cursor INTO @name  
END  

CLOSE db_cursor  
DEALLOCATE db_cursor


GO

