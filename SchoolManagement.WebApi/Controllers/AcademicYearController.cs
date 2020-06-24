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
    public class AcademicYearController : ControllerBase
    {
        private readonly IAcademicYearService academicYearService;

        public AcademicYearController(IAcademicYearService academicYearService)
        {
            this.academicYearService = academicYearService;
        }


        [HttpGet("GetAllAcademicYearClassDetails")]
        public IActionResult Get(int currentPage, int pageSize, string sortBy)
        {
            var response = academicYearService.GetAllAcademicYearClassDetails(currentPage, pageSize, sortBy);
            return Ok(response);
        }

        [HttpGet("GetSelectedAcademicYearClassDetailById/{id:int}")]
        public IActionResult Get(int id)
        {
            var response = academicYearService.GetSelectedAcademicYearClassDetailById(id);
            return Ok(response);
        }

        //[HttpGet("GetEmptyAssessmentType")]
        //public IActionResult GetEmptyAssessmentType()
        //{
        //    var response = assessmentTypeService.GetEmptyAssessmentType();
        //    return Ok(response);
        //}

        [HttpPost("SaveAcademicYear")]
        public async Task<IActionResult> Post(AcademicYearViewModel vm)
        {
            var response = await academicYearService.SaveAcademicYear(vm, IdentityHelper.GetUsername());
            return Ok(response);
        }

        [HttpPut("UpdateAcademicYear")]
        public async Task<IActionResult> Put(AcademicYearViewModel vm)
        {
            var response = await academicYearService.UpdateAcademicYear(vm, IdentityHelper.GetUsername());
            return Ok(response);
        }

        [HttpDelete("DeleteAcademivYear/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await academicYearService.DeleteAcademivYear(id, IdentityHelper.GetUsername());

            return Ok(response);
        }

    }
}