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

        public IEnumerable<EmployeeDto> GetAllEmployees(bool withTracking = false)
            =>
             mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(_employeeRepository.GetAll());


        public EmployeeDetailsDto? GetEmployeeById(int Id)
        { 
        var employee = _employeeRepository.GetById(Id);
            return employee is null ? null : mapper.Map<EmployeeDetailsDto>(employee);
            
        }
        public int AddEmployee(CreatedEmployeeDto dto)
        {
            //var Emp = mapper.Map<CreatedEmployeeDto, Employee>(dto);
            //Emp.CreatedBy = 1;
            //Emp.CreatedOn = DateTime.Now;
            //Emp.LastModifiedBy = 1;
            //Emp.LastModifiedOn = DateTime.Now;
            //return _employeeRepository.Add(Emp);
            var employee = mapper.Map<Employee>(dto);
            return _employeeRepository.Add(employee);

        }
        public int UpdateEmployee(UpdatedEmployeeDto dto)
        {
            //var Emp = mapper.Map<UpdatedEmployeeDto, Employee>(dto);
            //Emp.LastModifiedBy = 1;
            //Emp.LastModifiedOn = DateTime.Now;
            //return _employeeRepository.Update(Emp);
            var employee = mapper.Map<Employee>(dto);
            return _employeeRepository.Update(employee);
        }

        public bool DeleteEmployee(int id)
        {
            //var employee = _employeeRepository.GetById(id.Value);
            //if (employee is null) return false;
            //else
            //{
            //    employee.IsDeleted = true;
            //    _employeeRepository.Update(employee);

            //    return _employeeRepository.SaveChanges() > 0 ? true : false;
            //}
            var employee = _employeeRepository.GetById(id);
            if (employee is null) return false;
            else 
            {
                employee.IsDeleted = true;
                return _employeeRepository.Update(employee)> 0 ?  true : false ;
            }
        }

    }
}
