FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

ENV APPENVIRONMENT=Dev 
WORKDIR App

COPY *.sln .
COPY ./ReportPortal_APITest/*.csproj ./ReportPortal_APITest/
COPY ./ReportPortal_API/*.csproj ./ReportPortal_API/
COPY ./ReportPortal_POM/*.csproj ./ReportPortal_POM/
COPY ./ReporPortal_MSTest/*.csproj ./ReporPortal_MSTest/
COPY ./ReportPortal_SpecFlowTest/*.csproj ./ReportPortal_SpecFlowTest/

# Restore as distinct layers
RUN dotnet restore

# copy full solution over
COPY . .
RUN dotnet build

# create a new build target called testrunner
FROM build AS testrunner

# navigate to the api test directory
WORKDIR /App/ReportPortal_APITest
# when you run this build target it will run the unit tests
CMD ["dotnet", "test", "--logger:trx"]

# run the unit tests
FROM build AS test
WORKDIR /App/ReportPortal_APITest
RUN dotnet test --logger:trx