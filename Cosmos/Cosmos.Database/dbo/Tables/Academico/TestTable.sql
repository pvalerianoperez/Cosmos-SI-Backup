CREATE TABLE [dbo].[TestTable] (
    [Column_1] INT IDENTITY (1, 1) NOT NULL,
    [Column_2] INT NOT NULL,
    [Column_3] INT NOT NULL,
    [Column_4] INT NOT NULL,
    [Column_5] INT NOT NULL,
    [Column_6] INT NOT NULL,
    [Column_7] INT NOT NULL,
    [Column_8] INT NOT NULL,
    [Column_9] INT NOT NULL,
    [Column_A] INT NOT NULL,
    [Column_B] INT NOT NULL,
    [Column_C] INT NOT NULL,
    [Column_D] INT NOT NULL,
    [Column_E] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Column_1] ASC)
);



GO
CREATE TRIGGER [TriggerUpdate]
	ON [dbo].[TestTable]
	AFTER UPDATE 
AS
 
IF UPDATE(Column_1)
BEGIN
   ;THROW 51000, 'You can''t update the primary key', 1;  
END
 
IF UPDATE(Column_2)
BEGIN
   PRINT 'Column_2 was updated'
END
 
IF UPDATE(Column_3)
BEGIN
   PRINT 'Column_3 was updated'
END
 
IF UPDATE(Column_4)
BEGIN
   PRINT 'Column_4 was updated'
END