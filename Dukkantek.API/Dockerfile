#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Dukkantek.API/Dukkantek.API.csproj", "Dukkantek.API/"]
COPY ["Dukkantek.Services/Dukkantek.Services.csproj", "Dukkantek.Services/"]
COPY ["Dukkantek.Infrastructure/Dukkantek.Infrastructure.csproj", "Dukkantek.Infrastructure/"]
COPY ["Dukkantek.Domain/Dukkantek.Domain.csproj", "Dukkantek.Domain/"]
RUN dotnet restore "Dukkantek.API/Dukkantek.API.csproj"
COPY . .
WORKDIR "/src/Dukkantek.API"
RUN dotnet build "Dukkantek.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Dukkantek.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dukkantek.API.dll"]
