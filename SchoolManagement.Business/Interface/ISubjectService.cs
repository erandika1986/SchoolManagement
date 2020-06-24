using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Admin.Subject;
using SchoolManagement.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interface
{
    public interface ISubjectService
    {
        PaginatedItemsViewModel<SubjectViewModel> GetAllSubjects(int currentPage, int pageSize, string sortBy);
        SubjectViewModel GetSubjectById(int id);
        List<BasicAcademicLevelViewModel> GetAcademicLevelDetailForSelectedSubject(int id);
        List<BasicSubjectViewModel> GetAvailableBasketSubjects(int parentSubjectId);
        SubjectViewModel GetEmptySubject();
        Task<ResponseViewModel> SaveSubject(SubjectViewModel vm, string userName);
        Task<ResponseViewModel> UpdateSubject(SubjectViewModel vm,string userName);
        Task<ResponseViewModel> DeleteSubject(int id);
    }
}
