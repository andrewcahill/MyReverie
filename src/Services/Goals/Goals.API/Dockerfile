FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY src/Services/Goals/Goals.API/Goals.API.csproj src/Services/Goals/Goals.API/
RUN dotnet restore src/Services/Goals/Goals.API/Goals.API.csproj
COPY . .
WORKDIR /src/src/Services/Goals/Goals.API
RUN dotnet build Goals.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Goals.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Goals.API.dll"]
