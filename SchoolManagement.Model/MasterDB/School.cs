using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Model
{
    public class School
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public string SchoolDomain { get; set; }
        public string SchoolLog { get; set; }
        public string ConnectionString { get; set; }
        public string SMTPServer { get; set; }
        public string SMTPUsername { get; set; }
        public string SMTPPassword { get; set; }
        public string SMTPFrom { get; set; }
        public int SMTPPort { get; set; }
        public bool IsSMTPUseSSL { get; set; }
        public Guid TenantId { get; set; }
        public Guid APIKey{ get; set; }
        public Guid SecretKey { get; set; }
        public bool IsActive { get; set; }

    }
}
