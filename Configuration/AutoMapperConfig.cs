using AppStudent.Data;
using AppStudent.Models;
using AutoMapper;
using System.Runtime;

namespace AppStudent.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<StudentDTO, Student>().ReverseMap();
            CreateMap<UserDTO, User>().ReverseMap();
        }
    }
}
