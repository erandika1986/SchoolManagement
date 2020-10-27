using SchoolManagement.Business.Interface;
using SchoolManagement.Data;
using SchoolManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using SchoolManagement.Util;
using SchoolManagement.Model;
using SchoolManagement.ViewModel.TimeTable;

namespace SchoolManagement.Business
{
    public class TimeTableService : ITimeTableService
    {
        private readonly ISMUow uow;

        long academicYear;
        AcademicLevel academicLevel6;
        AcademicLevel academicLevel7;
        AcademicLevel academicLevel8;
        AcademicLevel academicLevel9;
        AcademicLevel academicLevel10;
        AcademicLevel academicLevel11;
        AcademicLevel academicLevel12;
        AcademicLevel academicLevel13;
        Day monday;
        Day tuesday;
        Day wednesday;
        Day thursday;
        Day friday;

        Subject presentationSubject;
        Subject mathSubject;
        Subject scienceSubject;
        Subject sinhalaSubject;
        Subject englisSubject;
        Subject buddhismSubject;
        Subject healthScienceSubject;
        Subject historySubject;
        Subject englishLitSubject;
        Subject geographySubject;
        Subject civicSubject;
        Subject cOMPHWSubject;
        Subject librarySubject;
        Subject tamilSubject;
        Subject pTSSubject;
        Subject iCTSubject;

        public TimeTableService(ISMUow uow)
        {
            this.uow = uow;

            academicYear = uow.AcademicYears.GetAll().Max(t => t.Id);
            academicLevel6 = uow.AcademicLevels.GetAll().FirstOrDefault(t => t.Description == Constants.GRADE6);
            academicLevel7 = uow.AcademicLevels.GetAll().FirstOrDefault(t => t.Description == Constants.GRADE7);
            academicLevel8 = uow.AcademicLevels.GetAll().FirstOrDefault(t => t.Description == Constants.GRADE8);
            academicLevel9 = uow.AcademicLevels.GetAll().FirstOrDefault(t => t.Description == Constants.GRADE9);
            academicLevel10 = uow.AcademicLevels.GetAll().FirstOrDefault(t => t.Description == Constants.GRADE10);
            academicLevel11 = uow.AcademicLevels.GetAll().FirstOrDefault(t => t.Description == Constants.GRADE11);
            academicLevel12 = uow.AcademicLevels.GetAll().FirstOrDefault(t => t.Description == Constants.GRADE12);
            academicLevel13 = uow.AcademicLevels.GetAll().FirstOrDefault(t => t.Description == Constants.GRADE13);

            monday = uow.Days.GetAll().FirstOrDefault(t => t.Name == Constants.MONDAY);
            tuesday = uow.Days.GetAll().FirstOrDefault(t => t.Name == Constants.TUESDAY);
            wednesday = uow.Days.GetAll().FirstOrDefault(t => t.Name == Constants.WEDNESDAY);
            thursday = uow.Days.GetAll().FirstOrDefault(t => t.Name == Constants.THURSDAY);
            friday = uow.Days.GetAll().FirstOrDefault(t => t.Name == Constants.FRIDAY);

            presentationSubject = uow.Subjects.GetAll().FirstOrDefault(t => t.Name == Constants.PRESENTATION_SUBJECT);
            mathSubject = uow.Subjects.GetAll().FirstOrDefault(t => t.Name == Constants.MATHS_SUBJECT);
            scienceSubject = uow.Subjects.GetAll().FirstOrDefault(t => t.Name == Constants.SCIENCE_SUBJECT);
            healthScienceSubject = uow.Subjects.GetAll().FirstOrDefault(t => t.Name == Constants.HEALTH_SCIENCE_SUBJECT);
            englisSubject = uow.Subjects.GetAll().FirstOrDefault(t => t.Name == Constants.ENGLISH);
            sinhalaSubject = uow.Subjects.GetAll().FirstOrDefault(t => t.Name == Constants.Sinhala);
            buddhismSubject = uow.Subjects.GetAll().FirstOrDefault(t => t.Name == Constants.Buddhism);
            healthScienceSubject = uow.Subjects.GetAll().FirstOrDefault(t => t.Name == Constants.HEALTH_SCIENCE_SUBJECT);
            historySubject = uow.Subjects.GetAll().FirstOrDefault(t => t.Name == Constants.History);
            englishLitSubject = uow.Subjects.GetAll().FirstOrDefault(t => t.Name == Constants.English_Lit);
            geographySubject = uow.Subjects.GetAll().FirstOrDefault(t => t.Name == Constants.Geography);
            civicSubject = uow.Subjects.GetAll().FirstOrDefault(t => t.Name == Constants.Civic);
            cOMPHWSubject = uow.Subjects.GetAll().FirstOrDefault(t => t.Name == Constants.COMP_HW);
            librarySubject = uow.Subjects.GetAll().FirstOrDefault(t => t.Name == Constants.Library);
            tamilSubject = uow.Subjects.GetAll().FirstOrDefault(t => t.Name == Constants.Tamil);
            pTSSubject = uow.Subjects.GetAll().FirstOrDefault(t => t.Name == Constants.PTS_SUBJECT);
            iCTSubject = uow.Subjects.GetAll().FirstOrDefault(t => t.Name == Constants.ICT_SUBJECT);
        }

