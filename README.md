# AlgorithmicLanguagesPracticProject

## Швидкий старт

```bash
dotnet restore
dotnet build AlgorithmicLanguagesPracticProject.slnx
dotnet run --project AlgorithmicLanguagesPracticProject/AlgorithmicLanguagesPracticProject.csproj
```

Застосунок використовує SQLite (файл `app.db`) та EF Core.

## Міграції EF Core

Створення міграції:

```bash
dotnet ef migrations add InitialCreate \
  --project AlgorithmicLanguagesPracticProject/AlgorithmicLanguagesPracticProject.csproj \
  --startup-project AlgorithmicLanguagesPracticProject/AlgorithmicLanguagesPracticProject.csproj
```

Застосування міграцій:

```bash
dotnet ef database update \
  --project AlgorithmicLanguagesPracticProject/AlgorithmicLanguagesPracticProject.csproj \
  --startup-project AlgorithmicLanguagesPracticProject/AlgorithmicLanguagesPracticProject.csproj
```

## Тестові облікові записи

- Адміністратор:
  - Email: `admin@local`
  - Password: `admin`

Можна також створити звичайного користувача через сторінку реєстрації.

## Основні сценарії перевірки

1. **Каталог**: відкрити список медіа та перейти на сторінку деталей.
2. **Коментарі**: увійти як користувач і додати коментар до медіа.
3. **Адмінка**: увійти як адмін і перевірити:
   - CRUD медіа (`Create/Edit/Delete`)
   - перегляд користувачів
   - керування коментарями
4. **Авторизація**:
   - `Login/Register` доступні для неавторизованих
   - `Profile` доступний лише після входу
   - `Admin/*` доступний лише ролі `Admin`

## Архітектура

- `Controllers` — прийом HTTP-запитів і повернення View.
- `Services` — бізнес-логіка (`IMediaService`, `IUserService`).
- `Data/AppDbContext` — EF Core контекст і конфігурація зв’язків.
- `Models/ViewModels` — моделі для відображення (без передачі Entity у View).
- `Views` — UI-шар.

## Примітка про порт

Якщо `dotnet run` повідомляє про зайнятий порт, зупиніть попередній процес у терміналі (`Ctrl+C`) або змініть URL запуску.
