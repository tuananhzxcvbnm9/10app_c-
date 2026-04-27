# Production Readiness

## Migration Strategy
- Khuyến nghị chạy migration thông qua CI/CD job riêng trước khi rollout API.
- Tắt `Database__ApplyMigrationsOnStartup` ở production.

## Backup Strategy
- Dùng `pg_dump` full backup hằng ngày và WAL/incremental theo giờ.
- Lưu backup ra object storage có versioning và lifecycle policy.
- Thực hiện restore drill hàng tuần trên môi trường staging.

## Security
- Secret qua environment/Kubernetes Secret, không commit secret.
- Reverse proxy bật security headers và giới hạn rate.
- Bật TLS termination ở ingress/load balancer.

## Observability
- Serilog JSON logs + correlation ID.
- Prometheus metrics `/metrics`.
- Grafana dashboard theo dõi request rate, p95 latency.
