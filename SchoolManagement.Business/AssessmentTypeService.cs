using SchoolManagement.Business.Interface;
using SchoolManagement.Data;
using SchoolManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SchoolManagement.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SchoolManagement.ViewModel.Common;

namespace SchoolManagement.Business
{
    public class AssessmentTypeService : IAssessmentTypeService
    {
        private readonly ISMUow uow;

        public AssessmentTypeService(ISMUow uow)
        {
            this.uow = uow;
        }

        public PaginatedItemsViewModel<AssessmentTypeViewModel> GetAllAssessmentTypes(int currentPage, int pageSize, string sortBy)
        {
            int totalRecordCount = 0;
            double totalPages = 0;
            int totalPageCount = 0;
            var vms = new List<AssessmentTypeViewModel>();

            var query = uow.AssessmentTypes.GetAll().OrderBy(t => t.Id);

            if (sortBy == "Description")
            {
                query = query.OrderBy(t => t.Description);
            }

            if (sortBy == "Name")
            {
                query = query.OrderBy(t => t.Name);
            }



            totalRecordCount = query.Count();
            totalPages = (double)totalRecordCount / pageSize;
            totalPageCount = (int)Math.Ceiling(totalPages);

            var academicLevelList = query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            foreach (var al in academicLevelList)
            {
                var vm = new AssessmentTypeViewModel
                {
                    Id = al.Id,
                    Name = al.Name,
                    Description = al.Description,
                    Levels = string.Join(",", al.AssessmentTypeAcademicLevels.Select(t=>t.AcademicLevel.Description).ToList()),
                    CreatedBy = al.CreatedBy.FullName,
                    CreatedOn = al.CreatedOn.ToShortDateString(),
                    UpdatedBy = al.UpdatedBy.FullName,
                    UpdatedOn = al.UpdatedOn.ToShortDateString(),
                    IsActive = al.IsActive
                };

                vms.Add(vm);
            }

            var container = new PaginatedItemsViewModel<AssessmentTypeViewModel>(currentPage, pageSize, totalPageCount, totalRecordCount, vms);

            return container;
        }

        public AssessmentTypeViewModel GetAssessmentTypeById(int id)
        {
            var at = uow.AssessmentTypes.GetAll().FirstOrDefault(t => t.Id == id);
            var vm = new AssessmentTypeViewModel
            {
                Id = at.Id,
                Name=at.Name,
                Description = at.Description,
                CreatedBy = at.CreatedBy.FullName,
                CreatedOn = at.CreatedOn.ToShortDateString(),
                UpdatedBy = at.UpdatedBy.FullName,
                UpdatedOn = at.UpdatedOn.ToShortDateString(),
                IsActive = at.IsActive
            };

            var allAcademicLevels = uow.AcademicLevels.GetAll().ToList();
            allAcademicLevels.ForEach(al =>
            {
                var matchRecord = at.AssessmentTypeAcademicLevels.FirstOrDefault(t => t.AcademicLevelId == al.Id);
                var alVm = new BasicAcademicLevelViewModel()
                {
                    Description = al.Description,
                    Id = al.Id,
                    IsChecked = matchRecord == null ? false : true
                };

                vm.AcademicLevels.Add(alVm);
            });

            return vm;
        }


        public AssessmentTypeViewModel GetEmptyAssessmentType()
        {
            var vm = new AssessmentTypeViewModel
            {
                IsActive = true
            };
            var allAcademicLevels = uow.AcademicLevels.GetAll().ToList();
            allAcademicLevels.ForEach(al =>
            {
                var alVm = new BasicAcademicLevelViewModel()
                {
                    Description = al.Description,
                    Id = al.Id,
                    IsChecked = false
                };

                vm.AcademicLevels.Add(alVm);
            });

            return vm;

        }

