using Application.DTO;
using Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MESLite.Tests.EmployeeServiceTests
{
    public class Create
    {
        [Fact]
        public void Create_ShouldReturnEmployee_WhenRequestIsValid()
        {
            // Arrange
            var employeeService = new EmployeeService();
            CreateEmployeeRequest createEmployeeRequest = new()
            {
                Name = "TestEmployee",
                DepartmentId = 1,
                PositionId = 2,
                StartTime = DateTime.UtcNow,
                BirthdayDate = null,
                Phone = "380991112233",
                Email = "TestEmployee@gmail.com"
            };

            // Act
            var employee = employeeService.Create(createEmployeeRequest);

            // Assert
            Assert.NotNull(employee);
            Assert.Equal(1, employee.Id);
            Assert.Equal("TestEmployee", employee.Name);
        }

        [Fact]
        public void Create_ShouldAssignIncrementingIds_WhenMultipleEmployeesAreCreated()
        {
            // Arrange
            var employeeService = new EmployeeService();
            CreateEmployeeRequest createEmployeeRequest1 = new()
            {
                Name = "TestEmployee",
                DepartmentId = 1,
                PositionId = 2,
                StartTime = DateTime.UtcNow,
                BirthdayDate = null,
                Phone = "380991112233",
                Email = "TestEmployee@gmail.com"
            };
            CreateEmployeeRequest createEmployeeRequest2 = new()
            {
                Name = "TestEmployee2",
                DepartmentId = 1,
                PositionId = 1,
                StartTime = DateTime.UtcNow,
                BirthdayDate = null,
                Phone = "380991112299",
                Email = "TestEmployee2@gmail.com"
            };

            employeeService.Create(createEmployeeRequest2);

            // Act
            employeeService.Create(createEmployeeRequest1);
            var employee1 = employeeService.GetById(1);

            employeeService.Create(createEmployeeRequest2);
            var employee2 = employeeService.GetById(2);

            // Assert
            Assert.NotNull(employee1);
            Assert.Equal(1, employee1.Id);
            Assert.Equal("TestEmployee", employee1.Name);

            Assert.NotNull(employee2);
            Assert.Equal(2, employee2.Id);
            Assert.Equal("TestEmployee2", employee2.Name);
        }



    }
}
