﻿using SchoolManagement.Business.Interface;
using SchoolManagement.Data;
using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Admin.ClassSubjectTeacher;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using SchoolManagement.Model;
using SchoolManagement.Util;

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

            var classTeachers = uow.ClassTeachers.GetAll().Where(t => t.AcademicYearId == academicYearId && t.AcademicLevelId == academicLevelId);

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
                var classTeacher = uow.ClassTeachers.GetAll()
                .FirstOrDefault(t => t.AcademicYearId == academicYearId && t.AcademicLevelId == academicLevelId && t.ClassNameId == classNameId);


                response.AcademicLevelId = academicLevelId;
                response.AcademicYearId = academicYearId;
                response.ClassNameId = classNameId;
                response.SelectedClassTeacherId = classTeacher.TeacherId;
                response.IsvalidClassTeacher = true;

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
                        SelectedTeacherId = matchingSubjectTeacher != null ? matchingSubjectTeacher.SubjectTeacherId : 0,
                        Isvalid= matchingSubjectTeacher != null ? true : false,
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

                //foreach (var item in classTeachers)
                //{
                //    response.ClassTeachers.Add(new ClassTeacherViewModel()
                //    {
                //        AcademicLevelId = item.AcademicLevelId,
                //        AcademicYearId = item.AcademicYearId,
                //        ClassNameId = item.ClassNameId,
                //        IsPrimaryTeacher = item.IsPrimary,
                //        SelectedTeacherId = item.TeacherId
                //    });
                //}
            }
            else
            {
                response.AcademicLevelId = academicLevelId;
                response.AcademicYearId = academicYearId;
                response.ClassNameId = classNameId;
                response.SelectedClassTeacherId = 0;
                response.IsvalidClassTeacher = false;
                response.ValidationMsg = "Must be select the class teacher.";

                var academicLevelSubjects = uow.SubjectAcademicLevels.GetAll()
        .Where(t => t.AcademicLevelId == academicLevelId && t.Subject.IsActive == true
        && (t.Subject.IsParentBasketSubject == false || t.Subject.IsBuscketSubject == true)).OrderBy(t => t.Subject.Name).ToList();

                foreach (var item in academicLevelSubjects)
                {

                    response.ClassSubjectTeachers.Add(new SubjectTeacherViewModel()
                    {
                        SelectedSubjectId = item.SubjectId,
                        SubjectTeachers = GetSubjectTeachers(academicYearId, academicLevelId, item.SubjectId),
                        SelectedTeacherId = 0,
                        Isvalid = false,
                        ValidationMsg = "Please select the subject teacher."
                    }); ;
                    ;
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
                var savedClassTeacher = uow.ClassTeachers.GetAll().FirstOrDefault(t => t.AcademicYearId == vm.AcademicYearId && t.AcademicLevelId == vm.AcademicLevelId && t.ClassNameId == vm.ClassNameId && t.IsPrimary==true) ;

                if(savedClassTeacher==null)
                {
                    var classTeacher = new ClassTeacher()
                    {
                        ClassNameId = vm.ClassNameId,
                        AcademicLevelId = vm.AcademicLevelId,
                        AcademicYearId = vm.AcademicYearId,
                        TeacherId = vm.SelectedClassTeacherId,
                        IsPrimary = true,
                        CreatedOn = DateTime.UtcNow,
                        CreatedById = user.Id,
                        UpdatedOn = DateTime.UtcNow,
                        UpdatedById = user.Id
                    };

                    uow.ClassTeachers.Add(classTeacher);
                }
                else
                {
                    savedClassTeacher.TeacherId = vm.SelectedClassTeacherId;
                    savedClassTeacher.UpdatedById = user.Id;
                    savedClassTeacher.UpdatedOn = DateTime.UtcNow;

                    uow.ClassTeachers.Update(savedClassTeacher);
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
                        await uow.CommitAsync();
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
                        await uow.CommitAsync();
                    }
                }
                

                //await uow.CommitAsync();

                response.IsSuccess = true;
                response.Message = "Class Teachers and Subject Teachers has been assigned to the selected class successfully.";

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.ToString();
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
                response.Add(new DropDownViewModal() { Id = t.Id, Name = t.Teacher.FullName });
            });

            return response;
        }

        public ResponseViewModel ValidateClassTeacher(long academicYearId,long academicLevelId,long classNameId,long teacherId)
        {
            var response = new ResponseViewModel();

            var teacher = uow.ClassTeachers.GetAll().FirstOrDefault(t => t.ClassNameId != classNameId &&
            t.AcademicYearId == academicYearId &&
            t.AcademicLevelId == academicLevelId &&
            t.TeacherId == teacherId);

            if(teacher==null)
            {
                response.IsSuccess = true;
                response.Message = "Teacher is available";
            }
            else
            {
                response.IsSuccess = true;
                response.Message = "Selected teacher is already assigned to the another class.";
            }

            return response;
        }

        public ResponseViewModel ValidateAssignedSubjectTeacher(long academicYearId, long academicLevelId, long classNameId,long subjectId, long teacherId)
        {
            var response = new ResponseViewModel();

            var totalNoOfPeriodPerWeek = uow.ClassSubjectTeachers.GetAll().Where(t => t.IsActive == true && t.AcademicYearId == academicYearId && t.SubjectTeacherId == teacherId).Sum(t => t.SubjectAcademicLevel.NoOfPeriodPerWeek);

            var newAssignedSubjectCountPerWeek = uow.SubjectAcademicLevels.GetAll().FirstOrDefault(t => t.SubjectId == subjectId && t.AcademicLevelId == academicLevelId).NoOfPeriodPerWeek;

            if((totalNoOfPeriodPerWeek+ newAssignedSubjectCountPerWeek)>Constants.TEACHER_MAXIMUM_PERIOD_PER_WEEK)
            {
                response.IsSuccess = false;
                response.Message = "Unable to assigned this teacher as a subject teacher,Since his/her total weekly period count exceed the maximum weekly period count for the teacher.";
            }
            else
            {
                response.IsSuccess = true;
                response.Message = "Subject teacher is available";
            }

            return response;
        }



    }
}
