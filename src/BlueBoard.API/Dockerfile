FROM mcr.microsoft.com/dotnet/core/aspnet:3.0.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["BlueBoard.API/BlueBoard.API.csproj", "BlueBoard.API/"]
COPY ["BlueBoard.Application/BlueBoard.Application.csproj", "BlueBoard.Application/"]
COPY ["BlueBoard.Persistence/BlueBoard.Persistence.csproj", "BlueBoard.Persistence/"]
COPY ["BlueBoard.Domain/BlueBoard.Domain.csproj", "BlueBoard.Domain/"]
COPY ["BlueBoard.Common/BlueBoard.Common.csproj", "BlueBoard.Common/"]
RUN dotnet restore "BlueBoard.API/BlueBoard.API.csproj"
COPY . .
WORKDIR /src/BlueBoard.API
RUN dotnet build "BlueBoard.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "BlueBoard.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BlueBoard.API.dll"]