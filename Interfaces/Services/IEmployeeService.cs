using Backend_TeaTech.DTO.Employee;
using Backend_TeaTech.Models;

namespace Backend_TeaTech.Interfaces.Services
{
    public interface IEmployeeService
    {
        Employee CreateEmployee(Employee employee);
        void DeleteEmployeeById(Guid id);
        List<EmployeeDTO> ListAllEmployee();
        Employee GetEmployeeById(Guid id);

    }
}
