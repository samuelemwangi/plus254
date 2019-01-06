
INSERT INTO dbo.Notifications(
       [From],
       [To],
       [Subject],
       [Body],
	   [CreatedBy],
	   [CreatedDate],
	   [LastEditedBy],
       [LastEditedDate],
	   [Deleted]
)
VALUES('test.from@example.com', 'sammiemwangi4@gmail.com', 'Sending Good Vibes Yo', 'Receive Good Vibes', 'System', GETUTCDATE(),'System',GETUTCDATE(),0),
      ('test.from@example.com', 'sammiemwangi4@gmail.com', 'Sending Good Vibes Yo', 'Receive Good Vibes', 'System', GETUTCDATE(),'System',GETUTCDATE(),0),
      ('test.from1@example.com', 'sammiemwangi4@gmail.com', 'Please pay your Items', 'Sending Reminder', 'System', GETUTCDATE(),'System',GETUTCDATE(),0)

