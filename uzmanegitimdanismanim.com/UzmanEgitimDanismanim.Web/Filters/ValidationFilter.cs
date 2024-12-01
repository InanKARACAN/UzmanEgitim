using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using UzmanEgitimDanismanim.Shared.Dtos.CustomDtos;

namespace UzmanEgitimDanismanim.Web.Filters
{
    public class ValidationFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var errorDto = new ErrorDto { Status = 400 };

                IEnumerable<ModelError> modelErrors = context.ModelState.Values.SelectMany(s => s.Errors);

                modelErrors.ToList().ForEach(x => errorDto.Errors.Add(x.ErrorMessage));

                context.Result = new BadRequestObjectResult(errorDto);
            }
        }
    }
}