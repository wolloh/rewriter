#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["System/Api/rewriter.api/rewriter.api.csproj", "System/Api/rewriter.api/"]
RUN dotnet restore "System/Api/rewriter.api/rewriter.api.csproj"
COPY . .
WORKDIR "/src/System/Api/rewriter.api"
RUN dotnet build "rewriter.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "rewriter.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "rewriter.api.dll"]