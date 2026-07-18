using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text;

namespace Application.DTO
{
    public class CreateProductRequest
    {
        [Required,MinLength(3),MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string? Descr { get; set; }
        
        [Required,Range(1,1000)]
        public int Quantity { get; set; }

    }
}
