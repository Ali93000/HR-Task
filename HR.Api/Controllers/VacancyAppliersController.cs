using HR.BLL.VacancyAppliersServices.Commands;
using HR.BLL.VacancyAppliersServices.Queries;
using HR.Entities.ApiModels.VacancyAppliersModels.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers
{
    [Route("api/v1/vacancy-appliers")]
    [ApiController]
    public class VacancyAppliersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public VacancyAppliersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllVacancyAppliers()
        {
            var applies = await _mediator.Send(new GetAllVacancyAppliersQuery());
            if (applies.VacancyAppliers.Count == 0)
                return NotFound(applies);
            if(!applies.IsSuccessful)
                return BadRequest(applies);
            return Ok(applies);
        }

        [Authorize(Roles = "HR Officer")]
        [HttpPost]
        public async Task<IActionResult> CreateVacancyAppliers([FromBody] CreateVacancyApplierRequest createVacancyApplierRequest)
        {
            var applies = await _mediator.Send(new CreateVacancyAppliersCommand(createVacancyApplierRequest));
            if(!applies.IsSuccessful)
                return BadRequest(applies);
            return Ok(applies);
        }
    }
}
