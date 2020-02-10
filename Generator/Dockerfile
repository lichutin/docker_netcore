FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Generator/Generator.csproj", "Generator/"]
RUN dotnet restore "Generator/Generator.csproj"
COPY . .
WORKDIR "/src/Generator"
RUN dotnet build "Generator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Generator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Generator.dll"]