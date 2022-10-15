using HR.BLL.VacancyServices.Commands;
using HR.BLL.VacancyServices.Queries;
using HR.Entities.ApiModels.VacancyModels.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Controllers
{
    [Route("api/vacancy")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public VacancyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVacancies()
        {
            var vacancies = await _mediator.Send(new GetAllVacanciesQuery());
            if (vacancies.Vacancies.Count == 0)
                return NotFound(vacancies);
            if (!vacancies.IsSuccessful)
                return BadRequest(vacancies);
            return Ok(vacancies);
        }

        [Authorize(Roles = "HR Manager")]
        [HttpPost]
        public async Task<IActionResult> CreateVacancy(CreateVacancyRequest createVacancyRequest)
        {
            var vacancies = await _mediator.Send(new CreateVacancyCommand(createVacancyRequest));
            if (!vacancies.IsSuccessful)
                return BadRequest(vacancies);
            return Ok(vacancies);
        }
    }
}
