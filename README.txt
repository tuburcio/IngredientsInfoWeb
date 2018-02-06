Example of WEB API for dishes, ingredients and dishes.

The purpose of this project is making a REST api with a SOAP interface also.

The solution has four projects:
-	IngredientsEntities: The data access layer, it relies on EF6 with code first implementation.
		It is an ORM which abstracts the underlaying storage technology. In this approach the 
		the storage is LocalDB of SQL Server but could easily be changed by just editing the
		connection string.
-	IngredientsService: The business layer, if has the logic part of the application itself.
		With this layer we only have to change logic here and give away specific presentation
		features.
		Depends on: IngredientsEntities 
-	IngredientsInfoWeb: The REST API implementation of the business layer, build with MVC5 and 
		WEB API2. It uses StructureMap as IoC for dependency injection.
		Depends on: IngredientsService
-	IngredientsInfo.DistSvc: The SOAP implementation of the business layer, build with WCF and
		StructureMap as Ioc for dependency injection.
		Depends on: IngredientsService
-	IngredientsInfoWeb.Test: The test project for que IngredientsInfoWeb project.

The project uses Automapper also to map objects between different layers.

TODO:
-	IngredientsEntities: 
		Check if there are not implemented methods.
		Refactor some methods based on templates.
		If we want to implement a tracker of changes made in the Db, we could just install the
			nuget package tracker-enabled-dbcontext which stores every change made on the db in 
			desired entities (it stores the changes in the db depending on the current thread 
			culture, which need to be fixed, easy to do), or add a migration adding our entities 
			3 fields, ActionType, User and ActionDate. We could also make an approach based on 
			stored procedures.
		Summarize the whole project.
		Unit Testing.
-	IngredientsService:
		Check which methods should added to the interfaces.
		Summarize the whole project.
		Unit Testing.
-	IngredientsInfoWeb:
		Add the URL to the responses through a helper to make the API be self descriptive. Add XML output and input
			formatters as optional.
		Add pagination.
		Add the possibility to decide the consumer whether or not include sub entities with a
			parameter on the query string.
		Add token if authentication is implemented.
		Summarize the whole project.
		Unit Testing.
-	IngrendientsInfo.DistSvc
		Add the remaining methods and missing interfaces.
		Add authentication if needed.
		Summarize the whole project.
		Unit Testing.

		