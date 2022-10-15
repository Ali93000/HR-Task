using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.GenericModels
{
    public class CustomStatusCodes
    {
        public static int Success { get; set; } = 5000;
        public static int Created { get; set; } = 5001;
        public static int NotFound { get; set; } = 5004;
        public static int Users_NotFound { get; set; } = 5010;
        public static int Vacancies_NotFound { get; set; } = 5011;
        public static int Appliers_NotFound { get; set; } = 5012;

        public static int Failed { get; set; } = 5999;
    }
}
