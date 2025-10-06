using IKEA.DAL.Reporsatories.DepartmentRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services
{
    public class DeparrtmentServices
    {
        private readonly IDepartmentReposatry _reposatry;
        public DeparrtmentServices(IDepartmentReposatry reposatry) 
        {
         _reposatry = reposatry;

        }
    }
}
