using HR.Entities.ApiModels.OAuthModels.Request;
using HR.Entities.ApiModels.OAuthModels.Response;
using HR.Entities.ApiModels.UserModels.Response;
using HR.Entities.DBModels;
using HR.Entities.DTOModels.OAuthDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.Interfaces.OAuthServices
{
    public interface IJwtManager
    {
        Task<JWTTokenDto> GenerateJWT(UserResponse user);
        ReadTokenInfo ReadTokenData(string token = "");

    }
}
