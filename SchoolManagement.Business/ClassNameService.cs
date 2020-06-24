using SchoolManagement.Business.Interface;
using SchoolManagement.Data;
using SchoolManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using SchoolManagement.ViewModel.Admin.ClassName;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Model;

namespace SchoolManagement.Business
{
    public class ClassNameService : IClassNameService
    {
        private readonly ISMUow uow;

        public ClassNameService(ISMUow uow)
        {
            this.uow = uow;
        }

        public PaginatedItemsViewModel<ClassNameViewModel> GetAllClassNames(int currentPage, int pageSize, string sortBy)
        {
            int totalRecordCount = 0;
            double totalPages = 0;
            int totalPageCount = 0;
            var vms = new List<ClassNameViewModel>();

            var query = uow.ClassNames.GetAll().OrderBy(t => t.Id);

            if(sortBy== "Name")
            {
                query = query.OrderBy(t => t.Name);
            }

            if (sortBy == "Description")
            {
                query = query.OrderBy(t => t.Description);
            }

            totalRecordCount = query.Count();
            totalPages = (double)totalRecordCount / pageSize;
            totalPageCount = (int)Math.Ceiling(totalPages);

            var classNames = query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            foreach (var cln in classNames)
            {
                var vm = new ClassNameViewModel
                {
                    Id = cln.Id,
                    Name=cln.Name,
                    Description = cln.Description,
                    CreatedBy = cln.CreatedBy.FullName,
                    CreatedOn = cln.CreatedOn.ToShortDateString(),
                    UpdatedBy = cln.UpdatedBy.FullName,
                    UpdatedOn = cln.UpdatedOn.ToShortDateString(),
                    IsActive = cln.IsActive,

                };

                vms.Add(vm);
            }

            var container = new PaginatedItemsViewModel<ClassNameViewModel>(currentPage, pageSize, totalPageCount, totalRecordCount, vms);

            return container;

        }

        public ClassNameViewModel GetClassNameById(long id)
        {
            var cln = uow.ClassNames.GetAll().FirstOrDefault(t => t.Id == id);

            var vm = new ClassNameViewModel
            {
                Id = cln.Id,
                Name = cln.Name,
                Description = cln.Description,
                CreatedBy = cln.CreatedBy.FullName,
                CreatedOn = cln.CreatedOn.ToShortDateString(),
                UpdatedBy = cln.UpdatedBy.FullName,
                UpdatedOn = cln.UpdatedOn.ToShortDateString(),
                IsActive = cln.IsActive,

            };

            return vm;
        }
        public async Task<ResponseViewModel> SaveClassName(ClassNameViewModel vm, string userName)
        {
            var response = new ResponseViewModel();
            try
            {
                var currentUser = uow.Users.GetAll().FirstOrDefault(t => t.Username == userName);
                var dateTimeNow = DateTime.UtcNow;

                if(vm.Id==0)
                {
                    if(!IsClassNameExists(vm.Name))
                    {
                        var classname = new ClassName();
                        classname.Name = vm.Name;
                        classname.Description = vm.Description;
                        classname.CreatedById = currentUser.Id;
                        classname.UpdatedById = currentUser.Id;
                        classname.IsActive = true;
                        classname.UpdatedOn = dateTimeNow;
                        classname.CreatedOn = dateTimeNow;

                        uow.ClassNames.Add(classname);
                        await uow.CommitAsync();

                        response.IsSuccess = true;
                        response.Message = "Class Name successfully added";
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.Message = "Class Name already exist in the database";
                    }

                }
                else
                {
                    response = await UpdateClassName(vm, userName);
                }


            }
            catch(Exception ex)
            {
                response.Message = "Error occured..Please try again..!";
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<ResponseViewModel> UpdateClassName(ClassNameViewModel vm, string userName)
        {
            var response = new ResponseViewModel();
            try
            {
                if (!IsClassNameExists(vm.Name,vm.Id))
                {
                    var currentUser = uow.Users.GetAll().FirstOrDefault(t => t.Username == userName);
                    var dateTimeNow = DateTime.UtcNow;

                    var className = uow.ClassNames.GetAll().FirstOrDefault(t => t.Id == vm.Id);
                    className.Name = vm.Name;
                    className.Description = vm.Description;
                    className.IsActive = true;
                    className.UpdatedOn = dateTimeNow;
                    className.UpdatedById = currentUser.Id;

                    uow.ClassNames.Update(className);
                    await uow.CommitAsync();

                    response.IsSuccess = true;
                    response.Message = "Class Name successfully updated";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Class Name already exist in the database";
                }

            }
            catch (Exception ex)
            {
                response.Message = "Error occuring Please try again..!";
                response.IsSuccess = false;
            }
            return response;
        }

        public async Task<ResponseViewModel> DeleteClassName(long id)
        {
            var response = new ResponseViewModel();
            try
            {
                var className = uow.ClassNames.GetAll().FirstOrDefault(t=>t.Id==id);
                uow.ClassNames.Delete(className);
                await uow.CommitAsync();
                response.IsSuccess = true;
                response.Message = "Class Name successfully deleted.";

            }
            catch (DbUpdateException dex)
            {
                response.Message = "This Class Name is already in use.";
                response.IsSuccess = false;
            }
            catch (Exception ex)
            {
                response.Message = "Error occured..Please try again..!";
                response.IsSuccess = false;
            }

            return response;
        }

        private bool IsClassNameExists(string name,long id=0)
        {
            name = name.Replace(" ", string.Empty).ToLower().Trim();

            if (id == 0)
            {
                var existingClassName = uow.ClassNames.GetAll().FirstOrDefault(t => t.Name.Replace(" ", "").ToLower().Trim() == name && t.IsActive == true);

                return existingClassName != null ? true : false;
            }
            else
            {
                var existingClassName = uow.ClassNames.GetAll().FirstOrDefault(t => t.Name.Replace(" ", "").ToLower().Trim() == name && t.IsActive == true && t.Id != id);

                return existingClassName != null ? true : false;
            }
        }
    }
}
