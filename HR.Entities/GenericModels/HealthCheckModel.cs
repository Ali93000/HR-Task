using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.GenericModels
{
    public class HealthCheckModel
    {
        public string Service { get; set; }
        public string Message { get; set; }
        public string DateTimeChecked { get; set; }
        public bool IsHealthy { get; set; }
    }
}
