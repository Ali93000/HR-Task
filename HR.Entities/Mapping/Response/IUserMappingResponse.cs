using HR.Entities.ApiModels.UserModels.Response;
using HR.Entities.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.Mapping.Response
{
    public interface IUserMappingResponse
    {
        UsersResponse MapFromDB_ToUsersResponse(List<DB_User> users);
        UserResponse MapFromDB_ToUserResponse(DB_User user);
        UserRolesResponse MapFromDB_ToUserRolesResponse(List<DB_UserRole> dB_UserRole);
    }
}
