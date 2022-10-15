using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.DBModels
{
    public class DB_VacancyApplierApproval
    {
        public int Id { get; set; }
        public int? VacancyApplierId { get; set; }
        public int? HrmanagerId { get; set; }
        public DateTime? HrmanagerApprovedAt { get; set; }
        public int? HrdirectorId { get; set; }
        public DateTime? HrdirectorApprovalAt { get; set; }

        public virtual DB_VacancyApplier? VacancyApplier { get; set; }
    }
}
