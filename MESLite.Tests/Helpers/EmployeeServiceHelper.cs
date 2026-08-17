using Application.DTO;
using Application.Services;
using Domain.Entries;
using System;
using System.Collections.Generic;
using System.Text;

namespace MESLite.Tests.Helpers
{
    public class EmployeeServiceHelper
    {
        public static EmployeeService CreateEmptyService()
        {
            return new EmployeeService();
        }
        public static EmployeeService CreateServiceWithEmployee()
        {
            var employeeService = new EmployeeService();
            var createEmployeeRequest = CreateValidEmployeeRequest();
            employeeService.Create(createEmployeeRequest);
            return employeeService;
        }
        public static EmployeeService CreateServiceWithEmployee(CreateEmployeeRequest request)
        {
            var employeeService = new EmployeeService();
            employeeService.Create(request);
            return employeeService;
        }

        public static CreateEmployeeRequest CreateValidEmployeeRequest()
        {
            return new ()
            {

                Name = "TestEmployee",
                DepartmentId = 1,
                PositionId = 2,
                StartTime = DateTime.UtcNow,
                BirthdayDate = null,
                Phone = "380991112233",
                Email = "TestEmployee@gmail.com"
            };
        }
    }
}
