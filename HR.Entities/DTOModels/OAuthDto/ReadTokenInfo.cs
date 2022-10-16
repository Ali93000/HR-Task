using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.DTOModels.OAuthDto
{
    public class ReadTokenInfo
    {
        public ReadTokenInfo()
        {
            Roles = new List<string>();
        }
        public string? Email { get; set; }
        public string Jti { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public List<string> Roles { get; set; }
    }
}
