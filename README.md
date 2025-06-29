# Савоник Мария БПИ238
# 📊 Контрольная работа №2 (КПО) — Анализ текстов на C# (.NET 7)
Требуется запустить ZIP архив
Описание
Веб-приложение должно представлять функциональность «текстового сканера», который принимает на вход отчёт студента (в формате .txt) и выполняет его анализ, включая:

Подсчёт статистики: количество абзацев; слов; символов.
Сравнение файлов на схожесть (для выявления 100% плагиата среди ранее присланных отчетов).
Визуализация данных (облака слов)
Компоненты
API Gateway

Порт: 5003
Отвечает за маршрутизацию запросов к бэкенд-сервисам.
Конфигурация: ocelot.json
File Storing Service

Порт: 5001
Загрузка и хранение файлов в PostgreSQL.
Эндпоинты:
POST /files — Body: form-data, поле file
GET  /files/{fileId} — скачивание
Swagger UI: http://localhost:5001/swagger
File Analysis Service

Порт: 5002
Анализ текстового содержимого, хранение результатов и генерация word-cloud.
Эндпоинты:
POST /analysis/{fileId} — запустить (или вернуть готовый) анализ
GET  /analysis/{fileId} — получить результат анализа
GET  /analysis/{fileId}/cloud — получить PNG-облако слов
Swagger UI: http://localhost:5002/swagger
PostgreSQL

Два отдельных контейнера (для файлов и для анализа).
Документация
Postman Collection: Ссылка на postman
Swagger:
FileStoring: http://localhost:5001/swagger
FileAnalysis: http://localhost:5002/swagger
Быстрый старт
Клонировать репозиторий и перейти в папку проекта: git clone <repo-url> cd <repo-folder>
Запустить всё через Docker Compose: docker-compose up --build
Убедиться, что сервисы поднялись: http://localhost:5003/health → { "status": "Gateway is up" }
Использование (Postman)
Все HTTP-запросы отправляются на API Gateway (localhost:5003).
Загрузка файла

Method: POST
URL: http://localhost:5003/files
Body:
Тип: form-data
Ключ: file (File)
Значение: любой PDF/TXT/…
Пример можете увидеть в Postman коллекции
Method: GET

URL: http://localhost:5003/files/{{fileId}}
Params: fileId — UUID, полученный при загрузке.
Запуск анализа

Method: POST
URL: http://localhost:5003/analysis/{{fileId}}
Params: fileId — тот же UUID.
Получение результата анализа

Method: GET
URL: http://localhost:5003/analysis/{{fileId}}
Response:
{ "id": "...", "fileId": "...", "fileHash": "...", "paragraphs": 5, "words": 120, "characters": 650, "similarityScore": 0.0, "createdAt": "2025-05-28T..." }

Генерация word–cloud

Method: GET
URL: http://localhost:5003/analysis/{{fileId}}/cloud
Headers:
Accept: image/png
Обработка ошибок
404 Not Found — файл или анализ не найдены.
400 Bad Request — например, недостаточно текста для облака слов.
502 Bad Gateway — внешний вызов (QuickChart или FileStoring) завершился ошибкой.
500 Internal Server Error — непойманное исключение.

👩‍💻 Автор
Савоник Мария БПИ238
Контрольная работа по курсу
«Конструирование программного обеспечения» (НИУ ВШЭ)
Разработка: .NET 7 + Docker + REST API

