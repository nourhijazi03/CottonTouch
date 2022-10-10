using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CottonTouch.ViewModels
{
    public class LoginViewModel
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int RoleID { get; set; }
        public Role Role { get; set; }

        public string Password { get; set; }

        public bool isAuthunticated { get; set; }
    }
}