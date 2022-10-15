using HR.Entities.ApiModels.VacancyModels.Response;
using HR.Entities.DBModels;
using HR.Entities.Mapping.MappingConfiguration;
using HR.Entities.Mapping.Response;

namespace HR.Api.MappingImplementations.Response
{
    public class VacancyMappingResponse : IVacancyMappingResponse
    {
        private readonly IVacancyMapperConfiguration _vacancyMapperConfiguration;
        public VacancyMappingResponse(IVacancyMapperConfiguration vacancyMapperConfiguration)
        {
            _vacancyMapperConfiguration = vacancyMapperConfiguration;
        }

        public VacanciesResponse MapFromDB_ToVacanciesResponse(List<DB_Vacancy> dB_Vacancies)
        {
            return _vacancyMapperConfiguration.GetMapper().Map<VacanciesResponse>(dB_Vacancies);
        }
    }
}
