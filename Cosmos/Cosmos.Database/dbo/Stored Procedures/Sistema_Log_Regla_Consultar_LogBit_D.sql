
Create Procedure [dbo].[Sistema_Log_Regla_Consultar_LogBit_D]

	@UserID			int = 0,
	@TablaNombre	nvarchar(50)

As 
BEGIN
	SET NOCOUNT ON;

--Reviso Si va a loggear a una persona en específico con una tabla en específico.
IF (
	SELECT SistemaLogRegla.UserID FROM SistemaLogRegla 
	WHERE (SistemaLogRegla.UserID = @UserID) And 
		  (SistemaLogRegla.TablaNombre = @TablaNombre) And
		  (SistemaLogRegla.D = 1)) = @UserID
	Return 1
Else
	IF (
		SELECT SistemaLogRegla.UserID FROM SistemaLogRegla 
		WHERE (SistemaLogRegla.UserID = @UserID) And 
			  (SistemaLogRegla.TablaNombre = @TablaNombre) And
			  (SistemaLogRegla.D = 0)) = @UserID
		Return 0
		Else

		--Reviso Si va a loggear a una persona en específico con cualquier tabla (*).
		IF (
			SELECT SistemaLogRegla.UserID FROM SistemaLogRegla 
			WHERE (SistemaLogRegla.UserID = @UserID) And 
				  (SistemaLogRegla.TablaNombre = '*') And
				  (SistemaLogRegla.D = 1)) = @UserID
			Return 1
		Else
			IF (
				SELECT SistemaLogRegla.UserID FROM SistemaLogRegla 
				WHERE (SistemaLogRegla.UserID = @UserID) And 
					  (SistemaLogRegla.TablaNombre = '*') And
					  (SistemaLogRegla.D = 0)) = @UserID
				Return 0
			Else

			--Reviso Si va a loggear todos los usuarios (0) y con una tabla en específico.
			IF (
			SELECT SistemaLogRegla.UserID FROM SistemaLogRegla 
			WHERE (SistemaLogRegla.UserID = 0) And 
				  (SistemaLogRegla.TablaNombre = @TablaNombre) And
				  (SistemaLogRegla.D = 1)) = 0
			Return 1
			Else
				IF (
				SELECT SistemaLogRegla.UserID FROM SistemaLogRegla 
				WHERE (SistemaLogRegla.UserID = 0) And 
					  (SistemaLogRegla.TablaNombre = @TablaNombre) And
					  (SistemaLogRegla.D = 0)) = 0
				Return 0
				Else

					--Reviso Si va a loggear todos los usuarios (0) y todas las tablas (*).
					IF (
					SELECT SistemaLogRegla.UserID FROM SistemaLogRegla 
					WHERE (SistemaLogRegla.UserID = 0) And 
						  (SistemaLogRegla.TablaNombre = '*') And
						  (SistemaLogRegla.D = 1)) = 0
					Return 1
					Else
						IF (
						SELECT SistemaLogRegla.UserID FROM SistemaLogRegla 
						WHERE (SistemaLogRegla.UserID = 0) And 
							  (SistemaLogRegla.TablaNombre = '*') And
							  (SistemaLogRegla.D = 0)) = 0
						Return 0
						Else	
						--Regreso 0, por que no encontré nada.
						Return 0

END