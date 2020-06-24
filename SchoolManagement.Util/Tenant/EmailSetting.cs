using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Util
{
    public class EmailSetting
    {
        public string SMTP_Server { get; set; }
        public string SMTP_User { get; set; }
        public string SMTP_Password { get; set; }
        public string SMTP_From { get; set; }
    }
}
