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
