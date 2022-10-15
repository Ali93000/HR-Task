using HR.Entities.GenericModels;
using HR.Entities.Interfaces.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers
{
    [Route("api/v1/helper")]
    [ApiController]
    public class HelpersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public HelpersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("check-db-conection")]
        [Produces("application/json", Type = typeof(HealthCheckModel))]
        public async Task<IActionResult> Get()
        {
            var dbResult = await _unitOfWork.CheckDbConnectionStatus();
            var result = new List<HealthCheckModel>()
            {
                new HealthCheckModel()
                {
                    Service="Database",
                    Message = dbResult.ResponseMessages.First(),
                    IsHealthy= dbResult.IsSuccessful,
                    DateTimeChecked=DateTime.Now.ToString()
                }
            };

            return Ok(result);
        }
    }
}
