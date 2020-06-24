using SchoolManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Business.Interface
{
    public interface IAuthService
    {
        UserToken Login(LoginViewModel model);
    }
}
