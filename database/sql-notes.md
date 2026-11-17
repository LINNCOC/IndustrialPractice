# SQL notes

## Task 01 — Создание базы и таблиц

### SQL
```sql
-- Выполнен скрипт init.sql, который включает:
CREATE DATABASE PracticeDB;
GO
USE PracticeDB;
GO
CREATE TABLE Departments (...);
CREATE TABLE Employees (...);
CREATE TABLE Projects (...);
CREATE TABLE EmployeeProjects (...);
```

## Task 02 — INSERT: заполнение данными

### SQL
```sql
-- Заполнение Departments
INSERT INTO Departments (DepartmentName) VALUES
    (N'Разработка'),
    (N'Аналитика'),
    (N'Тестирование'),
    (N'Менеджмент');

-- Заполнение Employees
INSERT INTO Employees (EmployeeName, Salary, HireDate, DepartmentId, ManagerId) VALUES
    (N'Анна Иванова',    65000, '2020-03-15', 1, NULL),
    (N'Пётр Сидоров',    72000, '2019-07-01', 1, NULL),
    (N'Мария Кузнецова', 55000, '2021-11-20', 1, NULL),
    (N'Иван Петров',     48000, '2023-02-10', 1, NULL),
    (N'Ольга Смирнова',  61000, '2020-09-05', 2, NULL),
    (N'Дмитрий Орлов',   58000, '2022-04-18', 2, NULL),
    (N'Елена Волкова',   52000, '2023-06-01', 2, NULL),
    (N'Сергей Морозов',  45000, '2021-12-12', 3, NULL),
    (N'Наталья Соколова',43000, '2024-01-15', 3, NULL),
    (N'Алексей Лебедев', 90000, '2018-05-25', 4, NULL);

-- Заполнение Projects
INSERT INTO Projects (ProjectName, StartDate) VALUES
    (N'CRM System',      '2023-01-10'),
    (N'Mobile App',      '2023-05-01'),
    (N'Data Warehouse',  '2022-11-20'),
    (N'AI Assistant',    '2024-02-01'),
    (N'Legacy Refactor', '2021-06-15');

-- Заполнение EmployeeProjects
INSERT INTO EmployeeProjects (EmployeeId, ProjectId, Hours) VALUES
    (1, 1, 120), (1, 3, 80),
    (2, 1, 150), (2, 4, 60),
    (3, 2, 100), (4, 2, 90),
    (4, 5, 40),  (5, 3, 110),
    (6, 3, 70),  (6, 4, 50),
    (7, 2, 95),  (8, 5, 130),
    (10, 4, 200),(10, 1, 30);
```

## Task 03 — SELECT + WHERE: базовые выборки

### SQL

```sql
USE PracticeDB;
GO

-- 1. Сотрудники с зарплатой > 50000
SELECT EmployeeName, Salary 
FROM Employees 
WHERE Salary > 50000;

-- 2. Сотрудники, нанятые в 2023 году
SELECT EmployeeName, HireDate 
FROM Employees 
WHERE YEAR(HireDate) = 2023;

-- 3. Сотрудники, чьё имя начинается на «А»
SELECT EmployeeName 
FROM Employees 
WHERE EmployeeName LIKE N'А%';

-- 4. Сотрудники из отдела DepartmentId = 2
SELECT EmployeeName, DepartmentId 
FROM Employees 
WHERE DepartmentId = 2;

-- 5. Сотрудники с зарплатой в диапазоне 40000–60000
SELECT EmployeeName, Salary 
FROM Employees 
WHERE Salary BETWEEN 40000 AND 60000;
```

Результат

1. Зарплата > 50000:

* Анна Иванова — 65 000.00
* Пётр Сидоров — 72 000.00
* Мария Кузнецова — 55 000.00
* Ольга Смирнова — 61 000.00
* Дмитрий Орлов — 58 000.00
* Елена Волкова — 52 000.00
* Алексей Лебедев — 90 000.00

3. Нанятые в 2023 году:

* Иван Петров — 2023-02-10
* Елена Волкова — 2023-06-01

3. Имя начинается на «А»:

* Анна Иванова
* Алексей Лебедев

4. Отдел 2 (Аналитика):

* Ольга Смирнова
* Дмитрий Орлов
* Елена Волкова

