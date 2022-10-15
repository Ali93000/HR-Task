using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.ApiModels.VacancyAppliersModels.Request
{
    public class CreateVacancyApplierRequest
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string UploadedResume { get; set; }
        //public int? Status { get; set; }
        public int VacancyId { get; set; }
    }
}
