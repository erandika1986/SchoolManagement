using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Admin.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interface
{
    public interface IUserService
    {
        PaginatedItemsViewModel<UserViewModel> GetUserList(string name, int roleId, int currentPage, int pageSize, string sortBy, bool status);

        Task<ResponseViewModel> SaveUser(UserViewModel userview, string userName);

        Task<ResponseViewModel> DeleteUser(long id, string userName);

        UserMasterDataViewModel GetUserMasterData();

        UserViewModel GetUserById(long id);
        UserViewModel GetNewUser();

        Task<ResponseViewModel> UpdateUser(UserViewModel userview, string userName);
    }
}