5. Зарплата от 40000 до 60000:

* Мария Кузнецова — 55 000.00
* Иван Петров — 48 000.00
* Дмитрий Орлов — 58 000.00
* Елена Волкова — 52 000.00
* Сергей Морозов — 45 000.00
* Наталья Соколова — 43 000.00

Вывод
* Освоил базовые фильтры: сравнение (>), функцию YEAR() для извлечения года из даты, шаблон LIKE для поиска по первой букве и оператор BETWEEN для диапазона значений. Все запросы вернули корректные данные.

## Task 04 — ORDER BY + TOP: сортировка и лимит

### SQL

```sql
USE PracticeDB;
GO

-- 1. Топ-3 по зарплате (убывание)
SELECT TOP 3 EmployeeName, Salary 
FROM Employees 
ORDER BY Salary DESC;

-- 2. Топ-5 самых давних сотрудников (возрастание по дате найма)
SELECT TOP 5 EmployeeName, HireDate 
FROM Employees 
ORDER BY HireDate ASC;

-- 3. Сортировка по отделу (возрастание), затем по зарплате (убывание)
SELECT EmployeeName, DepartmentId, Salary 
FROM Employees 
ORDER BY DepartmentId ASC, Salary DESC;
```

Результат
1. Топ-3 по зарплате:

* Алексей Лебедев — 90 000.00
* Пётр Сидоров — 72 000.00
* Анна Иванова — 65 000.00

2. Топ-5 самых давних сотрудников:

* Алексей Лебедев — 2018-05-25
* Пётр Сидоров — 2019-07-01
* Анна Иванова — 2020-03-15
* Ольга Смирнова — 2020-09-05
* Сергей Морозов — 2021-12-12

3. Сортировка по отделу, затем по зарплате:

* Отдел 1: Пётр Сидоров (72 000.00), Анна Иванова (65 000.00), Мария Кузнецова (55 000.00), Иван Петров (48 000.00)
* Отдел 2: Ольга Смирнова (61 000.00), Дмитрий Орлов (58 000.00), Елена Волкова (52 000.00)
* Отдел 3: Сергей Морозов (45 000.00), Наталья Соколова (43 000.00)
* Отдел 4: Алексей Лебедев (90 000.00)

Вывод
* Освоил TOP для ограничения количества строк и ORDER BY для сортировки. Понял, как работает сортировка по нескольким столбцам сразу: сначала данные упорядочиваются по отделу, а внутри каждого отдела — по зарплате (по убыванию).

## Task 05 — Агрегация: COUNT, SUM, AVG, MIN, MAX

### SQL

```sql
USE PracticeDB;
GO

-- 1. Общее количество сотрудников
SELECT COUNT(*) AS TotalEmployees FROM Employees;

-- 2. Сумма всех зарплат
SELECT SUM(Salary) AS TotalSalary FROM Employees;

-- 3. Средняя зарплата (округленная до 2 знаков)
SELECT ROUND(AVG(Salary), 2) AS AverageSalary FROM Employees;

-- 4. Минимальная и максимальная зарплата
SELECT MIN(Salary) AS MinSalary, MAX(Salary) AS MaxSalary FROM Employees;

-- 5. Количество сотрудников с зарплатой > 50000
SELECT COUNT(*) AS RichEmployees FROM Employees WHERE Salary > 50000;
```

Результат

Всего сотрудников:
* 10

Сумма всех зарплат:
* 594 000.00

Средняя зарплата:
* 59 400.00

Минимальная и максимальная зарплата:
* Минимум: 43 000.00
* Максимум: 90 000.00

Сотрудников с зарплатой > 50000:
* 7

Вывод
* Освоил агрегатные функции: COUNT (подсчет строк), SUM (сумма), AVG (среднее), MIN и MAX (минимум и максимум). Также использовал ROUND для округления результата до двух знаков.

## Task 06 — GROUP BY: статистика по отделам

### SQL

```sql
USE PracticeDB;
GO

SELECT 
    DepartmentId, 
    COUNT(*) AS EmployeeCount, 
    ROUND(AVG(Salary), 2) AS AvgSalary, 
    SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentId
ORDER BY AvgSalary DESC;
```

Результат

