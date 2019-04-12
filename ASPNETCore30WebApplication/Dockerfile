FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-stretch AS build
WORKDIR /src
COPY ["ASPNETCore30WebApplication/ASPNETCore30WebApplication.csproj", "ASPNETCore30WebApplication/"]
RUN dotnet restore "ASPNETCore30WebApplication/ASPNETCore30WebApplication.csproj"
COPY . .
WORKDIR "/src/ASPNETCore30WebApplication"
RUN dotnet build "ASPNETCore30WebApplication.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ASPNETCore30WebApplication.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ASPNETCore30WebApplication.dll"]