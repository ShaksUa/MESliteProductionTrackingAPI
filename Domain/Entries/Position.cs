using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entries
{
    public class Position
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int DepartmentId { get; private set; }
        public DateTime CreatedAt { get; private set; }
         public bool IsRemote { get; private set; }


    public Position(int id, string name, string? descr, int? departmentId, bool? isRemote)
        {
            Id = id;
            Name = name;
            if (descr != null) Description = descr;
            if (departmentId != null) DepartmentId = departmentId.Value;
            CreatedAt = DateTime.UtcNow;
            if (isRemote != null) IsRemote = isRemote.Value;
        }
    public void Update( string? name, string? descr, int? departmentId, DateTime? createdAt, bool? isRemote)
        {
            if(name!=null) Name = name;
            if (descr != null) Description = descr;
            if (departmentId != null) DepartmentId = departmentId.Value;
            if (createdAt != null) CreatedAt = createdAt.Value;
            if (isRemote != null) IsRemote = isRemote.Value;
        }
    }

}
