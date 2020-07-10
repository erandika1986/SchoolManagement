using SchoolManagement.Business.Interface;
using SchoolManagement.Data;
using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Admin.ClassSubjectTeacher;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using SchoolManagement.Model;

namespace SchoolManagement.Business
{
    public class SubjectClassTeacherService : ISubjectClassTeacherService
    {
        private readonly ISMUow uow;

        public SubjectClassTeacherService(ISMUow uow)
        {
            this.uow = uow;
        }

        public async Task<ResponseViewModel> DeleteClassSubjectTeacher(int academicYearId, int academicLevelId, int classNameId)
        {
            var response = new ResponseViewModel();

            try
            {
                var classTeachers = uow.ClassTeachers.GetAll().Where(t => t.AcademicYearId == academicYearId && t.AcademicLevelId == academicLevelId && t.ClassNameId == classNameId).ToList();

                foreach(var item in classTeachers)
                {
                    uow.ClassTeachers.Delete(item);
                }

                var subjectTeachers = uow.ClassSubjectTeachers.GetAll().Where(t => t.AcademicYearId == academicYearId && t.AcademicLevelId == academicLevelId && t.ClassNameId == classNameId).ToList();

                foreach (var item in subjectTeachers)
                {
                    uow.ClassSubjectTeachers.Delete(item);
                }

                await uow.CommitAsync();

                response.IsSuccess = true;
                response.Message = "Assigned class teachers and subject teachers successfully deleted for selected class.";

            }
            catch(Exception ex)
            {

                response.IsSuccess = false;
                response.Message = "Unable to delete the class teachers and subject teachers since they are already in use.";
            }

            return response;
        }

        public PaginatedItemsViewModel<ClassSubjectTeacherBasicDetailViewModel> GetAllSubjectClassTeachers(int currentPage, int pageSize, string sortBy, int academicYearId, int academicLevelId)
        {
            int totalRecordCount = 0;
            double totalPages = 0;
            int totalPageCount = 0;
            var vms = new List<ClassSubjectTeacherBasicDetailViewModel>();

            var classTeachers = uow.ClassTeachers.GetAll().Where(t => t.AcademicYearId == academicYearId && t.AcademicLevelId == academicYearId);

            totalRecordCount = classTeachers.Count();
            totalPages = (double)totalRecordCount / pageSize;
            totalPageCount = (int)Math.Ceiling(totalPages);

            var clteachers = classTeachers.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            clteachers.ForEach(u =>
            {
                vms.Add(new ClassSubjectTeacherBasicDetailViewModel()
                {
                    AcademicYearId=u.AcademicYearId,
                    AcademicLevelId=u.AcademicLevelId,
                    AcademicLevelName=u.Class.AcademicLevel.Description,
                    ClassNameId = u.ClassNameId,
                    Name = u.Class.Name,
                    UpdatedBy = u.UpdatedBy.FullName,
                    UpdatedOn= u.UpdatedOn.ToShortDateString()
                }); 
            });


            var container = new PaginatedItemsViewModel<ClassSubjectTeacherBasicDetailViewModel>(currentPage, pageSize, totalPageCount, totalRecordCount, vms);

            return container;
        }

        public ClassSubjectTeacherViewModel GetSelectedSubjectClassTeacherDetails(int academicYearId, int academicLevelId, int classNameId)
        {
            var response = new ClassSubjectTeacherViewModel();

            var classSubjectTeachers = uow.ClassSubjectTeachers.GetAll()
                .Where(t => t.AcademicYearId == academicYearId && t.AcademicLevelId == academicLevelId && t.ClassNameId == classNameId && t.IsActive==true && t.EndDate==(DateTime?)null).ToList();

            if(classSubjectTeachers.Count>0)
            {
                var classTeachers = uow.ClassTeachers.GetAll()
                .Where(t => t.AcademicYearId == academicYearId && t.AcademicLevelId == academicLevelId && t.ClassNameId == classNameId);


                response.AcademicLevelId = academicLevelId;
                response.AcademicYearId = academicYearId;
                response.ClassNameId = classNameId;

                var academicLevelSubjects = uow.SubjectAcademicLevels.GetAll()
        .Where(t => t.AcademicLevelId == academicLevelId && t.Subject.IsActive == true
        && (t.Subject.IsParentBasketSubject == false || t.Subject.IsBuscketSubject == true)).OrderBy(t => t.Subject.Name).ToList();

                foreach (var item in academicLevelSubjects)
                {
                    var matchingSubjectTeacher = classSubjectTeachers.FirstOrDefault(t => t.SubjectId == item.SubjectId);

                    response.ClassSubjectTeachers.Add(new SubjectTeacherViewModel()
                    {
                        SelectedSubjectId = item.SubjectId,
                        SubjectTeachers = GetSubjectTeachers(academicYearId, academicLevelId, item.SubjectId),
                        SelectedTeacherId = matchingSubjectTeacher != null ? matchingSubjectTeacher.SubjectTeacherId : 0
                    }); 
                }

                //foreach (var item in classSubjectTeachers)
                //{
                //    response.ClassSubjectTeachers.Add(new  SubjectTeacherViewModel()
                //    {
                //      SelectedSubjectId=item.SubjectId,
                //      SelectedTeacherId=item.SubjectTeacherId
                //    });
                //}

                foreach (var item in classTeachers)
                {
                    response.ClassTeachers.Add(new ClassTeacherViewModel()
                    {
                        AcademicLevelId = item.AcademicLevelId,
                        AcademicYearId = item.AcademicYearId,
                        ClassNameId = item.ClassNameId,
                        IsPrimaryTeacher = item.IsPrimary,
                        SelectedTeacherId = item.TeacherId
                    });
                }
            }
            else
            {
                response.AcademicLevelId = academicLevelId;
                response.AcademicYearId = academicYearId;
                response.ClassNameId = classNameId;

                var academicLevelSubjects = uow.SubjectAcademicLevels.GetAll()
        .Where(t => t.AcademicLevelId == academicLevelId && t.Subject.IsActive == true
        && (t.Subject.IsParentBasketSubject == false || t.Subject.IsBuscketSubject == true)).OrderBy(t => t.Subject.Name).ToList();

                foreach (var item in academicLevelSubjects)
                {

                    response.ClassSubjectTeachers.Add(new SubjectTeacherViewModel()
                    {
                        SelectedSubjectId = item.SubjectId,
                        SubjectTeachers = GetSubjectTeachers(academicYearId, academicLevelId, item.SubjectId),
                        SelectedTeacherId =  0
                    });
                }
            }



            return response;
        }

