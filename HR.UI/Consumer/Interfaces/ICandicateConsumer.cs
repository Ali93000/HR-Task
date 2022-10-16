using HR.Entities.ApiModels.VacancyAppliersModels.Request;
using HR.Entities.ApiModels.VacancyAppliersModels.Response;
using HR.Entities.ApiModels.VacancyModels.Request;
using HR.Entities.ApiModels.VacancyModels.Response;
using HR.Entities.GenericModels;

namespace HR.UI.Consumer.Interfaces
{
    public interface ICandicateConsumer
    {
        Task<VacancyAppliersResponse> GetAllVacancyAppliers();
        Task<GenericResponse> CreateVacancyApplier(CreateVacancyApplierRequest data);
        Task<GenericResponse> ApproveByDirector(HRManagerApprovalRequest data);
        Task<GenericResponse> ApproveByManager(HRManagerApprovalRequest data);
    }
}
