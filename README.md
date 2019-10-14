# Security-Doors
[![Build Status](https://dev.azure.com/30CTB/Security-Doors/_apis/build/status/securedevteam.Security-Doors?branchName=master)](https://dev.azure.com/30CTB/Security-Doors/_build/latest?definitionId=2&branchName=master)

Разработанный комплекс приложений максимально приближен к IT сфере. Основной идей является проход людей или сотрудников определенной организации через дверные контроллеры с использованием карточек различного уровня. Данные приложения имеют огромный ряд возможностей: от создания объектов (Дверь, Карточка, Сотрудник и т.д.) до управления всеми находящимися данными в базе данных. Основной интерфейс приложения реализован в виде веб-приложения, который позволяет зарегистрироваться, авторизироваться и использовать приложение в определенной роли: администратор, модератор, сотрудник или посетитель. Вспомогательные интерфейсы разработанные в виде Console App, для администраторов комплекса, позволяют управлять базой данных и отображать дверные проходы сотрудников.

Что было реализовано:
- Веб-приложение разграниченное по опредленным ролям;
- Консольное приложение для взаимодействия с базой данных для администратор комплекса;
- Консольное приложение для фиксации дверных проходов;
- Возможность создания данных через консольное или веб-приложение;
- Отображение и редактирование данных базы данных через консольное или веб-приложение;
- Контроль дверных проходов через консольное или веб-приложение;
- Отправка Email письма для подтверждение регистрации;

Используемый стек технологий:
- ASP.NET Core 2.1 MVC веб-приложение;
- Console App Core приложения;
- N-Layer архитектура;
- Repository pattern C#;
- Entity Framework Core;
- LINQ (Language-Integrated Query);
- Manual и xUnit тестирование;
- WebAPI + Swagger;
- Microsoft Identity;
- Система контроля версий: Git;
- Система менеджмента заданий: Trello;
- Непрерывная интеграция: CI by Azure DevOps Pipelines;
