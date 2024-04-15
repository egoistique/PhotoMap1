#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Systems/Api/PhotoMap.Api/PhotoMap.Api.csproj", "Systems/Api/PhotoMap.Api/"]
COPY ["Data/PhotoMap.Context.Entities/PhotoMap.Context.Entities.csproj", "Data/PhotoMap.Context.Entities/"]
COPY ["Data/PhotoMap.Context.Migrations/PhotoMap.Context.Migrations.PgSql/PhotoMap.Context.Migrations.PgSql.csproj", "Data/PhotoMap.Context.Migrations/PhotoMap.Context.Migrations.PgSql/"]
COPY ["Data/PhotoMap.Context/PhotoMap.Context.csproj", "Data/PhotoMap.Context/"]
COPY ["Services/PhotoMap.Services.Settings/PhotoMap.Services.Settings.csproj", "Services/PhotoMap.Services.Settings/"]
COPY ["Shared/PhotoMap.Common/PhotoMap.Common.csproj", "Shared/PhotoMap.Common/"]
COPY ["Data/PhotoMap.Context.Seeder/PhotoMap.Context.Seeder.csproj", "Data/PhotoMap.Context.Seeder/"]
COPY ["Services/PhotoMap.Services.UserAccount/PhotoMap.Services.UserAccount.csproj", "Services/PhotoMap.Services.UserAccount/"]
COPY ["Services/PhotoMap.Services.Actions/PhotoMap.Services.Actions.csproj", "Services/PhotoMap.Services.Actions/"]
COPY ["Services/PhotoMap.Services.RabbitMq/PhotoMap.Services.RabbitMq.csproj", "Services/PhotoMap.Services.RabbitMq/"]
COPY ["Services/PhotoMap.Services.Feedbacks/PhotoMap.Services.Feedbacks.csproj", "Services/PhotoMap.Services.Feedbacks/"]
COPY ["Services/PhotoMap.Services.ImagePathes/PhotoMap.Services.ImagePathes.csproj", "Services/PhotoMap.Services.ImagePathes/"]
COPY ["Services/PhotoMap.Services.Logger/PhotoMap.Services.Logger.csproj", "Services/PhotoMap.Services.Logger/"]
COPY ["Services/PhotoMap.Services.PointCategories/PhotoMap.Services.PointCategories.csproj", "Services/PhotoMap.Services.PointCategories/"]
COPY ["Services/PhotoMap.Services.Points/PhotoMap.Services.Points.csproj", "Services/PhotoMap.Services.Points/"]
COPY ["Systems/Api/PhotoMap.Api.Settings/PhotoMap.Api.Settings.csproj", "Systems/Api/PhotoMap.Api.Settings/"]
RUN dotnet restore "./Systems/Api/PhotoMap.Api/./PhotoMap.Api.csproj"
COPY . .
WORKDIR "/src/Systems/Api/PhotoMap.Api"
RUN dotnet build "./PhotoMap.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PhotoMap.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PhotoMap.Api.dll"]