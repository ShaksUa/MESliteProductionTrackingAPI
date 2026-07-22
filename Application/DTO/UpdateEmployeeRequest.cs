using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class UpdateEmployeeRequest
    {
        [MinLength(2), MaxLength(100)]
        public string? Name { get; set; }
        [Range(1, 50)]
        public int? DepartmentId { get; set; }
        [Range(1, 1000)]
        public int? PositionId { get; set; }
        public DateOnly? BirthdayDate { get; set; }
        [Phone]
        public string? Phone { get; set; }
        [EmailAddress]
        public string? Email { get; set; }

    }
}
