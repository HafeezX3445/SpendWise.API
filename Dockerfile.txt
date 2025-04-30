# --- Build stage ---
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy everything and restore packages
COPY . . 
RUN dotnet restore

# Publish the app to the /out directory
RUN dotnet publish SpendWise.API.csproj -c Release -o /out

# --- Runtime stage ---
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy from build image
COPY --from=build /out . 

# Expose port (optional for local dev)
EXPOSE 80

# Start the app
ENTRYPOINT ["dotnet", "SpendWise.API.dll"]
