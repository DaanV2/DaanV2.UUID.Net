


restore:
	dotnet restore

test: restore
	dotnet test --no-restore --verbosity normal

build: restore
	dotnet build --no-restore --verbosity normal