using SchoolManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interface
{
    public interface IAcademicLevelService
    {
        PaginatedItemsViewModel<AcademicLevelViewModel> GetAllAcademicLevels(int currentPage, int pageSize, string sortBy);
        AcademicLevelViewModel GetAcademicLevelById(int id);
        Task<ResponseViewModel> SaveAcademicLevel(AcademicLevelViewModel vm, string userName);
        Task<ResponseViewModel> UpdateAcademicLevel(AcademicLevelViewModel vm, string userName);
        Task<ResponseViewModel> DeleteAcademivLevel(int id,string username);
        List<DropDownViewModal> GetSchoolHods();
    }
}