        public async Task<ResponseViewModel> GenerateTimeTable(string username)
        {
            var response = new ResponseViewModel();

            try
            {
                var user = uow.Users.GetAll().FirstOrDefault(t => t.Username == username);

                var timeTableCount = uow.TimeTables.GetAll().Where(t => t.AcademicYearId == academicYear).Count();

                var timeTable = new TimeTable()
                {
                    AcademicYearId = academicYear,
                    CreatedById = user.Id,
                    CreatedOn = DateTime.UtcNow,
                    IsActive = true,
                    IsPublished = false,
                    Name = string.Format("{0}-TimeTable-{1}", academicYear, timeTableCount + 1),
                    UpdatedById = user.Id,
                    UpdatedOn = DateTime.UtcNow
                };

                timeTable.ClassTimeTablePeriods = new HashSet<ClassTimeTablePeriod>();

                var academicLevels = uow.AcademicLevels.GetAll().Where(t => t.Id == academicLevel6.Id || t.Id == academicLevel7.Id || t.Id == academicLevel8.Id || t.Id == academicLevel9.Id).ToList();

                foreach (var al in academicLevels)
                {
                    var gradeClasses = uow.Classes.GetAll().Where(t => t.AcademicYearId == academicYear && t.AcademicLevelId == al.Id).ToList();
                    //var subjectAcademicLevel = uow.SubjectAcademicLevels.GetAll().FirstOrDefault(t => t.AcademicLevelId == al.Id && t.SubjectId == presentationSubject.Id);

                    switch (al.Description)
                    {
                        case Constants.GRADE6:
                            {
                                foreach (var cl in gradeClasses)
                                {

                                    var classTimeTablePeriodMonday = new ClassTimeTablePeriod()
                                    {
                                        ClassNameId = cl.ClassNameId,
                                        AcademicLevelId = cl.AcademicLevelId,
                                        AcademicYearId = cl.AcademicYearId,
                                        DayId = monday.Id,
                                        PeriodId = 1,
                                        SubjectId = presentationSubject.Id,
                                        IsActive = true,
                                        CreatedOn = DateTime.UtcNow,
                                        CreatedById = user.Id,
                                        UpdatedOn = DateTime.UtcNow,
                                        UpdatedById = user.Id
                                    };



                                    var classTimeTablePeriodWednesday = new ClassTimeTablePeriod()
                                    {
                                        ClassNameId = cl.ClassNameId,
                                        AcademicLevelId = cl.AcademicLevelId,
                                        AcademicYearId = cl.AcademicYearId,
                                        DayId = wednesday.Id,
                                        PeriodId = 1,
                                        SubjectId = presentationSubject.Id,
                                        IsActive = true,
                                        CreatedOn = DateTime.UtcNow,
                                        CreatedById = user.Id,
                                        UpdatedOn = DateTime.UtcNow,
                                        UpdatedById = user.Id
                                    };

                                    AssignSubjectTeacherForPresentationSubject(classTimeTablePeriodMonday, user);
                                    AssignSubjectTeacherForPresentationSubject(classTimeTablePeriodWednesday, user);


                                    timeTable.ClassTimeTablePeriods.Add(classTimeTablePeriodMonday);
                                    timeTable.ClassTimeTablePeriods.Add(classTimeTablePeriodWednesday);
                                }
                            }
                            break;
                        case Constants.GRADE7:
                            {
                                foreach (var cl in gradeClasses)
                                {

                                    var classTimeTablePeriodTuesday = new ClassTimeTablePeriod()
                                    {
                                        ClassNameId = cl.ClassNameId,
                                        AcademicLevelId = cl.AcademicLevelId,
                                        AcademicYearId = cl.AcademicYearId,
                                        DayId = tuesday.Id,
                                        PeriodId = 1,
                                        SubjectId = presentationSubject.Id,
                                        IsActive = true,
                                        CreatedOn = DateTime.UtcNow,
                                        CreatedById = user.Id,
                                        UpdatedOn = DateTime.UtcNow,
                                        UpdatedById = user.Id
                                    };



                                    var classTimeTablePeriodThursday = new ClassTimeTablePeriod()
                                    {
                                        ClassNameId = cl.ClassNameId,
                                        AcademicLevelId = cl.AcademicLevelId,
                                        AcademicYearId = cl.AcademicYearId,
                                        DayId = thursday.Id,
                                        PeriodId = 1,
                                        SubjectId = presentationSubject.Id,
                                        IsActive = true,
                                        CreatedOn = DateTime.UtcNow,
                                        CreatedById = user.Id,
                                        UpdatedOn = DateTime.UtcNow,
                                        UpdatedById = user.Id
                                    };

                                    AssignSubjectTeacherForPresentationSubject(classTimeTablePeriodTuesday, user);
                                    AssignSubjectTeacherForPresentationSubject(classTimeTablePeriodThursday, user);

                                    timeTable.ClassTimeTablePeriods.Add(classTimeTablePeriodTuesday);
                                    timeTable.ClassTimeTablePeriods.Add(classTimeTablePeriodThursday);
                                }
                            }
                            break;
                        case Constants.GRADE8:
                            {
                                foreach (var cl in gradeClasses)
                                {

                                    var classTimeTablePeriodWednesday = new ClassTimeTablePeriod()
                                    {
                                        ClassNameId = cl.ClassNameId,
                                        AcademicLevelId = cl.AcademicLevelId,
                                        AcademicYearId = cl.AcademicYearId,
                                        DayId = wednesday.Id,
                                        PeriodId = 1,
                                        SubjectId = presentationSubject.Id,
                                        IsActive = true,
                                        CreatedOn = DateTime.UtcNow,
                                        CreatedById = user.Id,
                                        UpdatedOn = DateTime.UtcNow,
                                        UpdatedById = user.Id
                                    };


                                    AssignSubjectTeacherForPresentationSubject(classTimeTablePeriodWednesday, user);

                                    timeTable.ClassTimeTablePeriods.Add(classTimeTablePeriodWednesday);
                                }
                            }
                            break;
                        case Constants.GRADE9:
                            {
                                foreach (var cl in gradeClasses)
                                {

                                    var classTimeTablePeriodThursday = new ClassTimeTablePeriod()
                                    {
                                        ClassNameId = cl.ClassNameId,
                                        AcademicLevelId = cl.AcademicLevelId,
                                        AcademicYearId = cl.AcademicYearId,
                                        DayId = thursday.Id,
                                        PeriodId = 1,
                                        SubjectId = presentationSubject.Id,
                                        IsActive = true,
                                        CreatedOn = DateTime.UtcNow,
                                        CreatedById = user.Id,
                                        UpdatedOn = DateTime.UtcNow,
                                        UpdatedById = user.Id
                                    };


                                    AssignSubjectTeacherForPresentationSubject(classTimeTablePeriodThursday, user);

                                    timeTable.ClassTimeTablePeriods.Add(classTimeTablePeriodThursday);
                                }
                            }
                            break;
                    }

                }

                //For class teachers
                var classTeachers = uow.ClassTeachers.GetAll().Where(t => t.AcademicYearId == academicYear).ToList();

                foreach (var clt in classTeachers)
                {
                    var classSubjectTeachers = uow.ClassSubjectTeachers.GetAll().Where(t => t.ClassNameId == clt.ClassNameId &&
                    t.AcademicLevelId == clt.AcademicLevelId &&
                    t.AcademicYearId == clt.AcademicYearId &&
                    t.SubjectTeacher.TeacherId == clt.TeacherId && t.SubjectId != presentationSubject.Id).ToList();


                    foreach (var item in classSubjectTeachers)
                    {

                        var subjectAcademicLevel = uow.SubjectAcademicLevels.GetAll().FirstOrDefault(t => t.AcademicLevelId == item.AcademicLevelId && t.SubjectId == item.SubjectId);

                        var noOfPeriodPerWeek = subjectAcademicLevel.NoOfPeriodPerWeek;
                        var remainingDoublePeriod = subjectAcademicLevel.NoOfPeriodPerWeek - 5;
                        var remainingSinglePeriod = noOfPeriodPerWeek - 2 * remainingDoublePeriod;
                        var isDoublePeriodAvailable = remainingDoublePeriod > 0 ? true : false;
                        var noOfDays = 5;

                        for (int i = 1; i <= noOfDays; i++)
                        {
                            if (noOfPeriodPerWeek > 0)
                            {
                                var allocatedPeriodCountForDay = timeTable.ClassTimeTablePeriods.Where(t => t.ClassNameId == item.ClassNameId &&
                                    t.AcademicYearId == academicYear &&
                                    t.AcademicLevelId == item.AcademicLevelId &&
                                    t.DayId == i).Count();

                                bool isPeriodEntered = false;

                                if (remainingDoublePeriod > 0 && allocatedPeriodCountForDay <= 6)
                                {
                                    var classTeacherPeriod1 = new ClassTimeTablePeriod()
                                    {
                                        ClassNameId = item.ClassNameId,
                                        AcademicLevelId = item.AcademicLevelId,
                                        AcademicYearId = item.AcademicYearId,
                                        DayId = i,
                                        PeriodId = allocatedPeriodCountForDay + 1,
                                        SubjectId = item.SubjectId,
                                        IsActive = true,
                                        CreatedOn = DateTime.UtcNow,
                                        CreatedById = user.Id,
                                        UpdatedOn = DateTime.UtcNow,
                                        UpdatedById = user.Id
                                    };

                                    var classTeacherPeriod2 = new ClassTimeTablePeriod()
                                    {
                                        ClassNameId = item.ClassNameId,
                                        AcademicLevelId = item.AcademicLevelId,
                                        AcademicYearId = item.AcademicYearId,
                                        DayId = i,
                                        PeriodId = allocatedPeriodCountForDay + 2,
                                        SubjectId = item.SubjectId,
                                        IsActive = true,
                                        CreatedOn = DateTime.UtcNow,
                                        CreatedById = user.Id,
                                        UpdatedOn = DateTime.UtcNow,
                                        UpdatedById = user.Id
                                    };

                                    GetSubjectTeacherForOtherSubjects(classTeacherPeriod1, user);
                                    GetSubjectTeacherForOtherSubjects(classTeacherPeriod2, user);

                                    timeTable.ClassTimeTablePeriods.Add(classTeacherPeriod1);
                                    timeTable.ClassTimeTablePeriods.Add(classTeacherPeriod2);
                                    noOfPeriodPerWeek = noOfPeriodPerWeek - 2;
                                    remainingDoublePeriod--;
                                    isPeriodEntered = true;
                                }


                                if (remainingSinglePeriod > 0 && isPeriodEntered == false && allocatedPeriodCountForDay <= 7)
                                {
                                    var classTeacherPeriod = new ClassTimeTablePeriod()
                                    {
                                        ClassNameId = item.ClassNameId,
                                        AcademicLevelId = item.AcademicLevelId,
                                        AcademicYearId = item.AcademicYearId,
                                        DayId = i,
                                        PeriodId = allocatedPeriodCountForDay + 1,
                                        SubjectId = item.SubjectId,
                                        IsActive = true,
                                        CreatedOn = DateTime.UtcNow,
                                        CreatedById = user.Id,
                                        UpdatedOn = DateTime.UtcNow,
                                        UpdatedById = user.Id
                                    };

                                    GetSubjectTeacherForOtherSubjects(classTeacherPeriod, user);
                                    timeTable.ClassTimeTablePeriods.Add(classTeacherPeriod);
                                    noOfPeriodPerWeek--;
                                    remainingSinglePeriod--;

                                    if (item.SubjectAcademicLevel.Subject.Name == Constants.PTS_SUBJECT && allocatedPeriodCountForDay <= 7)
                                    {
                                        var ictPeriodId = allocatedPeriodCountForDay + 2;
                                        var ictSubject = uow.SubjectAcademicLevels.GetAll().FirstOrDefault(t => t.Subject.Name == Constants.ICT_SUBJECT && t.AcademicLevelId == item.AcademicLevelId);
                                        var subjectTeacher = uow.ClassSubjectTeachers.GetAll().Where(t => t.AcademicLevelId == item.AcademicLevelId && t.AcademicYearId == item.AcademicYearId && t.ClassNameId == item.ClassNameId && t.SubjectId == ictSubject.SubjectId).Select(t => t.SubjectTeacher).Select(t => t.Teacher).Distinct().FirstOrDefault();
                                        var availablePeriod = GetTeacherAvailablePeriods(subjectTeacher.Id, timeTable).DayAllocations.Where(t => t.DayId == i).SelectMany(t => t.AvailablePeriodIds).Where(t => t == ictPeriodId).Count();
                                        var noOfICTSubjectPerWeek = ictSubject.NoOfPeriodPerWeek;

                                        var savedICTSubject = timeTable.ClassTimeTablePeriods.Where(t => t.ClassNameId == item.ClassNameId && t.AcademicLevelId == item.AcademicLevelId && t.AcademicYearId == item.AcademicYearId && t.SubjectId == ictSubject.SubjectId).Count();

                                        if (savedICTSubject < noOfICTSubjectPerWeek && availablePeriod > 0)
                                        {
                                            var ictPeriod = new ClassTimeTablePeriod()
                                            {
                                                ClassNameId = item.ClassNameId,
                                                AcademicLevelId = item.AcademicLevelId,
                                                AcademicYearId = item.AcademicYearId,
                                                DayId = i,
                                                PeriodId = ictPeriodId,
                                                SubjectId = ictSubject.SubjectId,
                                                IsActive = true,
                                                CreatedOn = DateTime.UtcNow,
                                                CreatedById = user.Id,
                                                UpdatedOn = DateTime.UtcNow,
                                                UpdatedById = user.Id
                                            };

                                            GetSubjectTeacherForOtherSubjects(ictPeriod, user);
                                            timeTable.ClassTimeTablePeriods.Add(ictPeriod);
                                            noOfPeriodPerWeek--;
                                        }


                                    }
                                }
                            }
                        }

                    }
                }


                //For Math Subject
                var mathTeachers = uow.ClassSubjectTeachers.GetAll().Where(t => t.AcademicYearId == academicYear && t.SubjectId == mathSubject.Id && t.IsActive == true).ToList();
                AddSubjectTeachersPeriodAllocation(mathTeachers, timeTable, user);

                //For Science Subject
                var scienceTeachers = uow.ClassSubjectTeachers.GetAll().Where(t => t.AcademicYearId == academicYear && t.SubjectId == scienceSubject.Id && t.IsActive == true).ToList();
                AddSubjectTeachersPeriodAllocation(scienceTeachers, timeTable, user);

                //For English Subject
                var englishTeachers = uow.ClassSubjectTeachers.GetAll().Where(t => t.AcademicYearId == academicYear && t.SubjectId == englisSubject.Id && t.IsActive == true).ToList();
                AddSubjectTeachersPeriodAllocation(englishTeachers, timeTable, user);

                //For English Subject
                var sinhalaTeachers = uow.ClassSubjectTeachers.GetAll().Where(t => t.AcademicYearId == academicYear && t.SubjectId == sinhalaSubject.Id && t.IsActive == true).ToList();
                AddSubjectTeachersPeriodAllocation(sinhalaTeachers, timeTable, user);

                var buddhismTeachers = uow.ClassSubjectTeachers.GetAll().Where(t => t.AcademicYearId == academicYear && t.SubjectId == buddhismSubject.Id && t.IsActive == true).ToList();
                AddSubjectTeachersPeriodAllocation(buddhismTeachers, timeTable, user);

                var historyTeachers = uow.ClassSubjectTeachers.GetAll().Where(t => t.AcademicYearId == academicYear && t.SubjectId == historySubject.Id && t.IsActive == true).ToList();
                AddSubjectTeachersPeriodAllocation(historyTeachers, timeTable, user);

                var hsTeachers = uow.ClassSubjectTeachers.GetAll().Where(t => t.AcademicYearId == academicYear && t.SubjectId == healthScienceSubject.Id && t.IsActive == true).ToList();
                AddSubjectTeachersPeriodAllocation(hsTeachers, timeTable, user);

                var elTeachers = uow.ClassSubjectTeachers.GetAll().Where(t => t.AcademicYearId == academicYear && t.SubjectId == englishLitSubject.Id && t.IsActive == true).ToList();
                AddSubjectTeachersPeriodAllocation(elTeachers, timeTable, user);

                var geoTeachers = uow.ClassSubjectTeachers.GetAll().Where(t => t.AcademicYearId == academicYear && t.SubjectId == geographySubject.Id && t.IsActive == true).ToList();
                AddSubjectTeachersPeriodAllocation(geoTeachers, timeTable, user);

                var civicTeachers = uow.ClassSubjectTeachers.GetAll().Where(t => t.AcademicYearId == academicYear && t.SubjectId == civicSubject.Id && t.IsActive == true).ToList();
                AddSubjectTeachersPeriodAllocation(civicTeachers, timeTable, user);

                var ptsTeachers = uow.ClassSubjectTeachers.GetAll().Where(t => t.AcademicYearId == academicYear && t.SubjectId == pTSSubject.Id && t.IsActive == true).ToList();
                AddSubjectTeachersPeriodAllocation(ptsTeachers, timeTable, user);

                var ictTeachers = uow.ClassSubjectTeachers.GetAll().Where(t => t.AcademicYearId == academicYear && t.SubjectId == iCTSubject.Id && t.IsActive == true).ToList();
                AddSubjectTeachersPeriodAllocation(ictTeachers, timeTable, user);

                var chweachers = uow.ClassSubjectTeachers.GetAll().Where(t => t.AcademicYearId == academicYear && t.SubjectId == cOMPHWSubject.Id && t.IsActive == true).ToList();
                AddSubjectTeachersPeriodAllocation(chweachers, timeTable, user);

                var tamileachers = uow.ClassSubjectTeachers.GetAll().Where(t => t.AcademicYearId == academicYear && t.SubjectId == tamilSubject.Id && t.IsActive == true).ToList();
                AddSubjectTeachersPeriodAllocation(tamileachers, timeTable, user);

                //var libararyTeachers = uow.ClassSubjectTeachers.GetAll().Where(t => t.AcademicYearId == academicYear && t.SubjectId == LlbrarySubject.Id && t.IsActive == true).ToList();
                //AddSubjectTeachersPeriodAllocation(libararyTeachers, timeTable, user);

                //otherSubjectTeachers

                //var subjectTeachers = uow.Roles.GetAll().Where(t => t.Name == "Teacher").SelectMany(t => t.UserRoles).Select(t=>t.User).Distinct().ToList();

                //var otherSubjectTeachers = uow.ClassSubjectTeachers.GetAll()
                //    .Where(t => t.AcademicYearId == academicYear &&
                //    t.SubjectId != mathSubject.Id &&
                //    t.SubjectId != scienceSubject.Id &&
                //    t.SubjectId != presentationSubject.Id &&
                //    t.SubjectId != librarySubject.Id &&
                //    t.IsActive == true).OrderByDescending(t => t.SubjectAcademicLevel.NoOfPeriodPerWeek).ToList();
                //AddSubjectTeachersPeriodAllocation(otherSubjectTeachers, timeTable, user);


                uow.TimeTables.Add(timeTable);
                await uow.CommitAsync();

                response.IsSuccess = true;
                response.Message = "Time table has been generated successfully.";
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error has been occured while generating the Time table. Please try again";
            }





            return response;
        }

