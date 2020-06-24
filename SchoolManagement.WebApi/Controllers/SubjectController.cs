using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Business.Interface;
using SchoolManagement.ViewModel.Admin.Subject;
using SchoolManagement.WebApi.Helpers;

namespace SchoolManagement.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            this.subjectService = subjectService;
        }

        [HttpGet("GetAllSubjects")]
        public IActionResult Get(int currentPage, int pageSize, string sortBy)
        {
            var response = subjectService.GetAllSubjects(currentPage, pageSize, sortBy);
            return Ok(response);
        }

        [HttpGet("GetSubjectById/{id:int}")]
        public IActionResult Get(int id)
        {
            var response = subjectService.GetSubjectById(id);
            return Ok(response);
        }

        [HttpPost("SaveSubject")]
        public async Task<IActionResult> Post(SubjectViewModel vm)
        {
            var response = await subjectService.SaveSubject(vm, IdentityHelper.GetUsername());
            return Ok(response);
        }

        [HttpGet("GetEmptySubject")]
        public IActionResult GetNewUser()
        {
            var response = this.subjectService.GetEmptySubject();
            return Ok(response);
        }

        [HttpGet("GetAvailableBasketSubjects/{parentSubjectId:int}")]
        public IActionResult GetAvailableBasketSubjects(int parentSubjectId)
        {
            var response = this.subjectService.GetAvailableBasketSubjects(parentSubjectId);
            return Ok(response);
        }

        [HttpGet("GetAcademicLevelDetailForSelectedSubject/{id:int}")]
        public IActionResult GetAcademicLevelDetailForSelectedSubject(int id)
        {
            var response = this.subjectService.GetAcademicLevelDetailForSelectedSubject(id);
            return Ok(response);
        }

        //[HttpPut("UpdateClassName")]
        //public async Task<IActionResult> Put(ClassNameViewModel vm)
        //{
        //    var response = await classNameService.UpdateClassName(vm, IdentityHelper.GetUsername());
        //    return Ok(response);
        //}

        [HttpDelete("DeleteSubject/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await subjectService.DeleteSubject(id);

            return Ok(response);
        }
    }
}