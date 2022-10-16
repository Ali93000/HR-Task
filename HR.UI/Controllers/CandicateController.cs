using HR.Entities.ApiModels.VacancyAppliersModels.Request;
using HR.Entities.ApiModels.VacancyModels.Request;
using HR.Entities.Interfaces.OAuthServices;
using HR.UI.Consumer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HR.UI.Controllers
{
    public class CandicateController : Controller
    {
        private readonly IVacancyConsumer _vacancyConsumer;
        private readonly ICandicateConsumer _candicateConsumer;
        private readonly IJwtManager _jwtManager;
        public CandicateController(IVacancyConsumer vacancyConsumer, ICandicateConsumer candicateConsumer,
            IJwtManager jwtManager)
        {
            _vacancyConsumer = vacancyConsumer;
            _candicateConsumer = candicateConsumer;
            _jwtManager = jwtManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _candicateConsumer.GetAllVacancyAppliers();
            var applier = result.VacancyAppliers.Where(c => c.Id == id).FirstOrDefault();
            return View(applier);
        } 
        
        public async Task<IActionResult> Approve(int id)
        {
            var roles = _jwtManager.ReadTokenData().Roles;
            if (roles.Contains("HR Manager"))
            {
                var res = await _candicateConsumer.ApproveByManager(new HRManagerApprovalRequest { VacancyApplierId = id });
            }   
            if (roles.Contains("HR Director"))
            {
                var res = await _candicateConsumer.ApproveByDirector(new HRManagerApprovalRequest { VacancyApplierId = id });
            }
            return View();
        }

        public async Task<IActionResult> Result(int id)
        {
            var result = await _candicateConsumer.GetAllVacancyAppliers();

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
            //if (string.IsNullOrWhiteSpace(createVacancyApplierRequest.UploadedResume))
            //{
            //    ModelState.AddModelError("UploadedResumeValidation", "  يجب ارفاق السيرة الذاتية");
            //    return View();
            //}  
            if (createVacancyApplierRequest.VacancyId == 0)
            {
                ModelState.AddModelError("VacancyIdValidation", "  يجب اختيار فئة الوظيفة");
                return View();
            }
            
            var result = await _candicateConsumer.CreateVacancyApplier(createVacancyApplierRequest);
            if (!result.IsSuccessful)
                return View();
            var models = await _candicateConsumer.GetAllVacancyAppliers();
            return RedirectToAction("Index", models);
        }
    }
}
