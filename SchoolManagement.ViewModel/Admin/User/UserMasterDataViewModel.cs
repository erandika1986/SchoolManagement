using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.ViewModel.Admin.User
{
    public class UserMasterDataViewModel
    {
        public UserMasterDataViewModel()
        {
            Roles = new List<DropDownViewModal>();
        }
        public List<DropDownViewModal> Roles { get; set; }
    }
}
