using IKEA.DAL.Context;
using IKEA.DAL.Models.Department;
using IKEA.DAL.Reporsatories.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IKEA.DAL.Reporsatories.DepartmentRepo
{
   
    public class DepartmentRepository :GenericRepository<Department>  ,IDepartmentRepository 
    {
        private readonly ApplicationDBContext _context;

        public DepartmentRepository(ApplicationDBContext context):base(context)
        {
            _context = context;

        }      
    }
}
