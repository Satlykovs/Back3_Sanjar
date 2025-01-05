FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5041

ENV ASPNETCORE_URLS=http://+:5041

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Lesson21.csproj", "Lesson21/"]
RUN dotnet restore "Lesson21/Lesson21.csproj"
COPY . /src/Lesson21
WORKDIR "/src/Lesson21/"
RUN dotnet build "Lesson21.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Lesson21.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lesson21.dll"]
