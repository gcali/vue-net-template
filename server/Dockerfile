FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY TEMPLATE_PLACEHOLDER_CAPITAL.Api/*.csproj TEMPLATE_PLACEHOLDER_CAPITAL.Api/
COPY TEMPLATE_PLACEHOLDER_CAPITAL.Core/*.csproj TEMPLATE_PLACEHOLDER_CAPITAL.Core/
COPY TEMPLATE_PLACEHOLDER_CAPITAL.Infrastructure/*.csproj TEMPLATE_PLACEHOLDER_CAPITAL.Infrastructure/
COPY *.sln ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out TEMPLATE_PLACEHOLDER_CAPITAL.Api

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
RUN apt-get update && apt-get install -y apt-utils libgdiplus libc6-dev
RUN mkdir -p /var/logs/TEMPLATE_PLACEHOLDER_LOWER/
WORKDIR /app
COPY --from=build-env /app/out .
ENV ASPNETCORE_ENVIRONMENT=Production
ENTRYPOINT ["dotnet", "TEMPLATE_PLACEHOLDER_CAPITAL.Api.dll"]

