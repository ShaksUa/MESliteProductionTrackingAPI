using Application.DTO;
using Domain.Entries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class DepartmentService
    {
        private int _nextId = 0;
        private readonly List<Department> _departments = new();
        
        public Department Create(CreateDepartmentRequest createDepartment)
        {
           _nextId++;
                var department = new Department(
                    _nextId,
                     createDepartment.Name,
                     createDepartment.Description,
                     createDepartment.Email,
                     createDepartment.Phone);
                _departments.Add(department);
          return department;
        }

        public Department GetById(int id)
        {
            return _departments.FirstOrDefault(d=>d.Id == id);
        }
        public bool DeleteById(int id)
        {
            return _departments.Remove(GetById(id));

        }

        public List<Department> GetAll()
        {
            return _departments;
        }

        public Department UpdateById(int id, UpdateDepartmentRequest updateDepartmentRequest)
        {
            var dep = GetById(id);
            if (dep != null)
            {
                dep.Update(
                    updateDepartmentRequest.Name,
                    updateDepartmentRequest.Description,
                    updateDepartmentRequest.Phone,
                    updateDepartmentRequest.Email);

                return dep;
            }

            return default;
        }

        public List<int> GetDepartmentIds()
        {
            return _departments
                   .Select(e => e.Id)
                   .ToList();
        }

        public List<string> GetDepartmentNames()
        {
            return _departments
                   .Select(e => e.Name)
                   .ToList();
        }


    }
}
