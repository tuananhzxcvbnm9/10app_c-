FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore apps/app-10-analytics-dashboard/src/Analytics.Web/Analytics.Web.csproj
RUN dotnet publish apps/app-10-analytics-dashboard/src/Analytics.Web/Analytics.Web.csproj -c Release -o /app/out

FROM nginx:1.27-alpine
RUN addgroup -S appgroup && adduser -S appuser -G appgroup
COPY --from=build /app/out/wwwroot /usr/share/nginx/html
RUN sed -i 's/listen       80;/listen 8080;/' /etc/nginx/conf.d/default.conf     && chown -R appuser:appgroup /usr/share/nginx/html /var/cache/nginx /var/run /etc/nginx/conf.d
EXPOSE 8080
USER appuser
CMD ["nginx", "-g", "daemon off;"]
