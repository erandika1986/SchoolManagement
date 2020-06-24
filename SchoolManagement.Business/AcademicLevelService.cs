using Microsoft.EntityFrameworkCore;
using SchoolManagement.Business.Interface;
using SchoolManagement.Data;
using SchoolManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SchoolManagement.Model;
using System.Threading.Tasks;

namespace SchoolManagement.Business
{
    public class AcademicLevelService : IAcademicLevelService
    {
        private readonly ISMUow uow;

        public AcademicLevelService(ISMUow uow)
        {
            this.uow = uow;
        }


        public PaginatedItemsViewModel<AcademicLevelViewModel> GetAllAcademicLevels(int currentPage, int pageSize, string sortBy)
        {
            int totalRecordCount = 0;
            double totalPages = 0;
            int totalPageCount = 0;
            var vms = new List<AcademicLevelViewModel>();

            var query = uow.AcademicLevels.GetAll().OrderBy(t => t.Id);

            if(sortBy=="Description")
            {
                query = query.OrderBy(t => t.Description);
            }
            else if(sortBy=="LevelHead")
            {
                query = query.OrderBy(t => t.LevelHead.FullName);
            }

            totalRecordCount = query.Count();
            totalPages = (double)totalRecordCount / pageSize;
            totalPageCount = (int)Math.Ceiling(totalPages);

            var academicLevelList = query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            foreach (var al in academicLevelList)
            {
                var vm = new AcademicLevelViewModel
                {
                    Id = al.Id,
                    Description = al.Description,
                    CreatedBy = al.CreatedBy.FullName,
                    CreatedOn = al.CreatedOn.ToShortDateString(),
                    UpdatedBy = al.UpdatedBy.FullName,
                    UpdatedOn = al.UpdatedOn.ToShortDateString(),
                    IsActive=al.IsActive,
                    LevelHeadId=al.LevelHeadId,
                    LevelHeadName = al.LevelHead.FullName
                };

                vms.Add(vm);
            }

            var container = new PaginatedItemsViewModel<AcademicLevelViewModel>(currentPage, pageSize, totalPageCount, totalRecordCount, vms);

            return container;
        }
        public AcademicLevelViewModel GetAcademicLevelById(int id)
        {
            var al = uow.AcademicLevels.GetAll().FirstOrDefault(t => t.Id == id);

            var vm = new AcademicLevelViewModel
            {
                Id = al.Id,
                Description = al.Description,
                CreatedBy = al.CreatedBy.FullName,
                CreatedOn = al.CreatedOn.ToShortDateString(),
                UpdatedBy = al.UpdatedBy.FullName,
                UpdatedOn = al.UpdatedOn.ToShortDateString(),
                IsActive = al.IsActive,
                LevelHeadId = al.LevelHeadId,
                LevelHeadName = al.LevelHead.FullName
            };

            return vm;
        }

        public async Task<ResponseViewModel> SaveAcademicLevel(AcademicLevelViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {

                var currentUser = uow.Users.GetAll().FirstOrDefault(t => t.Username == userName);
                var dateTimeNow = DateTime.UtcNow;
                if (vm.Id == 0)
                {
                    if (!IsAcademicLevelExists(vm.Description))
                    {
                        var academiclevel = new AcademicLevel();
                        academiclevel.Description = vm.Description;
                        academiclevel.LevelHeadId = vm.LevelHeadId;
                        academiclevel.CreatedById = currentUser.Id;
                        academiclevel.UpdatedById = currentUser.Id;
                        academiclevel.IsActive = true;
                        academiclevel.UpdatedOn = dateTimeNow;
                        academiclevel.CreatedOn = dateTimeNow;
                        uow.AcademicLevels.Add(academiclevel);
                        await uow.CommitAsync();
                        var addedId = academiclevel.Id;
                        response.Message = "Academic Level successfully saved";
                        response.IsSuccess = true;
                    }
                    else
                    {
                        response.Message = "Academic Level already exists";
                        response.IsSuccess = false;
                    }
                }
                else
                {
                    response = await UpdateAcademicLevel(vm, userName);
                }
            }
            catch (Exception ex)
            {
                response.Message = "Error occured..Please try again..!";
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<ResponseViewModel> UpdateAcademicLevel(AcademicLevelViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var academicLevel = vm.Description.Replace(" ", string.Empty).ToLower().Trim();

                if(!IsAcademicLevelExists(vm.Description,vm.Id))
                {
                    var currentUser = uow.Users.GetAll().FirstOrDefault(t => t.Username == userName);
                    var dateTimeNow = DateTime.UtcNow;

                    var academiclevel = uow.AcademicLevels.GetAll().FirstOrDefault(t=>t.Id==vm.Id);
                    if (academiclevel != null)
                    {
                        academiclevel.Description = vm.Description;
                        academiclevel.IsActive = vm.IsActive;
                        academiclevel.LevelHeadId = vm.LevelHeadId;
                        academiclevel.UpdatedById = currentUser.Id;
                        academiclevel.UpdatedOn = DateTime.Now;

                        uow.AcademicLevels.Update(academiclevel);
                        await uow.CommitAsync();
                        response.Message = "Academic Level successfully updated";
                        response.IsSuccess = true;
                    }
                }
                else
                {
                    response.Message = "Academic Level already exists";
                    response.IsSuccess = false;
                }


            }
            catch (Exception ex)
            {
                response.Message = "Error occured..Please try again..!";
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<ResponseViewModel> DeleteAcademivLevel(int id, string username)
        {
            var response = new ResponseViewModel();

            try
            {
                var academicassessment = uow.AssessmentTypeAcademicLevels.GetAll().Where(x => x.AcademicLevelId == id).ToList();
                if (academicassessment.Count == 0)
                {
                    var deleteacademiclevel = uow.AcademicLevels.GetAll().FirstOrDefault(t=>t.Id==id);
                    uow.AcademicLevels.Delete(deleteacademiclevel);
                    await uow.CommitAsync();

                    response.IsSuccess = true;
                    response.Message = "Academic Level successfully deleted.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Academic Level is already in use.";
                }
            }
            catch (DbUpdateException ex)
            {
                response.IsSuccess = false;
                response.Message = "Academic Level is already in use.";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error occured,Please try again..!";
            }

            return response;
        }

        public List<DropDownViewModal> GetSchoolHods()
        {
            var response = new List<DropDownViewModal>();

            var hods = uow.Roles.GetAll().FirstOrDefault(t => t.Name == "HOD").UserRoles.Select(t => t.User).Where(t=>t.IsActive==true).ToList();

            hods.ForEach(h =>
            {
                response.Add(new DropDownViewModal() { Id = h.Id, Name = h.FullName });
            });

            return response;
        }

        private bool IsAcademicLevelExists(string academicLevel, long id =0)
        {
            academicLevel = academicLevel.Replace(" ", string.Empty).ToLower().Trim();

            if (id == 0)
            {
                var existingAcademicLevel = uow.AcademicLevels.GetAll().FirstOrDefault(t => t.Description.Replace(" ", "").ToLower().Trim() == academicLevel && t.IsActive == true);

                return existingAcademicLevel != null ? true : false;
            }
            else
            {
                var existingAcademicLevel = uow.AcademicLevels.GetAll().FirstOrDefault(t => t.Description.Replace(" ", "").ToLower().Trim() == academicLevel && t.IsActive == true && t.Id != id);

                return existingAcademicLevel != null ? true : false;
            }
        }
    }
}
