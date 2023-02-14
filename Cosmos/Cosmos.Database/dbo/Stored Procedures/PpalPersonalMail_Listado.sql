

CREATE PROCEDURE [dbo].[PpalPersonalMail_Listado]
AS

SELECT  PpalPersonalMailID,PpalPersonalID,Email,CfgTipoMailID,Predeterminado,Comentarios
FROM    PpalPersonalMail