Отдел 2 (Аналитика):
* Количество сотрудников: 3
* Средняя зарплата: 57 000.00
* Суммарная зарплата: 171 000.00

Отдел 1 (Разработка):
* Количество сотрудников: 4
* Средняя зарплата: 60 000.00
* Суммарная зарплата: 240 000.00

Отдел 3 (Тестирование):
* Количество сотрудников: 2
* Средняя зарплата: 44 000.00
* Суммарная зарплата: 88 000.00

Отдел 4 (Менеджмент):
* Количество сотрудников: 1
* Средняя зарплата: 90 000.00
* Суммарная зарплата: 90 000.00

Вывод
* Освоил GROUP BY для группировки строк по столбцу DepartmentId. Понял, как работают агрегатные функции в сочетании с группировкой, и как сортировать результат по вычисляемому столбцу (AvgSalary DESC).

## Task 07 — GROUP BY + HAVING: фильтрация групп

### SQL

```sql
USE PracticeDB;
GO

-- 1. Отделы, в которых больше 2 сотрудников
SELECT DepartmentId, COUNT(*) AS EmployeeCount
FROM Employees
GROUP BY DepartmentId
HAVING COUNT(*) > 2;

-- 2. Отделы со средней зарплатой > 55000
SELECT DepartmentId, ROUND(AVG(Salary), 2) AS AvgSalary
FROM Employees
GROUP BY DepartmentId
HAVING AVG(Salary) > 55000;

-- 3. Отделы с суммарной зарплатой > 150000
SELECT DepartmentId, SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentId
HAVING SUM(Salary) > 150000;
```

Результат

Отделы, в которых больше 2 сотрудников:
* Отдел 1 (Разработка) — 4 сотрудника
* Отдел 2 (Аналитика) — 3 сотрудника

Отделы со средней зарплатой > 55000:
* Отдел 1 (Разработка) — 60 000.00
* Отдел 2 (Аналитика) — 57 000.00
* Отдел 4 (Менеджмент) — 90 000.00

Отделы с суммарной зарплатой > 150000:
* Отдел 1 (Разработка) — 240 000.00
* Отдел 2 (Аналитика) — 171 000.00

Вывод
* Освоил HAVING. Главное отличие от WHERE: WHERE фильтрует отдельные строки до группировки, а HAVING фильтрует уже сгруппированные данные (например, группы по отделам). В HAVING можно использовать агрегатные функции (COUNT, AVG, SUM).

## Task 08 — INNER JOIN: сотрудники и отделы

### SQL

```sql
USE PracticeDB;
GO

SELECT 
    e.EmployeeName, 
    d.DepartmentName, 
    e.Salary
FROM Employees e
INNER JOIN Departments d ON e.DepartmentId = d.DepartmentId
ORDER BY d.DepartmentName ASC, e.Salary DESC;
```

Результат

Аналитика:
* Ольга Смирнова — 61 000.00
* Дмитрий Орлов — 58 000.00
* Елена Волкова — 52 000.00

Менеджмент:
* Алексей Лебедев — 90 000.00

Разработка:
* Пётр Сидоров — 72 000.00
* Анна Иванова — 65 000.00
* Мария Кузнецова — 55 000.00
* Иван Петров — 48 000.00

Тестирование:
* Сергей Морозов — 45 000.00
* Наталья Соколова — 43 000.00

Вывод
* Освоил INNER JOIN для объединения двух таблиц по общему ключу (DepartmentId). Понял, что INNER JOIN возвращает только те строки, где есть совпадение в обеих таблицах. Также закрепил сортировку по двум столбцам: сначала по названию отдела, затем по зарплате внутри отдела.

## Task 09 — LEFT JOIN: сотрудники без проектов

### SQL

```sql
USE PracticeDB;
GO

SELECT 
    e.EmployeeId, 
    e.EmployeeName
FROM Employees e
LEFT JOIN EmployeeProjects ep ON e.EmployeeId = ep.EmployeeId
WHERE ep.EmployeeId IS NULL;
```

Результат

Сотрудники без проектов:
* 3 — Мария Кузнецова
* 9 — Наталья Соколова

