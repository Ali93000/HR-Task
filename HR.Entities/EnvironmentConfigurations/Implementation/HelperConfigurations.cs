using HR.Entities.EnvironmentConfigurations.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.EnvironmentConfigurations.Implementation
{
    public class HelperConfigurations : IHelperConfigurations
    {
        public int UTCDiff { get; set; }

    }
}
