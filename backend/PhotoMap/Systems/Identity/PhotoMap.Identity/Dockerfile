#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Systems/Identity/PhotoMap.Identity/PhotoMap.Identity.csproj", "Systems/Identity/PhotoMap.Identity/"]
COPY ["Data/PhotoMap.Context/PhotoMap.Context.csproj", "Data/PhotoMap.Context/"]
COPY ["Services/PhotoMap.Services.Settings/PhotoMap.Services.Settings.csproj", "Services/PhotoMap.Services.Settings/"]
COPY ["Shared/PhotoMap.Common/PhotoMap.Common.csproj", "Shared/PhotoMap.Common/"]
COPY ["Data/PhotoMap.Context.Entities/PhotoMap.Context.Entities.csproj", "Data/PhotoMap.Context.Entities/"]
RUN dotnet restore "./Systems/Identity/PhotoMap.Identity/./PhotoMap.Identity.csproj"
COPY . .
WORKDIR "/src/Systems/Identity/PhotoMap.Identity"
RUN dotnet build "./PhotoMap.Identity.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PhotoMap.Identity.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PhotoMap.Identity.dll"]