\# 🏋️‍♂️ IronTrack API



Backendowy system do zarządzania treningami w trójboju siłowym (Powerlifting - Squat, Bench Press, Deadlift). Aplikacja pozwala zawodnikom i trenerom na precyzyjne planowanie jednostek treningowych, śledzenie postępów oraz estymację wyników.



\## 🚀 Technologie (Stack)

\- \*\*.NET 10\*\* / \*\*C# 14\*\*

\- ASP.NET Core Web API

\- Swagger / OpenAPI (Dokumentacja API)

\- \*W planach:\* Entity Framework Core, SQL (PostgreSQL/SQL Server), MediatR, xUnit.



\## ⚙️ Obecne funkcjonalności

\* \*\*Zarządzanie oknami treningowymi (Exercise Slots):\*\* Pełna obsługa operacji CRUD dla planowanych bojów.

\* \*\*Ścisła walidacja reguł biznesowych:\*\* Obsługa wyłącznie oficjalnych bojów trójbojowych (Squat, Bench Press, Deadlift) oraz zapobieganie duplikowaniu tego samego ćwiczenia przez tego samego zawodnika w obrębie jednego dnia.

\* \*\*Restrykcje czasowe:\*\* Walidacja planowania jednostek treningowych z wyprzedzeniem od 1 dnia do maksymalnie 14 dni w przód.

\* \*\*Podstawy REST API:\*\* Implementacja bazowych kodów statusu HTTP (200, 201, 204, 400, 404) oraz wstępna separacja logiki (Controller -> Service) oparta na Dependency Injection. Projekt jest w fazie aktywnej ewolucji w kierunku docelowej, zaawansowanej architektury.



\---



\## 🏗️ Podejście Architektoniczne (Showcase Project)



> \\\*\\\*⚠️ Ewolucja Architektury\\\*\\\*

> IronTrack API to projekt rozwijany iteracyjnie. Obecnie znajduje się w fazie wczesnego MVP, opierając się na klasycznych założeniach API (kontrolery, serwisy, DI). Jednakże ze względu na docelową złożoność domeny trójboju siłowego (np. estymacje 1RM, wyliczanie wskaźników DOTS, zaawansowana periodyzacja), aplikacja celowo ewoluuje w stronę rozwiązań klasy Enterprise. W kolejnych etapach projekt będzie wdrażał m.in. \\\*\\\*Clean Architecture, CQRS oraz Domain-Driven Design (DDD)\\\*\\\*, demonstrując moje kompetencje w projektowaniu systemów gotowych na rosnącą złożoność biznesową.



\---



\## 🛠️ Jak uruchomić projekt lokalnie



1\. Sklonuj repozytorium:

&#x20;  ```bash

&#x20;  git clone \[https://github.com/pawelkuczek/IronTrack.Api.git](https://github.com/pawelkuczek/IronTrack.Api.git)

