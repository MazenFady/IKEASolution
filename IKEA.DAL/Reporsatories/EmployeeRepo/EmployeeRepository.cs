using IKEA.DAL.Context;
using IKEA.DAL.Models.Department;
using IKEA.DAL.Models.Employees;
using IKEA.DAL.Reporsatories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Reporsatories.EmployeeRepo
{
    public class EmployeeRepository :GenericRepository<Employee> , IEmployeeRepository
    {
        public readonly ApplicationDBContext _context;
        public EmployeeRepository(ApplicationDBContext context) : base(context)
        { 
            this._context = context;
        }

      
    }
}
