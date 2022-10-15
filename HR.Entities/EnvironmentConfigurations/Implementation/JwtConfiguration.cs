using HR.Entities.EnvironmentConfigurations.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.EnvironmentConfigurations.Implementation
{
    public class JwtConfiguration : IJwtConfiguration
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpireIn { get; set; }
    }
}
