//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CottonTouch
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
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
