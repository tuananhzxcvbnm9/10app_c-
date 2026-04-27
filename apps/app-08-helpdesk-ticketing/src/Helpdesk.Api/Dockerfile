FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore apps/app-08-helpdesk-ticketing/src/Helpdesk.Api/Helpdesk.Api.csproj
RUN dotnet publish apps/app-08-helpdesk-ticketing/src/Helpdesk.Api/Helpdesk.Api.csproj -c Release -o /app/out /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
RUN addgroup --system appgroup && adduser --system --ingroup appgroup appuser
COPY --from=build /app/out .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
USER appuser
ENTRYPOINT ["dotnet", "Helpdesk.Api.dll"]
