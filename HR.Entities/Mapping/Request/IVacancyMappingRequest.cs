using HR.Entities.ApiModels.VacancyModels.Request;
using HR.Entities.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Entities.Mapping.Request
{
    public interface IVacancyMappingRequest
    {
        DB_Vacancy MapFromCreateRequest_ToDB(CreateVacancyRequest createVacancyRequest);
    }
}
