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
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, UsersResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserMappingResponse _userMappingResponse;

        public GetAllUsersHandler(IUnitOfWork unitOfWork,
             IUserMappingResponse userMappingResponse)
        {
            this._unitOfWork = unitOfWork;
            this._userMappingResponse = userMappingResponse;
        }
        public async Task<UsersResponse> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            if (users.Count == 0)
            {
                return new UsersResponse
                {
                    Users = new List<GetAllUsersDto>(),
                    IsSuccessful = false,
                    ResponseCode = CustomStatusCodes.Users_NotFound,
                    ResponseMessages = new List<string>() { ValidationMessages.EmptyData("Users") }
                };
            }
            // Mapping Data
            var mappedUsers = _userMappingResponse.MapFromDB_ToUsersResponse(users);
            return mappedUsers;
        }
    }
}
