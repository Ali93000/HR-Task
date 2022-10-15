using HR.BLL.UserServices.Queries;
using HR.Entities.ApiModels.UserModels.Response;
using HR.Entities.DTOModels.UserDto;
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

namespace HR.BLL.UserServices.Handlers
{
    public class GetAllUserRolesByIdHandler : IRequestHandler<GetAllUserRolesByIdQuery, UserRolesResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserMappingResponse _userMappingResponse;

        public GetAllUserRolesByIdHandler(IUnitOfWork unitOfWork,
             IUserMappingResponse userMappingResponse)
        {
            this._unitOfWork = unitOfWork;
            this._userMappingResponse = userMappingResponse;
        }
        public async Task<UserRolesResponse> Handle(GetAllUserRolesByIdQuery request, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.UserRolesRepository.GetAllUserRoles(request.userId);
            if (users.Count == 0)
            {
                return new UserRolesResponse
                {
                    Roles = new List<UserRolesDto>(),
                    IsSuccessful = false,
                    ResponseCode = CustomStatusCodes.Users_NotFound,
                    ResponseMessages = new List<string>() { ValidationMessages.EmptyData("Users") }
                };
            }
            // Mapping Data
            var mappedUsers = _userMappingResponse.MapFromDB_ToUserRolesResponse(users);
            return mappedUsers;
        }
    }
}
