using Application.DTO;
using Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MESLite.Tests.EmployeeServiceTests
{
    public class UpdateById
    {
        [Fact]
        public void UpdateById_ShouldReturnEmployee_WhenEmployeeExists()
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

            UpdateEmployeeRequest updateEmployeeRequest = new()
            {
                Email = "NewTestEmployee@gmail.com"
            };
            employeeService.Create(createEmployeeRequest);
            // Act
            var employee = employeeService.GetById(1);
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
