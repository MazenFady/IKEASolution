using AutoMapper;
using IKEA.BLL.Dto_s.DepartmentDto_s;
using IKEA.BLL.Dto_s.EmployeeDto_s;
using IKEA.DAL.Models.Employees;
using IKEA.DAL.Reporsatories.EmployeeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services.EmployeeServices
{
    public class EmployeeServices : IEmployeeServices
    {
        public  readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper mapper;

        public EmployeeServices(IEmployeeRepository employeeRepository , IMapper mapper)
        {
           this._employeeRepository = employeeRepository;
            this.mapper = mapper;
        }

        public IEnumerable<EmployeeDto> GetAllEmployees()
            =>
             mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(_employeeRepository.GetAll());
            
        
        public EmployeeDetailsDto GetEmployeeById(int Id)
        =>mapper.Map<Employee,EmployeeDetailsDto>(_employeeRepository.GetById(Id));
        
        public int CreateEmployee(CreatedEmployeeDto dto)
        {
            var Emp =mapper.Map<CreatedEmployeeDto, Employee>(dto);
            Emp.CreatedBy = 1;
                Emp.CreatedOn=DateTime.Now;
            Emp.LastModifiedBy= 1;
                Emp.LastModifiedOn= DateTime.Now;
           return _employeeRepository.Add(Emp);
        }
        public int UpdateEmployee(UpdatedEmployeeDto dto)
        {
            var Emp = mapper.Map<UpdatedEmployeeDto, Employee>(dto);
            Emp.LastModifiedBy = 1;
            Emp.LastModifiedOn = DateTime.Now;
           return _employeeRepository.Update(Emp);
        }

        public int DeleteEmployee(int? id)
        {
            if (id is not null)
                return _employeeRepository.Delete(id.Value);
            else
                return 0;
        }
       
       
    }
}
