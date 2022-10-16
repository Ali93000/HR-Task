using HR.BLL.VacancyAppliersServices.Commands;
using HR.Entities.Enums;
using HR.Entities.GenericModels;
using HR.Entities.Interfaces.OAuthServices;
using HR.Entities.Interfaces.Repository;
using HR.Entities.Interfaces.SharedServices;
using HR.Entities.Mapping.Request;
using HR.Entities.ValidationMessages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.BLL.VacancyAppliersServices.Handlers
{
    public class CreateVacancyAppliersHandler : IRequestHandler<CreateVacancyAppliersCommand, GenericResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVacancyAppliersMappingRequest _vacancyAppliersMappingRequest;
        private readonly IHelperServices _helperServices;
        private readonly IJwtManager _jwtManager;

        public CreateVacancyAppliersHandler(IUnitOfWork unitOfWork,
            IVacancyAppliersMappingRequest vacancyAppliersMappingRequest,
            IHelperServices helperServices,
            IJwtManager jwtManager)
        {
            _unitOfWork = unitOfWork;
            _vacancyAppliersMappingRequest = vacancyAppliersMappingRequest;
            _helperServices = helperServices;
            _jwtManager = jwtManager;
        }

        public async Task<GenericResponse> Handle(CreateVacancyAppliersCommand request, CancellationToken cancellationToken)
        {
            var mapped = _vacancyAppliersMappingRequest.MapFromCreateApplier_ToDB(request.createVacancyApplierRequest);
            mapped.CreatedAt = _helperServices.GetCurrentDateTimeUTC();
            mapped.CreatedBy = _jwtManager.ReadTokenData().UserName;
            mapped.Status = (int)VacancyApplierStatus.CreateByHROffice;
            mapped.UploadedResume = request.createVacancyApplierRequest.CV.FileName;

            string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "Files"));
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (var fileStream = new FileStream(Path.Combine(path, request.createVacancyApplierRequest.CV.FileName), FileMode.Create))
            {
                await request.createVacancyApplierRequest.CV.CopyToAsync(fileStream);
            }
            await _unitOfWork.VacancyAppliersRepository.AddAsync(mapped);
            await _unitOfWork.SaveAsync();
            return new GenericResponse()
            {
                IsSuccessful = true,
                ResponseCode = CustomStatusCodes.Created,
                ResponseMessages = new List<string> { SuccessfulyMessages.CreatedSuccessfuly("Applier") }
            };
        }
    }
}
