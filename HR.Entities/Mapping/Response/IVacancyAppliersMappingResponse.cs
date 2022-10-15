using HR.Entities.ApiModels.VacancyAppliersModels.Response;
using HR.Entities.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.Mapping.Response
{
    public interface IVacancyAppliersMappingResponse
    {
        VacancyAppliersResponse MapFromDB_ToAppliersResponse(List<DB_VacancyApplier> dB_VacancyAppliers);
    }
}
