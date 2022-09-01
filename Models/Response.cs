using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace backend.Models
{
    public class Response
    {
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public tblsmdb user { get; set; }
        public List<tblsmdb> listUsers { get; set; }
    }
}