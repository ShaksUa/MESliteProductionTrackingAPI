using Application.DTO;
using Domain.Entries;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class EmployeeService
    {
        private int _nextId { get; set; } = 0;
        private List<Employee> _employees { get; set; } = new List<Employee>();
        public Employee Create (CreateEmployeeRequest createEmployeeRequest)
        {
            _nextId++;
            var employee = new Employee(
                _nextId,
                createEmployeeRequest.Name,
                createEmployeeRequest.DepartmentId,
                createEmployeeRequest.PositionId,
                createEmployeeRequest.StartTime,
                createEmployeeRequest.BirthdayDate,
                createEmployeeRequest.Phone,
                createEmployeeRequest.Email
                );
            _employees.Add(employee);

        return employee;
        }
    }
}
