
using Dapper;
using System.Data;
namespace BlazorDapperCRUD.Data
{


    public class EmployeeRepository
    {
        private readonly DapperContext _context;

        public EmployeeRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            var query = "SELECT * FROM Employees";
            using (var connection = _context.CreateConnection())
            {
                var employees = await connection.QueryAsync<Employee>(query);
                return employees;
            }

        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var query = "SELECT * FROM Employees WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                var employee = await connection.QuerySingleOrDefaultAsync<Employee>(query, new { Id = id });
                return employee;
            }
        }

        public async Task CreateEmployeeAsync(Employee employee)
        {
            var query = "INSERT INTO Employees (Name, Department, Salary, Designation, Location) VALUES (@Name, @Department, @Salary, @Designation, @Location)";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, employee);
            }
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            var query = "UPDATE Employees SET Name = @Name, Department = @Department, Salary = @Salary, Designation = @Designation, Location = @Location WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, employee);
            }
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var query = "DELETE FROM Employees WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }
    }
}