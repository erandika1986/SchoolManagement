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
    public class AcademicLevelController : ControllerBase
    {
        private readonly IAcademicLevelService academicLevelService;
        public AcademicLevelController(IAcademicLevelService academicLevelService)
        {
            this.academicLevelService = academicLevelService;
        }

        [HttpGet("GetAllAcademicLevels")]
        public IActionResult Get(int currentPage, int pageSize, string sortBy)
        {
            var response = academicLevelService.GetAllAcademicLevels(currentPage, pageSize,sortBy);
            return Ok(response);
        }

        [HttpGet("GetAcademicLevelById/{id:int}")]
        public IActionResult Get(int id)
        {
            var response = academicLevelService.GetAcademicLevelById(id);
            return Ok(response);
        }

        [HttpGet("GetSchoolHods")]
        public ActionResult GetSchoolHods()
        {
            var response = academicLevelService.GetSchoolHods();

            return Ok(response);
        }

        [HttpPost("SaveAcademicLevel")]
        public async Task<IActionResult> Post(AcademicLevelViewModel vm)
        {
            var response = await academicLevelService.SaveAcademicLevel(vm, IdentityHelper.GetUsername());
            return Ok(response);
        }

        [HttpPut("UpdateAcademicLevel")]
        public async Task<IActionResult> Put(AcademicLevelViewModel vm)
        {
            var response = await academicLevelService.UpdateAcademicLevel(vm, IdentityHelper.GetUsername());
            return Ok(response);
        }

        [HttpDelete("DeleteAcademivLevel/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await academicLevelService.DeleteAcademivLevel(id, IdentityHelper.GetUsername());

            return Ok(response);
        }


    }
}