FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Blue.Calculadora.Worker.csproj", "."]
RUN dotnet restore "./Blue.Calculadora.Worker.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Blue.Calculadora.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Blue.Calculadora.Worker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Blue.Calculadora.Worker.dll"]
