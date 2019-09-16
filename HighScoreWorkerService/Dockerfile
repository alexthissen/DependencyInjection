FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["HighScoreWorkerService/HighScoreWorkerService.csproj", "HighScoreWorkerService/"]
RUN dotnet restore "HighScoreWorkerService/HighScoreWorkerService.csproj"
COPY . .
WORKDIR "/src/HighScoreWorkerService"
RUN dotnet build "HighScoreWorkerService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HighScoreWorkerService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HighScoreWorkerService.dll"]