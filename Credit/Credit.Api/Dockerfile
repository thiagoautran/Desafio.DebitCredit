#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Credit.Api/Credit.Api.csproj", "Credit.Api/"]
COPY ["Credit.ApplicationCore/Credit.ApplicationCore.csproj", "Credit.ApplicationCore/"]
COPY ["Credit.Infrastructure/Credit.Infrastructure.csproj", "Credit.Infrastructure/"]
RUN dotnet restore "Credit.Api/Credit.Api.csproj"
COPY . .
WORKDIR "/src/Credit.Api"
RUN dotnet build "Credit.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Credit.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Credit.Api.dll"]