using IKEA.BLL.Dto_s.DepartmentDto_s;
using IKEA.BLL.Dto_s.EmployeeDto_s;
using IKEA.BLL.Factories.DepartmentFactory;
using IKEA.BLL.Services.DepartmentServices.DepartmentService;
using IKEA.DAL.Reporsatories.DepartmentRepo;
using IKEA.DAL.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services.DepartmentService
{
    public class DepartmentServices :   IDepartmentServices
    {
        
        private readonly IUnitOfWork uintOfWork;

        public DepartmentServices(IUnitOfWork uintOfWork)
        {
            
            this.uintOfWork = uintOfWork;
        }

        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var Departments = uintOfWork.DepartmentRepository.GetAll();

            List<DepartmentDto> MappedDepartments = new List<DepartmentDto>();
            foreach (var Dept in Departments)
            {
                var MappedDepart = Dept.ToDepartmentDto();
                MappedDepartments.Add(MappedDepart);
            }
            return MappedDepartments;

        }

        public DepartmentDetailsDto GetDepartmentById(int id)
        {
            var Department = uintOfWork.DepartmentRepository.GetById(id);

            if (Department == null) return null;
            else
            {
                var DepartmentToReturn = Department.ToEntity();
                return DepartmentToReturn;
            }
        }

        public int AddDepartment(CreatedDepartmentDto dto)
        {
            var Dept = dto.ToDepartment();
            return uintOfWork.DepartmentRepository.Add(Dept);

        }
        public int UpdateDepartment(UpdatedDepartmentDto dto)
        {
            var Dept = dto.fromUpdatedDepartment();
            return uintOfWork.DepartmentRepository.Update(Dept);
        }
        public bool DeleteDepartment(int id)
        {
            var department = uintOfWork.DepartmentRepository.GetById(id);
            if (department is null) return false;
            else
            {
                var result = uintOfWork.DepartmentRepository.Delete(department);
                if (result > 0) return true;
                 else return false;
          
            }

        }
    }
}
