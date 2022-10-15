using HR.BLL.VacancyAppliersServices.Commands;
using HR.Entities.DBModels;
using HR.Entities.Enums;
using HR.Entities.GenericModels;
using HR.Entities.Interfaces.OAuthServices;
using HR.Entities.Interfaces.Repository;
using HR.Entities.Interfaces.SharedServices;
using HR.Entities.ValidationMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.BLL.VacancyAppliersServices.Handlers
{
    internal class HRDirectorApprovalHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHelperServices _helperServices;
        private readonly IJwtManager _jwtManager;

        public HRDirectorApprovalHandler(IUnitOfWork unitOfWork,
            IHelperServices helperServices,
            IJwtManager jwtManager)
        {
            _unitOfWork = unitOfWork;
            _helperServices = helperServices;
            _jwtManager = jwtManager;
        }

        public async Task<GenericResponse> Handle(HRDirectorApprovalCommand request, CancellationToken cancellationToken)
        {
            var vacancyApplier = await _unitOfWork.VacancyAppliersRepository.GetFirstOrDefaultAsync(c => c.Id == request.hrManagerApprovalRequest.VacancyApplierId);
            if (vacancyApplier == null)
            {
                return new GenericResponse
                {
                    IsSuccessful = false,
                    ResponseCode = CustomStatusCodes.Appliers_NotFound,
                    ResponseMessages = new List<string> { ValidationMessages.EmptyData("applier") }
                };
            }

            vacancyApplier.Status = (int)VacancyApplierStatus.ApprovedByHRDirector;

            var applierFromDb = await _unitOfWork.VacancyApplierApprovalRepository.GetFirstOrDefaultAsync(c => c.VacancyApplierId == request.hrManagerApprovalRequest.VacancyApplierId);
            if (applierFromDb == null)
            {
                DB_VacancyApplierApproval approval = new DB_VacancyApplierApproval();
                approval.VacancyApplierId = vacancyApplier.Id;
                approval.HrdirectorId = _jwtManager.ReadTokenData().UserId;
                approval.HrdirectorApprovalAt = _helperServices.GetCurrentDateTimeUTC();
                _unitOfWork.VacancyAppliersRepository.Update(vacancyApplier);
                await _unitOfWork.VacancyApplierApprovalRepository.AddAsync(approval);
                await _unitOfWork.SaveAsync();
            }
            else
            {
                applierFromDb.VacancyApplierId = vacancyApplier.Id;
                applierFromDb.HrdirectorId = _jwtManager.ReadTokenData().UserId;
                applierFromDb.HrdirectorApprovalAt = _helperServices.GetCurrentDateTimeUTC();
                vacancyApplier.IsApproved = true;
                _unitOfWork.VacancyAppliersRepository.Update(vacancyApplier);
                _unitOfWork.VacancyApplierApprovalRepository.Update(applierFromDb);
                await _unitOfWork.SaveAsync();
            }
            return new GenericResponse
            {
                IsSuccessful = true,
                ResponseCode = CustomStatusCodes.Success,
                ResponseMessages = new List<string> { SuccessfulyMessages.ApprovedSuccessfuly("applier") }
            };
        }
    }
}
