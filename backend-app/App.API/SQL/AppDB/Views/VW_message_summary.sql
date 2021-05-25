CREATE OR REPLACE VIEW vw_message_summary AS
SELECT  MESSAGE.Id AS MessageId,
        MESSAGE.MessageTitle,
        MESSAGE.MessageContent,
        MESSAGE.SenderName AS Sender,
        MESSAGE.RecipientName AS Receiver,
        MESSAGE_STATUS.StatusLabel
FROM message AS MESSAGE
    INNER JOIN message_status AS MESSAGE_STATUS ON MESSAGE_STATUS.Id = MESSAGE.MessageStatusID;