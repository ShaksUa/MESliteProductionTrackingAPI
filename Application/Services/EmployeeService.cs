using Application.DTO;
using Domain.Entries;
using Domain.Interfaces;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Application.Services
{
    public class EmployeeService
    {
        private int _nextId { get; set; } = 0;
        public List<Employee> _employees { get; set; } = new List<Employee>();
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

        public Employee GetById(int id)
        {
            foreach(Employee emp in _employees)
            {
                if (emp.Id == id) return emp;
            }    
            return null;

        }

        public List<Employee> GetAll()
        { 
           return _employees;
        }

        public bool DeleteById(int id)
        {
            var employee = GetById(id);
            return _employees.Remove(employee);
        }

        public bool UpdateById(int id, UpdateEmployeeRequest updateEmployeeRequest)
        {
            var employee = GetById(id);
            if (employee == null) return false;
            employee.Update(
                updateEmployeeRequest.Name,
                updateEmployeeRequest.DepartmentId,
                updateEmployeeRequest.PositionId,
                updateEmployeeRequest.BirthdayDate,
                updateEmployeeRequest.Phone,
                updateEmployeeRequest.Email);

            return true;
        }
    }
}
