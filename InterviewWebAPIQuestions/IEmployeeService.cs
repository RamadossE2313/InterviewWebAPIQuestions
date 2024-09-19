namespace InterviewWebAPIQuestions
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> AddEmployeesAsync(Employee employee);
        Task<Employee> UpdateEmployeesAsync(int employeeId, Employee employee);
        Task DeleteEmployeesAsync(int employeeId);
    }

    public class EmployeeService : IEmployeeService
    {
        public async Task<Employee> AddEmployeesAsync(Employee employee)
        {
            await Task.Delay(1000);
            return employee;
        }

        public async Task DeleteEmployeesAsync(int employeeId)
        {
            await Task.Delay(1000);
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            await Task.Delay(1000);
            return new List<Employee> { 
                new Employee() {  Id = 1, Name ="test", Position ="test", Salary = 1 },
            };
        }

        public async Task<Employee> UpdateEmployeesAsync(int employeeId, Employee employee)
        {
            await Task.Delay(1000);
            return employee;
        }
    }
}
