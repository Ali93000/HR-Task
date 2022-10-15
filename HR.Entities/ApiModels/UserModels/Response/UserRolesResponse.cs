using HR.Entities.DTOModels.UserDto;
using HR.Entities.GenericModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.ApiModels.UserModels.Response
{
    public class UserRolesResponse : GenericResponse
    {
        public UserRolesResponse()
        {
            Roles = new List<UserRolesDto>();
        }
        public List<UserRolesDto> Roles { get; set; }
    }
}
