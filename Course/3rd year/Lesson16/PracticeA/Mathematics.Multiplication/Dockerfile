FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Mathematics.Multiplication.csproj", "Mathematics.Multiplication/"]
RUN dotnet restore "Mathematics.Multiplication/Mathematics.Multiplication.csproj"
COPY . ./Mathematics.Multiplication
WORKDIR "/src/Mathematics.Multiplication"
RUN dotnet build "Mathematics.Multiplication.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Mathematics.Multiplication.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mathematics.Multiplication.dll"]
