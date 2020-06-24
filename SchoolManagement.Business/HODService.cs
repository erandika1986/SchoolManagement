using SchoolManagement.Business.Interface;
using SchoolManagement.Data;
using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Admin.HeadOfDepartment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business
{
    public class HODService: IHODService
    {
        private readonly ISMUow uow;

        public HODService(ISMUow uow)
        {
            this.uow = uow;
        }

        public async Task<ResponseViewModel> DeleteHOD(int id, string userName)
        {
            var response = new ResponseViewModel();

            try
            {

            }
            catch(Exception ex)
            {

            }

            return response;
        }

        public PaginatedItemsViewModel<HODBasicViewModel> GetAllHODs(int currentPage, int pageSize, string sortBy)
        {
            throw new NotImplementedException();
        }

        public HODDetailViewModel GetSelectedHODDetailById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseViewModel> SaveHOD(HODDetailViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {

            }
            catch (Exception ex)
            {

            }

            return response;
        }

        public async Task<ResponseViewModel> UpdateHOD(HODDetailViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {

            }
            catch (Exception ex)
            {

            }

            return response;
        }
    }
}
