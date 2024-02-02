FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DummyIceCreamFactoryApi/DummyIceCreamFactoryApi.csproj", "DummyIceCreamFactoryApi/"]
RUN dotnet restore "DummyIceCreamFactoryApi/DummyIceCreamFactoryApi.csproj"
COPY . .
WORKDIR "/src/DummyIceCreamFactoryApi"
RUN dotnet build "DummyIceCreamFactoryApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "DummyIceCreamFactoryApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DummyIceCreamFactoryApi.dll"]
