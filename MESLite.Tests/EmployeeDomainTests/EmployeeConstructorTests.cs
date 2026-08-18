using Domain.Entries;

namespace MESLite.Tests;

public class EmployeeConstructorTests
{
    [Fact]
    public void Employee_ShouldBeCreated_WhenDataIsValid()
    {
        //Arrange

        //Act
        Employee employee = new(
    1,
    "TestEmployee",
    1,
    1,
    DateTime.UtcNow,
    null,
    "380992223311",
    "testEmployee@gmail.com"
    );

        //Assert
        Assert.Equal(1, employee.Id);
        Assert.Equal("TestEmployee", employee.Name);
        Assert.Equal(1, employee.DepartmentId);
        Assert.Equal(1, employee.PositionId);
        Assert.Equal("380992223311", employee.Phone);
        Assert.Equal("testEmployee@gmail.com", employee.Email);
    }

    [Fact]
    public void Employee_ShouldThrowArgumentException_WhenNameIsEmpty()
    {
        //Arrange

        //Act & Assert
        Assert.Throws<ArgumentException>(() =>
            new Employee(1, "", 1, 1, DateTime.UtcNow, null, "380992223311", "testEmployee@gmail.com")
        );
    }

    [Fact]
    public void Employee_ShouldThrowArgumentException_WhenNameIsWhitespace()
    {
        //Arrange

        //Act & Assert
        Assert.Throws<ArgumentException>(() =>
            new Employee(1, " ", 1, 1, DateTime.UtcNow, null, "380992223311", "testEmployee@gmail.com")
        );
    }


    [Fact]
    public void Employee_ShouldThrowArgumentException_WhenEmailIsEmpty()
    {
        //Arrange

        //Act & Assert
        Assert.Throws<ArgumentException>(() =>
            new Employee(1, "TestEmployee", 1, 1, DateTime.UtcNow, null, "380992223311", "")
        );
    }

    [Fact]
    public void Employee_ShouldThrowArgumentException_WhenStartTimeIsTooFarInFuture()
    {
        //Arrange

        //Act & Assert
        Assert.Throws<ArgumentException>(() =>
            new Employee(1, "TestEmployee", 1, 1, DateTime.UtcNow.AddDays(366), null, "380992223311", "testEmployee@gmail.com")
        );
    }

    [Fact]
    public void Employee_ShouldThrowArgumentException_WhenIdIsNegative()
    {
        //Arrange

        //Act & Assert
        Assert.Throws<ArgumentException>(() =>
            new Employee(-1, "TestEmployee", 1, 1, DateTime.UtcNow, null, "380992223311", "testEmployee@gmail.com")
        );
    }

    [Fact]
    public void Employee_ShouldThrowArgumentException_WhenIdIsZero()
    {
        //Arrange

        //Act & Assert
        Assert.Throws<ArgumentException>(() =>
            new Employee(0, "TestEmployee", 1, 1, DateTime.UtcNow, null, "380992223311", "testEmployee@gmail.com")
        );
    }


}
