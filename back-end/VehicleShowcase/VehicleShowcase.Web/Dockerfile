FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["VehicleShowcase.Web/VehicleShowcase.Web.csproj", "VehicleShowcase.Web/"]
COPY ["VehicleShowcase.Application/VehicleShowcase.Application.csproj", "VehicleShowcase.Application/"]
COPY ["VehicleShowcase.Domain/VehicleShowcase.Domain.csproj", "VehicleShowcase.Domain/"]
COPY ["VehicleShowcase.Infrastructure/VehicleShowcase.Infrastructure.csproj", "VehicleShowcase.Infrastructure/"]
RUN dotnet restore "VehicleShowcase.Web/VehicleShowcase.Web.csproj"
COPY . .
WORKDIR "/src/VehicleShowcase.Web"
RUN dotnet build "VehicleShowcase.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VehicleShowcase.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VehicleShowcase.Web.dll"]