using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.ValidationMessages
{
    public static class ValidationMessages
    {
        public static string EmptyData(string modelName)
        {
            return $"not available {modelName}";
        }
    }
}
