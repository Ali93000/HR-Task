using HR.BLL.VacancyAppliersServices.Queries;
using HR.Entities.ApiModels.VacancyAppliersModels.Response;
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

namespace HR.BLL.VacancyAppliersServices.Handlers
{
    public class GetAllVacancyAppliersHandler : IRequestHandler<GetAllVacancyAppliersQuery, VacancyAppliersResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVacancyAppliersMappingResponse _vacancyAppliersMappingResponse;
        public GetAllVacancyAppliersHandler(IUnitOfWork unitOfWork,
            IVacancyAppliersMappingResponse vacancyAppliersMappingResponse)
        {
            _unitOfWork = unitOfWork;
            _vacancyAppliersMappingResponse = vacancyAppliersMappingResponse;
        }

        public async Task<VacancyAppliersResponse> Handle(GetAllVacancyAppliersQuery request, CancellationToken cancellationToken)
        {
            var appliers = await _unitOfWork.VacancyAppliersRepository.LoadAllVacancies();
            if (appliers.Count == 0)
            {
                return new VacancyAppliersResponse
                {
                    IsSuccessful = false,
                    ResponseCode = CustomStatusCodes.Appliers_NotFound,
                    ResponseMessages = new List<string>() { ValidationMessages.EmptyData("vacancy appliers") }
                };
            }

            var mapped = _vacancyAppliersMappingResponse.MapFromDB_ToAppliersResponse(appliers);
            return mapped;
        }
    }
}
