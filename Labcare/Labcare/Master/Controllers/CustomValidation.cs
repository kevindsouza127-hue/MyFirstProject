using Labcare.Master.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Labcare.Master.Controllers
{
    public static class CustomValidations
    {
        public static ObjectResult ModelErrorResponse(this ActionContext actionContext)
        {
            var errors = actionContext.ModelState
             .Where(modelError => modelError.Value.Errors.Count > 0)
             .Select(modelError => new ErrorResponse
             {
                 ErrorField = modelError.Key.Contains("$.") ? modelError.Key.Remove(0, 2) : modelError.Key,
                 ErrorDescription = modelError.Key.Contains("$.") ? "Invalid data type" : modelError.Value.Errors.FirstOrDefault().ErrorMessage
             }).ToList();

            ValidationResponseData data = new ValidationResponseData { Errors = errors };
            ObjectResult response = new ObjectResult(new ValidationResponse { success = ResponseStatus.Failure, statusCode = StatusCodes.APIModelValidations, message = "One or more validation error occured", data = data });
            response.StatusCode = StatusCodes.APIModelValidations;
            return response;
        }
        public static ObjectResult APIControllerErrorResponse(this object obj, int statusCode)
        {
            ObjectResult response = new ObjectResult(obj);
            response.StatusCode = statusCode;
            return response;
        }
        public static ObjectResult CustomModelErrorResponse(string ErrorMessage, int StatusCode)
        {
            string ErrorField = string.Empty;
            string[] Error = ErrorMessage.Split(":");
            if (Error.Length == 2)
            {
                ErrorField = Error[0];
                ErrorMessage = Error[1];
            }

            var errors = new List<ErrorResponse>();
            errors.Add(new ErrorResponse()
            {
                ErrorField = ErrorField,
                ErrorDescription = ErrorMessage
            });

            ValidationResponseData data = new ValidationResponseData { Errors = errors };
            ObjectResult response = new ObjectResult(new ValidationResponse { success = ResponseStatus.Failure, statusCode = StatusCode, message = "One or more validation error occured", data = data });
            response.StatusCode = StatusCode;
            return response;
        }

        public static ObjectResult CustomModelErrorResponse(List<ErrorResponse> errors, int StatusCode)
        {
            ValidationResponseData data = new ValidationResponseData { Errors = errors };
            ObjectResult response = new ObjectResult(new ValidationResponse { success = ResponseStatus.Failure, statusCode = StatusCode, message = "One or more validation error occured", data = data });
            response.StatusCode = StatusCode;
            return response;
        }
    }
}