        private void AddSubjectTeachersPeriodAllocation(List<ClassSubjectTeacher> subjectTeachers, TimeTable timeTable,User user)
        {
            foreach (var cst in subjectTeachers)
            {
                if(cst.SubjectId==9 && cst.AcademicLevelId==8 && cst.ClassNameId==1)
                {
                    Console.WriteLine("Test");
                }
                var subjectAcademicLevel = uow.SubjectAcademicLevels.GetAll().FirstOrDefault(t => t.AcademicLevelId == cst.AcademicLevelId && t.SubjectId == cst.SubjectId);

                //Check subject is already entered as a class Teacher subject
                var classSubjectCount = timeTable.ClassTimeTablePeriods.Where(t => t.ClassNameId == cst.ClassNameId &&
                t.AcademicLevelId == cst.AcademicLevelId &&
                t.AcademicYearId == cst.AcademicYearId &&
                t.SubjectId == cst.SubjectId).Count();



                if (classSubjectCount == 0)
                {
                    var noofPeriodUnChange = subjectAcademicLevel.NoOfPeriodPerWeek;
                    var noOfPeriodPerWeek = subjectAcademicLevel.NoOfPeriodPerWeek;
                    var remainingDoublePeriod = subjectAcademicLevel.NoOfPeriodPerWeek - 5;
                    var remainingSinglePeriod = noOfPeriodPerWeek - 2 * remainingDoublePeriod;
                    var isDoublePeriodAvailable = remainingDoublePeriod > 0 ? true : false;
                    var noOfDays = 5;
                    var remainingDays = 5;

                    var availablePeriodsForSubjectTearcher = GetTeacherAvailablePeriods(cst.SubjectTeacher.TeacherId, timeTable);


                    for (int i = 1; i <= noOfDays; i++)
                    {
                        if (noOfPeriodPerWeek > 0)
                        {
                            var allocatedPeriodPeriodForDay = timeTable.ClassTimeTablePeriods.Where(t => t.ClassNameId == cst.ClassNameId &&
                                t.AcademicYearId == academicYear &&
                                t.AcademicLevelId == cst.AcademicLevelId &&
                                t.DayId == i).Select(t => t.PeriodId).OrderBy(t => t).ToList();

                            if (noOfPeriodPerWeek > remainingDays && remainingDoublePeriod==0)
                            {
                                remainingDoublePeriod = subjectAcademicLevel.NoOfPeriodPerWeek - remainingDays;
                                remainingSinglePeriod = noOfPeriodPerWeek - 2 * remainingDoublePeriod;
                                isDoublePeriodAvailable = remainingDoublePeriod > 0 ? true : false;
                            }

                            var availableDoublePeriod = GetAvailableDoublePeriodForClass(allocatedPeriodPeriodForDay);
                            var avaialablePeriods = GetAvailablePeriodsForClass(allocatedPeriodPeriodForDay);
                            var teacherDay = availablePeriodsForSubjectTearcher.DayAllocations.FirstOrDefault(t => t.DayId == i);
                            var teacherAvailablePeriods = teacherDay.AvailablePeriodIds;
                            var teacherAvailableDoublePeriods = GetAvailableDoublePeriodForTeacher(teacherDay.AvailablePeriodIds);
                            bool isPeriodEntered = false;

                            if (remainingDoublePeriod > 0 && availableDoublePeriod.Count > 0)
                            {
                                foreach (var item in availableDoublePeriod)
                                {
                                    bool isMatchingPeriondFound = false;
                                    foreach (var tp in teacherAvailableDoublePeriods)
                                    {
                                        if (tp.FirstPeriod == item.FirstPeriod && tp.SecondPeriod == item.SecondPeriod)
                                        {
                                            var mathPeriod1 = new ClassTimeTablePeriod()
                                            {
                                                ClassNameId = cst.ClassNameId,
                                                AcademicLevelId = cst.AcademicLevelId,
                                                AcademicYearId = cst.AcademicYearId,
                                                DayId = i,
                                                PeriodId = tp.FirstPeriod,
                                                SubjectId = cst.SubjectId,
                                                IsActive = true,
                                                CreatedOn = DateTime.UtcNow,
                                                CreatedById = user.Id,
                                                UpdatedOn = DateTime.UtcNow,
                                                UpdatedById = user.Id
                                            };

                                            var mathPeriod2 = new ClassTimeTablePeriod()
                                            {
                                                ClassNameId = cst.ClassNameId,
                                                AcademicLevelId = cst.AcademicLevelId,
                                                AcademicYearId = cst.AcademicYearId,
                                                DayId = i,
                                                PeriodId = tp.SecondPeriod,
                                                SubjectId = cst.SubjectId,
                                                IsActive = true,
                                                CreatedOn = DateTime.UtcNow,
                                                CreatedById = user.Id,
                                                UpdatedOn = DateTime.UtcNow,
                                                UpdatedById = user.Id
                                            };

                                            GetSubjectTeacherForOtherSubjects(mathPeriod1, user);
                                            GetSubjectTeacherForOtherSubjects(mathPeriod2, user);

                                            timeTable.ClassTimeTablePeriods.Add(mathPeriod1);
                                            timeTable.ClassTimeTablePeriods.Add(mathPeriod2);
                                            noOfPeriodPerWeek = noOfPeriodPerWeek - 2;
                                            remainingDoublePeriod--;
                                            isPeriodEntered = true;
                                            isMatchingPeriondFound = true;
                                            break;
                                        }
                                    }

                                    if (isMatchingPeriondFound)
                                    {
                                        break;
                                    }
                                }

                            }


                            if (remainingSinglePeriod > 0 && allocatedPeriodPeriodForDay.Count <= 7 && isPeriodEntered == false)
                            {
                                foreach (var item in avaialablePeriods)
                                {
                                    bool isMatchingPeriondFound = false;
                                    foreach (var tp in teacherAvailablePeriods)
                                    {
                                        if (item == tp)
                                        {
                                            var classTeacherPeriod = new ClassTimeTablePeriod()
                                            {
                                                ClassNameId = cst.ClassNameId,
                                                AcademicLevelId = cst.AcademicLevelId,
                                                AcademicYearId = cst.AcademicYearId,
                                                DayId = i,
                                                PeriodId = tp,
                                                SubjectId = cst.SubjectId,
                                                IsActive = true,
                                                CreatedOn = DateTime.UtcNow,
                                                CreatedById = user.Id,
                                                UpdatedOn = DateTime.UtcNow,
                                                UpdatedById = user.Id
                                            };

                                            GetSubjectTeacherForOtherSubjects(classTeacherPeriod, user);
                                            timeTable.ClassTimeTablePeriods.Add(classTeacherPeriod);
                                            remainingSinglePeriod--;
                                            noOfPeriodPerWeek--;
                                            isMatchingPeriondFound = true;
                                            break;
                                        }

                                    }

                                    if (isMatchingPeriondFound)
                                    {
                                        break;
                                    }
                                }



                            }
                        }

                        remainingDays--;
                    }

                    //if(noOfPeriodPerWeek>0)
                    //{
                    //    for (int r = 1; r <= noOfPeriodPerWeek; r++)
                    //    {
                    //        bool isFound = false;
                    //        for (int d = 1; d <= noOfDays; d++)
                    //        {
                    //            for (int p = 1; p <= 8; p++)
                    //            {
                    //                var currentPariod = timeTable.ClassTimeTablePeriods.FirstOrDefault(t => t.PeriodId == p &&
                    //                t.DayId == d &&
                    //                t.ClassNameId == cst.ClassNameId &&
                    //                t.AcademicLevelId == cst.AcademicLevelId &&
                    //                t.AcademicYearId == cst.AcademicYearId);
                    //                if (currentPariod !=null && ( currentPariod.SubjectId != presentationSubject.Id || currentPariod.SubjectId!= cst.SubjectId))
                    //                {
                    //                    var assignedTeacherAvailablePeriods = GetTeacherAvailablePeriods(currentPariod.ClassTimeTablePeriodAssignTeachers.FirstOrDefault().TeacherId, timeTable);
                    //                    var assigneTeacherAvailableDayPeriod = assignedTeacherAvailablePeriods.TeacherDayAllocations.FirstOrDefault(t => t.DayId == d);

                    //                    var teacherDay = availablePeriodsForSubjectTearcher.TeacherDayAllocations.FirstOrDefault(t => t.DayId == d);
                    //                    var teacherAvailablePeriods = teacherDay.AvailablePeriodIds;

                    //                    foreach (var atp in assigneTeacherAvailableDayPeriod.AvailablePeriodIds)
                    //                    {
                    //                        foreach (var stp in teacherDay.AvailablePeriodIds)
                    //                        {
                    //                            if (atp == stp)
                    //                            {
                    //                                //then again find an available date for the assignedUser
                    //                                var allocatedPeriodPeriodForDay = timeTable.ClassTimeTablePeriods.Where(t => t.ClassNameId == currentPariod.ClassNameId &&
                    //                                        t.AcademicYearId == academicYear &&
                    //                                        t.AcademicLevelId == currentPariod.AcademicLevelId &&
                    //                                        t.DayId == d).Select(t => t.PeriodId).OrderBy(t => t).ToList();
                    //                                var avaialablePeriods = GetAvailablePeriodsForClass(allocatedPeriodPeriodForDay);

                    //                                foreach (var item in avaialablePeriods)
                    //                                {
                    //                                    if (item == atp)
                    //                                    {
                    //                                        currentPariod.DayId = d;
                    //                                        currentPariod.PeriodId = item;

                    //                                        var classTeacherPeriod = new ClassTimeTablePeriod()
                    //                                        {
                    //                                            ClassNameId = cst.ClassNameId,
                    //                                            AcademicLevelId = cst.AcademicLevelId,
                    //                                            AcademicYearId = cst.AcademicYearId,
                    //                                            DayId = d,
                    //                                            PeriodId = atp,
                    //                                            SubjectId = cst.SubjectId,
                    //                                            IsActive = true,
                    //                                            CreatedOn = DateTime.UtcNow,
                    //                                            CreatedById = user.Id,
                    //                                            UpdatedOn = DateTime.UtcNow,
                    //                                            UpdatedById = user.Id
                    //                                        };

                    //                                        GetSubjectTeacherForOtherSubjects(classTeacherPeriod, user);
                    //                                        timeTable.ClassTimeTablePeriods.Add(classTeacherPeriod);
                    //                                        noOfPeriodPerWeek--;
                    //                                        isFound = true;
                    //                                        break;
                    //                                    }
                    //                                }

                    //                            }

                    //                            if (isFound)
                    //                                break;
                    //                        }

                    //                        if (isFound)
                    //                            break;
                    //                    }
                    //                }
                    //                else if(currentPariod == null)
                    //                {
                    //                    Console.WriteLine("asasdasd");
                    //                }
                                    


                    //                if (isFound)
                    //                    break;


                    //            }

                    //            if (isFound)
                    //                break;
                    //        }


                    //    }


                    //}


                }


            }
        }

