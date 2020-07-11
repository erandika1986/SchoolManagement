using SchoolManagement.Business.Interface;
using SchoolManagement.Data;
using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Admin.SubjectTeacher;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace SchoolManagement.Business
{
    public class SubjectTeacherService : ISubjectTeacherService
    {
        private readonly ISMUow uow;

        public SubjectTeacherService(ISMUow uow)
        {
            this.uow = uow;
        }
        public async Task<ResponseViewModel> DeleteSubjectTeachersAllocationForSelectedLevel(long academicYearId, long academicLevelId, long subjectId, string userName)
        {
            var response = new ResponseViewModel();
            response.IsSuccess = true;

            try
            {
                var user = uow.Users.GetAll().FirstOrDefault(t => t.Username == userName);
                var subjectTeachers = uow.SubjectTeachers.GetAll()
                    .Where(t => t.AcademicYearId == academicYearId &&
                    t.AcademicLevelId == academicLevelId &&
                    t.SubjectId == subjectId && t.IsActive == true).ToList();

                foreach (var item in subjectTeachers)
                {
                    var classSubjectsTeacherCount = uow.ClassSubjectTeachers.GetAll().Where(t => t.AcademicYearId == academicYearId &&
                    t.AcademicLevelId == academicLevelId &&
                    t.SubjectId == subjectId &&
                    t.SubjectTeacherId == item.TeacherId).Count();

                    if (classSubjectsTeacherCount > 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Unable to delete subjecte teachers for the selected academic level since they are already allocated to the classes";
                        break;
                    }

                    item.IsActive = false;
                    item.EndDate = DateTime.UtcNow;
                    item.UpdatedOn = DateTime.UtcNow;
                    item.UpdatedById = user.Id;
                    uow.SubjectTeachers.Update(item);
                }

                if (response.IsSuccess)
                {
                    await uow.CommitAsync();
                    response.Message = "Subject Teachers were deleted for selected academic Level";
                }


            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error has been occured while deleting the subject teachers for selected academic level. Please try again";
            }

            return response;
        }

        public async Task<ResponseViewModel> DeleteSubjectTeacherAllocationForSelectedLevel(long academicYearId, long academicLevelId, long subjectId, long teacherId, string userName)
        {
            var response = new ResponseViewModel();
            response.IsSuccess = true;

            try
            {
                var classSubjectsTeacher = uow.ClassSubjectTeachers.GetAll().FirstOrDefault(t => t.AcademicYearId == academicYearId &&
                t.AcademicLevelId == academicLevelId &&
                t.SubjectId == subjectId &&
                t.SubjectTeacherId == teacherId);

                if (classSubjectsTeacher == null)
                {
                    var user = uow.Users.GetAll().FirstOrDefault(t => t.Username == userName);
                    var subjectTeacher = uow.SubjectTeachers.GetAll()
                        .FirstOrDefault(t => t.AcademicYearId == academicYearId &&
                        t.AcademicLevelId == academicLevelId &&
                        t.SubjectId == subjectId && t.TeacherId == teacherId && t.IsActive == true);

                    subjectTeacher.IsActive = false;
                    subjectTeacher.EndDate = DateTime.UtcNow;
                    subjectTeacher.UpdatedOn = DateTime.UtcNow;
                    subjectTeacher.UpdatedById = user.Id;
                    uow.SubjectTeachers.Update(subjectTeacher);

                    await uow.CommitAsync();
                    response.Message = "Subject teacher were deleted for selected academic Level";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Message = "Unable to delete subjecte teachers for the selected academic level since they are already allocated to the classes";

                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error has been occured while deleting the subject teacher for the selected academic level. Please try again";
            }

            return response;
        }


        public List<AcademicLevelSubjectsAllocationViewModel> GetAcademicYearSubjectTeacherAllocation(long academicYearId, long academicLevelId)
        {
            var response = new List<AcademicLevelSubjectsAllocationViewModel>();

            var subjectTeachers = uow.SubjectTeachers.GetAll().Where(t => t.AcademicYearId == academicYearId && t.AcademicLevelId == academicLevelId && t.IsActive==true).ToList()
                .GroupBy(t => t.SubjectId, (x, y) => new { Key=x,Subjects=y.ToList()}).ToList();

            //For Class Subject teacher assign
            var academicLevelSubjects = uow.SubjectAcademicLevels.GetAll()
                .Where(t => t.AcademicLevelId == academicLevelId && t.Subject.IsActive == true
                && (t.Subject.IsParentBasketSubject == false || t.Subject.IsBuscketSubject == true)).OrderBy(t => t.Subject.Name).ToList();

            foreach (var item in academicLevelSubjects)
            {
                var vm = new AcademicLevelSubjectsAllocationViewModel()
                {
                    AcademicYearId = academicYearId,
                    AcademicLevelId = academicLevelId,
                    AcademicLevelName = item.AcademicLevel.Description,
                    SubjectId = item.SubjectId,
                    SubjectName = item.Subject.Name
                };

                var matchingRecord = subjectTeachers.FirstOrDefault(t => t.Key == item.SubjectId);
                if(matchingRecord!=null)
                {
                    vm.TechersName = string.Join(",", matchingRecord.Subjects.Select(t => t.Teacher.FullName).ToList());  
                }

                response.Add(vm);
            }

            return response;
        }

        public SubjectAllocationDetailViewModel GetSubjectAllocationForSelectedAcademicLevel(long academicYearId, long academicLevelId, long subjectId)
        {
            var response = new SubjectAllocationDetailViewModel();
            response.AcademicYearId = academicYearId;
            response.AcademicLevelId = academicLevelId;
            response.SubjectId = subjectId;

            var subjectTeachers = uow.SubjectTeachers.GetAll().Where(t => t.AcademicYearId == academicYearId && t.AcademicLevelId == academicLevelId && t.SubjectId==subjectId && t.IsActive==true).ToList();
            subjectTeachers.ForEach(t =>
            {
                response.AssignedTeachers.Add(new DropDownViewModal() { Id = t.TeacherId, Name = t.Teacher.FullName });
            });


            return response;
        }

        public async Task<ResponseViewModel> SaveSelectedSubjectAllocation(SubjectAllocationDetailViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var savedTeachers = uow.SubjectTeachers.GetAll()
                        .Where(t => t.AcademicYearId == vm.AcademicYearId &&
                        t.AcademicLevelId == vm.AcademicLevelId &&
                        t.SubjectId == vm.SubjectId && t.IsActive == true).ToList();

                var deletedTeachers = (from dt in savedTeachers where !vm.AssignedTeachers.Any(t => t.Id == dt.TeacherId) select dt).ToList();
                var newslyAddedUsers = (from nt in vm.AssignedTeachers where !savedTeachers.Any(t => t.TeacherId == nt.Id) select nt).ToList();
                var user = uow.Users.GetAll().FirstOrDefault(t => t.Username == userName);

                foreach (var teacher in newslyAddedUsers)
                {
                    var subjectTeacher = new Model.SubjectTeacher()
                    {
                        AcademicLevelId = vm.AcademicLevelId,
                        AcademicYearId = vm.AcademicYearId,
                        CreatedById = user.Id,
                        CreatedOn = DateTime.UtcNow,
                        IsActive = true,
                        StartDate = DateTime.UtcNow,
                        SubjectId = vm.SubjectId,
                        TeacherId = teacher.Id,
                        UpdatedById = user.Id,
                        UpdatedOn = DateTime.UtcNow
                    };

                    uow.SubjectTeachers.Add(subjectTeacher);
                }

                foreach (var deletedTeacher in deletedTeachers)
                {
                    deletedTeacher.IsActive = false;
                    deletedTeacher.EndDate = DateTime.UtcNow;
                    deletedTeacher.UpdatedOn = DateTime.UtcNow;
                    deletedTeacher.UpdatedById = user.Id;

                    uow.SubjectTeachers.Update(deletedTeacher);
                }

                await uow.CommitAsync();
                response.IsSuccess = true;
                response.Message = "Subject Teachers details for selected academic level has been saved successfully.";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "An Error has been occured while saving the subject teacher details.";
            }

            return response;

        }

        public List<DropDownViewModal> GetAllAvailableTeachers(long academicYearId, long academicLevelId, long subjectId)
        {
            var response = new List<DropDownViewModal>();

            var assignedTeachers = uow.SubjectTeachers.
                GetAll().Where(t => t.AcademicYearId == academicYearId && 
                t.AcademicLevelId == academicLevelId && 
                t.SubjectId == subjectId && 
                t.IsActive == true).Select(t=>t.TeacherId).ToList();

            var teachers = uow.UserRoles.GetAll().Where(t => t.Role.Name == "Teacher").Select(t => t.User).Where(t=> !assignedTeachers.Any(x => x == t.Id)).ToList();


            teachers.ForEach(t =>
            {
                response.Add(new DropDownViewModal() { Id = t.Id, Name = t.FullName });
            });

            return response;
        }

    }
}
