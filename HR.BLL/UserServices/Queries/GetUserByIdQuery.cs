using HR.Entities.ApiModels.UserModels.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.BLL.UserServices.Queries
{
    public record GetUserByIdQuery(int id) : IRequest<UserResponse>;
}
