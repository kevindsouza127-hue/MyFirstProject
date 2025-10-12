using Labcare.Master.Classes;
using Labcare.Master.Helpers;
using Labcare.Master.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Runtime.ConstrainedExecution;

namespace Labcare.Master.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        ITest _Test;

        public TestController(ITest Test)
        {

            _Test = Test;
        }


        [HttpPost("InsertTest")]
        public async Task<ActionResult<Test>> Test(Test Test)
        {
            try
            {
                SortedList output = await _Test.Test(Test);

                if (output["Rid"].ToString() == "0")
                {
                    return CustomValidations.APIControllerErrorResponse(new Response<Test>(ResponseStatus.Failure, StatusCodes.DuplicateRecord, output["Result"].ToString()), StatusCodes.DatabaseException);


                }
                else if (output["Rid"].ToString() == "-1")
                {
                    return CustomValidations.APIControllerErrorResponse(new Response<Test>(ResponseStatus.Failure, StatusCodes.DuplicateRecord, output["Result"].ToString()), StatusCodes.DatabaseException);
                }
                else
                {
                    return Ok(new Response<Test>(ResponseStatus.Success, StatusCodes.OK, output["Result"].ToString()));
                }
            }
            catch (Exception e)
            {
                return CustomValidations.APIControllerErrorResponse(new Response<Test>(ResponseStatus.Failure, StatusCodes.APIException, e.Message), StatusCodes.APIException);
            }


        }
        [HttpPut("UpdateTest")]
        public async Task<ActionResult<Test>> UpdateTest(Test Test)
        {
            try
            {
                SortedList output = await _Test.UpdateTest(Test);

                if (output["Rid"].ToString() == "0")
                {
                    return CustomValidations.APIControllerErrorResponse(new Response<Test>(ResponseStatus.Failure, StatusCodes.DuplicateRecord, output["Result"].ToString()), StatusCodes.DatabaseException);


                }
                else if (output["Rid"].ToString() == "-1")
                {
                    return CustomValidations.APIControllerErrorResponse(new Response<Test>(ResponseStatus.Failure, StatusCodes.DuplicateRecord, output["Result"].ToString()), StatusCodes.DatabaseException);
                }
                else
                {
                    return Ok(new Response<Test>(ResponseStatus.Success, StatusCodes.OK, output["Result"].ToString()));
                }
            }
            catch (Exception e)
            {
                return CustomValidations.APIControllerErrorResponse(new Response<Test>(ResponseStatus.Failure, StatusCodes.APIException, e.Message), StatusCodes.APIException);
            }


        }

        


        [HttpDelete("DeleteTest")]
        public async Task<ActionResult<Test>> DeleteTest(string TestName)
        {
            try
            {
                SortedList output = await _Test.DeleteTest(TestName);

                if (output["Rid"].ToString() == "0")
                {
                    return CustomValidations.APIControllerErrorResponse(new Response<Test>(ResponseStatus.Failure, StatusCodes.DuplicateRecord, output["Result"].ToString()), StatusCodes.DatabaseException);


                }
                else if (output["Rid"].ToString() == "-1")
                {
                    return CustomValidations.APIControllerErrorResponse(new Response<Test>(ResponseStatus.Failure, StatusCodes.DuplicateRecord, output["Result"].ToString()), StatusCodes.DatabaseException);
                }
                else
                {
                    return Ok(new Response<Test>(ResponseStatus.Success, StatusCodes.OK, output["Result"].ToString()));
                }
            }
            catch (Exception e)
            {
                return CustomValidations.APIControllerErrorResponse(new Response<Test>(ResponseStatus.Failure, StatusCodes.APIException, e.Message), StatusCodes.APIException);
            }


        }
    }
}
