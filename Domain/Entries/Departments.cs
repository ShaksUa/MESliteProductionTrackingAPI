using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Entries
{
    public class Department
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public string? Description { get; private set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public Department (int id, string name, string? descr, string? email, string? phone)
        {
            this.Id = id;
            this.Name = name;
            if (descr!=null) this.Description = descr;
            if (email != null) this.Email = email;
            if (phone != null) this.Phone = phone;
        }

        public void Update(string name, string? descr, string? email, string? phone)
        {
            if (!String.IsNullOrWhiteSpace(name) && name.Length > 3)
            {
                this.Name = name;
            }

            if (!String.IsNullOrWhiteSpace(descr) && descr.Length > 10)
            {
                this.Description = descr;
            }

            if (!String.IsNullOrWhiteSpace(email))
            {
                this.Email = email;
            }
           
            if (!String.IsNullOrWhiteSpace(phone))
            {
                this.Phone = phone;
            }

        }
    }
}
