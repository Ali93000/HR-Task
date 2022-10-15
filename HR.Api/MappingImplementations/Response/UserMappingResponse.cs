using HR.Entities.ApiModels.UserModels.Response;
using HR.Entities.DBModels;
using HR.Entities.Mapping.MappingConfiguration;
using HR.Entities.Mapping.Response;

namespace HR.Api.MappingImplementations.Response
{
    public class UserMappingResponse : IUserMappingResponse
    {
        private readonly IUserMapperConfiguration _userMapperConfiguration;
        public UserMappingResponse(IUserMapperConfiguration userMapperConfiguration)
        {
            this._userMapperConfiguration = userMapperConfiguration;
        }

        public UserResponse MapFromDB_ToUserResponse(DB_User user)
        {
            return _userMapperConfiguration.GetMapper().Map<UserResponse>(user);
        }

        public UserRolesResponse MapFromDB_ToUserRolesResponse(List<DB_UserRole> dB_UserRoles)
        {
            return _userMapperConfiguration.GetMapper().Map<UserRolesResponse>(dB_UserRoles);
        }

        public UsersResponse MapFromDB_ToUsersResponse(List<DB_User> users)
        {
            return _userMapperConfiguration.GetMapper().Map<UsersResponse>(users);
        }
    }
}
