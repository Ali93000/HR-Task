using HR.Entities.DTOModels.OAuthDto;
using HR.Entities.GenericModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.ApiModels.OAuthModels.Response
{
    public class RefreshTokenResponse : GenericResponse
    {
        public JWTTokenDto JWTTokenDto { get; set; }
    }
}
