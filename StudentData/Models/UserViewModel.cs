using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentData.Models
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserEmail { get; set; }
    }
}