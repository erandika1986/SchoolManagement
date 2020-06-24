
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using SchoolManagement.Util;
using Microsoft.AspNetCore.Http;
using SchoolManagement.ViewModel;
using System.Security.Claims;

namespace SchoolManagement.Master
{
    public class AuthSQLServerTenantProvider : ITenantProvider
    {
        private static List<Tenant> _tenants;
        private Tenant _tenant;
        private IHttpContextAccessor _accessor;

        public AuthSQLServerTenantProvider(MasterDBContext dBContext, IHttpContextAccessor accessor)
        {
            this._accessor = accessor;
            if (_tenants == null)
            {
                LoadTenants(dBContext);
            }
        }

        public CompanySettings GetCompanySettings()
        {
            throw new NotImplementedException();
        }

        public EmailSetting GetEmailSetting()
        {
            throw new NotImplementedException();
        }

        public async Task<Tenant> GetTenant()
        {
            var identity = _accessor.HttpContext.User.Identity as ClaimsIdentity;
            if(identity.Claims.Count()>0)
            {
                var requestAPIKey = identity.FindFirst("SecretKey").Value;
                _tenant = _tenants.FirstOrDefault(t => t.SecretKey.ToUpper() == requestAPIKey.ToUpper());

                return _tenant;
            }
            else
            {
                var body = _accessor.HttpContext.Request.Body;

                using (StreamReader reader = new StreamReader(body, Encoding.UTF8))
                {
                    string value = await reader.ReadToEndAsync();

                    LoginViewModel vm = JsonConvert.DeserializeObject<LoginViewModel>(value);

                    _tenant = _tenants.FirstOrDefault(t => t.SchoolDomain.ToLower() == vm.SchoolName.ToLower());

                    _accessor.HttpContext.Request.Body = new MemoryStream(Encoding.UTF8.GetBytes(value)); ;

                    return _tenant;
                }
            }


        }


        private void LoadTenants(MasterDBContext dBContext)
        {
            _tenants = dBContext.Schools.Select(t => new Tenant() 
            { 
                Id = t.Id,
                SchoolName = t.SchoolName,
                SchoolDomain = t.SchoolDomain,
                SchoolLog = t.SchoolLog,
                ConnectionString=t.ConnectionString,
                SMTPServer=t.SMTPServer,
                SMTPUsername=t.SMTPUsername,
                SMTPPassword=t.SMTPPassword,
                SMTPFrom=t.SMTPFrom,
                SMTPPort=t.SMTPPort,
                SecretKey=t.SecretKey.ToString(),
                APIKey=t.APIKey.ToString(),
                TenantId=t.TenantId.ToString(),
                IsSMTPUseSSL =t.IsSMTPUseSSL
            }).ToList();
        }
    }
}
