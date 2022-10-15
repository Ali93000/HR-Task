using HR.Entities.EnvironmentConfigurations.Interface;
using HR.Entities.Interfaces.SharedServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.BLL.SharedServices
{
    public class HelperServices : IHelperServices
    {
        private readonly IHelperConfigurations _helperConfigurations;
        public HelperServices(IHelperConfigurations helperConfigurations)
        {
            _helperConfigurations = helperConfigurations;
        }

        public DateTime GetCurrentDateTimeUTC()
        {
            var datetime = DateTime.UtcNow.AddHours(_helperConfigurations.UTCDiff);
            return datetime;
        }
    }
}
