IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[VW_Notifications]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[VW_Notifications]
AS
SELECT       [From] AS SentFrom,
             [To]  AS SentTo,
             [Subject] AS Subject,
             [Body] AS NotificationMessage,
             [CreatedBy] AS CreatedBy            
FROM         dbo.Notifications  
'