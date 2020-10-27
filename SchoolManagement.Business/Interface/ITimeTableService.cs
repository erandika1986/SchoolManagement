using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.TimeTable;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business.Interface
{
    public interface ITimeTableService
    {
        Task<ResponseViewModel> GenerateTimeTable(string username);
        List<DropDownViewModal> GetAcademicYears();
        List<TimeTableViewModel> GetGeneratedTimeTable(long academicYearId);
    }
}
