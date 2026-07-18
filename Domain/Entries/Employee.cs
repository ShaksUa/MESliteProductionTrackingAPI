using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entries
{
    public class Employee
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int DepartmentId { get; private set; }
        public int PositionId { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateOnly? BirthdayDate { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public DateTime CreatedAt { get; private set; }

    public Employee() { }
        public Employee(string name, int departmentId, int positionId, DateTime startTime, DateOnly? birthDate, string phone, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            DepartmentId = departmentId;
            PositionId = positionId;
            StartTime = startTime;
            BirthdayDate = birthDate;
            Phone = phone;
            Email = email;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
