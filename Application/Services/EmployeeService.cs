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
        private readonly List<Employee> _employees = new();
        public Employee Create(CreateEmployeeRequest createEmployeeRequest)
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
            return _employees.FirstOrDefault(emp => emp.Id == id);
        }
        public bool DeleteById(int id)
        {
            return _employees.Remove(GetById(id));
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

        public List<Employee> GetByDepartmentId(int departmentId)
        {
            return _employees
                    .Where(emp => emp.DepartmentId == departmentId)
                    .ToList();
        }

        public List<string> GetEmployeeNamesByDepartment(int departmentId)
        {
            return _employees
                .Where(emp => emp.DepartmentId == departmentId)
                .Select(emp => emp.Name)
                .ToList();
        }

        public List<string> GetEmployeeEmails()
        {
            return _employees
                .Select(e => e.Email)
                .ToList();
        }

        public List<Employee> GetOrderedById()
        {
            return _employees
                .OrderBy(e => e.Id)
                .ToList();
        }

        public List<Employee> GetEmployeesOrderedByName()
        {
            return _employees
                .OrderBy(e => e.Name)
                .ToList();
        }

        public List<Employee> GetEmployeesOrderedByDepartment()
        {
            return _employees
               .OrderBy(e => e.DepartmentId)
               .ToList();
        }

        public List<Employee> GetEmployeesOrderedByDepartmentThenName()
        {
            return _employees
              .OrderBy(e => e.DepartmentId)
              .ThenBy(e => e.Name)
              .ToList();
        }

        public List<int> GetUniqueDepartmentIds()
        {
            return _employees
                .Select(e => e.DepartmentId)
                .Distinct()
                .ToList();
        }

        public bool HasOnlyDepartment(int departmentId)
        {
            return _employees
                .All(e => e.DepartmentId == departmentId);
        }

    }
}
