using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Admin.Class;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interface
{
    public interface IClassService
    {
        Task<ResponseViewModel> SaveClassSubjectTeacherAllocation(ClassSubjectTeacherConatinerViewModel vm, string userName);
        ClassSubjectTeacherConatinerViewModel GetClassSubjectTeacherAllocationForSelectedClass(long classNameId, int academicLevelId, int academicYearId);
    }
}
