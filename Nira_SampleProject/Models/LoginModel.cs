using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nira_SampleProject.Models
{
    public class LoginModel
    {
        public decimal login_Id { get; set; }
        public string login_Name { get; set; }
        public string login_Email { get; set; }
        public string login_Password { get; set; }
        public bool login_IsActive { get; set; }
        public System.DateTime login_UpdatedDate { get; set; }
        public System.DateTime login_CreatedDate { get; set; }
    }
}