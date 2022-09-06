FROM mcr.microsoft.com/dotnet/core/sdk:3.1

# disable microsoft telematry
ENV DOTNET_CLI_TELEMETRY_OPTOUT='true'

ARG LBHPACKAGESTOKEN
ENV LBHPACKAGESTOKEN=$LBHPACKAGESTOKEN
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./Hackney.Shared.Processes.sln ./
COPY ./Hackney.Shared.Processes/Hackney.Shared.Processes.csproj ./Hackney.Shared.Processes/
COPY ./Hackney.Shared.Processes.Tests/Hackney.Shared.Processes.Tests.csproj ./Hackney.Shared.Processes.Tests/
COPY /nuget.config /root/.nuget/NuGet/NuGet.Config

RUN dotnet restore ./Hackney.Shared.Processes/Hackney.Shared.Processes.csproj
RUN dotnet restore ./Hackney.Shared.Processes.Tests/Hackney.Shared.Processes.Tests.csproj

# Copy everything else and build
COPY . .

RUN dotnet build -c debug -o out Hackney.Shared.Processes.Tests/Hackney.Shared.Processes.Tests.csproj

CMD dotnet test