        private void FillMissingSubjects(TimeTable timeTable,User user)
        {
            var academicLevels = uow.AcademicLevels.GetAll().Where(t => t.Id != academicLevel12.Id && t.Id != academicLevel13.Id).ToList();

            foreach (var academicLevel in academicLevels)
            {
                foreach(var subject in academicLevel.SubjectAcademicLevels)
                {
                    var classes = academicLevel.Classes.Where(t=>t.AcademicYearId==academicYear);
                    foreach(var cl in classes)
                    {
                        var assignedPeriodCount = timeTable.ClassTimeTablePeriods.Where(t => 
                        t.SubjectId == subject.SubjectId && 
                        t.ClassNameId == cl.ClassNameId && 
                        t.AcademicLevelId== academicLevel.Id && 
                        t.AcademicYearId==academicYear).Count();

                        if(assignedPeriodCount<subject.NoOfPeriodPerWeek)
                        {
                            var missingPeriods = FindMissingPeriodForClass(timeTable, cl);
                            var teacher = uow.ClassSubjectTeachers.GetAll().FirstOrDefault(t => t.AcademicYearId == academicYear && 
                            t.AcademicLevelId == academicLevel.Id && 
                            t.ClassNameId == cl.ClassNameId && 
                            t.SubjectId == subject.SubjectId).SubjectTeacher;

                            var teacherAvailablePeriods = GetTeacherAvailablePeriods(teacher.TeacherId, timeTable);

                            foreach (var day in missingPeriods.DayAllocations)
                            {
                                foreach(var period in day.AvailablePeriodIds)
                                {
                                    var teacherAllocatedClassPeriod = timeTable.ClassTimeTablePeriods.Where(t => t.PeriodId == period && 
                                    t.DayId == day.DayId && t.ClassNameId!=cl.ClassNameId).SelectMany(t=>t.ClassTimeTablePeriodAssignTeachers).FirstOrDefault(t=>t.TeacherId== teacher.TeacherId);

                                    var teacherPeriods = GetTeacherAvailablePeriods(teacher.TeacherId, timeTable).DayAllocations.FirstOrDefault(t => t.DayId == day.DayId).AvailablePeriodIds;

                                    if (teacherAllocatedClassPeriod != null)
                                    {
                                        var subjectTeachers = uow.ClassSubjectTeachers.GetAll().Where(t => t.AcademicYearId == academicYear && 
                                        t.AcademicLevelId == academicLevel.Id && 
                                        t.ClassNameId == cl.ClassNameId  && 
                                        t.SubjectTeacher.TeacherId!= teacher.Id).Select(t=>t.SubjectTeacher);

                                        foreach (var subjectTeacher in subjectTeachers)
                                        {
                                            var availablePeriods = GetTeacherAvailablePeriods(subjectTeacher.TeacherId, timeTable).DayAllocations.FirstOrDefault(t=>t.DayId==day.DayId).AvailablePeriodIds;
                                            var matchingPeriodCount = availablePeriods.Where(t => t == period).Count();
                                            var teacherAllocatedPeriods = GetTeacherDayAllocation(timeTable, subjectTeacher.TeacherId, day.DayId);
                                            var intersects = teacherPeriods.Intersect(availablePeriods).ToList();
                                            if (matchingPeriodCount>0 && intersects.Count>0)
                                                {

                                            }
                                     
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void AssignSubjectTeacherForPresentationSubject(ClassTimeTablePeriod ctp,User user)
        {
            ctp.ClassTimeTablePeriodAssignTeachers = new HashSet<ClassTimeTablePeriodAssignTeacher>();

            if(ctp.ClassNameId==5)
            {

            }
            //Get All Math,Science and Health Science Teachers
            var presentationTeachers = uow.ClassSubjectTeachers.GetAll().Where(t => t.AcademicLevelId == ctp.AcademicLevelId && t.AcademicYearId==ctp.AcademicYearId && t.ClassNameId==ctp.ClassNameId && t.IsActive==true && (t.SubjectId == mathSubject.Id || t.SubjectId == scienceSubject.Id || t.SubjectId == healthScienceSubject.Id)).Select(t => t.SubjectTeacher).Select(t=>t.Teacher).Distinct().ToList();
            foreach (var item in presentationTeachers)
            {
                var assignedTeacher = new ClassTimeTablePeriodAssignTeacher()
                {
                    TeacherId = item.Id,
                    AllocatedDate = DateTime.UtcNow,
                    IsActive = true,
                    CreatedOn = DateTime.UtcNow,
                    CreatedById = user.Id,
                    UpdatedOn = DateTime.UtcNow,
                    UpdatedById = user.Id
                };

                ctp.ClassTimeTablePeriodAssignTeachers.Add(assignedTeacher);
               // ctp.ClassTimeTablePeriodAssignTeachers.Add(assignedTeacher);
            }

            //return ctp;

        }

        private void GetSubjectTeacherForOtherSubjects(ClassTimeTablePeriod ctp, User user)
        {
            ctp.ClassTimeTablePeriodAssignTeachers = new HashSet<ClassTimeTablePeriodAssignTeacher>();
            var subjectTeacher = uow.ClassSubjectTeachers.GetAll().Where(t => t.AcademicLevelId == ctp.AcademicLevelId && t.AcademicYearId == ctp.AcademicYearId && t.ClassNameId == ctp.ClassNameId && t.SubjectId==ctp.SubjectId).Select(t => t.SubjectTeacher).Select(t => t.Teacher).Distinct().FirstOrDefault();

            var assignedTeacher = new ClassTimeTablePeriodAssignTeacher()
            {
                TeacherId = subjectTeacher.Id,
                AllocatedDate = DateTime.UtcNow,
                IsActive = true,
                CreatedOn = DateTime.UtcNow,
                CreatedById = user.Id,
                UpdatedOn = DateTime.UtcNow,
                UpdatedById = user.Id
            };

            ctp.ClassTimeTablePeriodAssignTeachers.Add(assignedTeacher);
        }

        private TeacherAvailablePeriods GetTeacherAvailablePeriods(long teacherId,TimeTable timeTable)
        {
            var response = new TeacherAvailablePeriods()
            {
                TeacherId = teacherId
            };

            var allPeriods = timeTable.ClassTimeTablePeriods.Where(t => t.AcademicYearId == academicYear).SelectMany(t => t.ClassTimeTablePeriodAssignTeachers).Where(t => t.TeacherId == teacherId);

            //Loop through days
            for (int d = 1; d <= 5; d++)
            {
                var dayAllocation = new DayAllocation()
                {
                    DayId = d
                };

                //Loop through periods
                for (int p = 1; p <= 8; p++)
                {
                    var period = timeTable.ClassTimeTablePeriods.Where(t => t.DayId == d && t.PeriodId == p).SelectMany(t => t.ClassTimeTablePeriodAssignTeachers).FirstOrDefault(t => t.TeacherId == teacherId);

                    if(period==null)
                    {
                        dayAllocation.AvailablePeriodIds.Add(p);
                    }
                    
                }

                response.DayAllocations.Add(dayAllocation);
            }

            return response;

        }

        private List<AvailableDoublePeriod> GetAvailableDoublePeriodForClass(List<long> alreadyallocatedPeriods)
        {
            var response = new List<AvailableDoublePeriod>();
            var availablePeriods = new List<long>();
            for (long i = 1; i <= 8; i++)
            {
                if(!alreadyallocatedPeriods.Contains(i))
                {
                    availablePeriods.Add(i);
                }
            }

            for (int i = 0; i < availablePeriods.Count; i++)
            {
                if(i== availablePeriods.Count-1)
                {
                    break;
                }

                if(availablePeriods[i+1]- availablePeriods[i] ==1)
                {
                    response.Add(new AvailableDoublePeriod() { FirstPeriod = availablePeriods[i], SecondPeriod = availablePeriods[i + 1] });
                }
            }

            return response;
        }

        private List<AvailableDoublePeriod> GetAvailableDoublePeriodForTeacher(List<long> availablePeriods)
        {
            var response = new List<AvailableDoublePeriod>();

            for (int i = 0; i < availablePeriods.Count; i++)
            {
                if (i == availablePeriods.Count - 1)
                {
                    break;
                }

                if (availablePeriods[i + 1] - availablePeriods[i] == 1)
                {
                    response.Add(new AvailableDoublePeriod() { FirstPeriod = availablePeriods[i], SecondPeriod = availablePeriods[i + 1] });
                }
            }

            return response;
        }

        private List<long> GetAvailablePeriodsForClass(List<long> alreadyallocatedPeriods)
        {
            var availablePeriods = new List<long>();
            for (long i = 1; i <= 8; i++)
            {
                if (!alreadyallocatedPeriods.Contains(i))
                {
                    availablePeriods.Add(i);
                }
            }

            return availablePeriods;
        }

        public List<DropDownViewModal> GetAcademicYears()
        {
            var response = new List<DropDownViewModal>();

            var academicYears = uow.AcademicYears.GetAll().ToList();

            academicYears.ForEach(ac =>
            {
                response.Add(new DropDownViewModal() { Id = ac.Id, Name = ac.Id.ToString() });

            });

            return response;
        }

        public List<TimeTableViewModel> GetGeneratedTimeTable(long academicYearId)
        {
            var response = new List<TimeTableViewModel>();

            var timeTables = uow.TimeTables.GetAll().ToList();

            timeTables.ForEach(t =>
            {
                response.Add(new TimeTableViewModel() { Id = t.Id, CreatedBy = t.CreatedBy.FullName, CreatedOn = t.CreatedOn.ToShortDateString(), IsPublished = t.IsPublished, Name = t.Name });
            });

            return response;
        }

        private TeacherAvailablePeriods FindMissingPeriodForClass(TimeTable timeTable,Class cl)
        {
            var response = new TeacherAvailablePeriods();

            for (int day = 1; day <=5; day++)
            {
                var teacherDay = new DayAllocation()
                {
                    DayId=day
                };
                for (int period = 1; period <= 8; period++)
                {
                    var assinedPeriod = timeTable.ClassTimeTablePeriods
                        .FirstOrDefault(t => t.ClassNameId == cl.ClassNameId && 
                    t.AcademicLevelId == cl.AcademicLevelId && 
                    t.DayId==day && t.PeriodId==period);

                    if(assinedPeriod==null)
                    {
                        teacherDay.AvailablePeriodIds.Add(period);
                    }
                }

                response.DayAllocations.Add(teacherDay);
            }

            return response;
        }

        private List<long> GetTeacherDayAllocation(TimeTable timeTable,long teacherId,long dayId)
        {
            var dayAllocatedPeriods = new List<long>();
            //for (int period = 1; period <= 8; period++)
            //{
            //    var p = timeTable.ClassTimeTablePeriods.Where(t => t.DayId == dayId && t.PeriodId == period).SelectMany(t => t.ClassTimeTablePeriodAssignTeachers).FirstOrDefault(t => t.TeacherId == teacherId);
            //    if(p!=null)
            //    {
            //        dayAllocatedPeriods.Add(p);
            //    }
            //}

            return dayAllocatedPeriods;
        }
    }

    public class TeacherAvailablePeriods
    {
        public TeacherAvailablePeriods()
        {
            DayAllocations = new List<DayAllocation>();
        }
        public long TeacherId { get; set; }
        public List<DayAllocation> DayAllocations { get; set; }
       

    }

    public class DayAllocation
    {
        public DayAllocation()
        {
            AvailablePeriodIds = new List<long>();
        }
        public long DayId { get; set; }
        public List<long> AvailablePeriodIds { get; set; }
    }

    public class AvailableDoublePeriod
    {
        public long FirstPeriod { get; set; }
        public long SecondPeriod { get; set; }
    }
}
