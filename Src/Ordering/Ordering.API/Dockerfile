#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Src/Ordering/Ordering.API/Ordering.API.csproj", "Src/Ordering/Ordering.API/"]
COPY ["Src/Ordering/Ordering.Application/Ordering.Application.csproj", "Src/Ordering/Ordering.Application/"]
COPY ["Src/Ordering/Ordering.Core/Ordering.Core.csproj", "Src/Ordering/Ordering.Core/"]
COPY ["Src/Ordering/Ordering.Infrastructure/Ordering.Infrastructure.csproj", "Src/Ordering/Ordering.Infrastructure/"]
RUN dotnet restore "Src/Ordering/Ordering.API/Ordering.API.csproj"
COPY . .
WORKDIR "/src/Src/Ordering/Ordering.API"
RUN dotnet build "Ordering.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ordering.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ordering.API.dll"]
