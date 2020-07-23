FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS RUNTIME
WORKDIR /app
COPY MyFirstCoreApi/bin/Debug/netcoreapp2.1/MyFirstCoreApi.dll ./
ENTRYPOINT ["dotnet", "MyFirstCoreApi.dll"]
EXPOSE 44315
