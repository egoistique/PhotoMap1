#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Systems/Worker/PhotoMap.Worker/PhotoMap.Worker.csproj", "Systems/Worker/PhotoMap.Worker/"]
COPY ["Services/PhotoMap.Services.Actions/PhotoMap.Services.Actions.csproj", "Services/PhotoMap.Services.Actions/"]
COPY ["Services/PhotoMap.Services.RabbitMq/PhotoMap.Services.RabbitMq.csproj", "Services/PhotoMap.Services.RabbitMq/"]
COPY ["Shared/PhotoMap.Common/PhotoMap.Common.csproj", "Shared/PhotoMap.Common/"]
COPY ["Services/PhotoMap.Services.Logger/PhotoMap.Services.Logger.csproj", "Services/PhotoMap.Services.Logger/"]
COPY ["Services/PhotoMap.Services.Settings/PhotoMap.Services.Settings.csproj", "Services/PhotoMap.Services.Settings/"]
RUN dotnet restore "./Systems/Worker/PhotoMap.Worker/./PhotoMap.Worker.csproj"
COPY . .
WORKDIR "/src/Systems/Worker/PhotoMap.Worker"
RUN dotnet build "./PhotoMap.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PhotoMap.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PhotoMap.Worker.dll"]