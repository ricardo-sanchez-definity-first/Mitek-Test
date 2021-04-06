#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Mitek-API/Mitek-API.csproj", "Mitek-API/"]
RUN dotnet restore "Mitek-API/Mitek-API.csproj"
COPY . .
WORKDIR "/src/Mitek-API"
RUN dotnet build "Mitek-API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mitek-API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mitek-API.dll"]