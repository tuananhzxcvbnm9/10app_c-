# CSharp 10 Apps Monorepo

Monorepo chứa 10 ứng dụng ASP.NET Core Web API + Blazor WebAssembly theo Clean Architecture.

## Quick start
```bash
cp .env.example .env
docker compose up --build
```

## Truy cập
- App 01: http://localhost/app-01/
- App 02: http://localhost/app-02/
- App 03: http://localhost/app-03/
- App 04: http://localhost/app-04/
- App 05: http://localhost/app-05/
- App 06: http://localhost/app-06/
- App 07: http://localhost/app-07/
- App 08: http://localhost/app-08/
- App 09: http://localhost/app-09/
- App 10: http://localhost/app-10/
- API: http://localhost/api/app-01/ ... http://localhost/api/app-10/
- Grafana: http://localhost:3000
- Prometheus: http://localhost:9090

Demo account:
- `admin@app.local` / `ChangeMe123!`

## Commands
```bash
make restore
make build
make test
make up
make down
make logs
make format
make migrate
make seed
make app APP=01
make rebuild
```


## Frontend UI/UX
- 10 app frontend đã dùng MudBlazor theo layout SaaS thống nhất: sidebar, topbar, dark mode, dashboard cards, chart, data table, form validation, loading/empty/error states, confirm dialog và toast.


## Production Readiness
- API/Web Dockerfile đã dùng multi-stage build và chạy non-root user.
- API hỗ trợ ProblemDetails, correlation ID (`X-Correlation-ID`), rate limiting, Serilog JSON logging, Prometheus metrics.
- CORS cấu hình từ env (`Cors__AllowedOrigins`), không hard-code secret.
- Migration strategy: `Database__ApplyMigrationsOnStartup=false` mặc định cho production; khuyến nghị chạy migration job riêng trước rollout.
- Kubernetes manifests mỗi app có ConfigMap, Secret template, liveness/readiness probes, resource requests/limits, HPA.
- Reverse proxy có security headers và request rate limiting cho API.
- Backup guideline: sử dụng `pg_dump` định kỳ + lưu object storage + kiểm tra restore hàng tuần.
