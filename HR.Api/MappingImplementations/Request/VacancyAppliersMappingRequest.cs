using HR.Entities.ApiModels.VacancyAppliersModels.Request;
using HR.Entities.DBModels;
using HR.Entities.Mapping.MappingConfiguration;
using HR.Entities.Mapping.Request;

namespace HR.Api.MappingImplementations.Request
{
    public class VacancyAppliersMappingRequest : IVacancyAppliersMappingRequest
    {
        private IVacancyAppliersMapperConfiguration _vacancyAppliersMapperConfiguration;
        public VacancyAppliersMappingRequest(IVacancyAppliersMapperConfiguration vacancyAppliersMapperConfiguration)
        {
            _vacancyAppliersMapperConfiguration = vacancyAppliersMapperConfiguration;
        }

        public DB_VacancyApplier MapFromCreateApplier_ToDB(CreateVacancyApplierRequest createVacancyApplierRequest)
        {
            return _vacancyAppliersMapperConfiguration.GetMapper().Map<DB_VacancyApplier>(createVacancyApplierRequest);
        }
    }
}
