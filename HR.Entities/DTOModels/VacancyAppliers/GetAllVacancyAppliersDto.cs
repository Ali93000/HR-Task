using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.DTOModels.VacancyAppliers
{
    public class GetAllVacancyAppliersDto
    {
        public int? Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public string? UploadedResume { get; set; }
        public int? Status { get; set; }
        public int? VacancyId { get; set; }
        public string VacancyName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
    }
}
