using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.Errors
{
    public class ErrorResponse
    {
        public ErrorResponse()
        {
            Errors = new List<ErrorCustomModel>();
        }
        public List<ErrorCustomModel> Errors { get; set; }
    }
}
