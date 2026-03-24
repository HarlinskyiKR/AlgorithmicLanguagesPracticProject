# Комплексний проєкт з

# Навчальної практики з Основ

# програмування та

# алгоритмічних мов

## 1. Мета роботи

Метою навчальної практики є набуття практичних навичок розробки веб-
застосунків із використанням архітектурного шаблону MVC Model–View–
Controller) у середовищі ASP .NET Core, а також:
проєктування реляційних баз даних;
реалізація взаємозвʼязків між сутностями;
використання Entity Framework Core;
організація багаторівневої архітектури (Controller–Service–Data);
реалізація автентифікації користувачів;
створення адміністративного функціоналу.

## 2. Загальний опис завдання

Необхідно розробити веб-застосунок із визначеної предметної області.
У якості прикладу може бути використана система для роботи з медіа-
контентом (фільми, серіали тощо), яка забезпечує:
перегляд списку обʼєктів;
перегляд детальної інформації;
додавання повʼязаних даних (наприклад, коментарів);
адміністративне керування;
автентифікацію користувачів.

Важливо: студент може обрати будь-яку іншу предметну область
(наприклад, книги, товари, події, курси тощо), за умови збереження всіх
функціональних та архітектурних вимог, визначених у даному завданні.

## 3. Вимоги до бази даних

База даних повинна бути реалізована з використанням Entity Framework Core
та містити щонайменше три сутності.
Нижче наведено приклад для предметної області “медіа”:

### 3. 1. Media

```
Id (первинний ключ)
Title (назва)
Description (опис)
ReleaseYear (рік випуску)
Rating (рейтинг)
StudioId (зовнішній ключ)
```

### 3. 2. Comment

```
Id (первинний ключ)
Content (текст)
CreatedAt (дата створення)
MediaId (зовнішній ключ)
```

### 3. 3. Studio

Id (первинний ключ)
Name (назва)
Country (країна)
Примітка: у разі вибору іншої тематики назви сутностей та їх атрибути
можуть бути змінені (наприклад, Product, Category, Order), однак структура
(наявність кількох повʼязаних таблиць) повинна зберігатися.

## 4. Вимоги до звʼязків між сутностями

У проєкті обовʼязково мають бути реалізовані такі типи звʼязків:
Один до багатьох 1 N)
(наприклад: Studio → Media)
Один до багатьох 1 N)
(наприклад: Media → Comment)
Один до одного 1 1 (додатково, за бажанням)
Примітка: при зміні предметної області типи звʼязків повинні залишатися
аналогічними (наприклад, Category → Product, Product → Review) або мати
аналогічну складність.

## 5. Функціональні вимоги до веб-застосунку

### 5. 1. Сторінка списку обʼєктів (Index)

```
відображення всіх записів основної таблиці;
відображення короткої інформації;
можливість переходу до детальної сторінки.
```

### 5. 2. Сторінка детальної інформації (Details)

```
відображення повної інформації про обʼєкт;
відображення повʼязаних даних;
можливість додавання повʼязаних записів (наприклад, коментарів) для
авторизованих користувачів.
```

### 5. 3. Додаткові сторінки

```
сторінка для відображення допоміжних сутностей (наприклад, студій /
категорій / авторів) за потреби.
```

### 5. 4. Адміністративна панель

Повинна забезпечувати:

```
CRUDоперації для основних сутностей;
керування повʼязаними даними.
```

### 5. 5. Автентифікація

```
реалізація локального входу та реєстрації;
доступ до частини функціоналу лише для авторизованих користувачів.
```

## 6. Вимоги до архітектури програмного

## забезпечення

Проєкт повинен бути реалізований відповідно до принципів багаторівневої
архітектури.

### 6. 1. Контролери (Controllers)

обробка HTTPзапитів;
виклик сервісів;
повернення представлень.
Заборонено:
розміщення бізнес-логіки;
пряму роботу з базою даних.

### 6. 2. Сервіси (Services)

```
реалізація бізнес-логіки;
взаємодія з DbContext;
використання інтерфейсів.
```

### 6. 3. Моделі представлення (ViewModels / DTO)

```
використання окремих моделей для відображення;
заборона передачі Entity у View.
```

