FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# It's important to keep lines from here down to "COPY . ." identical in all Dockerfiles
# to take advantage of Docker's build cache, to speed up local container builds
COPY "desafio-cnab-backend.sln" "desafio-cnab-backend.sln"

COPY "Desafio.API/Desafio.API.csproj" "Desafio.API/Desafio.API.csproj"
COPY "Desafio.Application/Desafio.Application.csproj" "Desafio.Application/Desafio.Application.csproj"
COPY "Desafio.Domain/Desafio.Domain.csproj" "Desafio.Domain/Desafio.Domain.csproj"
COPY "Desafio.Infra/Desafio.Infra.csproj" "Desafio.Infra/Desafio.Infra.csproj"
COPY "Desafio.Service/Desafio.Service.csproj" "Desafio.Service/Desafio.Service.csproj"
COPY "Desafio.Test/Desafio.Test.csproj" "Desafio.Test/Desafio.Test.csproj"

RUN dotnet restore "desafio-cnab-backend.sln"

COPY . .

WORKDIR "/src/Desafio.API"
RUN dotnet build "Desafio.API.csproj" -c Release -o /app/build

RUN dotnet test "Desafio.API.csproj"


FROM build AS publish
RUN dotnet publish "Desafio.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Desafio.API.dll"]
