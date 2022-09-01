using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using backend.Models;
namespace backend.Controllers
{
    [RoutePrefix("api/Test")]
    public class TestController : ApiController
    {   [HttpGet]
        [Route("getSample")]
        public string Get()
        {
            return "hoi";
        }


        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        SqlCommand cmd = null;
        [HttpPost]
        [Route("Registration")]

        public string Registration(User user)
        {
            string msg = string.Empty;
            try
            {
                cmd = new SqlCommand("user_register", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", user.name);
                cmd.Parameters.AddWithValue("@password", user.password);
                cmd.Parameters.AddWithValue("@confirmpassword", user.confirmpassword);
                cmd.Parameters.AddWithValue("@email", user.email);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                conn.Close();
                if (i > 0)
                {
                    msg = "Success";
                }
                else
                {
                    msg = "Error";
                }
            }
            catch(Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
        [HttpPost]
        [Route("Login")]
        public string Login(User user)
        {
            string msg = string.Empty;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("user_login", conn);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@name", user.name);
                da.SelectCommand.Parameters.AddWithValue("@password", user.password);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    msg = "valid";
                }
                else
                {
                    msg = "invalid";
                }
                
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
    }
     
}
