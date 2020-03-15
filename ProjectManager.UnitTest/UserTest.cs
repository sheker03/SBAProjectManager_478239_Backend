using NUnit.Framework;
using ProjectManager.Model;
using ProjectManager.Service.Controllers;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;

namespace ProjectManager.UnitTest
{

    [TestFixture]
    class UserTest
    {

        [Test]
        public void Test_GetAllUsers()
        {
            UserController tc = new UserController();
            var result = tc.GetAllUsers();
            var actual = result as OkNegotiatedContentResult<List<User>>;
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Content);

        }

        [Test]
        public void Test_GetUserByID()
        {
            UserController tc = new UserController();
            IHttpActionResult result = tc.GetUserByID("32498ad3-2bf8-44ae-b119-c3c048237533");
            var actual = result as OkNegotiatedContentResult<User>;
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Content);

        }


        [Test]
        public void Test_PostUser()
        {
            UserController tc = new UserController();
            User userToAdd = new User();
            userToAdd.First_Name = "User FN from Unit Test Project";
            userToAdd.Employee_ID = 50;
            userToAdd.Last_Name = "User LN from Unit Test Project";
            IHttpActionResult result = tc.PostUser(userToAdd);
            var actual = result as OkNegotiatedContentResult<User>;
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Content);

        }

        [Test]
        public void Test_UpdateUser()
        {
            UserController tc = new UserController();
            User userToAdd = new User();
            userToAdd.User_ID = "cab41ea1-6999-4368-ab4b-26f946680d74";
            userToAdd.First_Name = "User FN updated from Project Unit Test Project";
            userToAdd.Employee_ID = 60;
            userToAdd.Last_Name = "User LN updated from Project Unit Test Project";
            IHttpActionResult result = tc.UpdateUser(userToAdd);
            var actual = result as OkNegotiatedContentResult<User>;
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Content);

        }

        [Test]
        public void Test_DeleteUser()
        {
            UserController tc = new UserController();
            IHttpActionResult result = tc.DeleteUser("6adc6fc4-0aa6-4f4a-be57-5a0d7b2e65ed");
            var actual = result as OkNegotiatedContentResult<bool>;
            Assert.AreEqual(actual.Content, true);
        }
    }
}
