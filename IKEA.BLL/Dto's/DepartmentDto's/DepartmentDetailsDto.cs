using IKEA.DAL.Models.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Dto_s.DepartmentDto_s
{
    public class DepartmentDetailsDto
    {
        public DepartmentDetailsDto(Department Department)
        {
            Id = Department.Id;
            Name = Department.Name;
            Code = Department.Code;
            Description = Department.Description;
            CreatedOn = DateOnly.FromDateTime(Department.CreatedOn);
            CreatedBy = Department.CreatedBy;
            LastModifiedBy = Department.LastModifiedBy;
            LastModifiedOn = DateOnly.FromDateTime(Department.LastModifiedOn);
        }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Code { get; set; }
        public int Id { get; set; } // Primary key
        public int CreatedBy { get; set; } // User ID who created the record USerID

        public DateOnly CreatedOn { get; set; }  // Timestamp of creation

        public int LastModifiedBy { get; set; } // User ID who last modified the record

        public DateOnly LastModifiedOn { get; set; }
    }

}
