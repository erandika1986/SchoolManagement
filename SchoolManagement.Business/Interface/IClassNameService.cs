using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Admin.ClassName;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interface
{
    public interface IClassNameService
    {
        PaginatedItemsViewModel<ClassNameViewModel> GetAllClassNames(int currentPage, int pageSize, string sortBy);
        ClassNameViewModel GetClassNameById(long id);
        Task<ResponseViewModel> SaveClassName(ClassNameViewModel classnameviewmodel, string userName);
        Task<ResponseViewModel> UpdateClassName(ClassNameViewModel classNameViewModel, string userName);
        Task<ResponseViewModel> DeleteClassName(long id);
    }
}
