using Microsoft.EntityFrameworkCore;
using SchoolManagement.Business.Interface;
using SchoolManagement.Data;
using SchoolManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using SchoolManagement.Model;
using SchoolManagement.ViewModel.Admin.Class;

namespace SchoolManagement.Business
{
    public class AcademicYearService : IAcademicYearService
    {
        private readonly ISMUow uow;

        public AcademicYearService(ISMUow uow)
        {
            this.uow = uow;
        }


        public async Task<ResponseViewModel> DeleteAcademivYear(int id,string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var academicYear = uow.AcademicYears.GetAll().FirstOrDefault(t => t.Id == id);

                var assignedClasses = academicYear.Classes.ToList();

                foreach(var cl in assignedClasses)
                {
                    uow.Classes.Delete(cl);
                    await uow.CommitAsync();
                }

            }
            catch(DbUpdateException ex)
            {
                response.Message = "This Academic Year already in use.";
                response.IsSuccess = false;
            }
            catch(Exception ex)
            {
                response.Message = "Error occured..Please try again..!";
                response.IsSuccess = false;
            }

            return response;
        }

        public PaginatedItemsViewModel<AcademicYearViewModel> GetAllAcademicYearClassDetails(int currentPage, int pageSize, string sortBy)
        {
            int totalRecordCount = 0;
            double totalPages = 0;
            int totalPageCount = 0;
            var vms = new List<AcademicYearViewModel>();

            var academicYears = uow.AcademicYears.GetAll().OrderByDescending(t => t.Id);

            totalRecordCount = academicYears.Count();
            totalPages = (double)totalRecordCount / pageSize;
            totalPageCount = (int)Math.Ceiling(totalPages);

            var academicYearList = academicYears.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            foreach(var acy in academicYearList)
            {
                var vm = new AcademicYearViewModel
                {
                    Id = acy.Id,
                    AcademicYear = acy.Id,
                    NoOfClassess = acy.Classes.Count(),
                    CreatedBy = acy.CreatedBy.FullName,
                    CreatedOn = acy.CreatedOn.ToShortDateString(),
                    UpdatedBy = acy.UpdatedBy.FullName,
                    UpdatedOn = acy.UpdatedOn.ToShortDateString()
                };

                var totalStudent = acy.Classes.SelectMany(t => t.StudentClasses).Count();
                vm.Total = totalStudent;

                vms.Add(vm);
            }

            var container = new PaginatedItemsViewModel<AcademicYearViewModel>(currentPage, pageSize, totalPageCount, totalRecordCount, vms);

            return container;
        }

        public AcademicYearViewModel GetSelectedAcademicYearClassDetailById(int id)
        {
            if(id!=0)
            {
                var academicYear = uow.AcademicYears.GetAll().FirstOrDefault(t => t.Id == id);

                var vm = new AcademicYearViewModel
                {
                    Id = academicYear.Id,
                    AcademicYear = academicYear.Id,
                    NoOfClassess = academicYear.Classes.Count(),
                    CreatedBy = academicYear.CreatedBy.FullName,
                    CreatedOn = academicYear.CreatedOn.ToShortDateString(),
                    UpdatedBy = academicYear.UpdatedBy.FullName,
                    UpdatedOn = academicYear.UpdatedOn.ToShortDateString()
                };

                var totalStudent = academicYear.Classes.SelectMany(t => t.StudentClasses).Count();
                vm.Total = totalStudent;

                var academicLevels = uow.AcademicLevels.GetAll().ToList();

                foreach (var al in academicLevels)
                {
                    var alvm = new AcademicLevelViewModel()
                    {
                        Id = al.Id,
                        CreatedBy = al.CreatedBy.FullName,
                        CreatedOn = al.CreatedOn.ToShortDateString(),
                        Description = al.Description,
                        IsActive = al.IsActive,
                        LevelHeadId = al.LevelHeadId,
                        LevelHeadName = al.LevelHead.FullName,
                        UpdatedBy = al.UpdatedBy.FullName,
                        UpdatedOn = al.UpdatedOn.ToShortDateString()
                    };

                    var classNames = uow.ClassNames.GetAll().ToList();


                    foreach (var cl in classNames)
                    {
                        var selectedClass = new ClassViewModel()
                        {
                            ClassName = cl.Name,
                            ClassNameId = cl.Id,
                            IsChecked = academicYear.Classes.FirstOrDefault(t => t.AcademicLevelId == al.Id && t.ClassNameId == cl.Id) == null ? false : true
                        };

                        alvm.Classes.Add(selectedClass);
                    }

                    vm.AcademicLevelViewModels.Add(alvm);

                    
                }
                return vm;
            }
            else
            {
                var vm = new AcademicYearViewModel();

                var academicLevels = uow.AcademicLevels.GetAll().ToList();

                foreach (var al in academicLevels)
                {
                    var alvm = new AcademicLevelViewModel()
                    {
                        Id = al.Id,
                        CreatedBy = al.CreatedBy.FullName,
                        CreatedOn = al.CreatedOn.ToShortDateString(),
                        Description = al.Description,
                        IsActive = al.IsActive,
                        LevelHeadId = al.LevelHeadId,
                        LevelHeadName = al.LevelHead.FullName,
                        UpdatedBy = al.UpdatedBy.FullName,
                        UpdatedOn = al.UpdatedOn.ToShortDateString()
                    };

                    var classNames = uow.ClassNames.GetAll().ToList();


                    foreach (var cl in classNames)
                    {
                        var selectedClass = new ClassViewModel()
                        {
                            ClassName = cl.Name,
                            ClassNameId = cl.Id,
                            IsChecked = false
                        };

                        alvm.Classes.Add(selectedClass);
                    }

                    vm.AcademicLevelViewModels.Add(alvm);


                }
                return vm;
            }


        }

