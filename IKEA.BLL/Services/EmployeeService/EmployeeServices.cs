using AutoMapper;
using IKEA.BLL.Dto_s.DepartmentDto_s;
using IKEA.BLL.Dto_s.EmployeeDto_s;
using IKEA.BLL.Services.AttachmentServices;
using IKEA.DAL.Models.Employees;
using IKEA.DAL.Reporsatories.EmployeeRepo;
using IKEA.DAL.UOW;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services.EmployeeServices
{
    public class EmployeeServices : IEmployeeServices
    {
        
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IAttachmentServices attachmentServices;
        

        public EmployeeServices(IUnitOfWork unitOfWork, IMapper mapper, IAttachmentServices attachmentServices)
        {

            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.attachmentServices = attachmentServices;
            
        }

        public IEnumerable<EmployeeDto> GetAllEmployees(bool withTracking = false)


        {
            var employees = unitOfWork.EmployeeRepository.GetAll()
        .Include(e => e.Department)  
        .Where(e => e.IsDeleted != true)
        .ToList();

            return mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }
        //{
        //    var result = _employeeRepository.GetQueryable().Where(e => e.IsDeleted != true).
        //        Select(e => new EmployeeDto()
        //        {
        //            Id = e.Id,
        //            Name = e.Name,
        //            Age = e.Age


        //        });

        //    return result.ToList();

        //} 
        // =>
        //    mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(_employeeRepository.GetAll());

        #region Details

        
        public EmployeeDetailsDto? GetEmployeeById(int Id)
        { 
            var employee = unitOfWork.EmployeeRepository.GetById(Id);
            return employee is null ? null : mapper.Map<EmployeeDetailsDto>(employee);
            
        }
        #endregion

        #region Create


        public int AddEmployee(CreatedEmployeeDto dto)
        {
           

                var employee = mapper.Map<Employee>(dto);

                if (dto.Image is not null)
                {
                    employee.ImageName = attachmentServices.UploadImage(dto.Image, "images");
                }

                unitOfWork.EmployeeRepository.Add(employee);
                return unitOfWork.Complete();

            


        }

        #endregion

        #region Update


        public int UpdateEmployee(UpdatedEmployeeDto dto)
        {
            

            var employee = mapper.Map<Employee>(dto);

            if (dto.Image is not null)
            {
                if (employee.ImageName is not null)
                {
                    var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", "images", employee.ImageName);
                    attachmentServices.DeleteImage(filepath);

                }
                employee.ImageName = attachmentServices.UploadImage(dto.Image, "images");


            }

             unitOfWork.EmployeeRepository.Update(employee);
            return unitOfWork.Complete();
        }
        #endregion

        #region Delete

        

        public bool DeleteEmployee(int id)
        {
            
            var employee = unitOfWork.EmployeeRepository.GetById(id);

            if (employee is not null)
            {
                if (employee.ImageName is not null)
                { 
                    var filepath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","files","images",employee.ImageName);
                    attachmentServices.DeleteImage(filepath);    

                }

                employee.IsDeleted = true;
                return unitOfWork.EmployeeRepository.Update(employee) > 0 ? true : false;

            }
            if (unitOfWork.Complete()>0)
                return true;
            else
                return false;

        }
        #endregion

        public IEnumerable<EmployeeDto> GetSearchedEmployees(string? searchValue)
        
        =>    mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(unitOfWork.EmployeeRepository.GetAll(searchValue).ToList());
        
    }
}

//if (employee is null) return false;
//else
//{
//    employee.IsDeleted = true;
//    return uintOfWork.EmployeeRepository.Update(employee) > 0 ? true : false;
//}