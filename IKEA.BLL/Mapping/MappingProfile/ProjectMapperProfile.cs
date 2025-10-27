using AutoMapper;
using IKEA.BLL.Dto_s.EmployeeDto_s;
using IKEA.DAL.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Mapping.MappingProfile
{
    public class ProjectMapperProfile : Profile
    {
        public ProjectMapperProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();

            CreateMap<Employee, EmployeeDetailsDto>().ReverseMap();

            CreateMap<CreatedEmployeeDto, Employee>()
                .ForMember(dest=> dest.EmployeeType , options=> options.MapFrom(src=> src.EmpType))
            .ForMember(dest => dest.Gender, options => options.MapFrom(src => src.EmpGender));
            CreateMap<UpdatedEmployeeDto, Employee>().ReverseMap();


        }
    }
}
