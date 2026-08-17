using Application.DTO;
using Application.Services;
using MESLite.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MESLite.Tests.EmployeeServiceTests
{
    public class GetByIdTests
    {
        [Fact]
        public void GetById_ShouldReturnEmployee_WhenEmployeeExists()
        {
            // Arrange
            var employeeService = EmployeeServiceHelper.CreateServiceWithEmployee();

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
