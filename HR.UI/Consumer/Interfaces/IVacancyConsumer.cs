using HR.Entities.ApiModels.VacancyModels.Request;
using HR.Entities.ApiModels.VacancyModels.Response;
using HR.Entities.GenericModels;

namespace HR.UI.Consumer.Interfaces
{
    public interface IVacancyConsumer
    {
        Task<VacanciesResponse> GetAllVacancies();
        Task<GenericResponse> CreateVacancy(CreateVacancyRequest data);

    }
}
