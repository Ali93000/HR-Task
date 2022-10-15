using HR.Entities.Errors;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace HR.Api.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                // To extract Validation Error only
                var errorsInModel = context.ModelState.Where(c => c.Value.Errors.Count > 0)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(c => c.ErrorMessage));

                ErrorResponse errorResponse = new ErrorResponse();
                foreach (var error in errorsInModel)
                {
                    foreach (var item in error.Value)
                    {
                        ErrorCustomModel errorModel = new ErrorCustomModel()
                        {
                            FieldName = error.Key,
                            Message = item
                        };
                        errorResponse.Errors.Add(errorModel);
                    }
                }
                context.Result = new BadRequestObjectResult(errorResponse);
            }
        }
    }
}
