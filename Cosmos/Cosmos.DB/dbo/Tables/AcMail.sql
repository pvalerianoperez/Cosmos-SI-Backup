CREATE TABLE [dbo].[AcMail] (
    [MailID]         INT           IDENTITY (1, 1) NOT NULL,
    [Email]          NVARCHAR (50) NULL,
    [Predeterminado] BIT           NULL,
    PRIMARY KEY CLUSTERED ([MailID] ASC),
    CONSTRAINT [AK_AcMail_Email] UNIQUE NONCLUSTERED ([Email] ASC)
);

