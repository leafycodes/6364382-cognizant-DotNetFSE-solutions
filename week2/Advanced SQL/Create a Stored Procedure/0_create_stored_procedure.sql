CREATE DATABASE IF NOT EXISTS EmployeeManagement;

USE EmployeeManagement;

CREATE TABLE IF NOT EXISTS Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);

CREATE TABLE IF NOT EXISTS Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT,
    Salary DECIMAL(10, 2),
    JoinDate DATE,
    FOREIGN KEY (DepartmentID) REFERENCES Departments (DepartmentID)
);

INSERT IGNORE INTO
    Departments
VALUES (1, 'HR'),
    (2, 'Finance'),
    (3, 'IT'),
    (4, 'Marketing');

INSERT IGNORE INTO
    Employees
VALUES (
        1,
        'John',
        'Doe',
        1,
        5000.00,
        '2020-01-15'
    ),
    (
        2,
        'Jane',
        'Smith',
        2,
        6000.00,
        '2019-03-22'
    ),
    (
        3,
        'Michael',
        'Johnson',
        3,
        7000.00,
        '2018-07-30'
    ),
    (
        4,
        'Emily',
        'Davis',
        4,
        5500.00,
        '2021-11-05'
    );

DROP PROCEDURE IF EXISTS GetEmployeesByDepartment;

DROP PROCEDURE IF EXISTS sp_InsertEmployee;

DELIMITER /
/

CREATE PROCEDURE GetEmployeesByDepartment(IN deptID INT)
BEGIN
    SELECT e.EmployeeID, e.FirstName, e.LastName, d.DepartmentName, e.Salary, e.JoinDate
    FROM Employees e
    JOIN Departments d ON e.DepartmentID = d.DepartmentID
    WHERE e.DepartmentID = deptID;
END
/
/

CREATE PROCEDURE sp_InsertEmployee(
    IN p_FirstName VARCHAR(50),
    IN p_LastName VARCHAR(50),
    IN p_DepartmentID INT,
    IN p_Salary DECIMAL(10,2),
    IN p_JoinDate DATE
)
BEGIN
    DECLARE newEmployeeID INT;
    SELECT IFNULL(MAX(EmployeeID), 0) + 1 INTO newEmployeeID FROM Employees;
    INSERT INTO Employees VALUES (newEmployeeID, p_FirstName, p_LastName, p_DepartmentID, p_Salary, p_JoinDate);
    SELECT newEmployeeID AS NewEmployeeID;
END
/
/

DELIMITER;

CALL GetEmployeesByDepartment (3);

CALL sp_InsertEmployee (
    'Robert',
    'Wilson',
    2,
    6500.00,
    '2023-01-10'
);

CALL GetEmployeesByDepartment (2);