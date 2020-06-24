using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Admin.Student;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interface
{
    public interface IStudentService
    {
        PaginatedItemsViewModel<StudentViewModel> GetAllStudents(int currentPage, int pageSize, string Name, int AcademicLevel, int academicYear, long classId, string orderBy);
        StudentViewModel GetStudentById(long id, int academicLevel, int academicYear, int classId);
        Task<ResponseViewModel> SaveStudent(StudentViewModel vm,string userName);
        Task<ResponseViewModel> UpdateStudent(StudentViewModel vm, string userName);
        Task<ResponseViewModel> DeleteStudentFromSchool(long id, string userName);
    }
}