### 6. 4. Робота з базою даних

```
використання Entity Framework Core;
налаштування звʼязків;
використання міграцій або Scaffolding Reverse Engineering).
```

### 6. 5. Dependency Injection

```
усі залежності через DI;
заборона створення обʼєктів через new у контролерах.
```

## 7. Вимоги до інтерфейсу користувача

```
базова стилізація (наприклад, Bootstrap);
зрозуміла навігація;
читабельність.
дозволяється генерувати через системи штучного інтелекту.
```

## 8. Додаткові завдання (за бажанням)

```
пагінація;
пошук;
сортування;
REST API;
Swagger;
кешування;
тощо.
```

## 9. Критерії оцінювання

```
коректність роботи;
відповідність архітектурі;
якість роботи з БД;
```

```
реалізація автентифікації;
наявність адмін-панелі;
якість коду.
```

## 10. Висновок

У результаті виконання роботи студент повинен продемонструвати:
розуміння MVC;
навички роботи з ASP .NET Core;
вміння проєктувати структуру застосунку;
роботу з базами даних;
базові принципи побудови масштабованих систем.

## 11. Рекомендований пайплайн розробки

## функціоналу

Нижче наведено типовий порядок реалізації функціоналу у веб-застосунку на
ASP .NET Core MVC. Даний підхід відображає правильний розподіл
відповідальностей між шарами застосунку.

### 11. 1. Загальна схема взаємодії

Реалізація будь-якого функціоналу повинна відповідати наступному
ланцюжку:
Controller **→** Service **→** Repository (за бажанням) **→** Database
Database **→** Repository (за бажанням) **→** Service **→** Controller **→** View

## 11. 2. Покрокова реалізація функціоналу

Розглянемо на прикладі: отримання списку обʼєктів (наприклад, Media).

### Крок 1. Створення моделі (Entity)

Описується структура таблиці бази даних:

```
public class Media
{
public int Id { get; set; }
public string Title { get; set; }
}
```

### Крок 2. Створення репозиторію (Repository) - за бажанням,

### але не є обовʼязково необхідним

У проєкті допускається використання як прямої роботи з DbContext у
сервісах, так і застосування патерну Repository. При цьому бізнес-логіка
обовʼязково повинна знаходитися у сервісному шарі, незалежно від обраного
підходу.
DbContext – це вже “вбудований репозиторій” EF Core, тому можна працювати
напряму у сервісах для простих CRUDоперацій. Repository додає шар
абстракції, зручний для тестування та складних запитів, але не обовʼязковий.
Головне – бізнес-логіка завжди повинна бути у сервісному шарі, а контролер
лише викликає сервіс і повертає результат.

### Інтерфейс:

```
public interface IMediaRepository
{
List<Media> GetAll();
MediaGetById (int id);
}
```

### Реалізація:

```
public class MediaRepository : IMediaRepository
{
private readonly AppDbContext _context;
public MediaRepository(AppDbContext context)
```

#### {

```
_context = context;
}
public List<Media> GetAll()
{
return _context.Media.ToList();
}
public MediaGetById(int id)
{
return _context.Media.FirstOrDefault(m => m.Id == i
d);
}
}
```

### Крок 3. Створення сервісу (Service)

### Інтерфейс:

```
public interface IMediaService
{
List<MediaViewModel> GetAll();
MediaDetailsViewModel GetById(int id);
}
```

### Реалізація:

```
public class MediaService : IMediaService
{
private readonly IMediaRepository _repository;
public MediaService(IMediaRepository repository)
{
_repository = repository;
```

#### }

```
public List<MediaViewModel> GetAll()
{
return _repository.GetAll()
.Select(m => new MediaViewModel
{
Id = m.Id,
Title = m.Title
})
.ToList();
}
}
```

### Крок 4. Створення ViewModel

ViewModel використовується для передачі даних у View

```
public class MediaViewModel
{
public int Id { get; set; }
public string Title { get; set; }
}
```

### Крок 5. Створення контролера (Controller)

```
public class MediaController : Controller
{
private readonly IMediaService _service;
public MediaController(IMediaService service)
{
_service = service;
}
```

