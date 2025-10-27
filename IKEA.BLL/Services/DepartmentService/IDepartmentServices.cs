using IKEA.BLL.Dto_s.DepartmentDto_s;
using IKEA.BLL.Dto_s.EmployeeDto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services.DepartmentServices.DepartmentService
{
    public interface  IDepartmentServices
    {
        public IEnumerable<DepartmentDto> GetAllDepartments();
        public DepartmentDetailsDto GetDepartmentById(int Id);

        public int AddDepartment (CreatedDepartmentDto dto);
        public int UpdateDepartment (UpdatedDepartmentDto dto);
        public bool DeleteDepartment (int id);


    }
}
