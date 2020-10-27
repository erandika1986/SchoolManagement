using SchoolManagement.Business.Interface;
using SchoolManagement.Data;
using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Admin.Subject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using SchoolManagement.ViewModel.Common;
using SchoolManagement.Model;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Util;

namespace SchoolManagement.Business
{
    public class SubjectService : ISubjectService
    {
        private readonly ISMUow uow;

        public SubjectService(ISMUow uow)
        {
            this.uow = uow;
        }

        public PaginatedItemsViewModel<SubjectViewModel> GetAllSubjects(int currentPage, int pageSize, string sortBy)
        {
            int totalRecordCount = 0;
            double totalPages = 0;
            int totalPageCount = 0;
            var vms = new List<SubjectViewModel>();

            var query = uow.Subjects.GetAll().Where(t=>t.IsActive == true).OrderBy(t => t.Name );

            if (sortBy == "Name")
            {
                query = query.OrderBy(t => t.Name);
            }
            else if (sortBy == "Code")
            {
                query = query.OrderBy(t => t.SubjectCode);
            }

            else if (sortBy== "UpdatedOn")
            {
                query = query.OrderBy(t => t.UpdatedOn);
            }

            else if (sortBy == "CreatedBy")
            {
                query = query.OrderBy(t => t.CreatedBy);
            }

            totalRecordCount = query.Count();
            totalPages = (double)totalRecordCount / pageSize;
            totalPageCount = (int)Math.Ceiling(totalPages);

            var subjectList = query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            foreach (var sb in subjectList)
            {
                var vm = new SubjectViewModel
                {
                    Id = sb.Id,
                    Name=sb.Name,
                    SubjectCode=sb.SubjectCode,
                    IsBasketSubject=sb.IsBuscketSubject,
                    IsParentBasketSubject=sb.IsParentBasketSubject,
                    CreatedBy = sb.CreatedBy.FullName,
                    CreatedOn = sb.CreatedOn.ToShortDateString(),
                    UpdatedBy = sb.UpdatedBy.FullName,
                    UpdatedOn = sb.UpdatedOn.ToShortDateString(),
                    IsActive = sb.IsActive,
                };

                vms.Add(vm);
            }

            var container = new PaginatedItemsViewModel<SubjectViewModel>(currentPage, pageSize, totalPageCount, totalRecordCount, vms);

            return container;

        }

        public SubjectViewModel GetSubjectById(int id)
        {
            var sb = uow.Subjects.GetAll().FirstOrDefault(t => t.Id == id);

            var vm = new SubjectViewModel
            {
                Id = sb.Id,
                Name = sb.Name,
                SubjectCode = sb.SubjectCode,
                CreatedBy = sb.CreatedBy.FullName,
                CreatedOn = sb.CreatedOn.ToShortDateString(),
                UpdatedBy = sb.UpdatedBy.FullName,
                UpdatedOn = sb.UpdatedOn.ToShortDateString(),
                IsBasketSubject=sb.IsBuscketSubject,
                IsParentBasketSubject=sb.IsParentBasketSubject,
                SubjectCategory=sb.SubjectCategory,
                SubjectStream=sb.SubjectStream,
                IsActive = sb.IsActive,
                ParentSubjectId =sb.ParentBasketSubjectId.HasValue?sb.ParentBasketSubjectId.Value:0
            };

            foreach (ALSubjectStream bn in (ALSubjectStream[])Enum.GetValues(typeof(ALSubjectStream)))
            {
                vm.SubjectStreams.Add(new DropDownViewModal() { Id = (int)bn, Name = EnumHelper.GetEnumDescription(bn) });
            }

            var academicLevels = uow.AcademicLevels.GetAll().Where(t => t.IsActive == true).OrderBy(t => t.Id).ToList();
            var subjectAcademicLevel = sb.SubjectAcademicLevels.ToList();
            foreach (var al in academicLevels)
            {
                var matchingSubject = subjectAcademicLevel.FirstOrDefault(t => t.SubjectId == sb.Id && t.AcademicLevelId == al.Id);
                var alvm = new BasicAcademicLevelViewModel()
                {
                    Description = al.Description,
                    Id = al.Id,
                    IsChecked = matchingSubject==null?false:true,
                    NoOfPeriodPerWeek= matchingSubject !=null?matchingSubject.NoOfPeriodPerWeek:0
                };

                vm.AcademicLevels.Add(alvm);
            }

            var availableParentSubjects = uow.Subjects.GetAll().Where(t => t.IsParentBasketSubject == true && t.IsActive == true).ToList();
            availableParentSubjects.ForEach(ps =>
            {
                vm.ParentSubjects.Add(new BasicSubjectViewModel() { Id = ps.Id, Name = ps.Name });
            });

            return vm;
        }

