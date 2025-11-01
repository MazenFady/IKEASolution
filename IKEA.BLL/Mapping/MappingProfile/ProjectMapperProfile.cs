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
            CreateMap<Employee, EmployeeDto>().ForMember(dest => dest.EmployeeType, options => options.MapFrom(src => src.EmployeeType))
            .ForMember(dest => dest.Gender, options => options.MapFrom(src => src.Gender)).ReverseMap();

            CreateMap<Employee, EmployeeDetailsDto>()
                .ForMember(dest => dest.Gender , option => option.MapFrom(src => src.Gender))
                .ForMember(dest => dest.EmployeeType, option => option.MapFrom(src => src.EmployeeType))
                .ForMember(dest => dest.HiringDate, option => option.MapFrom(src => DateOnly.FromDateTime(src.HiringDate))).ReverseMap();

            CreateMap<CreatedEmployeeDto, Employee>()
                .ForMember(dest => dest.HiringDate, option => option.MapFrom(src => src.HiringDate.ToDateTime(new TimeOnly()))).ReverseMap();

            CreateMap<UpdatedEmployeeDto, Employee>()
                .ForMember(dest => dest.HiringDate, option => option.MapFrom(src => src.HiringDate.ToDateTime(new TimeOnly()))).ReverseMap();
            


        }
    }
}
 