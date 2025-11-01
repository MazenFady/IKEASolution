﻿using IKEA.BLL.Dto_s.DepartmentDto_s;
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
        public IEnumerable<EmployeeDto> GetAllEmployees();
        public EmployeeDetailsDto GetEmployeeById(int Id);

        public int CreateEmployee(CreatedEmployeeDto dto);
        public int UpdateEmployee(UpdatedEmployeeDto dto);
        public int DeleteEmployee(int? id); 
    }
}
