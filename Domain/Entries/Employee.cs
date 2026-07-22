using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;

namespace Domain.Entries
{
    public class Employee
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int DepartmentId { get; private set; }
        public int PositionId { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateOnly? BirthdayDate { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Employee(int id, string name, int departmentId, int positionId, DateTime startTime, DateOnly? birthDate, string phone, string email)
        {
            Id = id;
            Name = name;
            DepartmentId = departmentId;
            PositionId = positionId;
            StartTime = startTime;
            BirthdayDate = birthDate;
            Phone = phone;
            Email = email;
            CreatedAt = DateTime.UtcNow;
        }

        public void Update(string? name, int? departmentId, int? positionId, DateOnly? birthDate, string? phone, string? email)
        {
            if (name != null) Name = name;
            if (departmentId != null) DepartmentId = departmentId.Value;
            if (positionId != null) PositionId = positionId.Value;
            if (birthDate.HasValue) BirthdayDate = birthDate;
            if (phone != null) Phone = phone;
            if (email != null) Email = email;
        }
    }
}
