using HR.Entities.ApiModels.VacancyAppliersModels.Request;
using HR.Entities.GenericModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.BLL.VacancyAppliersServices.Commands
{
    public record HRDirectorApprovalCommand(HRManagerApprovalRequest hrManagerApprovalRequest) : IRequest<GenericResponse>;
}
