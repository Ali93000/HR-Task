using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.DBModels
{
    public class DB_VacancyApplier
    {
        public int? Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public string? UploadedResume { get; set; }
        public int? Status { get; set; }
        public int? VacancyId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }

        public virtual DB_Vacancy? Vacancy { get; set; }
    }
}
