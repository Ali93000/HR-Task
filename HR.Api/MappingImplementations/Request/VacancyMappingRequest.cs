using HR.Entities.ApiModels.VacancyModels.Request;
using HR.Entities.DBModels;
using HR.Entities.Mapping.MappingConfiguration;
using HR.Entities.Mapping.Request;

namespace HR.Api.MappingImplementations.Request
{
    public class VacancyMappingRequest : IVacancyMappingRequest
    {
        private readonly IVacancyMapperConfiguration _vacancyMapperConfiguration;
        public VacancyMappingRequest(IVacancyMapperConfiguration vacancyMapperConfiguration)
        {
            _vacancyMapperConfiguration = vacancyMapperConfiguration;
        }

        public DB_Vacancy MapFromCreateRequest_ToDB(CreateVacancyRequest createVacancyRequest)
        {
            return _vacancyMapperConfiguration.GetMapper().Map<DB_Vacancy>(createVacancyRequest);
        }
    }
}
