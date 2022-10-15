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
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserMappingResponse _userMappingResponse;

        public GetUserByIdHandler(IUnitOfWork unitOfWork,
             IUserMappingResponse userMappingResponse)
        {
            this._unitOfWork = unitOfWork;
            this._userMappingResponse = userMappingResponse;
        }
        public async Task<UserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetFirstOrDefaultAsync(c => c.Id == request.id); ;
            if (user == null)
            {
                return new UserResponse
                {
                    User = new GetAllUsersDto(),
                    IsSuccessful = false,
                    ResponseCode = CustomStatusCodes.Users_NotFound,
                    ResponseMessages = new List<string>() { ValidationMessages.EmptyData("Users") }
                };
            }
            // Mapping Data
            var mappedUser = _userMappingResponse.MapFromDB_ToUserResponse(user);
            return mappedUser;
        }
    }
}
