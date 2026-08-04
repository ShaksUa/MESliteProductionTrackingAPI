using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class CreateDepartmentRequest
    {
        [Required, MinLength(3), MaxLength(100)]
        public string Name { get; set; }
        [MinLength(10)]
        public string? Description { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
    }
}
