using HR.Entities.ApiModels.VacancyModels.Request;
using HR.UI.Consumer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HR.UI.Controllers
{
    public class VacancyController : Controller
    {
        private readonly IVacancyConsumer _vacancyConsumer;
        public VacancyController(IVacancyConsumer vacancyConsumer)
        {
            _vacancyConsumer = vacancyConsumer;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _vacancyConsumer.GetAllVacancies();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateVacancyRequest createVacancyRequest)
        {
            if (string.IsNullOrWhiteSpace(createVacancyRequest.NameAr))
            {
                ModelState.AddModelError("NameArValidation", "  يجب ادخال اسم الموديل");
                return View();
            }
            createVacancyRequest.NameEn = createVacancyRequest.NameAr;

            var result = await _vacancyConsumer.CreateVacancy(createVacancyRequest);
            if (!result.IsSuccessful)
                return View();
            var models = await _vacancyConsumer.GetAllVacancies();
            return RedirectToAction("Index", models);
        }

    }
}
