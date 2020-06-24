using SchoolManagement.Business.Interface;
using SchoolManagement.Data;
using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Admin.Class;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using SchoolManagement.Model;

namespace SchoolManagement.Business
{
    public class ClassService : IClassService
    {
        private readonly ISMUow uow;

        public ClassService(ISMUow uow)
        {
            this.uow = uow;
        }


        public ClassSubjectTeacherConatinerViewModel GetClassSubjectTeacherAllocationForSelectedClass(long classNameId, int academicLevelId, int academicYearId)
        {
            var response = new ClassSubjectTeacherConatinerViewModel();
            response.SelectedAcademicLevelId = academicLevelId;
            response.SelectedAcademicYearId = academicYearId;
            response.SelectedClassNameId = classNameId;

            var teachers = uow.Roles.GetAll().FirstOrDefault(t => t.Id == 6 || t.Id == 5 || t.Id == 4).UserRoles.Select(t => t.User).Distinct().Select(t=> new BasicUserViewModel() { Id=t.Id,FullName=t.FullName}).ToList();
            response.Teachers.Add(new BasicUserViewModel() { Id = 0, FullName = "--Select--" });
            response.Teachers.AddRange(teachers);

            var selectedClassTeachers = uow.ClassTeachers.GetAll()
                .Where
                (
                    t => t.ClassNameId == classNameId && 
                    t.AcademicLevelId == academicLevelId && 
                    t.AcademicYearId == academicYearId
                 ).OrderBy(t => t.IsPrimary).ToList();

            foreach(var ct in selectedClassTeachers)
            {
                response.SelectedClassTeachers.Add(new BasicUserViewModel() { Id = ct.Teacher.Id, FullName = ct.Teacher.FullName, IsPrimary = ct.IsPrimary });
            }

            var academicYearSubjects = uow.SubjectAcademicLevels.GetAll().Where(t => t.AcademicLevelId == academicLevelId).ToList();

            foreach(var subject in academicYearSubjects)
            {
                var classSubjectTeacher = new ClassSubjectTeacherViewModel();
                classSubjectTeacher.Subject = new ViewModel.Common.BasicSubjectViewModel()
                {
                    Id=subject.SubjectId,
                    Name = subject.Subject.Name
                };


                var subjectTeachers = uow.SubjectTeachers.GetAll().Where(t => t.SubjectId == subject.SubjectId && t.AcademicLevelId == academicLevelId && t.AcademicYearId == academicYearId).Select(x=>new BasicSubjectTeacherViewModel() { Id=x.Id,Name=x.Teacher.FullName}).ToList();
                foreach(var st in subjectTeachers)
                {
                    var selectedClassSubjectTeacher = uow.ClassSubjectTeachers.GetAll().FirstOrDefault(t => t.IsActive == true && t.SubjectTeacherId == st.Id && t.ClassNameId == classNameId && t.AcademicLevelId == academicLevelId && t.AcademicYearId == academicYearId);
                    if(selectedClassSubjectTeacher!=null)
                    {
                        classSubjectTeacher.SelectedSubjectTeacher = st.Id;
                    }
                }

                if(classSubjectTeacher.SelectedSubjectTeacher<=0 && subjectTeachers.Count>0)
                {
                    classSubjectTeacher.SelectedSubjectTeacher = subjectTeachers[0].Id;
                }

                response.ClassSubjectTeachers.Add(classSubjectTeacher);

   
            }

            return response;
        }