        public List<BasicAcademicLevelViewModel> GetAcademicLevelDetailForSelectedSubject(int id)
        {
            var response = new List<BasicAcademicLevelViewModel>();
            if(id>0)
            {
                var sb = uow.Subjects.GetAll().FirstOrDefault(t => t.Id == id);

                var academicLevels = uow.AcademicLevels.GetAll().Where(t => t.IsActive == true).OrderBy(t => t.Id).ToList();
                var subjectAcademicLevel = sb.SubjectAcademicLevels.ToList();
                foreach (var al in academicLevels)
                {
                    var matchingSubject = subjectAcademicLevel.FirstOrDefault(t => t.SubjectId == sb.Id && t.AcademicLevelId == al.Id);
                    var alvm = new BasicAcademicLevelViewModel()
                    {
                        Description = al.Description,
                        Id = al.Id,
                        IsChecked = matchingSubject == null ? false : true,
                        NoOfPeriodPerWeek = matchingSubject != null ? matchingSubject.NoOfPeriodPerWeek : 0
                    };

                    response.Add(alvm);
                }
            }
            else
            {
                var academicLevels = uow.AcademicLevels.GetAll().Where(t => t.IsActive == true).OrderBy(t => t.Id).ToList();

                academicLevels.ForEach(t =>
                {
                    response.Add(new BasicAcademicLevelViewModel() { Id = t.Id, Description = t.Description, IsChecked = false, NoOfPeriodPerWeek = 0 });
                });

            }



            return response;
        }
        public List<BasicSubjectViewModel> GetAvailableBasketSubjects(int parentSubjectId)
        {
            var basketSubjects = new List<BasicSubjectViewModel>();

            var availableSubjects = uow.Subjects.GetAll().Where(t => t.IsActive == true && t.IsBuscketSubject == true && ( t.ParentBasketSubjectId.HasValue == false || t.ParentBasketSubjectId.Value==parentSubjectId)).ToList();

            availableSubjects.ForEach(t =>
            {
                basketSubjects.Add(new BasicSubjectViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    IsChecked = t.ParentBasketSubjectId.HasValue?true:false
                });
            });

            return basketSubjects;
        }
        public SubjectViewModel GetEmptySubject()
        {
            var response = new SubjectViewModel();
            var subjects = uow.Subjects.GetAll().Where(t => t.IsActive == true && t.IsBuscketSubject == true && t.ParentBasketSubjectId == (int?)null).OrderBy(t=>t.Name).ToList();

            var academicLevels = uow.AcademicLevels.GetAll().Where(t => t.IsActive == true).OrderBy(t => t.Description).ToList();

            academicLevels.ForEach(t =>
            {
                response.AcademicLevels.Add(new BasicAcademicLevelViewModel() { Id = t.Id, Description = t.Description, IsChecked = false, NoOfPeriodPerWeek = 0 });
            });

            var availableParentSubjects = uow.Subjects.GetAll().Where(t => t.IsParentBasketSubject == true && t.IsActive == true).ToList();
            availableParentSubjects.ForEach(ps =>
            {
                response.ParentSubjects.Add(new BasicSubjectViewModel() { Id = ps.Id, Name = ps.Name });
            });


            return response;

        }

