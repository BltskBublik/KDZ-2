# Савоник Мария БПИ238
# 📊 Контрольная работа №2 (КПО) — Анализ текстов на C# (.NET 7)

## 📌 Описание

Это микросервисное приложение выполняет автоматический анализ студенческих отчетов в `.txt` формате. Реализовано на **C#** с использованием **.NET 7** и **Docker**.

### 🔧 Возможности:
- Загрузка `.txt` файла
- Подсчет **абзацев**, **слов**, **символов**
- Проверка на **100% совпадение** с ранее загруженными файлами
- Swagger-документация для всех сервисов

---

## 🧱 Архитектура микросервисов

| Сервис               | Назначение                             |
|----------------------|----------------------------------------|
| 🧭 `ApiGateway`         | Принимает HTTP-запросы и маршрутизирует их |
| 📁 `FileStoringService` | Принимает и хранит `.txt` файлы       |
| 🔍 `FileAnalysisService`| Анализирует файлы                     |

Все сервисы разворачиваются через `docker-compose`.

---

## 🚀 Запуск проекта

> ✅ Требуется установленный [Docker](https://www.docker.com/products/docker-desktop)

### 1. Клонируй или распакуй проект

```bash
git clone https://github.com/your-username/kpo-kr2.git
cd kpo-kr2

```

2. Запусти контейнеры
docker-compose up --build
🌐 Доступ к сервисам
Сервис	Swagger UI URL
Gateway	http://localhost:5000/swagger
Storage	http://localhost:5001/swagger
Analysis	http://localhost:5002/swagger

📬 Примеры API-запросов
🔸 Загрузка файла
```bash
curl -F "file=@myreport.txt" http://localhost:5000/gateway/upload
```
Ответ:
json

{ "file_id": "abc123-..." }
🔸 Анализ файла
```bash
curl http://localhost:5000/gateway/analyze/abc123
```
Ответ:
json

{
  "paragraphs": 4,
  "words": 210,
  "characters": 1456
}
🧪 Тестирование
Swagger доступен для всех сервисов

Возможность тестирования через Postman или curl

📁 Структура проекта
Копировать
Редактировать
kpo-kr2/
├── ApiGateway/
├── FileStoringService/
├── FileAnalysisService/
├── docker-compose.yml
├── README.md
└── .gitignore
🧠 Возможные улучшения
Генерация облака слов (через QuickChart)

Проверка на частичный плагиат (по совпадению фраз)

Хранение истории анализов

👩‍💻 Автор
Контрольная работа по курсу
«Конструирование программного обеспечения» (НИУ ВШЭ)
Разработка: .NET 7 + Docker + REST API

yaml

Что внутри:
Полный рабочий проект на C# (.NET 7)

docker-compose.yml для запуска всех микросервисов

Готовый README.md с:

описанием

архитектурой

инструкцией запуска

примерами запросов

ссылками на Swagger

