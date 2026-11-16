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
EmployeeName       Salary
------------------ ----------
Анна Иванова       65000.00
Пётр Сидоров       72000.00
Мария Кузнецова    55000.00
Ольга Смирнова     61000.00
Дмитрий Орлов      58000.00
Елена Волкова      52000.00
Алексей Лебедев    90000.00

2. Нанятые в 2023 году:
EmployeeName       HireDate
------------------ ----------
Иван Петров        2023-02-10
Елена Волкова      2023-06-01

3. Имя начинается на «А»:
EmployeeName
------------------
Анна Иванова
Алексей Лебедев

4. Отдел 2 (Аналитика):
EmployeeName       DepartmentId
------------------ ------------
Ольга Смирнова     2
Дмитрий Орлов      2
Елена Волкова      2

5. Зарплата от 40000 до 60000:
EmployeeName       Salary
------------------ ----------
Мария Кузнецова    55000.00
Иван Петров        48000.00
Дмитрий Орлов      58000.00
Елена Волкова      52000.00
Сергей Морозов     45000.00
Наталья Соколова   43000.00