        public async Task<ResponseViewModel> SaveAcademicYear(AcademicYearViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var currentUser = uow.Users.GetAll().FirstOrDefault(t => t.Username == userName);
                var academicYear = uow.AcademicYears.GetAll().FirstOrDefault(t => t.Id == vm.AcademicYear);
                var dateTimeNow = DateTime.UtcNow;

                if(academicYear==null)
                {
                    academicYear = new AcademicYear()
                    {
                        Id = vm.AcademicYear,
                        IsActive = true,
                        CreatedById = currentUser.Id,
                        UpdatedById = currentUser.Id,
                        UpdatedOn = dateTimeNow,
                        CreatedOn = dateTimeNow
                    };

                    academicYear.Classes = new HashSet<Class>();
                    foreach (var x in vm.AcademicLevelViewModels)
                    {
                        foreach (var y in x.Classes.Where(cl => cl.IsChecked == true).ToList())
                        {
                            var newClass = new Class()
                            {
                                AcademicYearId = academicYear.Id,
                                AcademicLevelId = x.Id,
                                ClassNameId = y.ClassNameId,
                                Name = string.Format("{0} {1}", x.Description, y.ClassName),
                                CreatedById = currentUser.Id,
                                CreatedOn = dateTimeNow,
                                UpdatedById = currentUser.Id,
                                UpdatedOn = dateTimeNow
                            };
                            academicYear.Classes.Add(newClass);
                        }
                    }

                    uow.AcademicYears.Add(academicYear);
                    await uow.CommitAsync();

                    response.IsSuccess = true;
                    response.Message = "New Academic Year has been added successfully.";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Failed to create academic year since entered academic year is already exists.";
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error has been occured while adding new academic year. Please try again.";
            }

            return response;
        }

        public async Task<ResponseViewModel> UpdateAcademicYear(AcademicYearViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var currentUser = uow.Users.GetAll().FirstOrDefault(t => t.Username == userName);
                var academicYear = uow.AcademicYears.GetAll().FirstOrDefault(t => t.Id == vm.Id);
                var dateTimeNow = DateTime.UtcNow;

                foreach (var al in vm.AcademicLevelViewModels)
                {
                    var selectedClasses = al.Classes.Where(t => t.IsChecked == true).ToList();
                    var savedClases = academicYear.Classes.Where(t=>t.AcademicLevelId==al.Id).ToList();

                    var selectedClassIds = selectedClasses.Select(t => t.ClassNameId).ToList();
                    var savedClassIds = savedClases.Select(t => t.ClassNameId).ToList();

                    var newlyAddedClasses = selectedClassIds.Except(savedClassIds).ToList();

                    foreach(var id in newlyAddedClasses)
                    {
                        var className = al.Classes.FirstOrDefault(t => t.ClassNameId == id);

                        var newClass = new Class()
                        {
                            AcademicYearId = academicYear.Id,
                            AcademicLevelId = al.Id,
                            ClassNameId = id,
                            Name = string.Format("{0} {1}", al.Description, className.ClassName),
                            CreatedById = currentUser.Id,
                            CreatedOn = dateTimeNow,
                            UpdatedById = currentUser.Id,
                            UpdatedOn = dateTimeNow
                        };

                        uow.Classes.Add(newClass);
                    }

                    var removeList = savedClassIds.Except(selectedClassIds).ToList();
                    foreach(var cl in removeList)
                    {
                        var removedClass = uow.Classes.GetAll().FirstOrDefault(t => t.AcademicLevelId == al.Id && t.AcademicYearId == academicYear.Id && t.ClassNameId == cl);
                        uow.Classes.Delete(removedClass);
                    }

                    await uow.CommitAsync();


                }

                response.IsSuccess = true;
                response.Message = "Academic Year Successfully Updated";

            }
            catch (DbUpdateException ex)
            {
                response.Message = "Classes already in use.";
                response.IsSuccess = false;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Academic Year update operation failed.Please try again.";
            }

            return response;
        }
    }
}
