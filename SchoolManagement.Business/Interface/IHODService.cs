using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Admin.HeadOfDepartment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interface
{
    public interface IHODService
    {
        PaginatedItemsViewModel<HODBasicViewModel> GetAllHODs(int currentPage, int pageSize, string sortBy);
        HODDetailViewModel GetSelectedHODDetailById(int id);
        Task<ResponseViewModel> SaveHOD(HODDetailViewModel vm, string userName);
        Task<ResponseViewModel> UpdateHOD(HODDetailViewModel vm, string userName);
        Task<ResponseViewModel> DeleteHOD(int id, string userName);
    }
}
