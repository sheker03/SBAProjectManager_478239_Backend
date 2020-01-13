using ProjectManager.Business;
using ProjectManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectManager.Service.Controllers
{
    public class UserController : ApiController
    {


        [HttpGet]
        [Route("GetAllUsers")]
        public IHttpActionResult GetAllUsers()
        {
            UserBusiness tb = new UserBusiness();
            List<User> allUsers = tb.GetAllUsers();
            return Ok(allUsers);
        }


        [HttpGet]
        [Route("GetUserByID")]
        public IHttpActionResult GetUserByID(string id)
        {
            UserBusiness tb = new UserBusiness();
            User selectedUser = tb.GetUserByID(id);
            return Ok(selectedUser);
        }

        [HttpGet]
        [Route("GetUserByID")]
        public IHttpActionResult GetUserByProjectID(string id)
        {
            UserBusiness tb = new UserBusiness();
            User selectedUser = tb.GetUserByProjectID(id);
            return Ok(selectedUser);
        }


        [HttpPost]
        [Route("PostUser")]
        public IHttpActionResult PostUser([FromBody] User userToAdd)
        {
            UserBusiness tb = new UserBusiness();
            userToAdd.User_ID = Guid.NewGuid().ToString();
            tb.AddUser(userToAdd);
            return Ok(userToAdd);
        }

        [HttpPut]
        [Route("UpdateUser")]
        public IHttpActionResult UpdateUser([FromBody] User userToUpdate)
        {
            UserBusiness tb = new UserBusiness();
            tb.UpdateUser(userToUpdate);
            return Ok(userToUpdate);
        }


        [HttpDelete]
        [Route("DeleteUser")]
        public IHttpActionResult DeleteUser(string id)
        {
            UserBusiness tb = new UserBusiness();
            var isDeleted = tb.DeleteUser(id);
            return Ok(isDeleted);
        }
    }
}