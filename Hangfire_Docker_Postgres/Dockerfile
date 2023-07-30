#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Hangfire_Docker_Postgres/Hangfire_Docker_Postgres.csproj", "Hangfire_Docker_Postgres/"]
RUN dotnet restore "Hangfire_Docker_Postgres/Hangfire_Docker_Postgres.csproj"
COPY . .
WORKDIR "/src/Hangfire_Docker_Postgres"
RUN dotnet build "Hangfire_Docker_Postgres.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Hangfire_Docker_Postgres.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Hangfire_Docker_Postgres.dll"]