using HR.Entities.ApiModels.VacancyAppliersModels.Response;
using HR.Entities.DBModels;
using HR.Entities.Mapping.MappingConfiguration;
using HR.Entities.Mapping.Response;

namespace HR.Api.MappingImplementations.Response
{
    public class VacancyAppliersMappingResponse : IVacancyAppliersMappingResponse
    {
        private readonly IVacancyAppliersMapperConfiguration _vacancyAppliersMapperConfiguration;
        public VacancyAppliersMappingResponse(IVacancyAppliersMapperConfiguration vacancyAppliersMapperConfiguration)
        {
            _vacancyAppliersMapperConfiguration = vacancyAppliersMapperConfiguration;
        }

        public VacancyAppliersResponse MapFromDB_ToAppliersResponse(List<DB_VacancyApplier> dB_VacancyAppliers)
        {
            return _vacancyAppliersMapperConfiguration.GetMapper().Map<VacancyAppliersResponse>(dB_VacancyAppliers);
        }
    }
}
