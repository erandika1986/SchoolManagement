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
    public class AssessmentTypeController : ControllerBase
    {
        private readonly IAssessmentTypeService assessmentTypeService;

        public AssessmentTypeController(IAssessmentTypeService assessmentTypeService)
        {
            this.assessmentTypeService = assessmentTypeService;
        }

        [HttpGet("GetAllAssessmentTypes")]
        public IActionResult Get(int currentPage, int pageSize, string sortBy)
        {
            var response = assessmentTypeService.GetAllAssessmentTypes(currentPage, pageSize, sortBy);
            return Ok(response);
        }

        [HttpGet("GetAssessmentTypeById/{id:int}")]
        public IActionResult Get(int id)
        {
            var response = assessmentTypeService.GetAssessmentTypeById(id);
            return Ok(response);
        }

        [HttpGet("GetEmptyAssessmentType")]
        public IActionResult GetEmptyAssessmentType()
        {
            var response = assessmentTypeService.GetEmptyAssessmentType();
            return Ok(response);
        }

        [HttpPost("SaveAssessmentType")]
        public async Task<IActionResult> Post(AssessmentTypeViewModel vm)
        {
            var response = await assessmentTypeService.SaveAssessmentType(vm, IdentityHelper.GetUsername());
            return Ok(response);
        }

        [HttpPut("UpdateAssessmentType")]
        public async Task<IActionResult> Put(AssessmentTypeViewModel vm)
        {
            var response = await assessmentTypeService.UpdateAssessmentType(vm, IdentityHelper.GetUsername());
            return Ok(response);
        }

        [HttpDelete("DeleteAssessmentType/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await assessmentTypeService.DeleteAssessmentType(id, IdentityHelper.GetUsername());

            return Ok(response);
        }
    }
}