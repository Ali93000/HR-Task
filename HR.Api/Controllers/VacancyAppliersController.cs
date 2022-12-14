using HR.BLL.VacancyAppliersServices.Commands;
using HR.BLL.VacancyAppliersServices.Queries;
using HR.BLL.VacancyServices.Commands;
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
        public async Task<IActionResult> CreateVacancyAppliers([FromForm] CreateVacancyApplierRequest createVacancyApplierRequest)
        {
            var applies = await _mediator.Send(new CreateVacancyAppliersCommand(createVacancyApplierRequest));
            if(!applies.IsSuccessful)
                return BadRequest(applies);
            return Ok(applies);
        }  
        
        [Authorize(Roles = "HR Manager")]
        [HttpPost("manager-approval")]
        public async Task<IActionResult> ApproveApplierByHRManager([FromBody] HRManagerApprovalRequest hrManagerApprovalRequest)
        {
            var applies = await _mediator.Send(new HRManagerApprovalCommand(hrManagerApprovalRequest));
            if(!applies.IsSuccessful)
                return BadRequest(applies);
            return Ok(applies);
        } 
        
        [Authorize(Roles = "HR Director")]
        [HttpPost("director-approval")]
        public async Task<IActionResult> ApproveApplierByHRDirector([FromBody] HRManagerApprovalRequest hrManagerApprovalRequest)
        {
            var applies = await _mediator.Send(new HRDirectorApprovalCommand(hrManagerApprovalRequest));
            if(!applies.IsSuccessful)
                return BadRequest(applies);
            return Ok(applies);
        }
    }
}
