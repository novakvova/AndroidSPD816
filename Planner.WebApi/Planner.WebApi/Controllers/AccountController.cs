using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Planner.Application.Account;
using Planner.Application.Account.Registration;
using Planner.WebApi.DTO;
using Planner.WebApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.WebApi.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody]LoginDTO model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(CustomValidator.GetErrorsByModel(ModelState));
            }
            return Ok(new 
            {
                token = "asdfalflaskdfalsdfj"
            });
        }
        [HttpPost("registration")]
        public async Task<ActionResult<UserViewModel>> RegistrationAsync(RegistrationCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
