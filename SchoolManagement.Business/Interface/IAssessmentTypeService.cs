using SchoolManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interface
{
    public interface IAssessmentTypeService
    {
        PaginatedItemsViewModel<AssessmentTypeViewModel> GetAllAssessmentTypes(int currentPage, int pageSize, string sortBy);
        AssessmentTypeViewModel GetEmptyAssessmentType();
        AssessmentTypeViewModel GetAssessmentTypeById(int id);
        Task<ResponseViewModel> SaveAssessmentType(AssessmentTypeViewModel vm, string userName);
        Task<ResponseViewModel> UpdateAssessmentType(AssessmentTypeViewModel vm, string userName);
        Task<ResponseViewModel> DeleteAssessmentType(int id, string username);
    }
}
