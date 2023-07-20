FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR .

COPY ./*.csproj ./
RUN dotnet restore

COPY . ./RestApi/
WORKDIR ./RestApi
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "RestApi.dll"]