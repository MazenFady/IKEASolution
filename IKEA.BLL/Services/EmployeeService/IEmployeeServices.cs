using IKEA.BLL.Dto_s.DepartmentDto_s;
using IKEA.BLL.Dto_s.EmployeeDto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services.EmployeeServices
{
    public interface IEmployeeServices
    {
         IEnumerable<EmployeeDto> GetAllEmployees(bool withTracking = false);
         EmployeeDetailsDto GetEmployeeById(int Id);

        int AddEmployee(CreatedEmployeeDto dto);
        int UpdateEmployee(UpdatedEmployeeDto dto);
        bool DeleteEmployee(int id); 
    }
}
