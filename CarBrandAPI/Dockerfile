FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["CarBrandAPI/CarBrandAPI.csproj", "CarBrandAPI/"]
RUN dotnet restore "CarBrandAPI/CarBrandAPI.csproj"
COPY . .
WORKDIR "/src/CarBrandAPI"
RUN dotnet build "CarBrandAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarBrandAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarBrandAPI.dll"]