        public async Task<ResponseViewModel> SaveSubject(SubjectViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                if(vm.Id==0)
                {
                    var currentUser = uow.Users.GetAll().FirstOrDefault(t => t.Username == userName);
                    var dateTimeNow = DateTime.UtcNow;

                    var subject = new Subject()
                    {
                        CreatedById = currentUser.Id,
                        CreatedOn = dateTimeNow,
                        IsBuscketSubject=vm.IsBasketSubject,
                        IsParentBasketSubject=vm.IsParentBasketSubject,
                        SubjectCategory=vm.SubjectCategory,
                        SubjectStream=vm.SubjectStream,
                        IsActive = true,
                        Name = vm.Name,
                        SubjectCode = vm.SubjectCode,
                        UpdatedById = currentUser.Id,
                        UpdatedOn = dateTimeNow
                    };

                    if(vm.ParentSubjectId>0)
                    {
                        subject.ParentBasketSubjectId = vm.ParentSubjectId;
                    }

                    subject.SubjectAcademicLevels = new HashSet<SubjectAcademicLevel>();

                    uow.Subjects.Add(subject);

                    //var selectedBasketSubjects = vm.BasketSubjects.Where(t => t.IsChecked == true).ToList();
                    foreach (var al in vm.AcademicLevels.Where(t => t.IsChecked == true).ToList())
                    {
                        var subjectAcademicLevel = new SubjectAcademicLevel()
                        {
                            AcademicLevelId = al.Id,
                            NoOfPeriodPerWeek = al.NoOfPeriodPerWeek,
                            CreatedById = currentUser.Id,
                            CreatedOn = dateTimeNow,
                            UpdatedById = currentUser.Id,
                            UpdatedOn = dateTimeNow
                        };

                        

                        subject.SubjectAcademicLevels.Add(subjectAcademicLevel);
                    }

                    await uow.CommitAsync();

                    //foreach (var sb in vm.BasketSubjects)
                    //{
                    //    var basketSubject = uow.Subjects.GetAll().FirstOrDefault(t => t.Id == sb);
                    //    basketSubject.ParentBasketSubjectId = subject.Id;
                    //    uow.Subjects.Update(basketSubject);
                    //}

                    //await uow.CommitAsync();

                    response.Message = "Subject successfully saved";
                    response.IsSuccess = true;
                }
                else
                {
                    response = await UpdateSubject(vm, userName);
                }

            }
            catch(Exception ex)
            {
                response.Message = ex.ToString();
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<ResponseViewModel> UpdateSubject(SubjectViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var currentUser = uow.Users.GetAll().FirstOrDefault(t => t.Username == userName);
                var dateTimeNow = DateTime.UtcNow;

                var subject = uow.Subjects.GetAll().FirstOrDefault(t => t.Id == vm.Id);

                //Delete All childrens
                if(subject.IsParentBasketSubject==true && vm.IsParentBasketSubject!=true)
                {
                    var childrens =subject.ChildBasketSubjects.ToList();
                    foreach(var ch in childrens)
                    {
                        ch.ParentBasketSubjectId = (int?)null;
                        uow.Subjects.Update(ch);
                    }
                }

                subject.Name = vm.Name;
                subject.SubjectCode = vm.SubjectCode;
                subject.UpdatedById = currentUser.Id;
                subject.UpdatedOn = dateTimeNow;
                subject.IsBuscketSubject = vm.IsBasketSubject;
                subject.IsParentBasketSubject = vm.IsParentBasketSubject;
                subject.SubjectCategory = vm.SubjectCategory;
                subject.SubjectStream = vm.SubjectStream;

                if (vm.ParentSubjectId > 0)
                {
                    subject.ParentBasketSubjectId = vm.ParentSubjectId;
                }
                else
                {
                    subject.ParentBasketSubjectId = (int?)null;
                }


                uow.Subjects.Update(subject);
 

                var existingAcademicLevels = subject.SubjectAcademicLevels.Select(x => x.AcademicLevelId).ToList();
                var newAcademicLevels = vm.AcademicLevels.Where(x => x.IsChecked == true).Select(t => t.Id).ToList();

                var newlyAddedAcademicLevels = newAcademicLevels.Except(existingAcademicLevels);
                var deletedAcademicLevels = existingAcademicLevels.Except(newAcademicLevels);
                var remainingAcademicLevle = existingAcademicLevels.Intersect(newAcademicLevels);

                //Add new academic levels
                foreach(var id in newlyAddedAcademicLevels)
                {
                    var academicLevel = vm.AcademicLevels.FirstOrDefault(t => t.Id == id);

                    var subjectAcademicLevel = new SubjectAcademicLevel()
                    {
                        SubjectId=subject.Id,
                        AcademicLevelId = id,
                        NoOfPeriodPerWeek = academicLevel.NoOfPeriodPerWeek,
                        CreatedById = currentUser.Id,
                        CreatedOn = dateTimeNow,
                        UpdatedById = currentUser.Id,
                        UpdatedOn = dateTimeNow
                    };

                    uow.SubjectAcademicLevels.Add(subjectAcademicLevel);

                }

                //Delete deleted academic levels
                foreach(var id in deletedAcademicLevels)
                {
                    var deleteAcademicLevel = uow.SubjectAcademicLevels.GetAll().FirstOrDefault(t => t.AcademicLevelId == id && t.SubjectId == subject.Id);
                    uow.SubjectAcademicLevels.Delete(deleteAcademicLevel);
                }

                //Update existing academic levels
                foreach(var id in remainingAcademicLevle)
                {
                    var academicLevel = vm.AcademicLevels.FirstOrDefault(t => t.Id == id);
                    var al = uow.SubjectAcademicLevels.GetAll().FirstOrDefault(t => t.SubjectId == subject.Id && t.AcademicLevelId == id);
                    if(al.NoOfPeriodPerWeek!=academicLevel.NoOfPeriodPerWeek)
                    {
                        al.NoOfPeriodPerWeek = academicLevel.NoOfPeriodPerWeek;
                        al.UpdatedById = currentUser.Id;
                        al.UpdatedOn = dateTimeNow;

                        uow.SubjectAcademicLevels.Update(al);
                    }
                }

                await uow.CommitAsync();

                response.Message = "Subject successfully updated";
                response.IsSuccess = true;

            }
            catch (Exception ex)
            {
                response.Message = "Error occured..Please try again..!";
                response.IsSuccess = false;
            }

            return response;
        }

