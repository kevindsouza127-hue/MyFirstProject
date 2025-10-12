using Labcare.Master.Helpers;
using Labcare.Master.Classes;
using Labcare.Master.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.Text;


namespace Labcare.Master.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        
        IUser _users;

        public UsersController(IUser Users)
        {

            _users = Users;
        }


        [HttpPost("InsertUser")]
        public async Task<ActionResult<Users>> UsersData(Users Users)
        {
            try
            {
                SortedList output = await _users.UsersData(Users);

                if (output["Rid"].ToString() == "0")
                {
                    return CustomValidations.APIControllerErrorResponse(new Response<Users>(ResponseStatus.Failure, StatusCodes.DuplicateRecord, output["Result"].ToString()), StatusCodes.DatabaseException);


                }
                else if (output["Rid"].ToString() == "-1")
                {
                    return CustomValidations.APIControllerErrorResponse(new Response<Users>(ResponseStatus.Failure, StatusCodes.DuplicateRecord, output["Result"].ToString()), StatusCodes.DatabaseException);
                }
                else
                {
                    return Ok(new Response<Users>(ResponseStatus.Success, StatusCodes.OK, output["Result"].ToString()));
                }
            }
            catch (Exception e)
            {
                return CustomValidations.APIControllerErrorResponse(new Response<Users>(ResponseStatus.Failure, StatusCodes.APIException, e.Message), StatusCodes.APIException);
            }


        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult<Users>> UpdateUsers(Users User)
        {
            try
            {
                SortedList output = await _users.UpdateUsers(User);

                if (output["Rid"].ToString() == "0")
                {
                    return CustomValidations.APIControllerErrorResponse(new Response<Users>(ResponseStatus.Failure, StatusCodes.DuplicateRecord, output["Result"].ToString()), StatusCodes.DatabaseException);


                }
                else if (output["Rid"].ToString() == "-1")
                {
                    return CustomValidations.APIControllerErrorResponse(new Response<Users>(ResponseStatus.Failure, StatusCodes.DuplicateRecord, output["Result"].ToString()), StatusCodes.DatabaseException);
                }
                else
                {
                    return Ok(new Response<Users>(ResponseStatus.Success, StatusCodes.OK, output["Result"].ToString()));
                }
            }
            catch (Exception e)
            {
                return CustomValidations.APIControllerErrorResponse(new Response<Users>(ResponseStatus.Failure, StatusCodes.APIException, e.Message), StatusCodes.APIException);
            }


        }

        

    }
}
