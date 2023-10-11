using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SaleHub.Api.Contracts
{
    public class ValidationErrorResponse
    {
        public List<ValidationError> Errors { get; set; } = new List<ValidationError>();

        public static IActionResult GenerateErrorResponse(ActionContext context)
        {
            var apiError = new ValidationErrorResponse();
            var errors = context.ModelState.AsEnumerable();

            foreach (var error in errors)
            {
                foreach (var inner in error.Value!.Errors)
                {                    
                    apiError.Errors.Add(new ValidationError
                    {
                        Field = error.Key,
                        Message = inner.ErrorMessage
                    });
                }
            }
            return new BadRequestObjectResult(apiError);
        }
    }
}