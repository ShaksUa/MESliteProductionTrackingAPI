using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class CreatePositionRequests
    {
        [Required, MinLength(3), MaxLength(100)]
        public string Name { get; set; }
        [MinLength(3), MaxLength(100)]
        public string Description { get; set; }
        [Range(1,1000)]
        public int DepartmentId { get; set; }
        
        public bool IsRemote { get; set; }
    }
}
