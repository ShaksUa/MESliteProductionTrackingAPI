using Application.DTO;
using Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MESLite.Tests.EmployeeServiceTests
{
    public class DeleteById
    {
        [Fact]
        public void DeleteById_ShouldReturnTrue_WhenEmployeeExists()
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
            var result = employeeService.DeleteById(1);
            var employee = employeeService.GetById(1);

            // Assert
            Assert.True(result);
            Assert.Null(employee);

        }
        [Fact]
        public void DeleteById_ShouldReturnFalse_WhenEmployeeDoesNotExist()
        {
            // Arrange
            var employeeService = new EmployeeService();

            // Act
            var result = employeeService.DeleteById(1);

            // Assert
            Assert.False(result);

        }
        [Fact]
        public void DeleteById_ShouldRemoveEmployee_WhenEmployeeExists()
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
            var employee1 = employeeService.GetById(1);
            var result = employeeService.DeleteById(1);
            var employee2 = employeeService.GetById(1);

            // Assert
            Assert.NotNull(employee1);
            Assert.True(result);
            Assert.Null(employee2);

        }
    }
}
