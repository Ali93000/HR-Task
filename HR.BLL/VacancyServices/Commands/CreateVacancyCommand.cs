using HR.Entities.ApiModels.VacancyModels.Request;
using HR.Entities.GenericModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.BLL.VacancyServices.Commands
{
    public record CreateVacancyCommand(CreateVacancyRequest CreateVacancyRequest) : IRequest<GenericResponse>;
    
}
