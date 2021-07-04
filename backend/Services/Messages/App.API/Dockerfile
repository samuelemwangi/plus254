#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Messages/App.API/App.API.csproj", "Messages/App.API/"]
RUN dotnet restore "Messages/App.API/App.API.csproj"
COPY . .
WORKDIR "/src/Messages/App.API"
RUN dotnet build "App.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "App.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "App.API.dll"]