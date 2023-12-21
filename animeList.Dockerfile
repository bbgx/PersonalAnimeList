#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AnimeList/AnimeList.csproj", "AnimeList/"]
RUN dotnet restore "./AnimeList/./AnimeList.csproj"
COPY . .
WORKDIR "/src/AnimeList"
RUN dotnet build "./AnimeList.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AnimeList.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
COPY --from=publish /app/publish .

COPY ["DevKey/certificate.pfx", "/https/certificate.pfx"]

ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/certificate.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=1234

ENTRYPOINT ["dotnet", "AnimeList.dll"]