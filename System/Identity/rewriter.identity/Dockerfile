#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["System/Identity/rewriter.identity/rewriter.identity.csproj", "System/Identity/rewriter.identity/"]
RUN dotnet restore "System/Identity/rewriter.identity/rewriter.identity.csproj"
COPY . .
WORKDIR "/src/System/Identity/rewriter.identity"
RUN dotnet build "rewriter.identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "rewriter.identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "rewriter.identity.dll"]