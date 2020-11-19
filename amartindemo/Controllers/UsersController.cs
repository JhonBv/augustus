using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using amartindemo.Factories;
using amartindemo.models.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace amartindemo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserFactory _factory;
        public UsersController(ILogger<UsersController> logger, IUserFactory factory)
        {
            _logger = logger;
            _factory = factory;
        }

        [HttpGet, Route("list")]
        [ProducesResponseType(typeof(List<UserListResponseModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(UserDetailErrorResponse), (int)HttpStatusCode.NoContent)]

        //[Produces("application/json")]
        public async Task<IActionResult> GetUsers()
        {
            object response = new object();
            try
            {
                if (await _factory.BuildUsersResponse() == null)
                {
                    response = new UserDetailErrorResponse { ErrorMessage = "No users could be be found" };
                    return BadRequest(response);
                }
                response = await _factory.BuildUsersResponse();
            }
            catch(Exception ex){

                _logger.LogError("{0} The following error exception was thrown by the syste:  ",ex.Message);
            }
            var jsonResponse = JsonSerializer.Serialize(response);
            return Ok(jsonResponse);
        }

        [HttpGet, Route("details/{userId}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetUserDetails(int userId)
        {
            object response = new object();
            try
            {
                if (await _factory.BuildUsersResponse() == null)
                {
                    response = new UserDetailErrorResponse { ErrorMessage = "There was an error processing the request." };
                    return BadRequest(response);
                }
                response = await _factory.BuildUserDetail(userId);
            }
            catch (Exception ex) {
                _logger.LogError("{0} The following error exception was thrown by the system when attempting to obtain user details for user {1}:  ", ex.Message, userId);
            }
            var jsonResponse = JsonSerializer.Serialize(response);
            //only for tests with Postman
            return Ok(response);
        }
    }
}
