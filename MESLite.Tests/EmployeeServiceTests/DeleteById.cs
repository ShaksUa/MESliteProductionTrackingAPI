using Application.DTO;
using Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using MESLite.Tests.Helpers;

namespace MESLite.Tests.EmployeeServiceTests
{
    public class DeleteByIdTests
    {
        [Fact]
        public void DeleteById_ShouldReturnTrue_WhenEmployeeExists()
        {
            // Arrange
            var employeeService = EmployeeServiceHelper.CreateServiceWithEmployee();
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
            var employeeService = EmployeeServiceHelper.CreateEmptyService();

            // Act
            var result = employeeService.DeleteById(1);

            // Assert
            Assert.False(result);

        }
    }
}
