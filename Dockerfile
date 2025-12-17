# CSS build stage
FROM node:22-alpine AS css-build
WORKDIR /app
COPY src/package.json src/package-lock.json ./
RUN npm ci --omit=dev --ignore-scripts
COPY src/wwwroot ./wwwroot
RUN npm run build

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

# Copy source code
COPY src/ .

# Copy pre-built CSS from css-build stage
COPY --from=css-build /app/wwwroot/css/app.css ./wwwroot/css/app.css

# Restore and build
ENV DOTNET_ENVIRONMENT=Docker
RUN dotnet restore
RUN dotnet build -c Release --no-restore
RUN dotnet publish -c Release --no-build -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

# Copy published app from build stage
COPY --from=build /app/publish .

# Expose port
EXPOSE 5000

# Set environment
ENV ASPNETCORE_URLS=http://+:5000

# Health check
HEALTHCHECK --interval=30s --timeout=3s --start-period=40s --retries=3 \
    CMD curl -f http://localhost:5000/ || exit 1

# Run the app
ENTRYPOINT ["dotnet", "exercise-planner.dll"]
