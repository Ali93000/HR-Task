using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.DTOModels.OAuthDto
{
    public class JWTTokenDto
    {
        public int ResponseCode { get; set; }
        public string Message { get; set; }
        public string Expire { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
