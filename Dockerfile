# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY DevopsProject.sln ./
COPY DevopsProject/DevopsProject.csproj DevopsProject/
COPY DevopsProject.Tests/DevopsProject.Tests.csproj DevopsProject.Tests/
RUN dotnet restore DevopsProject.sln

COPY . .
RUN dotnet publish DevopsProject/DevopsProject.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./

ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "DevopsProject.dll"]