Вывод
* Освоил LEFT JOIN. В отличие от INNER JOIN, он возвращает все строки из левой таблицы (Employees), даже если для них нет совпадений в правой таблице (EmployeeProjects). Сотрудники без проектов получают NULL в полях правой таблицы. Условие WHERE ep.EmployeeId IS NULL позволяет отфильтровать только тех, кто остался без проекта.

## Task 10 — Множественный JOIN: сотрудники, отделы, проекты

### SQL

```sql
USE PracticeDB;
GO

SELECT 
    e.EmployeeName, 
    d.DepartmentName, 
    p.ProjectName, 
    ep.Hours
FROM Employees e
INNER JOIN Departments d ON e.DepartmentId = d.DepartmentId
INNER JOIN EmployeeProjects ep ON e.EmployeeId = ep.EmployeeId
INNER JOIN Projects p ON ep.ProjectId = p.ProjectId
ORDER BY d.DepartmentName ASC, e.EmployeeName ASC, p.ProjectName ASC;
```

Результат

Аналитика:
* Дмитрий Орлов — Data Warehouse (70 ч.)
* Дмитрий Орлов — AI Assistant (50 ч.)
* Елена Волкова — Mobile App (95 ч.)
* Ольга Смирнова — Data Warehouse (110 ч.)

Менеджмент:
* Алексей Лебедев — CRM System (30 ч.)
* Алексей Лебедев — AI Assistant (200 ч.)

Разработка:
* Анна Иванова — CRM System (120 ч.)
* Анна Иванова — Data Warehouse (80 ч.)
* Иван Петров — Legacy Refactor (40 ч.)
* Иван Петров — Mobile App (90 ч.)
* Мария Кузнецова — Mobile App (100 ч.)
* Пётр Сидоров — AI Assistant (60 ч.)
* Пётр Сидоров — CRM System (150 ч.)

Тестирование:
* Сергей Морозов — Legacy Refactor (130 ч.)

Вывод
* Освоил множественный JOIN (соединение 4 таблиц в одном запросе). Понял, как работают цепочки INNER JOIN: каждая следующая таблица присоединяется по внешнему ключу к предыдущей. Это позволяет получить полную картину связей «многие-ко-многим» через промежуточную таблицу EmployeeProjects.

## Task 11 — Self-join: иерархия руководителей

### SQL

```sql
USE PracticeDB;
GO

SELECT 
    e.EmployeeName, 
    m.EmployeeName AS ManagerName
FROM Employees e
LEFT JOIN Employees m ON e.ManagerId = m.EmployeeId;
```

Результат

* Анна Иванова — NULL
* Пётр Сидоров — NULL
* Мария Кузнецова — Пётр Сидоров
* Иван Петров — Анна Иванова
* Ольга Смирнова — NULL
* Дмитрий Орлов — Ольга Смирнова
* Елена Волкова — NULL
* Сергей Морозов — NULL
* Наталья Соколова — Алексей Лебедев
* Алексей Лебедев — NULL

Вывод
* Использовал LEFT JOIN таблицы Employees на саму себя (Self-join), чтобы получить имя руководителя. Для тех, у кого ManagerId равен NULL, руководитель отображается как NULL.

## Task 12 — Подзапросы в WHERE

### SQL
```sql
USE PracticeDB;
GO

-- 1. Сотрудники с зарплатой выше средней
SELECT EmployeeName, Salary
FROM Employees
WHERE Salary > (SELECT AVG(Salary) FROM Employees);

-- 2. Сотрудники с максимальной зарплатой
SELECT EmployeeName, Salary
FROM Employees
WHERE Salary = (SELECT MAX(Salary) FROM Employees);
```

Результат

Выше средней:
* Алексей Лебедев — 90 000.00
* Пётр Сидоров — 72 000.00
* Анна Иванова — 65 000.00
* Ольга Смирнова — 61 000.00

Максимальная зарплата:
* Алексей Лебедев — 90 000.00

Вывод
* Использовал скалярные подзапросы в WHERE. Подзапрос (SELECT AVG(Salary) ...) вычисляется один раз и возвращает одно число, с которым сравнивается зарплата каждого сотрудника.

## Task 13 — Скалярные подзапросы в SELECT

### SQL
```sql
USE PracticeDB;
GO

SELECT 
    e.EmployeeName, 
    e.Salary, 
    e.DepartmentId,
    ROUND(e.Salary - (SELECT AVG(e2.Salary) FROM Employees e2 WHERE e2.DepartmentId = e.DepartmentId), 2) AS DiffFromAvg
FROM Employees e;
```