```
public IActionResult Index()
{
var mediaList = _service.GetAll();
return View(mediaList);
}
}
```

### Крок 6. Створення представлення (View)

```
@model List<MediaViewModel>
@foreach (var item in Model)
{
<div>
<h3>@item.Title</h3>
</div>
}
```

## 11. 3. Приклад для створення (Create)

Пайплайн для створення запису:
View **→** Controller **→** Service **→** Repository **→** Database

### Контролер:

```
[HttpPost]
public IActionResult Create(CreateMediaViewModel model)
{
_service.Create(model);
return RedirectToAction("Index");
}
```

### Сервіс:

```
public void Create(CreateMediaViewModel model)
{
var media = new Media
{
Title = model.Title
};
_repository.Add(media); // чи з використанням dbContext
}
```

### Репозиторій (не обовʼязково):

```
public void Add(Media media)
{
_context.Media.Add(media);
_context.SaveChanges();
}
```

## 11. 4. Основні правила

### Controller

```
тільки приймає запит і повертає відповідь
не працює напряму з DbContext
не містить бізнес-логіки
```

### Service

```
вся логіка тут
працює через Repository
робить мапінг у ViewModel
```

### Repository (за бажанням)

```
тільки робота з базою даних
без бізнес-логіки
```

### ViewModel

```
тільки дані для UI
не містить логіки
не є Entity
```

### View

```
тільки відображення
мінімум логіки
```

## 11. 5. Типова структура проєкту

```
/Controllers
MediaController.cs
/Services
Interfaces/
MediaService.cs
/Repositories
Interfaces/
MediaRepository.cs
/Models
Entities/
/ViewModels
MediaViewModel.cs
/Data
AppDbContext.cs
```

## 11. 6. Типові помилки, яких слід уникати

```
використання DbContext у Controller;
відсутність Service шару;
передача Entity у View;
змішування логіки та відображення;
відсутність інтерфейсів;
дублювання логіки у різних місцях.
```

## Локальна авторизація та аутентифікація

### 1. База даних

Таблиці:
Users
Id PK
Username (уникальний)
Email (уникальний)
PasswordHash (зберігаємо хеш, а не пароль)
Role Admin / User / Guest)
Roles(опціонально, якщо хочемо окрему таблицю ролей)
Id PK
Name
Приклад Entity:

```
public class User
{
public int Id { get; set; }
public string Username { get; set; }
public string Email { get; set; }
```

```
public string PasswordHash { get; set; }
public string Role { get; set; } // "Admin", "User"
}
```

### 2. Сервіси (Service Layer)

UserService – головна логіка для роботи з користувачами.
Методи:
Register(UserRegisterViewModel model) – реєстрація, хешування пароля.
Login(UserLoginViewModel model) – перевірка пароля, створення cookie/сесії.
Logout() – вихід користувача.
GetUserById(int id) – отримання користувача.
IsUserAdmin(int id)^ –^ перевірка^ ролі.
Важливо: бізнес-логіка завжди тут, контролер лише викликає сервіс.

### 3. Контролери (Controller Layer)

AccountController:
Register() → GET/POST
Login() → GET/POST
Logout() → POST
Profile() → GET (тільки авторизовані користувачі)
Приклад атрибутів:

```
[Authorize]// для захищених сторінок
[AllowAnonymous]// для Login/Register
```

### 4. ViewModels

```
 UserRegisterViewModel – Username, Email, Password, ConfirmPassword
 UserLoginViewModel – Email або Username, Password
```

```
 UserProfileViewModel – Username, Email, Role
Використовуємо ViewModel, щоб не передавати Entity напряму у View.
```

### 5. Views

```
 Register.cshtml – форма для реєстрації
 Login.cshtml – форма для входу
 Profile.cshtml – сторінка користувача (імʼя, email, роль)
 _Layout.cshtml – виводимо кнопки Login / Logout / Profile залежно від
авторизації
```

### 6. Репозиторій (опціонально)

```
IUserRepository^ –^ CRUD^ з^ Users
Можна використати Generic Repository для базових операцій
Або працювати напряму з DbContext у сервісі
```

### 7. Хешування паролів

