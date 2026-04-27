FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore apps/app-09-blog-cms/src/Blog.Api/Blog.Api.csproj
RUN dotnet publish apps/app-09-blog-cms/src/Blog.Api/Blog.Api.csproj -c Release -o /app/out /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
RUN addgroup --system appgroup && adduser --system --ingroup appgroup appuser
COPY --from=build /app/out .
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080
USER appuser
ENTRYPOINT ["dotnet", "Blog.Api.dll"]
