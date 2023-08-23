using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIsProjec.Models
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentPhoneNumber { get; set; }
        public string StudentEmail { get; set; }
        public string RollNo { get; set; }
    }
}