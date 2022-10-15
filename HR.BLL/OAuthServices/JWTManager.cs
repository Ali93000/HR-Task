using HR.BLL.UserServices.Queries;
using HR.Entities.ApiModels.UserModels.Response;
using HR.Entities.DBModels;
using HR.Entities.DTOModels.OAuthDto;
using HR.Entities.DTOModels.UserDto;
using HR.Entities.EnvironmentConfigurations.Interface;
using HR.Entities.Interfaces.OAuthServices;
using HR.Entities.ValidationMessages;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HR.BLL.OAuthServices
{
    public class JWTManager : IJwtManager
    {
        private readonly IJwtConfiguration _jwtConfiguration;
        private readonly IMediator _mediator;
        public JWTManager(IJwtConfiguration jwtConfiguration,
            IMediator mediator)
        {
            _jwtConfiguration = jwtConfiguration;
            _mediator = mediator;
        }

        public async Task<JWTTokenDto> GenerateJWT(UserResponse user)
        {
            // 1- load all user claims
            var userRoles = await _mediator.Send(new GetAllUserRolesByIdQuery(user.User.Id));
            var roles = GetUserRoles(userRoles.Roles, user.User);

            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtConfiguration.Key));
            var signinCredentioals = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Create the JWT and write it to a string
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtConfiguration.Issuer,
                audience: _jwtConfiguration.Audience,
                claims: roles,
                expires: DateTime.Now.AddMinutes(_jwtConfiguration.ExpireIn),
                signingCredentials: signinCredentioals);

            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            JWTTokenDto jwtTokenDto = new JWTTokenDto()
            {
                Message = SuccessfulyMessages.AccessTokenGeneratedSuccessfuly(),
                ResponseCode = (int)HttpStatusCode.OK,
                AccessToken = token,
                Expire = DateTime.Now.AddMinutes(_jwtConfiguration.ExpireIn).ToString()
            };
            return jwtTokenDto;
        }

        private List<Claim> GetUserRoles(List<UserRolesDto> roles, GetAllUsersDto user)
        {
           List<Claim> _roles = new List<Claim>();
            _roles.Add(new Claim(JwtRegisteredClaimNames.Sub, ""));// subjesct
            _roles.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            _roles.Add(new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString())); // JWT ID  (used in open Id connect) 
            _roles.Add(new Claim("UserId", user.Id.ToString()));
            _roles.Add(new Claim("UserName", user.UserName));

            if (roles.Count != 0)
            {
                foreach (var item in roles)
                {
                    Claim claim = new Claim(ClaimTypes.Role, item.RoleName);
                    _roles.Add(claim);
                }
            }
            return _roles;
        }

        public ReadTokenInfo ReadTokenData(string token = "")
        {
            return new ReadTokenInfo();
        }
    }
}
