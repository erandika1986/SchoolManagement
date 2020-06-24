using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Util
{
    public interface ITenantProvider
    {
        Task<Tenant> GetTenant();
        CompanySettings GetCompanySettings();
        EmailSetting GetEmailSetting();
    }
}
