using IKEA.DAL.Context;
using IKEA.DAL.Reporsatories.DepartmentRepo;
using IKEA.DAL.Reporsatories.EmployeeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext context;
        public UnitOfWork(ApplicationDBContext context) 
        {
            this.context = context;
            EmployeeRepository = new EmployeeRepository(context);
            DepartmentRepository = new DepartmentRepository(context);

        }
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IDepartmentRepository DepartmentRepository { get ; set ; }




        public int Complete()
        {
           return context.SaveChanges();
        }
    }
}
