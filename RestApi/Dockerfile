FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR .

COPY ./*.csproj ./
RUN dotnet restore

COPY . ./h1/
WORKDIR ./h1
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "h1.dll"]