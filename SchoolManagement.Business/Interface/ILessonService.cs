using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Lesson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interface
{
    public interface ILessonService
    {
        Task<LessonResponseViewModel> AddNewLesson(LessonViewModel vm, string userName);
        Task<LessonResponseViewModel> UpdateLesson(LessonViewModel vm, string userName);
        Task<ResponseViewModel> DeleteLesson(long id, string userName);
        Task<ResponseViewModel> ActivateDeletedLesson(long id, string userName);
        LessonViewModel GetLessonByIdForTeachers(long id, string userName);
        PaginatedItemsViewModel<LessonViewModel> GetOwnLessonForTeacher(LessonFilterViewModel filter, string userName);


    }
}
