using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Dto_s.DepartmentDto_s
{
    public class CreatedDepartmentDto
    {
        [Required(ErrorMessage ="Name Is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Code Is Required")]
        public string Code { get; set; }
        
        [Required(ErrorMessage = "Description Is Required")]
        public string? Description { get; set; }
    }
}
