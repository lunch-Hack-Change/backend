#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HackAndChangeApi/HackAndChangeApi.csproj", "HackAndChangeApi/"]
RUN dotnet restore "HackAndChangeApi/HackAndChangeApi.csproj"
COPY . .
WORKDIR "/src/HackAndChangeApi"
RUN dotnet build "HackAndChangeApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HackAndChangeApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HackAndChangeApi.dll"]