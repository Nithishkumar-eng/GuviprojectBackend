using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backend.Models
{
    public class UserModel
    {
       
        public int ID { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string confirmpassword { get; set; }
        public string email { get; set; }
        public string type { get; set; }
    }
}