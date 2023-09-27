using AutoMapper;
using CleanArquitecture.Core.Entities;

namespace CleanArquitecture.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
        }
    }
}
