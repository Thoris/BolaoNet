
DECLARE @NomeBolao VARCHAR(100)


SET @NomeBolao = 'Copa do Mundo 2018'
 

INSERT INTO [dbo].[BoloesPremiacao]
           ([NomeBolao]
           ,[Posicao]
           ,[Percentual]
           ,[Valor]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[ModifiedBy] 
           ,[ModifiedDate]
           ,[ActiveFlag])
     VALUES
           (@NomeBolao
           ,1
           ,70
           ,1400
           ,'thoris'
           ,GetDate()
           ,'thoris'
           ,GetDate()
           ,NULL)

INSERT INTO [dbo].[BoloesPremiacao]
           ([NomeBolao]
           ,[Posicao]
           ,[Percentual]
           ,[Valor]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[ModifiedBy] 
           ,[ModifiedDate]
           ,[ActiveFlag])
     VALUES
           (@NomeBolao
           ,2
           ,20
           ,400
           ,'thoris'
           ,GetDate()
           ,'thoris'
           ,GetDate()
           ,NULL)

INSERT INTO [dbo].[BoloesPremiacao]
           ([NomeBolao]
           ,[Posicao]
           ,[Percentual]
           ,[Valor]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[ModifiedBy] 
           ,[ModifiedDate]
           ,[ActiveFlag])
     VALUES
           (@NomeBolao
           ,3
           ,9
           ,180
           ,'thoris'
           ,GetDate()
           ,'thoris'
           ,GetDate()
           ,NULL)

 INSERT INTO [dbo].[BoloesPremiacao]
           ([NomeBolao]
           ,[Posicao]
           ,[Percentual]
           ,[Valor]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[ModifiedBy] 
           ,[ModifiedDate]
           ,[ActiveFlag])
     VALUES
           (@NomeBolao
           ,40
           ,1
           ,20
           ,'thoris'
           ,GetDate()
           ,'thoris'
           ,GetDate()
           ,NULL)
GO



