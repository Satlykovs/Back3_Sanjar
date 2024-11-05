
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app


COPY MySolve/Server/MySolve.csproj ./Server/
#COPY MySolve/ToDo.Tests/ToDo.Tests.csproj ./Todo.Tests/
RUN dotnet restore ./Server/MySolve.csproj


COPY MySolve/. .
RUN dotnet build ./Server/MySolve.csproj -c Release -o /app/build


FROM build AS publish
RUN dotnet publish ./Server/MySolve.csproj -c Release -o /app/publish


FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=publish /app/publish .



EXPOSE 8080


ENTRYPOINT ["dotnet", "MySolve.dll"]

#Я всё еще не особо понимаю, как правильно писать это...
