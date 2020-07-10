using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Admin.SubjectTeacher;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interface
{
    public interface ISubjectTeacherService
    {
        List<AcademicLevelSubjectsAllocationViewModel> GetAcademicYearSubjectTeacherAllocation(long academicYearId, long academicLevelId);

        SubjectAllocationDetailViewModel GetSubjectAllocationForSelectedAcademicLevel(long academicYearId, long academicLevelId, long subjectId);
        Task<ResponseViewModel> SaveSelectedSubjectAllocation(SubjectAllocationDetailViewModel vm,string userName);

        Task<ResponseViewModel> DeleteSubjectTeachersAllocationForSelectedLevel(long academicYearId, long academicLevelId, long subjectId, string userName);
        Task<ResponseViewModel> DeleteSubjectTeacherAllocationForSelectedLevel(long academicYearId, long academicLevelId, long subjectId, long teacherId, string userName);
        List<DropDownViewModal> GetAllTeachers();
    }
}
