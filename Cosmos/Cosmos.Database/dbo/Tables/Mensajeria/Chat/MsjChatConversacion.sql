CREATE TABLE [dbo].[MsjChatConversacion]
(
	[ConversacionID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nombre] NVARCHAR(50) NOT NULL, 
    [Borrada] DATETIME NULL
)
