using Application.DTO;
using Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MESLite.Tests.EmployeeServiceTests
{
    public class GetById
    {
        [Fact]
        public void GetById_ShouldReturnEmployee_WhenEmployeeExists()
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
            employeeService.Create(createEmployeeRequest);
            // Act
            var employee = employeeService.GetById(1);

            // Assert
            Assert.NotNull(employee);
            Assert.Equal(1, employee.Id);
            Assert.Equal("TestEmployee", employee.Name);

        }

        [Fact]
        public void GetById_ShouldReturnNull_WhenEmployeeDoesNotExist()
        {
            // Arrange
            var employeeService = new EmployeeService();

            // Act
            var employee = employeeService.GetById(1);

            // Assert
            Assert.Null(employee);
        }

    }
}
