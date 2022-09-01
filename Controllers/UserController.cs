using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace backend.Controllers
{
    public class UserController : ApiController
    {
        SMdbEntities db = new SMdbEntities();
        [Route("api/User/AddUser")]
        [HttpPost]
        public Response AddUser(UserModel userModel)
        {
            Response response = new Response();
            tblsmdb user = new tblsmdb();
            user.name = userModel.name;
            user.password = userModel.password;
            user.confirmpassword = userModel.confirmpassword;
            user.email = userModel.email;
            if (user != null)
            {
                db.tblsmdbs.Add(user);
                db.SaveChanges();
                response.ResponseCode = "200";
                response.ResponseMessage = "User added";
            }
            else
            {
                response.ResponseCode = "100";
                response.ResponseMessage = "Error" +
                    "";
            }
            return response;
        }

        [Route("api/User/GetUser")]
        [HttpGet]
        public Response GetUsers()
        {
            Response response = new Response();
            List<tblsmdb> listUsers = new List<tblsmdb>();
            listUsers = db.tblsmdbs.ToList();
            response.ResponseCode = "200";
            response.ResponseMessage = "Data fetched";
            response.listUsers = listUsers;
            return response;
        }
        [Route("api/login")]
        [HttpPost]
        public string UserLogin(Login login)

        {
            string output;
            var log = db.tblsmdbs.Where(x => x.email.Equals(login.email) && x.password.Equals(login.password)).FirstOrDefault();
            if (log == null)
            {
                output= "Email or password is invalid";
            }
            else
            {
                output="success";
            }
            return output;
        }
    }
}
