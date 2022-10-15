using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.GenericModels
{
    public class GenericResponse
    {
        public GenericResponse()
        {
            ResponseMessages = new List<string>();
        }
        public int ResponseCode { get; set; } = CustomStatusCodes.Success;
        public bool IsSuccessful { get; set; } = true;
        public List<string> ResponseMessages { get; set; }
    }
}
