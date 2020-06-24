using SchoolManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interface
{
    public interface IAcademicYearService
    {
        PaginatedItemsViewModel<AcademicYearViewModel> GetAllAcademicYearClassDetails(int currentPage, int pageSize, string sortBy);
        AcademicYearViewModel GetSelectedAcademicYearClassDetailById(int id);
        Task<ResponseViewModel> SaveAcademicYear(AcademicYearViewModel vm, string userName);
        Task<ResponseViewModel> UpdateAcademicYear(AcademicYearViewModel vm, string userName);
        Task<ResponseViewModel> DeleteAcademivYear(int id, string userName);

    }
}
