using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Orders.DTO
{
    public class CreateProductRequest
    {
        public string Name { get; set; }
        public string? Descr { get; set; }

    }
}
