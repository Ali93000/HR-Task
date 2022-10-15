using HR.Entities.ApiModels.VacancyAppliersModels.Request;
using HR.Entities.ApiModels.VacancyModels.Request;
using HR.UI.Consumer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HR.UI.Controllers
{
    public class CandicateController : Controller
    {
        private readonly IVacancyConsumer _vacancyConsumer;
        private readonly ICandicateConsumer _candicateConsumer;
        public CandicateController(IVacancyConsumer vacancyConsumer, ICandicateConsumer candicateConsumer)
        {
            _vacancyConsumer = vacancyConsumer;
            _candicateConsumer = candicateConsumer;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var vacancy = await _vacancyConsumer.GetAllVacancies();
            ViewBag.Vacancies = vacancy.Vacancies;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateVacancyApplierRequest createVacancyApplierRequest)
        {
            var vacancy = await _vacancyConsumer.GetAllVacancies();
            ViewBag.Vacancies = vacancy.Vacancies;

            if (string.IsNullOrWhiteSpace(createVacancyApplierRequest.FullName))
            {
                ModelState.AddModelError("FullNameValidation", "  يجب ادخال اسم المرشح");
                return View();
            }
            if (string.IsNullOrWhiteSpace(createVacancyApplierRequest.Email))
            {
                ModelState.AddModelError("EmailValidation", "  يجب ادخال البريد الالكترونى");
                return View();
            }
            if (string.IsNullOrWhiteSpace(createVacancyApplierRequest.MobileNumber))
            {
                ModelState.AddModelError("MobileNumberValidation", "  يجب ادخال رقم الهاتف");
                return View();
            }
            if (string.IsNullOrWhiteSpace(createVacancyApplierRequest.UploadedResume))
            {
                ModelState.AddModelError("UploadedResumeValidation", "  يجب ارفاق السيرة الذاتية");
                return View();
            }  
            if (createVacancyApplierRequest.VacancyId == 0)
            {
                ModelState.AddModelError("VacancyIdValidation", "  يجب اختيار فئة الوظيفة");
                return View();
            }
            
            var result = await _candicateConsumer.CreateVacancyApplier(createVacancyApplierRequest);
            if (!result.IsSuccessful)
                return View();
            var models = await _vacancyConsumer.GetAllVacancies();
            return RedirectToAction("Index", models);
        }
    }
}
