using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.ViewModel
{
    public class UserToken
    {
        public bool IsLoginSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public string Token { get; set; }
        public List<string> Roles { get; set; }
        public string DisplayName { get; set; }
        public string SchoolDomain { get; set; }
    }
}
