# criar pasta para solução e a solução via terminal
mkdir sqlite
cd sqlite
dotnet new sln

# criar pasta para api e a api
mkdir api
cd api
dotnet new webapi --no-openai -controllers

# adicionar a api na solução
cd ..
sln add ./api

# abrir o projeto no vscode
cd api
code .

# adicionar o sqlite e entity framework
dotnet add package Microsoft.Data.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Sqlite

