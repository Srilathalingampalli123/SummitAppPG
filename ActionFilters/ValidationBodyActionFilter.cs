using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using SummitAppDemo.Contracts.Responses;

namespace SummitAppDemo.ActionFilters
{
    public class ValidationBodyActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errorsInModelState = context.ModelState
                                                .Where(x => x.Value.Errors.Count > 0)
                                                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage)).ToArray();

                var errorresponse = new ErrorResponse() { Errors = new List<ErrorModel>() };
                foreach (var error in errorsInModelState)
                {
                    foreach (var suberror in error.Value)
                    {
                        errorresponse.Errors.Add(new ErrorModel()
                        {
                            FieldName = error.Key,
                            Message = suberror
                        });
                    }
                }
                context.Result = new BadRequestObjectResult(errorresponse);
                return;
            }
            await next();

        }
    }
}
