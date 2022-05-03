# Docker Image to run/deploy the API project

# Use .NETCore SDK base image

FROM mcr.microsoft.com/dotnet/sdk:5.0 as build-env

# Setup a working directory

WORKDIR /app

#Copy project file to working directory

#COPY *.csproj ./

COPY ["ProjectManagement.Api/E-healthcare.Api.csproj","ProjectManagement.Api/"]
COPY ["ProjectManagement.Data/ProjectManagement.Data.Interfaces.csproj","ProjectManagement.Data.Interfaces/"]
COPY ["ProjectManagement.Data.Implementation/E-healthcare.Data.csproj","ProjectManagement.Data.Implementation/"]
COPY ["ProjectManagement.Data.Implementation/ProjectManagement.Data.Implementation.csproj","ProjectManagement.Data.Implementation/"]
COPY ["ProjectManagement.Entities/E-healthcare.Entities.csproj","ProjectManagement.Entities/"]
COPY ["ProjectManagement.Shared/E-healthcare.Shared.csproj","ProjectManagement.Shared/"]

RUN dotnet restore "ProjectManagement.Api/E-healthcare.Api.csproj"

# Copy everything else to working directory

COPY . ./

RUN dotnet publish "ProjectManagement.Api/E-healthcare.Api.csproj" -c Release -o out

# use dotnet runtime image and run the app

FROM mcr.microsoft.com/dotnet/aspnet:5.0

#setup working directory

WORKDIR /app
COPY --from=build-env /app/out .

#Specify entry point
ENTRYPOINT ["dotnet","E-healthcare.Api.dll"]

#Run this image on a docker container [80]




