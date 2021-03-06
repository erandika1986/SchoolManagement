﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.ViewModel
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Roles = new List<RoleViewModel>();
        }

        public long Id { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string MobileNo { get; set; }
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public List<RoleViewModel> Roles { get; set; }

        //For List View
        public string LstUserRole { get; set; }
    }
}