Результат

* Анна Иванова (Отдел 1) — +5 000.00
* Пётр Сидоров (Отдел 1) — +12 000.00
* Мария Кузнецова (Отдел 1) — -5 000.00
* Иван Петров (Отдел 1) — -12 000.00
* Ольга Смирнова (Отдел 2) — +4 000.00
* Дмитрий Орлов (Отдел 2) — +1 000.00
* Елена Волкова (Отдел 2) — -5 000.00
* Сергей Морозов (Отдел 3) — +1 000.00
* Наталья Соколова (Отдел 3) — -1 000.00
* Алексей Лебедев (Отдел 4) — 0.00

Вывод
* Использовал коррелированный подзапрос в SELECT. Для каждой строки вычисляется средняя зарплата именно для его отдела, и разница округляется до 2 знаков.

## Task 14 — EXISTS / NOT EXISTS

### SQL
```sql
USE PracticeDB;
GO

-- 1. Есть проекты
SELECT e.EmployeeName
FROM Employees e
WHERE EXISTS (SELECT 1 FROM EmployeeProjects ep WHERE ep.EmployeeId = e.EmployeeId);

-- 2. Нет проектов
SELECT e.EmployeeName
FROM Employees e
WHERE NOT EXISTS (SELECT 1 FROM EmployeeProjects ep WHERE ep.EmployeeId = e.EmployeeId);
```

Результат

Есть проекты (8 человек):
* Анна Иванова, Пётр Сидоров, Мария Кузнецова, Иван Петров, Ольга Смирнова, Дмитрий Орлов, Елена Волкова, Сергей Морозов, Алексей Лебедев.

Нет проектов:
* Наталья Соколова

Вывод
* EXISTS возвращает true, если подзапрос возвращает хотя бы одну строку. Это быстрее, чем JOIN с DISTINCT, потому что SQL Server останавливает поиск, как только находит первое совпадение.

## Task 15 — UNION / UNION ALL

### SQL
```sql
USE PracticeDB;
GO

-- 1. UNION (уникальные)
SELECT EmployeeName, Salary FROM Employees WHERE Salary > 60000
UNION
SELECT EmployeeName, Salary FROM Employees WHERE HireDate < '2022-01-01';

-- 2. UNION ALL (с дубликатами)
SELECT EmployeeName, Salary FROM Employees WHERE Salary > 60000
UNION ALL
SELECT EmployeeName, Salary FROM Employees WHERE HireDate < '2022-01-01';
```

Результат

UNION (уникальные): 
* Алексей Лебедев - 90000.00
* Анна Иванова - 65000.00
* Мария Кузнецова - 55000.00
* Ольга Смирнова - 61000.00
* Пётр Сидоров - 72000.00
* Сергей Морозов - 45000.00

UNION ALL (с дубликатами): 
* Анна Иванова - 65000.00
* Пётр Сидоров - 72000.00
* Ольга Смирнова - 61000.00
* Алексей Лебедев - 90000.00
* Анна Иванова - 65000.00
* Пётр Сидоров - 72000.00
* Мария Кузнецова - 55000.00
* Ольга Смирнова - 61000.00
* Сергей Морозов - 45000.00
* Алексей Лебедев - 90000.00

Вывод
* UNION удаляет дубликаты (медленнее), UNION ALL оставляет все строки (быстрее). Разница видна по количеству строк: в UNION ALL их больше.

## Task 16 — UPDATE: изменение данных

### SQL
```sql
USE PracticeDB;
GO

-- 1. Зарплата сотрудников отдела 1 (+10%)
SELECT EmployeeName, Salary FROM Employees WHERE DepartmentId = 1; -- ДО
UPDATE Employees SET Salary = Salary * 1.10 WHERE DepartmentId = 1;
SELECT EmployeeName, Salary FROM Employees WHERE DepartmentId = 1; -- ПОСЛЕ

-- 2. Зарплата нанятых до 2022 года (+5000)
SELECT EmployeeName, Salary, HireDate FROM Employees WHERE HireDate < '2022-01-01'; -- ДО
UPDATE Employees SET Salary = Salary + 5000 WHERE HireDate < '2022-01-01';
SELECT EmployeeName, Salary, HireDate FROM Employees WHERE HireDate < '2022-01-01'; -- ПОСЛЕ

-- 3. Обновление HireDate одного сотрудника
SELECT EmployeeName, HireDate FROM Employees WHERE EmployeeId = 1; -- ДО
UPDATE Employees SET HireDate = '2021-01-01' WHERE EmployeeId = 1;
SELECT EmployeeName, HireDate FROM Employees WHERE EmployeeId = 1; -- ПОСЛЕ
```

