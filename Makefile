SOLUTION=CSharpTenApps.sln

restore:
	dotnet restore $(SOLUTION)

build:
	dotnet build $(SOLUTION)

test:
	dotnet test $(SOLUTION)

up:
	docker compose up --build

down:
	docker compose down

logs:
	docker compose logs -f --tail=200

format:
	dotnet format $(SOLUTION) --verify-no-changes

migrate:
	@echo "Run migrations by app, e.g: dotnet ef database update --project apps/app-01-task-manager/src/TaskManager.Infrastructure --startup-project apps/app-01-task-manager/src/TaskManager.Api"

seed:
	@echo "Seed runs automatically on API startup"

app:
	docker compose up --build app-$(APP)-api app-$(APP)-web reverse-proxy postgres redis

rebuild:
	docker compose build --no-cache
