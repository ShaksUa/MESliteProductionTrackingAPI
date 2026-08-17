using Application.DTO;
using Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using MESLite.Tests.Helpers;

namespace MESLite.Tests.EmployeeServiceTests
{
    public class UpdateByIdTests
    {
        [Fact]
        public void UpdateById_ShouldReturnEmployee_WhenEmployeeExists()
        {
            // Arrange
            var employeeService = EmployeeServiceHelper.CreateServiceWithEmployee();

            UpdateEmployeeRequest updateEmployeeRequest = new()
            {
                Email = "NewTestEmployee@gmail.com"
            };
            // Act
            var updatedEmpl = employeeService.UpdateById(1, updateEmployeeRequest);

            // Assert
            Assert.NotNull(updatedEmpl);
            Assert.Equal(1, updatedEmpl.Id);
            Assert.Equal("NewTestEmployee@gmail.com", updatedEmpl.Email);
        }
        [Fact]
        public void UpdateById_ShouldReturnNull_WhenEmployeeDoesNotExist()
        {
            // Arrange
            var employeeService = EmployeeServiceHelper.CreateEmptyService();

            UpdateEmployeeRequest updateEmployeeRequest = new()
            {
                Email = "NewTestEmployee@gmail.com"
            };
            // Act
            var updatedEmpl = employeeService.UpdateById(1, updateEmployeeRequest);

            // Assert
            Assert.Null(updatedEmpl);

        }
        [Fact]
        public void UpdateById_ShouldUpdateOnlyProvidedField()
        {
            // Arrange

            var employeeService = EmployeeServiceHelper.CreateServiceWithEmployee();

            UpdateEmployeeRequest updateEmployeeRequest = new()
            {
                Email = "NewTestEmployee@gmail.com"
            };
            // Act
            var updatedEmpl = employeeService.UpdateById(1, updateEmployeeRequest);

            // Assert
            Assert.NotNull(updatedEmpl);
            Assert.Equal(1, updatedEmpl.Id);
            Assert.Equal("TestEmployee", updatedEmpl.Name);
            Assert.Equal(1, updatedEmpl.DepartmentId);
            Assert.Equal(2, updatedEmpl.PositionId);
            Assert.Equal("380991112233", updatedEmpl.Phone);
            Assert.Equal("NewTestEmployee@gmail.com", updatedEmpl.Email);
        }
        [Fact]
        public void UpdateById_ShouldUpdateOnlyProvidedFields()
        {
            // Arrange
            var employeeService = EmployeeServiceHelper.CreateServiceWithEmployee();

            UpdateEmployeeRequest updateEmployeeRequest = new()
            {
                Name = "NewTestEmployee",
                Email = "NewTestEmployee@gmail.com"
            };
            // Act
            var employee = employeeService.GetById(1);
            var updatedEmpl = employeeService.UpdateById(1, updateEmployeeRequest);

            // Assert
            Assert.NotNull(updatedEmpl);
            Assert.Equal(1, updatedEmpl.Id);
            Assert.Equal(1, updatedEmpl.DepartmentId);
            Assert.Equal(2, updatedEmpl.PositionId);
            Assert.Equal("380991112233", updatedEmpl.Phone);
            Assert.Equal("NewTestEmployee", updatedEmpl.Name);
            Assert.Equal("NewTestEmployee@gmail.com", updatedEmpl.Email);

        }
    }
}
