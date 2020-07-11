using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Admin.ClassSubjectTeacher;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interface
{
    public interface ISubjectClassTeacherService
    {
        PaginatedItemsViewModel<ClassSubjectTeacherBasicDetailViewModel> GetAllSubjectClassTeachers(int currentPage, int pageSize, string sortBy,int academicYearId,int academicLevelId);
        ClassSubjectTeacherViewModel GetSelectedSubjectClassTeacherDetails(int academicYearId,int academicLevelId,int classNameId);
        Task<ResponseViewModel> SaveClassSubjectTeacherDetails(ClassSubjectTeacherViewModel vm, string userName);
        Task<ResponseViewModel> DeleteClassSubjectTeacher(int academicYearId, int academicLevelId, int classNameId);
        ClassSubjectTeacherMasterDataViewModel GetClassSubjectTeacherMasterData();
        List<DropDownViewModal> GetClassesForSelectedAcademicYearAndAcademicLevel(long academicYearId, long academicLevelId);
        List<DropDownViewModal> GetClassUnAssignedTeachers();
        List<DropDownViewModal> GetSubjectTeachers(long academicYearId, long academicLevelId, long subjectId);
        List<DropDownViewModal> GetAcademicLevelSubjects(int selectedAcademicLevelId);
        ResponseViewModel ValidateClassTeacher(long academicYearId, long academicLevelId, long classNameId, long teacherId);
        ResponseViewModel ValidateAssignedSubjectTeacher(long academicYearId, long academicLevelId, long classNameId, long subjectId, long teacherId);
    }
}
