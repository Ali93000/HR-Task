using HR.Entities.ApiModels.VacancyAppliersModels.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.BLL.VacancyAppliersServices.Queries
{
    public record GetAllVacancyAppliersQuery : IRequest<VacancyAppliersResponse>;

}
