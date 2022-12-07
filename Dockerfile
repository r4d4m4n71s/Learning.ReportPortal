FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR App

COPY *.sln .
COPY ./ReportPortal_APITest/*.csproj ./ReportPortal_APITest/
COPY ./ReportPortal_API/*.csproj ./ReportPortal_API/
COPY ./ReportPortal_POM/*.csproj ./ReportPortal_POM/
COPY ./ReporPortal_MSTest/*.csproj ./ReporPortal_MSTest/
COPY ./ReportPortal_SpecFlowTest/*.csproj ./ReportPortal_SpecFlowTest/




# Restore as distinct layers
RUN dotnet restore

# Copy everything
COPY ./ReportPortal_APITest/ ./ReportPortal_APITest/
COPY ./ReportPortal_API/ ./ReportPortal_API/

# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "ReportPortal_APITest.dll"]