        public async Task<ResponseViewModel> DeleteSubject(int id)
        {
            var response = new ResponseViewModel();

            try
            {
                var subjectacademiclevls = uow.SubjectAcademicLevels.GetAll().Where(sa => sa.SubjectId == id).ToList();

                subjectacademiclevls.ForEach(sa =>
                {
                    uow.SubjectAcademicLevels.Delete(sa);
                });

                var deletesubject = uow.Subjects.GetAll().FirstOrDefault(t=>t.Id==id);
                uow.Subjects.Delete(deletesubject);
                await uow.CommitAsync();
                response.Message = "Subject successfully deleted.";
                response.IsSuccess = true;
            }
            catch (DbUpdateException dbex)
            {
                response.Message = "This subject is already in use.";
                response.IsSuccess = false;
            }
            catch (Exception ex)
            {
                response.Message = "Error occured..Please try again..!";
                response.IsSuccess = false;
            }

            return response;
        }

        public SubjectTeacherContainerViewModel GetSubjectTeacherAllocationDetailsForSelectedAcademicYear(int academicYearId,int academicLevelId)
        {
            var response = new SubjectTeacherContainerViewModel();

            var academicYear = uow.AcademicYears.GetAll().FirstOrDefault(t => t.Id == academicYearId);
            var academicLevel = uow.AcademicLevels.GetAll().FirstOrDefault(t => t.Id == academicLevelId);

            response.AcademicLevel = new BasicAcademicLevelViewModel() { Id = academicLevel.Id, Description = academicLevel.Description };
            response.AcademicYear = new BasicAcademicYear() { Id = academicYear.Id, AcademicYear = academicYear.Id };

            var academicYearSubjects = uow.SubjectAcademicLevels.GetAll().Where(t => t.AcademicLevelId == academicYearId).ToList();

            var teachers = uow.Roles.GetAll().FirstOrDefault(t => t.Id == 6 || t.Id==5 || t.Id==4).UserRoles.Select(t => t.User).Distinct().ToList();

            foreach (var subject in academicYearSubjects)
            {
                var subjectTeachers = new List<SubjectTeacherViewModel>();

                var subjectTeacher = new SubjectTeacherViewModel();
                subjectTeacher.Subject = new BasicSubjectViewModel { Id = subject.SubjectId, Name = subject.Subject.Name };

                foreach (var t in teachers)
                {
                    var sbt = uow.SubjectTeachers.GetAll().FirstOrDefault(s => s.AcademicYearId == academicYearId && s.AcademicLevelId == academicLevelId && s.SubjectId == subject.SubjectId && s.TeacherId == t.Id && s.IsActive == true);
                    var teacher = new BasicUserViewModel()
                    {
                        Id = t.Id,
                        FullName = t.FullName,
                        IsChecked = sbt == null ? false : true
                    };

                    subjectTeacher.Tecahers.Add(teacher);
                }

                response.SubjectTeachers.AddRange(subjectTeachers);
            }


            return response;
        }

