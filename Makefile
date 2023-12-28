build:
	dotnet build
	
run:
	dotnet run
	
ef-scaffold:
	dotnet ef dbcontext scaffold "Data Source=identifier.sqlite" Microsoft.EntityFrameworkCore.Sqlite --context-dir Data --output-dir Models