using HR.Entities.ApiModels.VacancyAppliersModels.Request;
using HR.Entities.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.Mapping.Request
{
    public interface IVacancyAppliersMappingRequest
    {
        DB_VacancyApplier MapFromCreateApplier_ToDB(CreateVacancyApplierRequest createVacancyApplierRequest);
    }
}
