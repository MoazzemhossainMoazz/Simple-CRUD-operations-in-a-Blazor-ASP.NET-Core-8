CREATE TABLE Employees (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Department NVARCHAR(100),
    Salary DECIMAL(18, 2),
	Designation NVARCHAR(100),
	Location NVARCHAR(100)

)
