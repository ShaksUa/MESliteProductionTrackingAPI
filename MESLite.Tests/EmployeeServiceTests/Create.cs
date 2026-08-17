using Application.DTO;
using Application.Services;
using MESLite.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MESLite.Tests.EmployeeServiceTests
{
    public class CreateTests
    {
        [Fact]
        public void Create_ShouldReturnEmployee_WhenRequestIsValid()
        {
            // Arrange
            var employeeService = new EmployeeService();
            var request = EmployeeServiceHelper.CreateValidEmployeeRequest();

            // Act
            var employee = employeeService.Create(request);

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
            var createEmployeeRequest1 = EmployeeServiceHelper.CreateValidEmployeeRequest();

            var createEmployeeRequest2 = EmployeeServiceHelper.CreateValidEmployeeRequest();
            createEmployeeRequest2.Name = "TestEmployee2";
            createEmployeeRequest2.DepartmentId = 1;
            createEmployeeRequest2.PositionId = 1;
            createEmployeeRequest2.StartTime = DateTime.UtcNow;
            createEmployeeRequest2.BirthdayDate = null;
            createEmployeeRequest2.Phone = "380991112299";
            createEmployeeRequest2.Email = "TestEmployee2@gmail.com";

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
