using IKEA.BLL.Dto_s.DepartmentDto_s;
using IKEA.BLL.Dto_s.EmployeeDto_s;
using IKEA.BLL.Factories.DepartmentFactory;
using IKEA.BLL.Services.DepartmentServices.DepartmentService;
using IKEA.DAL.Reporsatories.DepartmentRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services.DepartmentService
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IDepartmentRepository _repository;
        public DepartmentServices(IDepartmentRepository reposatry) 
        {
            _repository = reposatry;

        }

        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            var Departments = _repository.GetAll();

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
            var Department = _repository.GetById(id);

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
            return _repository.Add(Dept);

        }
        public int UpdateDepartment(UpdatedDepartmentDto dto)
        {
            var Dept = dto.fromUpdatedDepartment();
            return _repository.Update(Dept);
        }
        public bool DeleteDepartment(int id)
        {

            return _repository.Delete(_repository.GetById(id)) > 0;
        }

       
    }
}
