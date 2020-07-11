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
using SchoolManagement.ViewModel.Admin.ClassSubjectTeacher;
using SchoolManagement.WebApi.Helpers;

namespace SchoolManagement.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClassSubjectTeacherController : ControllerBase
    {
        private readonly ISubjectClassTeacherService subjectClassTeacherService;

        public ClassSubjectTeacherController(ISubjectClassTeacherService subjectClassTeacherService)
        {
            this.subjectClassTeacherService = subjectClassTeacherService;
        }


        [HttpGet]
        [Route("getAllSubjectClassTeachers")]
        [ProducesResponseType(typeof(PaginatedItemsViewModel<ClassSubjectTeacherBasicDetailViewModel>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllSubjectClassTeachers(int currentPage, int pageSize, string sortBy, int academicYearId, int academicLevelId)
        {
            var response = subjectClassTeacherService.GetAllSubjectClassTeachers(currentPage, pageSize, sortBy, academicYearId, academicLevelId);

            return Ok(response);
        }

        [HttpGet]
        [Route("getSelectedSubjectClassTeacherDetails")]
        [ProducesResponseType(typeof(ClassSubjectTeacherViewModel), (int)HttpStatusCode.OK)]
        public IActionResult GetSelectedSubjectClassTeacherDetails(int academicYearId, int academicLevelId, int classNameId)
        {
            var response = subjectClassTeacherService.GetSelectedSubjectClassTeacherDetails(academicYearId, academicLevelId, classNameId);

            return Ok(response);
        }

        [HttpGet]
        [Route("getClassesForSelectedAcademicYearAndAcademicLevel")]
        [ProducesResponseType(typeof(List<DropDownViewModal>), (int)HttpStatusCode.OK)]
        public IActionResult GetClassesForSelectedAcademicYearAndAcademicLevel(long academicYearId, long academicLevelId)
        {
            var response = subjectClassTeacherService.GetClassesForSelectedAcademicYearAndAcademicLevel(academicYearId, academicLevelId);

            return Ok(response);
        }

        [HttpGet]
        [Route("getClassSubjectTeacherMasterData")]
        [ProducesResponseType(typeof(ClassSubjectTeacherMasterDataViewModel), (int)HttpStatusCode.OK)]
        public IActionResult GetClassSubjectTeacherMasterData()
        {
            var response = subjectClassTeacherService.GetClassSubjectTeacherMasterData();

            return Ok(response);
        }

        [HttpGet]
        [Route("getClassUnAssignedTeachers")]
        [ProducesResponseType(typeof(List<DropDownViewModal>), (int)HttpStatusCode.OK)]
        public IActionResult GetClassUnAssignedTeachers()
        {
            var response = subjectClassTeacherService.GetClassUnAssignedTeachers();

            return Ok(response);
        }

        [HttpGet]
        [Route("getAcademicLevelSubjects")]
        [ProducesResponseType(typeof(List<DropDownViewModal>), (int)HttpStatusCode.OK)]
        public IActionResult GetAcademicLevelSubjects(int selectedAcademicLevelId)
        {
            var response = subjectClassTeacherService.GetAcademicLevelSubjects(selectedAcademicLevelId);

            return Ok(response);
        }

        [HttpGet]
        [Route("validateClassTeacher")]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        public IActionResult ValidateClassTeacher(long academicYearId, long academicLevelId, long classNameId, long teacherId)
        {
            var response = subjectClassTeacherService.ValidateClassTeacher(academicYearId, academicLevelId,  classNameId, teacherId);

            return Ok(response);
        }

        [HttpGet]
        [Route("validateAssignedSubjectTeacher")]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        public IActionResult ValidateAssignedSubjectTeacher(long academicYearId, long academicLevelId, long classNameId, long subjectId, long teacherId)
        {
            var response = subjectClassTeacherService.ValidateAssignedSubjectTeacher(academicYearId, academicLevelId, classNameId, subjectId, teacherId);

            return Ok(response);
        }

        [HttpPost]
        [Route("saveClassSubjectTeacherDetails")]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> SaveClassSubjectTeacherDetails(ClassSubjectTeacherViewModel vm)
        {
            var response = await subjectClassTeacherService.SaveClassSubjectTeacherDetails(vm, IdentityHelper.GetUsername());

            return Ok(response);
        }

        [HttpDelete]
        [Route("deleteClassSubjectTeacher")]
        [ProducesResponseType(typeof(ResponseViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteClassSubjectTeacher(int academicYearId, int academicLevelId, int classNameId)
        {
            var response = await subjectClassTeacherService.DeleteClassSubjectTeacher(academicYearId, academicLevelId, classNameId);

            return Ok(response);
        }


    }
}