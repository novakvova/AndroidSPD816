using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Planner.Application.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planner.WebApi.Controllers
{
    
    public class UserController : BaseController
    {
        [Authorize]
        [HttpGet("profile")]
        public async Task<ActionResult<UserViewModel>> ProfileAsync()
        {
            UserViewModel model = new UserViewModel()
            {
                UserName = User.Claims.FirstOrDefault(x => x.Type == "username").Value,
                Image= "/images/noimage.png"

            };
            return model;
        }
    }
}
