using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Business.Interface;
using SchoolManagement.ViewModel;
using SchoolManagement.WebApi.Helpers;

namespace SchoolManagement.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("GetUserList")]
        public IActionResult Get(string name, int roleId, int currentPage, int pageSize, string sortBy, bool status)
        {
            var response = userService.GetUserList(name, roleId, currentPage, pageSize, sortBy, status);

            return Ok(response);
        }

        [HttpGet("GetUserMasterData")]
        public IActionResult GetUserMasterData()
        {
            var response = userService.GetUserMasterData();

            return Ok(response);
        }

        [HttpGet("GetUserById/{id:int}")]
        public IActionResult Get(long id)
        {
            var response = this.userService.GetUserById(id);
            return Ok(response);
        }

        [HttpGet("GetNewUser")]
        public IActionResult GetNewUser()
        {
            var response = this.userService.GetNewUser();
            return Ok(response);
        }

        [HttpPost("SaveUser")]
        public async Task<IActionResult> Post(UserViewModel user)
        {
            var response = await userService.SaveUser(user, IdentityHelper.GetUsername());

            return Ok(response);
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> Put(UserViewModel user)
        {
            var response = await userService.UpdateUser(user, IdentityHelper.GetUsername());

            return Ok(response);
        }

        [HttpDelete("DeleteUser/{id:int}")]
        public async Task<ActionResult> Delete(long id)
        {
            var response = await userService.DeleteUser(id, IdentityHelper.GetUsername());

            return Ok(response);
        }


    }
}