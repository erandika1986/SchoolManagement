using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Business.Interface;
using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Admin.SubjectTeacher;
using SchoolManagement.WebApi.Helpers;

namespace SchoolManagement.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectTeacherController : ControllerBase
    {
        private readonly ISubjectTeacherService subjectTeacherService;

        public SubjectTeacherController(ISubjectTeacherService subjectTeacherService)
        {
            this.subjectTeacherService = subjectTeacherService;
        }


        [HttpGet]
        [Route("getAcademicYearSubjectTeacherAllocation")]
        [ProducesResponseType(typeof(List<AcademicLevelSubjectsAllocationViewModel>), (int)HttpStatusCode.OK)]
        public IActionResult GetAcademicYearSubjectTeacherAllocation(long academicYearId, long academicLevelId)
        {
            var response = subjectTeacherService.GetAcademicYearSubjectTeacherAllocation(academicYearId, academicLevelId);

            return Ok(response);
        }

        [HttpGet]
        [Route("getSubjectAllocationForSelectedAcademicLevel")]
        [ProducesResponseType(typeof(SubjectAllocationDetailViewModel), (int)HttpStatusCode.OK)]
        public IActionResult GetSubjectAllocationForSelectedAcademicLevel(long academicYearId, long academicLevelId, long subjectId)
        {
            var response = subjectTeacherService.GetSubjectAllocationForSelectedAcademicLevel(academicYearId, academicLevelId, subjectId);

            return Ok(response);
        }

        [HttpGet]
        [Route("getAllAvailableTeachers")]
        [ProducesResponseType(typeof(List<DropDownViewModal>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllAvailableTeachers(long academicYearId, long academicLevelId, long subjectId)
        {
            var response = subjectTeacherService.GetAllAvailableTeachers(academicYearId,academicLevelId,subjectId);

            return Ok(response);
        }

        [HttpPost]
        [Route("saveSelectedSubjectAllocation")]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SaveSelectedSubjectAllocation(SubjectAllocationDetailViewModel vm)
        {
            var response = await subjectTeacherService.SaveSelectedSubjectAllocation(vm, IdentityHelper.GetUsername());

            return Ok(response);
        }

        [HttpDelete]
        [Route("deleteSubjectTeachersAllocationForSelectedLevel")]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteSubjectTeachersAllocationForSelectedLevel(long academicYearId, long academicLevelId, long subjectId)
        {
            var response = await subjectTeacherService.DeleteSubjectTeachersAllocationForSelectedLevel(academicYearId, academicLevelId,subjectId, IdentityHelper.GetUsername());

            return Ok(response);
        }

        [HttpDelete]
        [Route("deleteSubjectTeacherAllocationForSelectedLevel")]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteSubjectTeacherAllocationForSelectedLevel(long academicYearId, long academicLevelId, long subjectId, long teacherId)
        {
            var response = await subjectTeacherService.DeleteSubjectTeacherAllocationForSelectedLevel(academicYearId, academicLevelId, subjectId, teacherId, IdentityHelper.GetUsername());

            return Ok(response);
        }
    }
}