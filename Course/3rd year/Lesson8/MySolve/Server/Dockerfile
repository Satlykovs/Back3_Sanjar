FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5087

ENV ASPNETCORE_URLS=http://+:5087

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Course/3rd year/Lesson8/MySolve/Server/MySolve.csproj", "Course/3rd year/Lesson8/MySolve/Server/"]
RUN dotnet restore "Course/3rd year/Lesson8/MySolve/Server/MySolve.csproj"
COPY . .
WORKDIR "/src/Course/3rd year/Lesson8/MySolve/Server"
RUN dotnet build "MySolve.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "MySolve.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MySolve.dll"]