        public async Task<ResponseViewModel> SaveAssessmentType(AssessmentTypeViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var currentUser = uow.Users.GetAll().FirstOrDefault(t => t.Username == userName);
                var dateTimeNow = DateTime.UtcNow;
                if (vm.Id == 0)
                {
                    var assessmentType = new AssessmentType();
                    assessmentType.Name = vm.Name;
                    assessmentType.Description = vm.Description;
                    assessmentType.CreatedById = currentUser.Id;
                    assessmentType.UpdatedById = currentUser.Id;
                    assessmentType.IsActive = true;
                    assessmentType.UpdatedOn = dateTimeNow;
                    assessmentType.CreatedOn = dateTimeNow;
                    uow.AssessmentTypes.Add(assessmentType);

                    assessmentType.AssessmentTypeAcademicLevels = new HashSet<AssessmentTypeAcademicLevel>();

                    foreach(var al in vm.AcademicLevels.Where(t=>t.IsChecked==true).ToList())
                    {
                        var astAcl = new AssessmentTypeAcademicLevel()
                        {
                            AcademicLevelId = al.Id,
                            CreatedOn = dateTimeNow,
                            UpdatedOn = dateTimeNow,
                            CreatedById = currentUser.Id,
                            UpdatedById = currentUser.Id
                        };

                        assessmentType.AssessmentTypeAcademicLevels.Add(astAcl);
                    }

                    await uow.CommitAsync();

                    response.Message = "Assessment type successfully saved";
                    response.IsSuccess = true;

                }
                else
                {
                    response =await UpdateAssessmentType(vm, userName);
                }
            }
            catch (Exception ex)
            {
                response.Message = "Error occured..Please try again..!";
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<ResponseViewModel> UpdateAssessmentType(AssessmentTypeViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var currentUser = uow.Users.GetAll().FirstOrDefault(t => t.Username == userName);
                var dateTimeNow = DateTime.UtcNow;
                var assessmentType = uow.AssessmentTypes.GetAll().FirstOrDefault(t => t.Id == vm.Id);
                assessmentType.Name = vm.Name;
                assessmentType.Description = vm.Description;
                assessmentType.UpdatedById = currentUser.Id;
                assessmentType.IsActive = true;
                assessmentType.UpdatedOn = dateTimeNow;
                uow.AssessmentTypes.Update(assessmentType);
                await uow.CommitAsync();

                var existingAssessmentAcademicYears = assessmentType.AssessmentTypeAcademicLevels.ToList();
                var newlyAddedAssessmentAcademicYears = (from a in vm.AcademicLevels where !existingAssessmentAcademicYears.Any(t => t.AcademicLevelId == a.Id) select a).ToList();

                foreach(var al in newlyAddedAssessmentAcademicYears)
                {
                    var astAcl = new AssessmentTypeAcademicLevel()
                    {
                        AssessmentTypeId = assessmentType.Id,
                        AcademicLevelId = al.Id,
                        CreatedOn = dateTimeNow,
                        UpdatedOn = dateTimeNow,
                        CreatedById = currentUser.Id,
                        UpdatedById = currentUser.Id
                    };

                    assessmentType.AssessmentTypeAcademicLevels.Add(astAcl);
                    await uow.CommitAsync();
                }

                var deletedAssessmentAcademicYears = (from a in existingAssessmentAcademicYears where vm.AcademicLevels.Any(t => t.Id == a.AcademicLevelId) select a).ToList();
                foreach(var item in deletedAssessmentAcademicYears)
                {
                    uow.AssessmentTypeAcademicLevels.Delete(item);
                    await uow.CommitAsync();
                }


                response.Message = "Assessment type successfully updated";
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.Message = "Error occured..Please try again..!";
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<ResponseViewModel> DeleteAssessmentType(int id, string username)
        {
            var response = new ResponseViewModel();

            try
            {
                var academicassessment = uow.AssessmentTypeAcademicLevels.GetAll().Where(x => x.AssessmentTypeId == id).ToList();
                if (academicassessment.Count == 0)
                {
                    var assessmentType = uow.AssessmentTypes.GetAll().FirstOrDefault(t=>t.Id==id);
                    uow.AssessmentTypes.Delete(assessmentType);
                    await uow.CommitAsync();

                    response.IsSuccess = true;
                    response.Message = "AssessmentType successfully deleted.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "AssessmentType is already in use.";
                }
            }
            catch (DbUpdateException ex)
            {
                response.IsSuccess = false;
                response.Message = "AssessmentType is already in use.";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error occured,Please try again..!";
            }

            return response;
        }
    }
}
