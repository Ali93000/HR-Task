using HR.Entities.ApiModels.VacancyModels.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.BLL.VacancyServices.Queries
{
    public record GetAllVacanciesQuery : IRequest<VacanciesResponse>;
    
}
