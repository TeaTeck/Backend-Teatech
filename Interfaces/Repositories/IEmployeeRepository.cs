﻿using Backend_TeaTech.Models;

namespace Backend_TeaTech.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        Employee Add(Employee employee);
        Employee Update(Employee employee);
        void DeleteByID(Guid id);
        Employee GetByID(Guid id);
        List<Employee> GetAll();

    }
}