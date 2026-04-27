FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore apps/app-05-ecommerce-admin/src/Ecommerce.Api/Ecommerce.Api.csproj
RUN dotnet publish apps/app-05-ecommerce-admin/src/Ecommerce.Api/Ecommerce.Api.csproj -c Release -o /app/out /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
RUN addgroup --system appgroup && adduser --system --ingroup appgroup appuser
COPY --from=build /app/out .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
USER appuser
ENTRYPOINT ["dotnet", "Ecommerce.Api.dll"]
