FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["VoteRonaldoVsMessi.WebApp/VoteRonaldoVsMessi.WebApp.csproj", "VoteRonaldoVsMessi.WebApp/"]
COPY ["VoteRonaldoVsMessi.Services/VoteRonaldoVsMessi.Services.csproj", "VoteRonaldoVsMessi.Services/"]
COPY ["VoteRonaldoVsMessi.Infrastructure/VoteRonaldoVsMessi.Infrastructure.csproj", "VoteRonaldoVsMessi.Infrastructure/"]
RUN dotnet restore "VoteRonaldoVsMessi.WebApp/VoteRonaldoVsMessi.WebApp.csproj"
COPY . .
WORKDIR "/src/VoteRonaldoVsMessi.WebApp"
RUN dotnet build "VoteRonaldoVsMessi.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VoteRonaldoVsMessi.WebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VoteRonaldoVsMessi.WebApp.dll"]