using IKEA.DAL.Reporsatories.DepartmentRepo;
using IKEA.DAL.Reporsatories.EmployeeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.UOW
{
    public interface IUnitOfWork
    {

        public IEmployeeRepository EmployeeRepository { get; set; }
        public IDepartmentRepository DepartmentRepository { get; set; }

        public int Complete();


    }
}
