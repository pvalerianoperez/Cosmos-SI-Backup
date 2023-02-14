

Create Procedure [dbo].[Sistema_Log_Guardar]

	 @TablaNombre		 VARCHAR(100)
    ,@TablaID			 INT			= Null
    ,@TablaColumna1		 VARCHAR(100)	= Null
    ,@TablaColumna2		 VARCHAR(100)	= Null
    ,@Operacion			 VARCHAR(10)
    ,@UserID			 INT
    ,@Descripcion		 VARCHAR(500)	= Null
    ,@Cambios			 VARCHAR(Max)
    ,@IpAddress			 VARCHAR(40)	= Null
    ,@HostName			 VARCHAR(50)	= Null

As
    Begin        
		
		Declare @SistemaLogID int = -1

        Insert Into [SistemaLog](
				 TablaNombre
				,TablaID
				,TablaColumna1
				,TablaColumna2
				,Operacion
				,UserID
				,Descripcion
				,Cambios
				,IpAddress
				,HostName
				,FechaHoraCambioUTC
				)
        Values  (
				 @TablaNombre
				,@TablaID
				,@TablaColumna1
				,@TablaColumna2
				,@Operacion
				,@UserID
				,@Descripcion
				,@Cambios
				,@IpAddress
				,@HostName
				,GetUTCDate()
				)
        
        Set @SistemaLogID = SCOPE_IDENTITY()

    End

RETURN @SistemaLogID