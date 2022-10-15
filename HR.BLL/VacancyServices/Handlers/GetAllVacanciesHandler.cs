using HR.BLL.VacancyServices.Queries;
using HR.Entities.ApiModels.VacancyModels.Response;
using HR.Entities.DTOModels.VacancyDto;
using HR.Entities.GenericModels;
using HR.Entities.Interfaces.Repository;
using HR.Entities.Mapping.Response;
using HR.Entities.ValidationMessages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.BLL.VacancyServices.Handlers
{
    public class GetAllVacanciesHandler : IRequestHandler<GetAllVacanciesQuery, VacanciesResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVacancyMappingResponse _vacancyMappingResponse;
        public GetAllVacanciesHandler(IUnitOfWork unitOfWork,
            IVacancyMappingResponse vacancyMappingResponse)
        {
            _unitOfWork = unitOfWork;
            this._vacancyMappingResponse = vacancyMappingResponse;
        }

        public async Task<VacanciesResponse> Handle(GetAllVacanciesQuery request, CancellationToken cancellationToken)
        {
            var vacancies = await _unitOfWork.VacancyRepository.GetAsync(c => c.IsActive);
            if (vacancies.Count == 0)
            {
                return new VacanciesResponse
                {
                    Vacancies = new List<GetAllVacanciesDto>(),
                    IsSuccessful = false,
                    ResponseCode = CustomStatusCodes.Vacancies_NotFound,
                    ResponseMessages = new List<string> { ValidationMessages.EmptyData("Vacancies") }
                };
            }

            var mapped = _vacancyMappingResponse.MapFromDB_ToVacanciesResponse(vacancies);
            return mapped;
        }
    }
}
