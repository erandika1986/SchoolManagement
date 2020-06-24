using SchoolManagement.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.ViewModel.Lesson
{
    public class TopicContentViewModel
    {
        public long Id { get; set; }
        public long TopicId { get; set; }
        public string Introduction { get; set; }
        public TopicContentType ContentType { get; set; }
        public string Content { get; set; }
    }
}
