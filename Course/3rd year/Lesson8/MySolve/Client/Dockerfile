FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5270

ENV ASPNETCORE_URLS=http://+:5270

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Course/3rd year/Lesson8/MySolve/Client/Client.csproj", "Course/3rd year/Lesson8/MySolve/Client/"]
RUN dotnet restore "Course/3rd year/Lesson8/MySolve/Client/Client.csproj"
COPY . .
WORKDIR "/src/Course/3rd year/Lesson8/MySolve/Client"
RUN dotnet build "Client.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Client.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Client.dll"]