        public async Task<ResponseViewModel> SaveSubjectTeacherAllocation(SubjectTeacherContainerViewModel vm,string userName)
        {
            var response = new ResponseViewModel();
            try
            {
                var currentUser = uow.Users.GetAll().FirstOrDefault(t => t.Username == userName);
                var dateTimeNow = DateTime.UtcNow;



                foreach (var sb in vm.SubjectTeachers)
                {
                    var existingSubjectTecahers = uow.SubjectTeachers.GetAll().Where(t =>
                    t.IsActive == true &&
                    t.AcademicYearId == vm.AcademicYear.Id &&
                    t.AcademicLevelId == vm.AcademicLevel.Id && t.SubjectId == sb.Subject.Id).ToList();

                    var selectedSubjectTeachers = sb.Tecahers.Where(t => t.IsChecked == true).ToList();

                    var newlyAddedSubjectTeachers = (from nsb in selectedSubjectTeachers where !existingSubjectTecahers.Any(t => t.TeacherId == nsb.Id) select nsb).ToList();
                    var deletedSubjectTeachers = (from dsb in existingSubjectTecahers where !selectedSubjectTeachers.Any(t => t.Id == dsb.TeacherId) select dsb).ToList();

                    foreach(var nsbt in newlyAddedSubjectTeachers)
                    {
                        var subjectTeacher = new SubjectTeacher()
                        {
                            AcademicLevelId = vm.AcademicLevel.Id,
                            AcademicYearId = vm.AcademicYear.Id,
                            SubjectId = sb.Subject.Id,
                            TeacherId = nsbt.Id,
                            StartDate = dateTimeNow,
                            IsActive = true,
                            CreatedOn = dateTimeNow,
                            CreatedById = currentUser.Id,
                            UpdatedOn = dateTimeNow,
                            UpdatedById = currentUser.Id
                        };

                        uow.SubjectTeachers.Add(subjectTeacher);
                    }

                    foreach(var dsbt in deletedSubjectTeachers)
                    {
                        var assignedClasses = uow.ClassSubjectTeachers.GetAll().Where(t => t.SubjectTeacherId == dsbt.Id && t.IsActive==true).ToList();
                        if(assignedClasses.Count==0)
                        {
                            dsbt.IsActive = false;
                            dsbt.EndDate = dateTimeNow;
                            dsbt.UpdatedById = currentUser.Id;
                            dsbt.UpdatedOn = dateTimeNow;

                            uow.SubjectTeachers.Update(dsbt);
                        }
                        else
                        {
                            response.IsSuccess = false;
                            response.Message=string.Format("Unable to remove the {0} from {1} subject. Since teacher already assigned to an one or more classe. Please de-allocate teacher from the class before removing for selected subject.", dsbt.Teacher.FullName, sb.Subject.Name);

                            return response;
                        }

                    }

                }

                response.IsSuccess = true;
                response.Message = "Opertation successfully completed.";

                await uow.CommitAsync();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error has been occured. Please try again";
            }

            return response;
        }
    }
}
