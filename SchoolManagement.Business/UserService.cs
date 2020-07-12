using SchoolManagement.Business.Interface;
using SchoolManagement.Data;
using SchoolManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using SchoolManagement.Model;
using SchoolManagement.Util;
using SchoolManagement.ViewModel.Admin.User;

namespace SchoolManagement.Business
{
    public class UserService : IUserService
    {
        private readonly ISMUow uow;
        public UserService(ISMUow uow)
        {
            this.uow = uow;
        }
        public async Task<ResponseViewModel> DeleteUser(long id, string userName)
        {
            var response = new ResponseViewModel();
            try
            {
                var updatedUser = uow.Users.GetAll().FirstOrDefault(t => t.Username == userName);

                var user = uow.Users.GetAll().FirstOrDefault(u => u.Id == id);
                if (user!=null)
                {
                    user.IsActive = false;
                    user.UpdatedOn = DateTime.UtcNow;
                    user.UpdatedById = updatedUser.Id;

                    uow.Users.Update(user);

                    await uow.CommitAsync();

                    response.IsSuccess = true;
                    response.Message = "Selected user has been deleted successfully.";
                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error has been occured. Please try again.";
            }

            return response;
        }

        public UserViewModel GetUserById(long id)
        {
            var query = uow.Users.GetAll().FirstOrDefault(t => t.Id == id);
            var roles = uow.Roles.GetAll().Where(t=>t.IsActive==true).ToList();
            var userRoles = uow.UserRoles.GetAll().Where(r => r.UserId == id).ToList();
            var user = new UserViewModel()
            {
                Id = query.Id,
                FullName = query.FullName,
                Email = query.Email,
                NickName = query.NickName,
                Username = query.Username,
                IsActive = query.IsActive,
                MobileNo = query.MobileNo,
            };

            foreach (var r in roles)
            {
                var currentRole = userRoles.FirstOrDefault(t => t.RoleId == r.Id);
                user.Roles.Add(new RoleViewModel() { Id = r.Id,Name=r.Name, IsCheck = currentRole ==null?false:true});
            }

            return user;
        }

        public UserViewModel GetNewUser()
        {

            var roles = uow.Roles.GetAll().Where(t => t.IsActive == true).ToList();
            var user = new UserViewModel()
            {
                Id = 0,
                FullName =string.Empty,
                Email = string.Empty,
                NickName = string.Empty,
                Username = string.Empty,
                IsActive = true,
                MobileNo = string.Empty,
            };

            foreach (var r in roles)
            {
                user.Roles.Add(new RoleViewModel() { Id = r.Id, Name = r.Name, IsCheck = false });
            }

            return user;
        }

        public PaginatedItemsViewModel<UserViewModel> GetUserList(string name, int roleId, int currentPage, int pageSize, string sortBy,bool status)
        {
            int totalRecordCount = 0;
            double totalPages = 0;
            int totalPageCount = 0;
            var vms = new List<UserViewModel>();

            var users = uow.Users.GetAll().Where(t=>t.IsActive==status).OrderBy(t => t.Id);

            if (!string.IsNullOrEmpty(name))
            {
                users = users.Where(u => u.FullName.Contains(name)).OrderBy(t => t.Id);
            }

            if(roleId>0)
            {
                users = users.Where(t => t.UserRoles.Select(r => r.RoleId).Contains(roleId)).OrderBy(t => t.Id);
            }

            if(!string.IsNullOrEmpty(sortBy))
            {
                if(sortBy=="FullName")
                {
                    users = users.OrderBy(t => t.FullName);
                }

                if (sortBy == "NickName")
                {
                    users = users.OrderBy(t => t.NickName);
                }

                if (sortBy == "Email")
                {
                    users = users.OrderBy(t => t.Email);
                }

                if (sortBy == "Username")
                {
                    users = users.OrderBy(t => t.Username);
                }
                if (sortBy == "MobileNo")
                {
                    users = users.OrderBy(t => t.MobileNo);
                }
            }

            totalRecordCount = users.Count();
            totalPages = (double)totalRecordCount / pageSize;
            totalPageCount = (int)Math.Ceiling(totalPages);

            var userList = users.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            userList.ForEach(u =>
            {
                var roles = u.UserRoles.Select(t => t.Role).Select(t => t.Name).ToList();

                vms.Add(new UserViewModel()
                {
                    Id = u.Id,
                    Email = u.Email,
                    FullName = u.FullName,
                    IsActive = u.IsActive,
                    MobileNo = u.MobileNo,
                    NickName = u.NickName,
                    Username = u.Username,
                    LstUserRole = string.Join(",", roles)
                }); ;
               
            });


            var container = new PaginatedItemsViewModel<UserViewModel>(currentPage, pageSize, totalPageCount, totalRecordCount, vms);

            return container;




        }

        public UserMasterDataViewModel GetUserMasterData()
        {
            var query = uow.Roles.GetAll().ToList();
            var masterData = new UserMasterDataViewModel();
            foreach(Role role in query)
            {
                masterData.Roles.Add(new DropDownViewModal() { Id = role.Id, Name = role.Name});
            }
            return masterData;
        }

        public async Task<ResponseViewModel> SaveUser(UserViewModel vm, string userName)
        {
            var response = new ResponseViewModel();
            try
            {
                var createdUser = uow.Users.GetAll().FirstOrDefault(t => t.Username == userName);
                var selectedRoles = vm.Roles.Where(t => t.IsCheck == true).Select(t => t.Id).ToList();
                var createdDateTime = DateTime.UtcNow;

                var existingUserName = uow.Users.GetAll().FirstOrDefault(t => t.Username.Trim().ToUpper() == vm.Username.Trim().ToUpper());

                if (existingUserName != null) 
                {
                    response.IsSuccess = false;
                    response.Message = "Username is aready taken.";

                    return response;
                }

                var existingEmail = uow.Users.GetAll().FirstOrDefault(t => t.Email.Trim().ToUpper() == vm.Email.Trim().ToUpper());

                if (existingUserName != null)
                {
                    response.IsSuccess = false;
                    response.Message = "Email is aready exist for registered user.";

                    return response;
                }

                var user = new User()
                {
                    FullName = vm.FullName,
                    NickName=vm.NickName,
                    Email = vm.Email,
                    Username = vm.Username,
                    MobileNo=vm.MobileNo,
                    Password = CustomPasswordHasher.GenerateHash(vm.Password),
                    IsActive=true,
                    CreatedOn= createdDateTime,
                    CreatedById =createdUser.Id,
                    UpdatedOn= createdDateTime,
                    UpdatedById= createdUser.Id
                };

                user.UserRoles = new List<UserRole>();

                selectedRoles.ForEach(r =>
                {
                    user.UserRoles.Add(new UserRole()
                    {
                        CreatedById = createdUser.Id,
                        CreatedOn=createdDateTime,
                        IsActive=true,
                        RoleId= r,
                        UpdatedById=createdUser.Id,
                        UpdatedOn=createdDateTime
                    });
                });

                uow.Users.Add(user);
                await uow.CommitAsync();

                response.IsSuccess = true;
                response.Message = "New user has been added successfully.";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.ToString() ;
            }

            return response;
        }

        public async Task<ResponseViewModel> UpdateUser(UserViewModel userview, string userName)
        {
            var response = new ResponseViewModel();
            try
            {

                var createdUser = uow.Users.GetAll().FirstOrDefault(t => t.Username == userName);
                var createdDateTime = DateTime.UtcNow;

                var user = uow.Users.GetAll().FirstOrDefault(t => t.Id == userview.Id);
                var assignedRoles = uow.UserRoles.GetAll().Where(x => x.UserId == userview.Id).Select(t => t.RoleId).ToList();
                var selectedRoles = userview.Roles.Where(t => t.IsCheck == true).Select(t => t.Id).ToList();

                user.FullName = userview.FullName;
                user.NickName = userview.NickName;
                user.MobileNo = userview.MobileNo;
                user.IsActive = userview.IsActive;
                user.UpdatedOn = createdDateTime;
                user.UpdatedById = createdUser.Id;


                var newlyAddedRoles = selectedRoles.Except(assignedRoles).ToList();
                foreach (var rid in newlyAddedRoles)
                {
                    var userRole = new UserRole()
                    {
                        CreatedById = createdUser.Id,
                        CreatedOn = createdDateTime,
                        IsActive = true,
                        RoleId = rid,
                        UpdatedById = createdUser.Id,
                        UpdatedOn = createdDateTime,
                        UserId = user.Id
                    };

                    user.UserRoles.Add(userRole);
                }

                var deletedUsers = assignedRoles.Except(selectedRoles).ToList();
                foreach (var rid in deletedUsers)
                {
                    var userRole = uow.UserRoles.GetAll().FirstOrDefault(t => t.RoleId == rid && t.UserId == user.Id);

                    user.UserRoles.Remove(userRole);
                }

                uow.Users.Update(user);
                await uow.CommitAsync();

                response.IsSuccess = true;
                response.Message = "User has been updated successfully.";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error has been occured. Please try again.";
            }
            return response;
        }
    }
}
