using Application.DTO;
using Domain.Entries;
using Domain.Interfaces;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace Application.Services
{
    public class EmployeeService
    {
        private int _nextId = 0;
        private readonly List<Employee> _employees = new ();
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
            if (id > 0 && id <= _nextId)
            {
                foreach (Employee emp in _employees)
                {
                    if (emp.Id == id) return emp;
                }
            }
            return default;

        }
        public bool DeleteById(int id)
        {
            var employee = GetById(id);
            if (employee != null)
            {
                return _employees.Remove(employee);
            }
            return false;
        }

        public List<Employee> GetAll()
        { 
           return _employees;
        }

        public Employee UpdateById(int id, UpdateEmployeeRequest updateEmployeeRequest)
        {
            var employee = GetById(id);
            if (employee != null)
            {
                employee.Update(
                updateEmployeeRequest.Name,
                updateEmployeeRequest.DepartmentId,
                updateEmployeeRequest.PositionId,
                updateEmployeeRequest.BirthdayDate,
                updateEmployeeRequest.Phone,
                updateEmployeeRequest.Email);

                return employee;
            }
            return default;
        }
    }
}
