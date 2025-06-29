DROP PROCEDURE IF EXISTS GetEmployeeCountByDepartment;

DELIMITER /
/

CREATE PROCEDURE GetEmployeeCountByDepartment(IN deptID INT)
BEGIN
    SELECT COUNT(*) AS EmployeeCount
    FROM Employees
    WHERE DepartmentID = deptID;
END
/
/

DELIMITER;

CALL GetEmployeeCountByDepartment (2);