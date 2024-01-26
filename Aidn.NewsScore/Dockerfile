#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["aidn_test/Aidn.NewsScore/Aidn.NewsScore.csproj", "aidn_test/Aidn.NewsScore/"]
RUN dotnet restore "./aidn_test/Aidn.NewsScore/./Aidn.NewsScore.csproj"
COPY . .
WORKDIR "/src/aidn_test/Aidn.NewsScore"
RUN dotnet build "./Aidn.NewsScore.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Aidn.NewsScore.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aidn.NewsScore.dll"]