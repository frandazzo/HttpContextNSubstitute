.PHONY: build test pack

build:
	dotnet build src/HttpContextNSubstitute.sln

test:
	dotnet test src/HttpContextNSubstitute.sln

coverage:
	dotnet test src/HttpContextNSubstitute.sln --collect:"XPlat Code Coverage"

pack:
	dotnet pack src/HttpContextNSubstitute/HttpContextNSubstitute.csproj -c Release --include-source --include-symbols -o nupkgs
