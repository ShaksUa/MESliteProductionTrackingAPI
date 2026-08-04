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
            if (id > 0 && id <= _nextId)
            {
                foreach (Department dep in _departments)
                {
                    if (dep.Id == id) return dep;
                }
            }
            return default;
        }
        public bool DeleteById(int id)
        {
            var dep = GetById(id);
            if (dep != null)
            {
                _departments.Remove(dep);
                return true;
            }
            return false;

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
    }
}
