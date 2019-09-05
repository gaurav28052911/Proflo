FROM  mcr.microsoft.com/dotnet/core/sdk:2.2-alpine3.9 AS build-env
WORKDIR /app
COPY . ./
RUN dotnet restore
RUN dotnet publish ./proflo-portal-backend/Proflo-portal-backend/Proflo-portal-backend.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-alpine3.9
WORKDIR /Proflo-portal-backend
COPY --from=build-env /app/proflo-portal-backend/Proflo-portal-backend/out .
ENTRYPOINT ["dotnet","Proflo-portal-backend.dll"]