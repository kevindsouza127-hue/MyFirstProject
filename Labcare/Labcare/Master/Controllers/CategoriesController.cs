using Labcare.Master.Classes;
using Labcare.Master.Helpers;
using Labcare.Master.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Labcare.Master.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICategories _Categories;

        public CategoriesController(ICategories Categories)
        {

            _Categories = Categories;
        }


        [HttpPost("InsertCategories")]
        public async Task<ActionResult<Categories>> Categories(Categories Categories)
        {
            try
            {
                SortedList output = await _Categories.Categories(Categories);

                if (output["Rid"].ToString() == "0")
                {
                    return CustomValidations.APIControllerErrorResponse(new Response<Categories>(ResponseStatus.Failure, StatusCodes.DuplicateRecord, output["Result"].ToString()), StatusCodes.DatabaseException);


                }
                else if (output["Rid"].ToString() == "-1")
                {
                    return CustomValidations.APIControllerErrorResponse(new Response<Categories>(ResponseStatus.Failure, StatusCodes.DuplicateRecord, output["Result"].ToString()), StatusCodes.DatabaseException);
                }
                else
                {
                    return Ok(new Response<Categories>(ResponseStatus.Success, StatusCodes.OK, output["Result"].ToString()));
                }
            }
            catch (Exception e)
            {
                return CustomValidations.APIControllerErrorResponse(new Response<Categories>(ResponseStatus.Failure, StatusCodes.APIException, e.Message), StatusCodes.APIException);
            }


        }
        [HttpPut("UpdateCategories")]
        public async Task<ActionResult<Categories>>UpdateCategories(Categories Categories)
        {
            try
            {
                SortedList output = await _Categories.UpdateCategories(Categories);

                if (output["Rid"].ToString() == "0")
                {
                    return CustomValidations.APIControllerErrorResponse(new Response<Categories>(ResponseStatus.Failure, StatusCodes.DuplicateRecord, output["Result"].ToString()), StatusCodes.DatabaseException);


                }
                else if (output["Rid"].ToString() == "-1")
                {
                    return CustomValidations.APIControllerErrorResponse(new Response<Categories>(ResponseStatus.Failure, StatusCodes.DuplicateRecord, output["Result"].ToString()), StatusCodes.DatabaseException);
                }
                else
                {
                    return Ok(new Response<Categories>(ResponseStatus.Success, StatusCodes.OK, output["Result"].ToString()));
                }
            }
            catch (Exception e)
            {
                return CustomValidations.APIControllerErrorResponse(new Response<Categories>(ResponseStatus.Failure, StatusCodes.APIException, e.Message), StatusCodes.APIException);
            }


        }


        [HttpDelete("DeleteCategories")]
        public async Task<ActionResult<Categories>> DeleteParam(string Category)
        {
            try
            {
                SortedList output = await _Categories.DeleteCategories(Category);

                if (output["Rid"].ToString() == "0")
                {
                    return CustomValidations.APIControllerErrorResponse(new Response<Categories>(ResponseStatus.Failure, StatusCodes.DuplicateRecord, output["Result"].ToString()), StatusCodes.DatabaseException);


                }
                else if (output["Rid"].ToString() == "-1")
                {
                    return CustomValidations.APIControllerErrorResponse(new Response<Categories>(ResponseStatus.Failure, StatusCodes.DuplicateRecord, output["Result"].ToString()), StatusCodes.DatabaseException);
                }
                else
                {
                    return Ok(new Response<Categories>(ResponseStatus.Success, StatusCodes.OK, output["Result"].ToString()));
                }
            }
            catch (Exception e)
            {
                return CustomValidations.APIControllerErrorResponse(new Response<Categories>(ResponseStatus.Failure, StatusCodes.APIException, e.Message), StatusCodes.APIException);
            }


        }

    }
}

