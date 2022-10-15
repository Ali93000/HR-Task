using HR.Entities.EnvironmentConfigurations.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.EnvironmentConfigurations.Implementation
{
    internal class HRConfigurations : IHRConfigurations
    {
        public string ApiUrl { get; set; }

    }
}
