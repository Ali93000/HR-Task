using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.ValidationMessages
{
    public static class SuccessfulyMessages
    {
        public static string AccessTokenGeneratedSuccessfuly()
        {
            return "access token generated successfuly";
        }
        
        public static string CreatedSuccessfuly(string model)
        {
            return $"{model} created successfuly";
        }

    }
}
