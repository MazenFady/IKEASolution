using IKEA.BLL.Dto_s.DepartmentDto_s;
using IKEA.DAL.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Factories
{
    public static class DepartmentFact
    {
        public static DepartmentDto ToDepartmentDto(this Department d)
        {  
            return new DepartmentDto
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description,
                Code = d.Code
            };
        }
        public static DepartmentDetailsDto ToEntity(this Department D)
        {
            return new DepartmentDetailsDto(D);

        }
        public static Department ToDepartment(this CreatedDepartmentDto dto)
        {
            return new Department()
            { 
                Name = dto.Name,
                Description = dto.Description,
                Code = dto.Code,
                CreatedOn= DateTime.Now,
                CreatedBy = 1,
                LastModifiedBy =1,
                LastModifiedOn = DateTime.Now,
                IsDeleted = false
            };
        
        }
        public static Department fromUpdatedDepartment(this UpdatedDepartmentDto dto)
        {
            return new Department()
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Code = dto.Code,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.Now,
                IsDeleted = false
            };

        }


    }
}

    

