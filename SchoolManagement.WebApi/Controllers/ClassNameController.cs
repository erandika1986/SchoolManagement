using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Business.Interface;
using SchoolManagement.ViewModel.Admin.ClassName;
using SchoolManagement.WebApi.Helpers;

namespace SchoolManagement.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClassNameController : ControllerBase
    {
        private readonly IClassNameService classNameService;
        public ClassNameController(IClassNameService classNameService)
        {
            this.classNameService = classNameService;
        }


        [HttpGet("GetAllClassNames")]
        public IActionResult Get(int currentPage, int pageSize, string sortBy)
        {
            var response = classNameService.GetAllClassNames(currentPage, pageSize, sortBy);
            return Ok(response);
        }

        [HttpGet("GetClassNameById/{id:int}")]
        public IActionResult Get(long id)
        {
            var response = classNameService.GetClassNameById(id);
            return Ok(response);
        }

        [HttpPost("SaveClassName")]
        public async Task<IActionResult> Post(ClassNameViewModel vm)
        {
            var response = await classNameService.SaveClassName(vm, IdentityHelper.GetUsername());
            return Ok(response);
        }

        //[HttpPut("UpdateClassName")]
        //public async Task<IActionResult> Put(ClassNameViewModel vm)
        //{
        //    var response = await classNameService.UpdateClassName(vm, IdentityHelper.GetUsername());
        //    return Ok(response);
        //}

        [HttpDelete("DeleteClassName/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await classNameService.DeleteClassName(id);

            return Ok(response);
        }
    }
}