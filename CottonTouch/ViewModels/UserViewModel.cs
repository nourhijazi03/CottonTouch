using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CottonTouch.ViewModels
{
    public class UserViewModel
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Nullable<int> RoleID { get; set; }
        public bool isAuthunticated { get; set; }
        public string Email { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }

        public virtual Role Role { get; set; }
    }
}