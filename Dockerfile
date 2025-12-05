FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY Cliently.Gateway.csproj .

RUN dotnet restore 

COPY . .

WORKDIR /src/

RUN dotnet publish "./Cliently.Gateway.csproj"  -c Release -o /app/publish 


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

EXPOSE 80

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Cliently.Gateway.dll"]