        public async Task<ResponseViewModel> SaveClassSubjectTeacherAllocation(ClassSubjectTeacherConatinerViewModel vm,string userName)
        {
            var response = new ResponseViewModel();
            try
            {
                var currentUser = uow.Users.GetAll().FirstOrDefault(t => t.Username == userName);
                var dateTimeNow = DateTime.UtcNow;

                var availableClassTeachers = vm.SelectedClassTeachers.Select(t => t.Id).ToList();
                var savedClassTeachers = uow.ClassTeachers.GetAll()
                    .Where
                    (
                        t => t.ClassNameId == vm.SelectedClassNameId &&
                        t.AcademicLevelId == vm.SelectedAcademicLevelId &&
                        t.AcademicYearId == vm.SelectedAcademicYearId
                     ).Select(t=>t.TeacherId).ToList();

                var newlyAddedClassTeachersId = availableClassTeachers.Except(savedClassTeachers);
                var deletedClassTeachersId = savedClassTeachers.Except(availableClassTeachers);

                foreach(var nclt in newlyAddedClassTeachersId)
                {
                    var selectedTeacher = vm.SelectedClassTeachers.FirstOrDefault(t => t.Id == nclt);

                    var classTeacher = new ClassTeacher()
                    {
                        ClassNameId = vm.SelectedClassNameId,
                        AcademicLevelId = vm.SelectedAcademicLevelId,
                        AcademicYearId = vm.SelectedAcademicYearId,
                        TeacherId = selectedTeacher.Id,
                        IsPrimary = selectedTeacher.IsPrimary,
                        CreatedOn = dateTimeNow,
                        CreatedById = currentUser.Id,
                        UpdatedOn = dateTimeNow,
                        UpdatedById = currentUser.Id
                    };

                    uow.ClassTeachers.Add(classTeacher);
                }

                foreach(var dclt in deletedClassTeachersId)
                {
                    var deletedClassTeacher = uow.ClassTeachers.GetAll()
                        .FirstOrDefault(t => t.ClassNameId == vm.SelectedClassNameId &&
                        t.AcademicLevelId == vm.SelectedAcademicLevelId &&
                        t.AcademicYearId == vm.SelectedAcademicYearId && t.TeacherId == dclt);

                    uow.ClassTeachers.Delete(deletedClassTeacher);
                }

                foreach (var clst in vm.ClassSubjectTeachers)
                {
                    var existingSubjectTeacher = uow.ClassSubjectTeachers.GetAll().FirstOrDefault(t => t.IsActive == true &&
                    t.ClassNameId == vm.SelectedClassNameId &&
                    t.AcademicLevelId == vm.SelectedAcademicLevelId &&
                    t.AcademicYearId == vm.SelectedAcademicYearId &&
                    t.SubjectId == clst.Subject.Id);
                    
                    if(existingSubjectTeacher==null)
                    {
                        AddNewClassSubjectTeacher(currentUser, dateTimeNow, vm, clst);
                    }
                    else if(existingSubjectTeacher!=null && existingSubjectTeacher.SubjectTeacherId!=clst.SelectedSubjectTeacher)
                    {
                        existingSubjectTeacher.IsActive = false;
                        existingSubjectTeacher.EndDate = dateTimeNow;
                        existingSubjectTeacher.UpdatedById = currentUser.Id;
                        existingSubjectTeacher.UpdatedOn = dateTimeNow;

                        uow.ClassSubjectTeachers.Update(existingSubjectTeacher);
                    }
                }

                await uow.CommitAsync();
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Operation failed. Please try again.";
            }

            return response;
        }

        
        
        private void AddNewClassSubjectTeacher(User user,DateTime currentDate, ClassSubjectTeacherConatinerViewModel vm,ClassSubjectTeacherViewModel clst)
        {
            var classSubjectTeacher = new ClassSubjectTeacher()
            {
                ClassNameId = vm.SelectedClassNameId,
                AcademicLevelId = vm.SelectedAcademicLevelId,
                AcademicYearId = vm.SelectedAcademicYearId,
                SubjectTeacherId = clst.SelectedSubjectTeacher,
                StartDate = currentDate,
                IsActive = true,
                CreatedOn = currentDate,
                CreatedById = user.Id,
                UpdatedOn = currentDate,
                UpdatedById = user.Id,
                SubjectId = clst.Subject.Id
            };

            uow.ClassSubjectTeachers.Add(classSubjectTeacher);
        }


    }
}
