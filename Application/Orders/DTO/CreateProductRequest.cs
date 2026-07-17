using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Orders.DTO
{
    public class CreateProductRequest
    {
        public string name { get; set; }
        public string? descr { get; set; }

    }
}
