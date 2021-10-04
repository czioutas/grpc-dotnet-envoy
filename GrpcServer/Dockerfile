FROM mcr.microsoft.com/dotnet/sdk:5.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY "GrpcServer.csproj" .
RUN dotnet restore "GrpcServer.csproj"
COPY . .
RUN dotnet build "GrpcServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GrpcServer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN dotnet dev-certs https --clean
RUN dotnet dev-certs https
RUN dotnet dev-certs https --trust
ENTRYPOINT ["dotnet", "GrpcServer.dll"]