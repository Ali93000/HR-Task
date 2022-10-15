using AutoMapper;
using HR.Entities.ApiModels.UserModels.Response;
using HR.Entities.DBModels;
using HR.Entities.DTOModels.UserDto;
using HR.Entities.Mapping.MappingConfiguration;

namespace HR.Api.MappingImplementations.MappingConfiguration
{
    public class UserMapperConfiguration : IUserMapperConfiguration
    {
        public IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DB_User, GetAllUsersDto>();
                cfg.CreateMap<List<DB_User>, UsersResponse>()
                    .ForMember(des => des.Users, map => map.MapFrom(src => src));

                cfg.CreateMap<DB_User, UserResponse>()
                    .ForMember(des => des.User, map => map.MapFrom(src => src));


                // Map User Roles
                cfg.CreateMap<DB_UserRole, UserRolesDto>()
                    .ForMember(des => des.RoleName, map => map.MapFrom(src => src.Role.RoleName));

                cfg.CreateMap<List<DB_UserRole>, UserRolesResponse>()
                    .ForMember(des => des.Roles, map => map.MapFrom(src => src));
            });
            return config.CreateMapper();
        }
    }
}
