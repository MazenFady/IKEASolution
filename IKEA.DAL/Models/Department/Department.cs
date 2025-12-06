using IKEA.DAL.Models.Employees;
using IKEA.DAL.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Models.Departments
{
    public class Department : BaseEntity
    { 
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Code { get; set; }
       public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}

