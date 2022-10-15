using HR.BLL.VacancyServices.Commands;
using HR.Entities.GenericModels;
using HR.Entities.Interfaces.OAuthServices;
using HR.Entities.Interfaces.Repository;
using HR.Entities.Interfaces.SharedServices;
using HR.Entities.Mapping.Request;
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
    public class CreateVacancyHandler : IRequestHandler<CreateVacancyCommand, GenericResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVacancyMappingRequest _vacancyMappingRequest;
        private readonly IHelperServices _helperServices;
        private readonly IJwtManager _jwtManager;

        public CreateVacancyHandler(IUnitOfWork unitOfWork,
            IVacancyMappingRequest vacancyMappingRequest,
            IHelperServices helperServices,
            IJwtManager jwtManager)
        {
            _unitOfWork = unitOfWork;
            _vacancyMappingRequest = vacancyMappingRequest;
            _helperServices = helperServices;
            _jwtManager = jwtManager;
        }

        public async Task<GenericResponse> Handle(CreateVacancyCommand request, CancellationToken cancellationToken)
        {
            var mapped = _vacancyMappingRequest.MapFromCreateRequest_ToDB(request.CreateVacancyRequest);
            mapped.IsActive = true;
            mapped.CreatedAt = _helperServices.GetCurrentDateTimeUTC();
            mapped.CreatedBy = _jwtManager.ReadTokenData().UserName;
            await _unitOfWork.VacancyRepository.AddAsync(mapped);
            await _unitOfWork.SaveAsync();
            return new GenericResponse()
            {
                IsSuccessful = true,
                ResponseCode = CustomStatusCodes.Created,
                ResponseMessages = new List<string> { SuccessfulyMessages.CreatedSuccessfuly("vacancy") }
            };
        }
    }
}
