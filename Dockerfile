FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine as build
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 80
EXPOSE 443

# Copy csproj and restore as distinct layers
COPY *.sln ./
COPY ./MrTerenceWebAPI/*.csproj ./MrTerenceWebAPI/
COPY ./MrTerence.DAL/*.csproj ./MrTerence.DAL/
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "MrTerenceWebAPI.dll"]


