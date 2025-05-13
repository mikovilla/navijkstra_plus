# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project and restore dependencies
COPY . .
RUN dotnet publish -c Release -o /app/build

# Runtime Stage: Serve with Nginx
FROM nginx:alpine
WORKDIR /usr/share/nginx/html

# Remove the default Nginx static assets
RUN rm -rf ./*

# Copy Blazor build output
COPY --from=build /app/build/wwwroot ./

# Optional: Replace the default nginx config (optional)
# COPY nginx.conf /etc/nginx/nginx.conf

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]