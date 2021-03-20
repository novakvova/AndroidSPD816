using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Planner.WebApi.DTO;
using Planner.WebApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AccountController : ControllerBase
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
    }
}
