using AutoMapper;
using CompanyG02.DAL.Models;
using System.Runtime.InteropServices;
using WebManarApplication.Models;

namespace WebManarApplication.MapperProfile
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();
        }
    }
}
