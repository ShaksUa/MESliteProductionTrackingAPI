using Application.DTO;
using Domain.Entries;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        public Employee Create ()
        {
            return new Employee();
        }
    }
}
