using Backend_TeaTech.DTO.Employees;
using Backend_TeaTech.DTO.Responsibles;
using Backend_TeaTech.DTO.Users;
using Backend_TeaTech.Interfaces.Repositories;
using Backend_TeaTech.Interfaces.Services;
using Backend_TeaTech.Models;
using Backend_TeaTech.Repositories;

namespace Backend_TeaTech.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public Employee CreateEmployee(Employee employee)
        {
            var employeeAdd = _employeeRepository.Add(employee);
            return employeeAdd;
        }

        public void DeleteEmployeeById(Guid id)
        {
            var existingEmployee = _employeeRepository.GetByID(id);
            if (existingEmployee != null)
            {
                _employeeRepository.DeleteByID(id);
            }
            else
            {
                throw new ArgumentException("Employee not found.");
            }
        }

        public Employee GetEmployeeById(Guid id)
        {
            try
            {
                var employee = _employeeRepository.GetByID(id);
                if (employee == null)
                {
                    throw new ArgumentException($"Employee with ID {id} not found.");
                }
                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception("", ex);
            }
        }

        public List<EmployeeDTO> ListAllEmployee()
        {
            var employees = _employeeRepository.GetAll();

            List<EmployeeDTO> employeeDTO = employees.Select(employee => new EmployeeDTO
            {
                Id = employee.Id,
                Name = employee.Name,
                OccupationType = employee.OccupationType,
                User = new UserDTO(employee.User),

            }).ToList();

            return employeeDTO;

        }
    }
}