        public async Task<ResponseViewModel> SaveClassSubjectTeacherDetails(ClassSubjectTeacherViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var user = uow.Users.GetAll().FirstOrDefault(t => t.Username == userName);


                //For Class Teacher assign
                var savedClassTeachers = uow.ClassTeachers.GetAll().Where(t => t.AcademicYearId == vm.AcademicYearId && t.AcademicLevelId == vm.AcademicLevelId && t.ClassNameId == vm.ClassNameId).ToList() ;

                var newClassTeachers = (from clt in vm.ClassTeachers where !savedClassTeachers.Any(t=>t.TeacherId==clt.SelectedTeacherId) select clt).ToList();

                foreach (var item in newClassTeachers)
                {
                    var classTeacher = new ClassTeacher()
                    {
                        ClassNameId = vm.ClassNameId,
                        AcademicLevelId = vm.AcademicLevelId,
                        AcademicYearId = vm.AcademicYearId,
                        TeacherId = item.SelectedTeacherId,
                        IsPrimary = item.IsPrimaryTeacher,
                        CreatedOn = DateTime.UtcNow,
                        CreatedById = user.Id,
                        UpdatedOn = DateTime.UtcNow,
                        UpdatedById = user.Id
                    };

                    uow.ClassTeachers.Add(classTeacher);
                }

                var deletedClassTeachers = (from scl in savedClassTeachers where !vm.ClassTeachers.Any(t => t.SelectedTeacherId == scl.TeacherId) select scl).ToList();

                foreach (var item in deletedClassTeachers)
                {
                    uow.ClassTeachers.Delete(item);
                }

                var updatedClassTeachers = (from clt in vm.ClassTeachers where savedClassTeachers.Any(t => t.TeacherId == clt.SelectedTeacherId) select clt).ToList();
                foreach (var item in updatedClassTeachers)
                {
                    var classTeacher = uow.ClassTeachers.GetAll().FirstOrDefault(t => t.AcademicYearId == vm.AcademicYearId && t.AcademicLevelId == vm.AcademicLevelId && t.ClassNameId == vm.ClassNameId && t.TeacherId == item.SelectedTeacherId);
                    classTeacher.IsPrimary = item.IsPrimaryTeacher;
                    classTeacher.UpdatedOn = DateTime.UtcNow;
                    classTeacher.UpdatedById = user.Id;

                    uow.ClassTeachers.Update(classTeacher);
                }

                //For Class Subject teacher assign
                var academicLevelSubjects = uow.SubjectAcademicLevels.GetAll().Where(t => t.AcademicLevelId == vm.AcademicLevelId && t.Subject.IsActive==true && (t.Subject.IsParentBasketSubject == false || t.Subject.IsBuscketSubject == true)).ToList();
                foreach (var item in academicLevelSubjects)
                {
                    var matchingSubjectAllocation = uow.ClassSubjectTeachers.GetAll()
                        .FirstOrDefault(t => t.ClassNameId == vm.ClassNameId && t.AcademicLevelId == vm.AcademicLevelId && t.AcademicYearId == vm.AcademicYearId && t.SubjectId == item.SubjectId && t.IsActive == true);

                    var currentSubjectUsers = vm.ClassSubjectTeachers.FirstOrDefault(t => t.SelectedSubjectId == item.SubjectId);

                    if(matchingSubjectAllocation==null)
                    {
                        matchingSubjectAllocation = new ClassSubjectTeacher()
                        {
                            ClassNameId = vm.ClassNameId,
                            AcademicLevelId = vm.AcademicLevelId,
                            AcademicYearId = vm.AcademicYearId,
                            SubjectId = item.SubjectId,
                            SubjectTeacherId = currentSubjectUsers.SelectedTeacherId,
                            StartDate = DateTime.UtcNow,
                            IsActive = true,
                            CreatedOn = DateTime.UtcNow,
                            CreatedById = user.Id,
                            UpdatedOn = DateTime.UtcNow,
                            UpdatedById = user.Id
                        };

                        uow.ClassSubjectTeachers.Add(matchingSubjectAllocation);
                    }
                    else if(matchingSubjectAllocation.SubjectTeacherId!=currentSubjectUsers.SelectedTeacherId)
                    {
                        matchingSubjectAllocation.IsActive = false;
                        matchingSubjectAllocation.EndDate = DateTime.UtcNow;
                        matchingSubjectAllocation.UpdatedById = user.Id;
                        matchingSubjectAllocation.UpdatedOn = DateTime.UtcNow;

                        uow.ClassSubjectTeachers.Update(matchingSubjectAllocation);

                        matchingSubjectAllocation = new ClassSubjectTeacher()
                        {
                            ClassNameId = vm.ClassNameId,
                            AcademicLevelId = vm.AcademicLevelId,
                            AcademicYearId = vm.AcademicYearId,
                            SubjectId = item.SubjectId,
                            SubjectTeacherId = currentSubjectUsers.SelectedTeacherId,
                            StartDate = DateTime.UtcNow,
                            IsActive = true,
                            CreatedOn = DateTime.UtcNow,
                            CreatedById = user.Id,
                            UpdatedOn = DateTime.UtcNow,
                            UpdatedById = user.Id
                        };

                        uow.ClassSubjectTeachers.Add(matchingSubjectAllocation);
                    }
                }
                

                await uow.CommitAsync();

                response.IsSuccess = true;
                response.Message = "Class Teachers and Subject Teachers has been assigned to the selected class successfully.";

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error has been occured while assigning subject teachers and class teachers.";
            }

