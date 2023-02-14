CREATE TABLE [dbo].[AcMail]
(
	[MailID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Email] NVARCHAR(50) NULL, 
    [Predeterminado] BIT NULL,
	CONSTRAINT [AK_AcMail_Email] UNIQUE ([Email])
)
