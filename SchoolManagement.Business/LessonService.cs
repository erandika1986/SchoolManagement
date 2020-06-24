using SchoolManagement.Business.Interface;
using SchoolManagement.Data;
using SchoolManagement.Model;
using SchoolManagement.ViewModel;
using SchoolManagement.ViewModel.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Business
{
    public class LessonService : ILessonService
    {
        #region Member variable

        private readonly ISMUow uow;

        #endregion

        #region Constructor

        public LessonService(ISMUow uow)
        {
            this.uow = uow;
        }

        #endregion

        #region Public Methods For Lesson

        public async Task<LessonResponseViewModel> AddNewLesson(LessonViewModel vm, string userName)
        {
            var response = new LessonResponseViewModel();
            try
            {
                var currentUser = uow.Users.GetAll().FirstOrDefault(t => t.Username == userName);
                var dateTimeNow = DateTime.UtcNow;

                var lesson = new Lesson()
                {
                    Name = vm.Name,
                    Description = vm.Description,
                    OwnerId = currentUser.Id,
                    AcademicLevelId = vm.SelectedAcademicLevel.Id,
                    ClassNameId = vm.SelectedClassNameId.Id,
                    AcademicYearId = vm.SelectedAcademicYear.Id,
                    SubjectId = vm.SelectedSubject.Id,
                    LearningOutcome = vm.LearningOutcome,
                    PlannedDate = vm.PlannedDate,
                    Status = LessonStatus.Design,
                    VersionNo = 1,
                    IsActive = true,
                    CreatedOn = dateTimeNow,
                    CreatedById = currentUser.Id,
                    UpdatedOn = dateTimeNow,
                    UpdatedById = currentUser.Id
                };

                uow.Lessons.Add(lesson);

                await uow.CommitAsync();


                response.IsSuccess = true;
                response.Message = "New Lesson has been saved Successfully.";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error has been occured.Please try again";
            }

            return response;
        }

        public async Task<LessonResponseViewModel> UpdateLesson(LessonViewModel vm, string userName)
        {
            var response = new LessonResponseViewModel();
            try
            {
                var currentUser = uow.Users.GetAll().FirstOrDefault(t => t.Username == userName);
                var dateTimeNow = DateTime.UtcNow;

                var lesson = uow.Lessons.GetAll().FirstOrDefault(t => t.Id == vm.Id);
                lesson.Name = vm.Name;
                lesson.Description = vm.Description;
                lesson.OwnerId = vm.SelectedOwner.Id;
                lesson.ClassNameId = vm.SelectedClassNameId.Id;
                lesson.AcademicYearId = vm.SelectedAcademicYear.Id;
                lesson.SubjectId = vm.SelectedSubject.Id;
                lesson.LearningOutcome = vm.LearningOutcome;
                lesson.PlannedDate = vm.PlannedDate;
                lesson.UpdatedById = currentUser.Id;
                lesson.UpdatedOn = dateTimeNow;

                uow.Lessons.Update(lesson);

                await uow.CommitAsync();


                response.IsSuccess = true;
                response.Message = "New Lesson has been saved Successfully.";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error has been occured.Please try again";
            }

            return response;
        }

        public async Task<ResponseViewModel> DeleteLesson(long id, string userName)
        {
            var response = new ResponseViewModel();
            try
            {
                var currentUser = uow.Users.GetAll().FirstOrDefault(t => t.Username == userName);
                var lesson = uow.Lessons.GetAll().FirstOrDefault(t => t.Id == id);

                lesson.IsActive = false;
                lesson.UpdatedOn = DateTime.UtcNow;
                lesson.UpdatedById = currentUser.Id;

                uow.Lessons.Update(lesson);

                await uow.CommitAsync();

                response.IsSuccess = true;
                response.Message = "Selected lesson has been deleted.";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error has been occured while deleting the selected lesson. Please try again.";
            }

            return response;
        }

        public async Task<ResponseViewModel> ActivateDeletedLesson(long id, string userName)
        {
            var response = new ResponseViewModel();
            try
            {
                var currentUser = uow.Users.GetAll().FirstOrDefault(t => t.Username == userName);
                var lesson = uow.Lessons.GetAll().FirstOrDefault(t => t.Id == id);

                lesson.IsActive = true;
                lesson.UpdatedOn = DateTime.UtcNow;
                lesson.UpdatedById = currentUser.Id;

                uow.Lessons.Update(lesson);

                await uow.CommitAsync();

                response.IsSuccess = true;
                response.Message = "Selected lesson has been activated again.";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error has been occured while activating the selected lesson. Please try again.";
            }

            return response;
        }

        public LessonViewModel GetLessonByIdForTeachers(long id, string userName)
        {
            var lesson = uow.Lessons.GetAll().FirstOrDefault(t => t.Id == id);

            var vm = new LessonViewModel()
            {
                Id = lesson.Id,
                CompletedDate = lesson.CompletedDate,
                SelectedOwner = new DropDownViewModal() { Id = lesson.OwnerId, Name = lesson.Owner.FullName },
                Description = lesson.Description,
                SelectedAcademicLevel = new DropDownViewModal() { Id = lesson.AcademicLevelId, Name = lesson.SubjectAcademicLevel.AcademicLevel.Description },
                SelectedSubject = new DropDownViewModal() { Id = lesson.SubjectId, Name = lesson.SubjectAcademicLevel.Subject.Name },
                LearningOutcome = lesson.LearningOutcome,
                Status = lesson.Status,
                Version = lesson.VersionNo,

            };

            if (lesson.AcademicYearId.HasValue)
            {
                vm.SelectedAcademicYear = new DropDownViewModal()
                {
                    Id = lesson.AcademicYearId.Value,
                    Name = lesson.Class.AcademicYear.Id.ToString()
                };
            }

            if (lesson.ClassNameId.HasValue)
            {
                vm.SelectedClassNameId = new DropDownViewModal()
                {
                    Id = lesson.Id,
                    Name = lesson.Name
                };
            }

            foreach (var topic in lesson.Topics.ToList())
            {
                var topicVm = new TopicViewModel()
                {
                    Id = topic.Id,
                    LessonId = lesson.Id,
                    SequenceNo = topic.SequenceNo,
                    Name = topic.Name,
                    LearningExperience = topic.LearningExperience
                };


                foreach (var content in topic.TopicContents)
                {
                    var tcontent = new TopicContentViewModel()
                    {
                        Id = content.Id,
                        Content = content.Content,
                        ContentType = content.ContentType,
                        Introduction = content.Introduction,
                        TopicId = topic.Id
                    };

                    topicVm.TeacherTopicContents.Add(tcontent);
                }

                //For Topic Level Question
                var questions = topic.Questions.ToList();
                var result = GetQuestions(questions, lesson);

                topicVm.TeacherTopicLevelEssayQuestions.AddRange(result.Item1);
                topicVm.TeacherTopicLevelMCQQuestions.AddRange(result.Item2);

                vm.TeacherTopics.Add(topicVm);
            }

            var lessonQuestion = lesson.Questions.ToList();
            var LessonQuestionResult = GetQuestions(lessonQuestion, lesson);

            vm.TeacherLessonLevelEssayQuestions.AddRange(LessonQuestionResult.Item1);
            vm.TeacherLessonLevelMCQQuestions.AddRange(LessonQuestionResult.Item2);



            return vm;
        }

        public PaginatedItemsViewModel<LessonViewModel> GetOwnLessonForTeacher(LessonFilterViewModel filter, string userName)
        {
            int totalRecordCount = 0;
            double totalPages = 0;
            int totalPageCount = 0;
            var vms = new List<LessonViewModel>();

            var currentUser = uow.Users.GetAll().FirstOrDefault(t => t.Username == userName);

            var query = uow.Lessons.GetAll().Where(t => t.OwnerId == currentUser.Id && t.IsActive == filter.IsActive);

            if (filter.SelectedStatus.Id != 0)
            {
                var status = (LessonStatus)filter.SelectedStatus.Id;
                query = query.Where(t => t.Status == status);
            }

            if (filter.SelectedAcademicLevel.Id != 0)
            {
                query = query.Where(t => t.AcademicLevelId == filter.SelectedAcademicLevel.Id);
            }

            if (filter.SelectedAcademicYear.Id != 0)
            {
                query = query.Where(t => t.AcademicYearId == filter.SelectedAcademicYear.Id);
            }

            if (filter.SelectedClass.Id != 0)
            {
                query = query.Where(t => t.ClassNameId == filter.SelectedClass.Id);
            }

            if (filter.SelectedSubject.Id != 0)
            {
                query = query.Where(t => t.SubjectId == filter.SelectedSubject.Id);
            }

            totalRecordCount = query.Count();
            totalPages = (double)totalRecordCount / filter.PageSize;
            totalPageCount = (int)Math.Ceiling(totalPages);

            var lessons = query.Skip((filter.CurrentPage - 1) * filter.PageSize).Take(filter.PageSize).ToList();

            foreach (var item in lessons)
            {
                var vm = new LessonViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    LearningOutcome = item.LearningOutcome,
                    PlannedDate = item.PlannedDate.HasValue ? item.PlannedDate.Value : (DateTime?)null,
                    CompletedDate = item.CompletedDate.HasValue ? item.CompletedDate.Value : (DateTime?)null,
                    Status = item.Status
                };

                vms.Add(vm);
            }

            var container = new PaginatedItemsViewModel<LessonViewModel>(filter.CurrentPage, filter.PageSize, totalPageCount, totalRecordCount, vms);

            return container;

        }

        #endregion


        public async Task<TopicResponseViewModel> SaveTopic(TopicViewModel vm,string userName)
        {
            var response = new TopicResponseViewModel();
            try
            {
                var currentUser = uow.Users.GetAll().FirstOrDefault(t => t.Username == userName);
                var dateTimeNow = DateTime.UtcNow;

                var topic = uow.Topics.GetAll().FirstOrDefault(t => t.Id == vm.Id);

                if(topic==null)
                {
                    topic = new Topic()
                    {
                        LessonId = vm.LessonId,
                        SequenceNo =vm.SequenceNo,
                        Name=vm.Name,
                        LearningExperience=vm.LearningExperience,
                        IsActive=true,
                        ModifiedOn=dateTimeNow,
                        CreatedOn=dateTimeNow
                    };

                    topic.Questions = new HashSet<Question>();
                    topic.TopicContents = new HashSet<TopicContent>();

                    foreach (var item in vm.TeacherTopicContents)
                    {
                        var content = new TopicContent()
                        {
                            Introduction= item.Introduction,
                            ContentType=item.ContentType,
                            Content=item.Content,
                            IsActive=true,
                            CreatedOn=dateTimeNow,
                            UpdatedOn=dateTimeNow
                        };

                        topic.TopicContents.Add(content);
                    }

                    foreach (var item in vm.TeacherTopicLevelMCQQuestions)
                    {
                        topic.Questions.Add(AddNewMCQQuestiion(item, dateTimeNow));
                    }

                    foreach (var item in vm.TeacherTopicLevelEssayQuestions)
                    {
                        topic.Questions.Add(AddNewEssayQuestiion(item,dateTimeNow));
                    }

                    uow.Topics.Add(topic);
                    await uow.CommitAsync();

                    vm.Id = topic.Id;
                    response.Topic = vm;
                    response.IsSuccess = true;
                    response.Message = "New Topic has been saved successfully.";
                }
                else
                {
                    topic.SequenceNo = vm.SequenceNo;
                    topic.Name = vm.Name;
                    topic.LearningExperience = vm.LearningExperience;
                    topic.ModifiedOn = dateTimeNow;

                    var existingContents = topic.TopicContents.ToList();
                    var newlyAddedContents = vm.TeacherTopicContents.Where(t => t.Id == 0).ToList();
                    var updatedContents = (from uc in newlyAddedContents where existingContents.Any(t => t.Id == uc.Id) select uc).ToList();
                    var deletedContents = (from dc in existingContents where !newlyAddedContents.Any(t => t.Id == dc.Id) select dc).ToList();

                    //Add newly Added Content
                    foreach (var item in newlyAddedContents)
                    {
                        var content = new TopicContent()
                        {
                            Introduction = item.Introduction,
                            ContentType = item.ContentType,
                            Content = item.Content,
                            IsActive = true,
                            CreatedOn = dateTimeNow,
                            UpdatedOn = dateTimeNow
                        };

                        topic.TopicContents.Add(content);
                    }

                    //Update Existing Content
                    foreach (var item in updatedContents)
                    {
                        var content = topic.TopicContents.FirstOrDefault(t => t.Id == item.Id);
                        content.Introduction = item.Introduction;
                        content.ContentType = item.ContentType;
                        content.Content = item.Content;
                        content.UpdatedOn = dateTimeNow;
                    }


                    //Delete Content
                    foreach (var item in deletedContents)
                    {
                        uow.TopicContents.Delete(item);
                    }

                    //For MCQ Question
                    var savedMCQQuestions = uow.Questions.GetAll().Where(t => t.TopicId == topic.Id && t.QuestionType == QuestionType.MCQ).ToList();
                    var newlyAddMCQedQuestions = vm.TeacherTopicLevelMCQQuestions.Where(t => t.Id == 0).ToList();
                    var deletedMCQQuestions = (from dq in savedMCQQuestions where !newlyAddMCQedQuestions.Any(t => t.Id == dq.Id) select dq).ToList();
                    var updatedMCQQuestions = (from uq in newlyAddMCQedQuestions where savedMCQQuestions.Any(t => t.Id == uq.Id) select uq).ToList();
                    
                    //Add new MCQ Question
                    foreach (var item in newlyAddMCQedQuestions)
                    {
                        topic.Questions.Add(AddNewMCQQuestiion(item, dateTimeNow));
                    }

                    //Update MCQ Question
                    foreach (var item in updatedMCQQuestions)
                    {
                        var question = topic.Questions.FirstOrDefault(t => t.Id == item.Id);
                        question.QuestionText = item.QuestionText;
                        question.SequenceNo = item.SequenceNo;
                        question.Marks = item.Marks;
                        question.UpdatedOn = dateTimeNow;


                        var savedMCQAnswers = question.MCQAnswers.ToList();
                        var newlyAddedMCQAnswers = item.TeacherMCQAnswers.Where(t => t.Id == 0).ToList();
                        var deletedMCQAnswers = (from da in savedMCQAnswers where !item.TeacherMCQAnswers.Any(t => t.Id == da.Id) select da).ToList();
                        var updatedMCQAnswers = (from ua in item.TeacherMCQAnswers where savedMCQAnswers.Any(t => t.Id == ua.Id) select ua).ToList();

                        //Add New MCQ Answer
                        AddNewMCQAnswers(question, newlyAddedMCQAnswers, dateTimeNow);

                        //Updaye MCQ Answer
                        foreach (var ua in updatedMCQAnswers)
                        {
                            var mcqAnswer = question.MCQAnswers.FirstOrDefault(t => t.Id == ua.Id);
                            mcqAnswer.AnswerText = ua.AnswerText;
                            mcqAnswer.SequenceNo = ua.SequenceNo;
                            mcqAnswer.IsCorrectAnswer = ua.IsCorrectAnswer;
                            mcqAnswer.ModifiedOn = dateTimeNow;
                        }

                        //Delete MCQ Answer
                        foreach (var da in deletedMCQAnswers)
                        {
                            uow.MCQAnswers.Delete(da);
                        }
    
                    }



                    uow.Topics.Update(topic);
                    await uow.CommitAsync();

                    response.Topic = vm;
                    response.IsSuccess = true;
                    response.Message = "Topic has been updated successfully.";
                }


                response.IsSuccess = true;
                response.Message = "New Lesson has been saved Successfully.";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error has been occured.Please try again";
            }

            return response;
        }



        #region Private Methods

        private Tuple<List<QuestionViewModel>, List<QuestionViewModel>> GetQuestions(List<Question> questions, Lesson lesson)
        {
            var essaryAsnwers = new List<QuestionViewModel>();
            var mcqAsnwers = new List<QuestionViewModel>();


            foreach (var q in questions)
            {
                var qvm = new QuestionViewModel()
                {
                    Id = q.Id,
                    TopicId = q.TopicId.Value,
                    LessonId = lesson.Id,
                    SequenceNo = q.SequenceNo,
                    QuestionText = q.QuestionText,
                    Marks = q.Marks,
                    QuestionLevel = q.QuestionLevel,
                    QuestionType = q.QuestionType
                };

                switch (q.QuestionType)
                {

                    case QuestionType.Essay:
                        {
                            var firstAnswer = q.EssayAnswers.FirstOrDefault();
                            qvm.TeacherEssayAnswers = new EssayAnswerViewModel()
                            {
                                Id = firstAnswer.Id,
                                AnswerText = firstAnswer.AnswerText,
                                QuestonId = q.Id,
                            };

                            essaryAsnwers.Add(qvm);
                        }
                        break;
                    case QuestionType.MCQ:
                        {
                            var mcqAnswers = q.MCQAnswers.ToList();
                            foreach (var an in mcqAnswers)
                            {
                                var mcqAnswerVm = new MCQAnswerViewModel()
                                {
                                    AnswerText = an.AnswerText,
                                    Id = an.Id,
                                    IsCorrectAnswer = an.IsCorrectAnswer,
                                    QuestonId = q.Id,
                                    SequenceNo = an.SequenceNo
                                };

                                qvm.TeacherMCQAnswers.Add(mcqAnswerVm);
                            }

                            mcqAsnwers.Add(qvm);
                        }
                        break;
                }
            }

            return new Tuple<List<QuestionViewModel>, List<QuestionViewModel>>(essaryAsnwers, mcqAsnwers);
        }

        private Question AddNewMCQQuestiion(QuestionViewModel item, DateTime dateTimeNow)
        {
            var question = new Question()
            {
                SequenceNo = item.SequenceNo,
                QuestionText = item.QuestionText,
                Marks = item.Marks,
                QuestionLevel = QuestionLevel.TopicLevel,
                QuestionType = QuestionType.MCQ,
                IsActive = true,
                CreatedOn = dateTimeNow,
                UpdatedOn = dateTimeNow
            };

            question.MCQAnswers = new HashSet<MCQAnswer>();
            AddNewMCQAnswers(question, item.TeacherMCQAnswers, dateTimeNow);

            return question;

        }

        private void AddNewMCQAnswers(Question question,List<MCQAnswerViewModel> answers, DateTime dateTimeNow)
        {
            foreach (var an in answers)
            {
                var answer = new MCQAnswer()
                {
                    AnswerText = an.AnswerText,
                    SequenceNo = an.SequenceNo,
                    IsCorrectAnswer = an.IsCorrectAnswer,
                    ModifiedOn = dateTimeNow,
                    CreatedOn = dateTimeNow
                };

                question.MCQAnswers.Add(answer);
            }
        }

        private Question AddNewEssayQuestiion(QuestionViewModel item, DateTime dateTimeNow)
        {
            var question = new Question()
            {
                SequenceNo = item.SequenceNo,
                QuestionText = item.QuestionText,
                Marks = item.Marks,
                QuestionLevel = QuestionLevel.TopicLevel,
                QuestionType = QuestionType.Essay,
                IsActive = true,
                CreatedOn = dateTimeNow,
                UpdatedOn = dateTimeNow
            };

            question.EssayAnswers = new HashSet<EssayAnswer>();
            var essayAnswer = new EssayAnswer()
            {
                AnswerText = item.TeacherEssayAnswers.AnswerText,
                CreatedOn = dateTimeNow,
                ModifiedOn = dateTimeNow
            };

            question.EssayAnswers.Add(essayAnswer);

            return question;
        }

        #endregion
    }
}