Результат

Зарплата сотрудников отдела 1 
ДО
* Анна Иванова - 65000.00
* Пётр Сидоров - 72000.00
* Мария Кузнецова - 55000.00
* Иван Петров	- 48000.00
ПОСЛЕ
* Анна Иванова - 71500.00
* Пётр Сидоров - 79200.00
* Мария Кузнецова	- 60500.00
* Иван Петров	- 52800.00

Зарплата нанятых до 2022 года
ДО
* Анна Иванова	71500.00
* Пётр Сидоров	79200.00
* Мария Кузнецова	60500.00
* Ольга Смирнова	61000.00
* Сергей Морозов	45000.00
* Алексей Лебедев	90000.00
ПОСЛЕ
* Анна Иванова	76500.00
* Пётр Сидоров	84200.00
* Мария Кузнецова	65500.00
* Ольга Смирнова	66000.00
* Сергей Морозов	50000.00
* Алексей Лебедев	95000.00

Обновление HireDate одного сотрудника
ДО
* Анна Иванова	2020-03-15
ПОСЛЕ
* Анна Иванова	2021-01-01

Вывод
* Освоил UPDATE. Понял, что перед изменением данных всегда нужно делать SELECT, чтобы видеть исходное состояние, и после — чтобы убедиться, что обновились только целевые строки.

### Задание 17. DELETE: удаление данных

### SQL
```sql
USE PracticeDB;
GO

-- Проверка до
SELECT COUNT(*) AS CountBefore FROM EmployeeProjects WHERE Hours = 0; 

-- Удалить назначения с Hours = 0 (если есть)
DELETE FROM EmployeeProjects WHERE Hours = 0;

-- Удалить сотрудника 
-- Выберем, например, EmployeeId = 9 
DELETE FROM EmployeeProjects WHERE EmployeeId = 9;
DELETE FROM Employees WHERE EmployeeId = 9;

-- Проверка после
SELECT COUNT(*) AS CountAfter FROM Employees;
```

Результат

Проверка до 
* 0 записей с Hours = 0.

Проверка после
* удален 1 сотрудник (ID=9) и его назначения. В таблице Employees осталось 9 строк.

Вывод
* Освоил DELETE. Главное правило: если у таблицы есть FOREIGN KEY (связь), сначала нужно удалить записи из дочерней таблицы (где ссылка), и только потом из родительской, иначе SQL выдаст ошибку.

### Задание 18. Транзакции: BEGIN TRAN / COMMIT / ROLLBACK

## SQL
```sql
USE PracticeDB;
GO

-- Откат (ROLLBACK)
BEGIN TRANSACTION;
SELECT Salary FROM Employees WHERE EmployeeId = 2;
UPDATE Employees SET Salary = 99999 WHERE EmployeeId = 2;
SELECT Salary FROM Employees WHERE EmployeeId = 2; 
ROLLBACK TRANSACTION;
SELECT Salary FROM Employees WHERE EmployeeId = 2;

-- Фиксация (COMMIT)
BEGIN TRANSACTION;
UPDATE Employees SET Salary = 80000 WHERE EmployeeId = 2;
COMMIT TRANSACTION;
SELECT Salary FROM Employees WHERE EmployeeId = 2;
```

Результат

ДО
* Salary - 84200.00
ВНУТРИ
* Salary - 99999.00
ПОСЛЕ
* Salary - 84200.00

После COMMIT
* Salary - 80000.00

Вывод
* Транзакция — это "контейнер" для изменений. Если что-то пошло не так (ошибка), ROLLBACK отменяет всё, что было внутри транзакции. Если всё хорошо — COMMIT сохраняет изменения навсегда.
