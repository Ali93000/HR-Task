using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.DBModels
{
    public class DB_Vacancy
    {
        public DB_Vacancy()
        {
            VacancyAppliers = new HashSet<DB_VacancyApplier>();
        }

        public int Id { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }

        public virtual ICollection<DB_VacancyApplier> VacancyAppliers { get; set; }
    }
}
