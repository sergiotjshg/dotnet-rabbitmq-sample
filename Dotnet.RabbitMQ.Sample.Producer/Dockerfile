FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Dotnet.RabbitMQ.Sample.Producer/Dotnet.RabbitMQ.Sample.Producer.csproj", "Dotnet.RabbitMQ.Sample.Producer/"]
RUN dotnet restore "Dotnet.RabbitMQ.Sample.Producer/Dotnet.RabbitMQ.Sample.Producer.csproj"
COPY . .
WORKDIR "/src/Dotnet.RabbitMQ.Sample.Producer"
RUN dotnet build "Dotnet.RabbitMQ.Sample.Producer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Dotnet.RabbitMQ.Sample.Producer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dotnet.RabbitMQ.Sample.Producer.dll"]
