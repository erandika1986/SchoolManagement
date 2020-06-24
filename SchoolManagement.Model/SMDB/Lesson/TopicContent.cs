using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Model
{
    public class TopicContent
    {
        public long Id { get; set; }
        public long TopicId { get; set; }
        public string Introduction { get; set; }
        public TopicContentType ContentType { get; set; }
        public string Content { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public virtual Topic Topic { get; set; }
    }
}
