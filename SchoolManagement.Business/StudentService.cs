using SchoolManagement.Business.Interface;
using SchoolManagement.Data;
using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Admin.Student;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using SchoolManagement.Model;

namespace SchoolManagement.Business
{
    public class StudentService : IStudentService
    {
        private readonly ISMUow uow;

        public StudentService(ISMUow uow)
        {
            this.uow = uow;
        }


        public PaginatedItemsViewModel<StudentViewModel> GetAllStudents(int currentPage, int pageSize, string name, int academicLevel, int academicYear, long classId, string orderBy)
        {
            int totalRecordCount = 0;
            double totalPages = 0;
            int totalPageCount = 0;
            var vms = new List<StudentViewModel>();

            var query = uow.StudentClasses.GetAll().Where(t=>t.AcademicYearId== academicYear && t.IsActive==true).OrderBy(t => t.AcademicLevelId);

            if(academicLevel!=0)
            {
                query = query.Where(t => t.AcademicLevelId == academicLevel).OrderBy(t => t.ClassNameId);
            }

            if(classId!=0)
            {
                query = query.Where(t => t.ClassNameId == classId).OrderBy(t => t.Student.FullName);
            }

            if(!string.IsNullOrEmpty(name))
            {
                query = query.Where(t => t.Student.FullName.Contains(name)).OrderBy(t => t.AcademicLevelId);
            }

            if(orderBy == "Gender")
            {
                query = query.OrderBy(t => t.Student.Gender);
            }

            if (orderBy == "DateOfBirth")
            {
                query = query.OrderBy(t => t.Student.DateOfBirth);
            }

            totalRecordCount = query.Count();
            totalPages = (double)totalRecordCount / pageSize;
            totalPageCount = (int)Math.Ceiling(totalPages);

            var students = query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            foreach (var std in students)
            {
                var vm = new StudentViewModel
                {
                    Id = std.Id,
                    AdmissionNo = std.Student.AdmissionNo,
                    CreatedBy = std.CreatedBy.FullName,
                    CreatedOn = std.CreatedOn.ToShortDateString(),
                    DateOfBirth = std.Student.DateOfBirth,
                    EmegencyContactNo1 = std.Student.EmegencyContactNo1,
                    EmegencyContactNo2 = std.Student.EmegencyContactNo2,
                    FullName = std.Student.FullName,
                    GenderInString = std.Student.Gender.ToString(),
                    IsActive = std.IsActive,
                    UpdatedBy = std.UpdatedBy.FullName,
                    UpdatedOn = std.UpdatedOn.ToShortDateString(),

                    SelectedAcademicLevelName = std.Class.AcademicLevel.Description,
                    SelectedAcademicLevelId = std.Class.AcademicLevelId,

                    SelectedAcademicYearName=std.Class.AcademicYearId.ToString(),
                    SelectedAcademicYearId=std.Class.AcademicYearId,

                    SelectedClassName = std.Class.Name,
                    SelectedClassNameId=std.Class.ClassNameId
                };

                vms.Add(vm);
            }

            var container = new PaginatedItemsViewModel<StudentViewModel>(currentPage, pageSize, totalPageCount, totalRecordCount, vms);

            return container;
        }

        public StudentViewModel GetStudentById(long id, int academicLevel, int academicYear, int classId)
        {
            var std = uow.StudentClasses.GetAll().FirstOrDefault(st => st.Id == id && st.AcademicYearId==academicYear && st.AcademicLevelId==academicLevel && st.ClassNameId==classId);

            var vm = new StudentViewModel
            {
                Id = std.Id,
                AdmissionNo = std.Student.AdmissionNo,
                CreatedBy = std.CreatedBy.FullName,
                CreatedOn = std.CreatedOn.ToShortDateString(),
                DateOfBirth = std.Student.DateOfBirth,
                EmegencyContactNo1 = std.Student.EmegencyContactNo1,
                EmegencyContactNo2 = std.Student.EmegencyContactNo2,
                FullName = std.Student.FullName,
                GenderInString = std.Student.Gender.ToString(),
                IsActive = std.IsActive,
                UpdatedBy = std.UpdatedBy.FullName,
                UpdatedOn = std.UpdatedOn.ToShortDateString(),

                SelectedAcademicLevelName = std.Class.AcademicLevel.Description,
                SelectedAcademicLevelId = std.Class.AcademicLevelId,

                SelectedAcademicYearName = std.Class.AcademicYearId.ToString(),
                SelectedAcademicYearId = std.Class.AcademicYearId,

                SelectedClassName = std.Class.Name,
                SelectedClassNameId = std.Class.ClassNameId
            };

            return vm;

        }

