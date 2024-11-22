FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5087

ENV ASPNETCORE_URLS=http://+:5087

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Mathematics.Division.csproj", "Mathematics.Division/"]
RUN dotnet restore "Mathematics.Division/Mathematics.Division.csproj"
COPY . ./Mathematics.Division
WORKDIR "/src/Mathematics.Division"
RUN dotnet build "Mathematics.Division.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Mathematics.Division.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mathematics.Division.dll"]
