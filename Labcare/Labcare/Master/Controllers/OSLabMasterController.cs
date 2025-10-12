using Labcare.Master.Classes;
using Labcare.Master.Helpers;
using Labcare.Master.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Labcare.Master.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class OSLabMasterController : ControllerBase
    {


              IOSLab _OSLab;
 
        public OSLabMasterController(IOSLab OSLab)
            {

                _OSLab = OSLab;
            }


            [HttpPost("InsertOSLab")]
            public async Task<ActionResult<IOSLab>> IOSLab(OSLab OSLab)
            {
                try
                {
                    SortedList output = await _OSLab.OSLab(OSLab);

                    if (output["Rid"].ToString() == "0")
                    {
                        return CustomValidations.APIControllerErrorResponse(new Response<OSLab>(ResponseStatus.Failure, StatusCodes.DuplicateRecord, output["Result"].ToString()), StatusCodes.DatabaseException);


                    }
                    else if (output["Rid"].ToString() == "-1")
                    {
                        return CustomValidations.APIControllerErrorResponse(new Response<OSLab>(ResponseStatus.Failure, StatusCodes.DuplicateRecord, output["Result"].ToString()), StatusCodes.DatabaseException);
                    }
                    else
                    {
                        return Ok(new Response<OSLab>(ResponseStatus.Success, StatusCodes.OK, output["Result"].ToString()));
                    }
                }
                catch (Exception e)
                {
                    return CustomValidations.APIControllerErrorResponse(new Response<OSLab>(ResponseStatus.Failure, StatusCodes.APIException, e.Message), StatusCodes.APIException);
                }


            }


        [HttpPut("UpdateOSLab")]
        public async Task<ActionResult<OSLab>> UpdateOSLab(OSLab OSLab)
        {
            try
            {
                SortedList output = await _OSLab.UpdateOSLab(OSLab);

                if (output["Rid"].ToString() == "0")
                {
                    return CustomValidations.APIControllerErrorResponse(new Response<OSLab>(ResponseStatus.Failure, StatusCodes.DuplicateRecord, output["Result"].ToString()), StatusCodes.DatabaseException);


                }
                else if (output["Rid"].ToString() == "-1")
                {
                    return CustomValidations.APIControllerErrorResponse(new Response<OSLab>(ResponseStatus.Failure, StatusCodes.DuplicateRecord, output["Result"].ToString()), StatusCodes.DatabaseException);
                }
                else
                {
                    return Ok(new Response<OSLab>(ResponseStatus.Success, StatusCodes.OK, output["Result"].ToString()));
                }
            }
            catch (Exception e)
            {
                return CustomValidations.APIControllerErrorResponse(new Response<OSLab>(ResponseStatus.Failure, StatusCodes.APIException, e.Message), StatusCodes.APIException);
            }


        }

        [HttpDelete("DeleteOSLab")]
        public async Task<ActionResult<OSLab>> DeleteOSLab(string OSLabName)
        {
            try
            {
                SortedList output = await _OSLab.DeleteOSLab(OSLabName);
   
                if (output["Rid"].ToString() == "-1")
                {
                    return CustomValidations.APIControllerErrorResponse(new Response<OSLab>(ResponseStatus.Failure, StatusCodes.DuplicateRecord, output["Result"].ToString()), StatusCodes.DatabaseException);
                }
                else
                {
                    return Ok(new Response<OSLab>(ResponseStatus.Success, StatusCodes.OK, output["Result"].ToString()));
                }
            }
            catch (Exception e)
            {
                return CustomValidations.APIControllerErrorResponse(new Response<OSLab>(ResponseStatus.Failure, StatusCodes.APIException, e.Message), StatusCodes.APIException);
            }


        }
    }
}
