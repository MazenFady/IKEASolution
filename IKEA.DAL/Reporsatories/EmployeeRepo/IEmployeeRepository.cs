using IKEA.DAL.Models.Employees;
using IKEA.DAL.Reporsatories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Reporsatories.EmployeeRepo
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        
    }
}
