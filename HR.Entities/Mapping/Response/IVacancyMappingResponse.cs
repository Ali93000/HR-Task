using HR.Entities.ApiModels.VacancyModels.Response;
using HR.Entities.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.Mapping.Response
{
    public interface IVacancyMappingResponse
    {
        VacanciesResponse MapFromDB_ToVacanciesResponse(List<DB_Vacancy> dB_Vacancies);
    }
}
