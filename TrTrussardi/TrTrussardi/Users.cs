namespace TrTrussardi
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public bool AdminPrivileges { get; set; }
    }
}
