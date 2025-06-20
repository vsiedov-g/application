FROM node:18 as nodebuild
WORKDIR /app
COPY ClientApp ./ClientApp
WORKDIR /app/ClientApp
RUN npm install && npm run build -- --configuration production

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
COPY --from=nodebuild /app/ClientApp/dist ./wwwroot
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "application.dll"]