
test:
	dotnet test --verbosity normal

build:
	dotnet build --verbosity normal

package:
	dotnet pack --output Packages --verbosity normal 