```
Обовʼязково не зберігати паролі у відкритому вигляді.
Можна використовувати:
using System.Security.Cryptography;
string hash = Convert.ToBase64String(
SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(password))
);
```

```
У продакшені рекомендують ASP.NET Core Identity або PBKDF 2 /Bcrypt.
```

### 8. Захист сторінок

```
[Authorize] – дозволяє лише авторизованим користувачам
[Authorize(Roles = "Admin")] – доступ тільки для адміністраторів
[AllowAnonymous] – дозволяє всім
```

### 9. Типова архітектура проєкту

```
/Controllers
AccountController.cs
/Services
Interfaces/
IUserService.cs
UserService.cs
/Repositories
Interfaces/
IUserRepository.cs
UserRepository.cs (опціонально)
/Models
Entities/
User.cs
/ViewModels
UserRegisterViewModel.cs
UserLoginViewModel.cs
UserProfileViewModel.cs
/Data
AppDbContext.cs
/Views/Account
Register.cshtml
Login.cshtml
Profile.cshtml
```

### 10. Пайплайн роботи

```
User заповнює форму → контролер отримує ViewModel
```

```
Controller викликає UserService → логіка реєстрації або логіну
Service звертається до Repository/DbContext → перевірка користувача
або додавання у БД
Service повертає результат → контролер редіректить на сторінку або
показує помилку
View відображає результат
```

## Адмін-панель у ASP .NET Core MVC – шпаргалка

### 1. Таблиці та ролі

```
У таблиці Users обовʼязково має бути поле Role, наприклад: "Admin" /
"User".
Опціонально: окрема таблиця Roles, якщо хочете нормалізувати.
В адмін-панель має доступ тільки користувач з роллю Admin.
```

### 2. Контролер для адмінки

AdminController:

```
[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
private readonly IUserService _userService;
private readonly IMediaService _mediaService; // приклад
для контенту
public AdminController(IUserService userService, IMediaSe
rvice mediaService)
{
_userService = userService;
_mediaService = mediaService;
}
public IActionResult Dashboard()
```

#### {

```
return View();
}
public IActionResult Users()
{
var users = _userService.GetAllUsers();
return View(users);
}
public IActionResult Media()
{
var media = _mediaService.GetAllMedia();
return View(media);
}
}
[Authorize(Roles = "Admin")] → тільки адміністратори можуть заходити
Сервіси роблять всю роботу з даними, контролер лише передає у View.
```

### 3. View для адмінки

```
Dashboard.cshtml – загальна панель (статистика, лінки на розділи)
Users.cshtml – список користувачів, можливість редагувати або видаляти
Media.cshtml^ –^ список^ контенту,^ CRUDоперації
Можна робити прості таблиці з кнопками Edit/Delete і формами Create.
```

### 4. CRUD для адмінки

```
Create – нові користувачі, новий контент
Read – перегляд списку користувачів, медіа, коментарів
Update – редагування ролей, даних контенту
Delete – видалення користувачів або медіа
```

```
Всі операції проходять через сервіси, контролер лише викликає методи
сервісу.
```

### 5. Навігація

```
У _Layout.cshtml додаєте меню:
@if(User.IsInRole("Admin"))
{
<a href="/Admin/Dashboard">Адмін-панель</a>
}
```

```
Звичайні користувачі не бачать цього меню.
```

### 6. Пайплайн роботи адмінки

```
User заходить на /Admin/Dashboard → авторизація перевіряє роль
Контролер викликає сервіс → отримує дані (Users, Media, Comment...)
Service звертається до Repository/DbContext → повертає дані
Controller передає дані у View → користувач бачить таблиці і кнопки для
CRUD
При натисканні кнопки Create/Edit/Delete → контролер викликає метод
сервісу → оновлює БД → редірект або Ajax-оновлення
```

### 7. Основні поради

```
Не робіть всю логіку у View або контролері.
Використовуйте ViewModel, щоб не передавати Entity напряму.
Завжди перевіряйте роль користувача через [Authorize(Roles = "Admin")] або
у сервісі.
Можна додати фільтри або AJAX, щоб полегшити роботу з таблицями.
```
