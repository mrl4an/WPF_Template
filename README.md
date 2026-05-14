# 🛠️ Universal WPF Application Template / Универсальный шаблон WPF приложения

[Русский](#русский) | [English](#english)

---

## Русский

### 📝 Описание проекта
Универсальный готовый шаблон приложения на WPF (Windows Presentation Foundation), созданный исключительно на **чистом .NET/C# без использования сторонних фреймворков и библиотек**.

Он включает в себя современный адаптивный дизайн и базовый функционал, необходимый для 99% десктопных приложений. Проект спроектирован на базе чистой сквозной (End-to-End) архитектуры, где паттерн MVVM и внедрение зависимостей реализованы исключительно стандартными средствами платформы.

### ✨ Основные возможности (Чистый WPF)
* **Zero Dependencies:** Полное отсутствие сторонних NuGet-пакетов (вроде CommunityToolkit, Prism или ReactiveUI). Только чистый WPF и C#.
* **Резиновый дизайн (Responsive UI):** Интерфейс динамически адаптируется под любые разрешения экрана с помощью стандартных контейнеров разметки.
* **Чистая локализация:** Динамическая смена языков интерфейса "на лету" через стандартные словари ресурсов (`ResourceDictionary`).
* **Смена тем оформления:** Поддержка Темной/Светлой темы, реализованная через механизмы `DynamicResource` без внешних UI-пакетов.
* **Собственный MVVM и DI:** Самостоятельная лаконичная реализация интерфейсов `INotifyPropertyChanged`, `ICommand` (RelayCommand) и легкий встроенный паттерн для внедрения зависимостей.

### 📐 Принципы разработки шаблона
* **Использование AI (ИИ):** Допускается генерация кода нейросетями для экономии времени при написании конкретных изолированных функций или базовых XAML-стилей.
* **Запрет на AI-архитектуру:** Категорически не допускается использование ИИ для проектирования архитектуры, слепого копипаста «под ключ» или внедрения внешних зависимостей.
* **Абсолютная универсальность:** Шаблон спроектирован так, чтобы его можно было брать и использовать «как есть». Развитие проекта строится на *добавлении* новых функций, а не на *вырезании* старого ненужного или слишком специфичного кода. Проект не оставляет за собой «мусорных» следов.

### 🔮 План развития (Roadmap)
Шаблон активно развивается. Новые универсальные функции будут добавляться последовательно с использованием только базовых возможностей .NET:
* Планируется планомерное расширение и дополнение базовых функций.
* Добавление механизмов оркестрации и управления нагрузкой.
* Реализация модулей авторизации и интеграции с внешними API.
* Легковесное кастомное логирование и перехват критических ошибок.
* Дополнение схемы постоянного внедрения и обновлений (CI/CD / Auto-updates).

### 🏗️ Сквозная (End-to-End) Архитектура
Проект использует строгое разделение на слои для упрощения поддержки и тестирования:
1. **Слой представления (UI):** XAML-разметка (Views), чистые стили, триггеры и адаптивные контейнеры.
2. **Логика представления (ViewModels):** Кастомные ViewModels, обрабатывающие действия через собственную реализацию `ICommand`.
3. **Бизнес-логика (Domain):** Чистые C#-сервисы приложения и основные правила обработки данных.
4. **Доступ к данным (Infrastructure):** Взаимодействие с файловой системой, родной `HttpClient` для API и конфигурация.

### ⚙️ Требования и быстрый запуск
* **Платформа:** .NET 8.0
* **Среда разработки:** Visual Studio 2022

1. Клонируйте репозиторий: `https://github.com/mrl4an/WPF_Template.git`
2. Откройте файл решения (`.sln`).

### 🤝 Пул-реквесты (Pull Requests)
Вы можете свободно использовать данный шаблон в своих личных и коммерческих проектах. Если вы хотите внести свой вклад в развитие самого шаблона, вы можете создавать пул-реквесты (PR). Главное условие — строгое следование ключевым принципам, архитектуре и правилу отсутствия внешних зависимостей.

### 💬 Послесловие
Данный проект разрабатывается преимущественно для моего личного использования, а также для наглядной презентации моих архитектурных навыков, возможностей и предлагаемых технологий. Шаблон служит демонстрацией моей квалификации при выполнении проектов на заказ или для потенциального найма.

---

## English

### 📝 Project Overview
This is a universal, production-ready WPF (Windows Presentation Foundation) application template built entirely on **pure .NET/C# without any third-party frameworks or libraries**. 

It includes a modern, responsive layout and baseline features required for 99% of desktop applications. The project is structured using a clean, scalable End-to-End (E2E) architecture, leveraging only native WPF mechanisms for data binding, commands, and dependency injection.

### ✨ Key Features (Vanilla WPF)
* **Zero Dependencies:** No external NuGet packages (like MVVM Light, Prism, or CommunityToolkit). Pure vanilla WPF and C#.
* **Responsive Design:** Dynamic UI layout built with native grids and viewboxes that adapt seamlessly to any screen resolution.
* **Native Localization:** Multi-language support implemented via native `ResourceDictionary` dynamic switching at runtime.
* **Theme Management:** Dynamic Dark/Light mode swapping using vanilla WPF resource dictionaries and dynamic resources.
* **Pure MVVM & DI:** Custom vanilla implementation of `INotifyPropertyChanged`, `ICommand` (RelayCommand), and a lightweight built-in C# dependency injection pattern.

### 📐 Development Principles
* **AI Generation Rules:** Using AI tools is acceptable solely for saving routine coding time, such as writing isolated utility functions or generating basic XAML styles.
* **No AI for Architecture:** AI generation is strictly prohibited for designing the core architecture, full code copy-pasting, or introducing external dependencies.
* **True Universality:** The template is built to be used "as is" out of the box. Development focuses on *adding* new core features rather than *cutting out* dead, over-specific, or outdated code. It leaves no unnecessary footprint behind.

### 🔮 Future Roadmap
The template is under active development. New standard modules will be added sequentially using only native .NET capabilities:
* Continuous expansion and improvement of core baseline features.
* Implementing orchestration and load management systems.
* Adding native authentication/authorization modules and API integration layers.
* Lightweight custom logging and unhandled exception routing.
* Developing a native continuous deployment and auto-update scheme.

### 🏗️ End-to-End (E2E) Architecture
The project follows a strict layered architecture to ensure maintainability and testability:
1. **Presentation Layer (UI):** Pure XAML Views, vanilla Styles, Triggers, and Responsive Layouts.
2. **Presentation Logic Layer:** Custom ViewModels implementing native `INotifyPropertyChanged` and vanilla `ICommand`.
3. **Business Logic Layer (Domain):** Pure C# application services and core business rules.
4. **Data Access Layer (Infrastructure):** Native file I/O, built-in `HttpClient` for APIs, and local configuration management.

### ⚙️ Requirements & Quick Start
* **Framework:** .NET 8.0
* **IDE:** Visual Studio 2022

1. Clone the repository: `https://github.com/mrl4an/WPF_Template.git`
2. Open the solution file (`.sln`).

### 🤝 Pull Requests
You are welcome to use this template in your own projects. If you wish to contribute to the template itself, you can submit Pull Requests. All submissions must strictly align with the project's core principles, architectural guidelines, and the zero-dependency rule.

### 💬 Afterword
This project is primarily developed for my personal use and to present my architectural capabilities and engineering stack. It serves as a live portfolio piece demonstrating my technical solutions for bespoke software development or recruitment purposes.
