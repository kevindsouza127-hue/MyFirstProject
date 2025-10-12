using Dapper;
using Labcare.Master.Classes;
using Labcare.Master.Helpers;
using Labcare.Master.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Data;
using System.Runtime.ConstrainedExecution;

namespace Labcare.Master.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
 
    public class TitleController : ControllerBase
    {
        ITitle _Title;

        public TitleController(ITitle Title)
        {

            _Title = Title;
        }

        [HttpPost("InsertTitle")]
        public async Task<ActionResult<Titles>> Param(Titles Title)
        {
            try
            {
                SortedList output = await _Title.AddTitle(Title);

                if (output["Rid"].ToString() == "0")
                {
                    return CustomValidations.APIControllerErrorResponse(new Response<Titles>(ResponseStatus.Failure, StatusCodes.DuplicateRecord, output["Result"].ToString()), StatusCodes.DatabaseException);


                }
                else if (output["Rid"].ToString() == "-1")
                {
                    return CustomValidations.APIControllerErrorResponse(new Response<Titles>(ResponseStatus.Failure, StatusCodes.DuplicateRecord, output["Result"].ToString()), StatusCodes.DatabaseException);
                }
                else
                {
                    return Ok(new Response<Titles>(ResponseStatus.Success, StatusCodes.OK, output["Result"].ToString()));
                }
            }
            catch (Exception e)
            {
                return CustomValidations.APIControllerErrorResponse(new Response<Titles>(ResponseStatus.Failure, StatusCodes.APIException, e.Message), StatusCodes.APIException);
            }


        }
        [HttpPut("UpdateTitle")]
        public async Task<ActionResult<Titles>> UpdateTitle(Titles Title)
        {
            try
            {
                SortedList output = await _Title.UpdateTitle(Title);

                if (output["Rid"].ToString() == "0")
                {
                    return CustomValidations.APIControllerErrorResponse(new Response<Titles>(ResponseStatus.Failure, StatusCodes.DuplicateRecord, output["Result"].ToString()), StatusCodes.DatabaseException);


                }
                else if (output["Rid"].ToString() == "-1")
                {
                    return CustomValidations.APIControllerErrorResponse(new Response<Titles>(ResponseStatus.Failure, StatusCodes.DuplicateRecord, output["Result"].ToString()), StatusCodes.DatabaseException);
                }
                else
                {
                    return Ok(new Response<Titles>(ResponseStatus.Success, StatusCodes.OK, output["Result"].ToString()));
                }
            }
            catch (Exception e)
            {
                return CustomValidations.APIControllerErrorResponse(new Response<Titles>(ResponseStatus.Failure, StatusCodes.APIException, e.Message), StatusCodes.APIException);
            }


        }

        [HttpGet("GetTitle")]
        public async Task <ActionResult> GetTitle()
        {
            try
            {
                var Titles = await _Title.GetTitle();

                if (Titles == null)
                {
                    return Ok(new Response<Titles>(ResponseStatus.Failure, StatusCodes.NoRecordsFound,"No Titles Found"));
                }
                else
                {
                    return Ok();
                }

            }
            catch (Exception e)
            {
                return CustomValidations.APIControllerErrorResponse(new Response<Titles>(ResponseStatus.Failure, StatusCodes.APIException, e.Message), StatusCodes.APIException);
            }




        }
    }
}