            return response;
        }

        public ClassSubjectTeacherMasterDataViewModel GetClassSubjectTeacherMasterData()
        {
            var response = new ClassSubjectTeacherMasterDataViewModel();

            var academicYears = uow.AcademicYears.GetAll().OrderByDescending(t=>t.Id).ToList();
            var academicLevels = uow.AcademicLevels.GetAll().OrderBy(t=>t. Id).ToList();

            academicYears.ForEach(t =>
            {
                response.AcademicYears.Add(new DropDownViewModal() { Id = t.Id, Name = t.Id.ToString() });
            });

            academicLevels.ForEach(t =>
            {
                response.AcademicLevels.Add(new DropDownViewModal() { Id = t.Id, Name = t.Description });
            });

            return response;
        }

        public List<DropDownViewModal> GetClassesForSelectedAcademicYearAndAcademicLevel(long academicYearId,long academicLevelId)
        {
            var response = new List<DropDownViewModal>();
            var classes = uow.Classes.GetAll().Where(t => t.AcademicYearId == academicYearId && t.AcademicLevelId == academicLevelId).ToList();

            classes.ForEach(cl =>
            {
                response.Add(new DropDownViewModal() { Id = cl.ClassNameId, Name = cl.Name });
            });

            return response;
        }

        public List<DropDownViewModal> GetClassUnAssignedTeachers()
        {
            var response = new List<DropDownViewModal>();
            response.Add(new DropDownViewModal() {Id=0, Name = "Select Class Teacher" });
            var teachers = uow.UserRoles.GetAll().Where(t => t.Role.Name == "Teacher").Select(t => t.User).ToList();


            teachers.ForEach(t =>
            {
                response.Add(new DropDownViewModal() { Id = t.Id, Name = t.FullName });
            });

            return response;
        }

       public List<DropDownViewModal> GetAcademicLevelSubjects(int selectedAcademicLevelId)
        {
            var response = new List<DropDownViewModal>();
            //For Class Subject teacher assign
            var academicLevelSubjects = uow.SubjectAcademicLevels.GetAll()
                .Where(t => t.AcademicLevelId == selectedAcademicLevelId && t.Subject.IsActive == true 
                && (t.Subject.IsParentBasketSubject == false || t.Subject.IsBuscketSubject == true)).OrderBy(t=>t.Subject.Name).ToList();

            academicLevelSubjects.ForEach(t =>
            {
                response.Add(new DropDownViewModal() { Id = t.SubjectId, Name = t.Subject.Name });
            });

            return response;
        }

        public List<DropDownViewModal> GetSubjectTeachers(long academicYearId, long academicLevelId, long subjectId)
        {
            var response = new List<DropDownViewModal>();
            response.Add(new DropDownViewModal() { Id = 0, Name = "Select Subject Teacher" });

            var subjectTeachers = uow.SubjectTeachers.GetAll().Where(t => t.AcademicYearId == academicYearId && t.AcademicLevelId == academicLevelId && t.SubjectId == subjectId && t.IsActive == true).ToList();

            subjectTeachers.ForEach(t =>
            {
                response.Add(new DropDownViewModal() { Id = t.TeacherId, Name = t.Teacher.FullName });
            });

            return response;
        }
    }
}