        public async Task<ResponseViewModel> SaveStudent(StudentViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                if(vm.Id==0)
                {
                    var currentUser = uow.Users.GetAll().FirstOrDefault(t => t.Username == userName);
                    var dateTimeNow = DateTime.UtcNow;

                    var student = new Student()
                    {
                        AdmissionNo = vm.AdmissionNo,
                        CreatedById = currentUser.Id,
                        CreatedOn = dateTimeNow,
                        DateOfBirth = vm.DateOfBirth,
                        EmegencyContactNo1 = vm.EmegencyContactNo1,
                        EmegencyContactNo2 = vm.EmegencyContactNo2,
                        FullName = vm.FullName,
                        Gender = vm.Gender,
                        IsActive = true,
                        UpdatedById = currentUser.Id,
                        UpdatedOn = dateTimeNow
                    };

                    student.StudentClasses = new HashSet<StudentClass>();
                    student.StudentSubjects = new HashSet<StudentSubject>();

                    uow.Students.Add(student);

                    student.StudentClasses.Add(new StudentClass()
                    {
                        ClassNameId = vm.SelectedClassNameId,
                        AcademicLevelId = vm.SelectedAcademicLevelId,
                        AcademicYearId = vm.SelectedAcademicYearId,
                        IsActive = true,
                        CreatedOn = dateTimeNow,
                        CreatedById = currentUser.Id,
                        UpdatedOn = dateTimeNow,
                        UpdatedById = currentUser.Id
                    });

                    var academicYearSubjects = uow.SubjectAcademicLevels.GetAll().ToList();
                    foreach (var alsub in academicYearSubjects)
                    {
                        student.StudentSubjects.Add(new StudentSubject()
                        {
                            AcademicLevelId = alsub.AcademicLevelId,
                            AcademicYearId = vm.SelectedAcademicYearId,
                            SubjectId = alsub.SubjectId,
                            IsActive = true,
                            CreatedOn = dateTimeNow,
                            CreatedById = currentUser.Id,
                            UpdatedOn = dateTimeNow,
                            UpdatedById = currentUser.Id
                        });
                    }

                    await uow.CommitAsync();

                    response.IsSuccess = true;
                    response.Message = "New student has been added successfully.";
                }
                else
                {
                    response = await UpdateStudent(vm, userName);
                }

            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error has been occured while adding new student. Please try again.";
            }

            return response;
        }

        public async Task<ResponseViewModel> UpdateStudent(StudentViewModel vm, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var currentUser = uow.Users.GetAll().FirstOrDefault(t => t.Username == userName);
                var dateTimeNow = DateTime.UtcNow;

                var student = uow.Students.GetAll().FirstOrDefault(t => t.Id == vm.Id);

                student.AdmissionNo = vm.AdmissionNo;
                student.DateOfBirth = vm.DateOfBirth;
                student.EmegencyContactNo1 = vm.EmegencyContactNo1;
                student.EmegencyContactNo2 = vm.EmegencyContactNo2;
                student.FullName = vm.FullName;
                student.Gender = vm.Gender;
                student.UpdatedById = currentUser.Id;
                student.UpdatedOn = dateTimeNow;

                uow.Students.Update(student);
                await uow.CommitAsync();

                response.IsSuccess = true;
                response.Message = "Student has been updated successfully.";
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error has been occured while updating student. Please try again.";
            }

            return response;
        }

        public async Task<ResponseViewModel> DeleteStudentFromSchool(long id, string userName)
        {
            var response = new ResponseViewModel();

            try
            {
                var currentUser = uow.Users.GetAll().FirstOrDefault(t => t.Username == userName);
                var dateTimeNow = DateTime.UtcNow;

                var student = uow.Students.GetAll().FirstOrDefault(t => t.Id == id);
                student.IsActive = false;
                student.UpdatedById = currentUser.Id;
                student.UpdatedOn = dateTimeNow;

                uow.Students.Update(student);
                //Delete assigned class
                foreach (var cl in student.StudentClasses.ToList())
                {
                    cl.IsActive = false;
                    cl.UpdatedById = currentUser.Id;
                    cl.UpdatedOn = dateTimeNow;
                    uow.StudentClasses.Update(cl);
                }

                //Delete Assigned Subjects
                foreach(var sb in student.StudentSubjects.ToList())
                {
                    sb.IsActive = false;
                    sb.UpdatedById = currentUser.Id;
                    sb.UpdatedOn = dateTimeNow;
                    uow.StudentSubjects.Update(sb);
                }

                await uow.CommitAsync();

                response.IsSuccess = true;
                response.Message = "Student has been deleted successfully.";
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error has been occured while deleting student. Please try again.";
            }

            return response;
        }

    }
}
