using HR.BLL.UserServices.Queries;
using HR.Entities.ApiModels.OAuthModels.Request;
using HR.Entities.Interfaces.OAuthServices;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers
{
    [Route("api/v1/oauth")]
    [ApiController]
    public class OAuthController : ControllerBase
    {
        private readonly IJwtManager _jwtManager;
        private readonly IMediator _mediator;
        public OAuthController(IJwtManager jwtManager,
            IMediator mediator)
        {
            this._jwtManager = jwtManager;
            this._mediator = mediator;
        }

        [HttpPost, Route("token")]
        public async Task<IActionResult> Get([FromBody] GenerateTokenRequest tokenRequest)
        {
            // Load user data to check credentials
            var user = await _mediator.Send(new VerifyLoggedInUserQuery(tokenRequest));
            if (user == null)
                return BadRequest("Invalid username or password");
            var token = await _jwtManager.GenerateJWT(user);
            return Ok(token);
        }
    }
}
