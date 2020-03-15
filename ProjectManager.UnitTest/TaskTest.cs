using NUnit.Framework;
using ProjectManager.Model;
using ProjectManager.Service.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;

namespace ProjectManager.UnitTest
{
    [TestFixture]
    public class TaskTest
    {


        [Test]
        public void Test_GetAllTasks()
        {
            TaskController tc = new TaskController();
            var result = tc.GetAllTasks();
            var actual = result as OkNegotiatedContentResult<List<Task>>;
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Content);

        }

        [Test]
        public void Test_GetTaskByID()
        {
            TaskController tc = new TaskController();
            IHttpActionResult result = tc.GetTaskByID("ef83c747-2001-406e-af1d-ab564d74666d");
            var actual = result as OkNegotiatedContentResult<Task>;
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Content);

        }


        [Test]
        public void Test_PostTask()
        {
            TaskController tc = new TaskController();
            Task taskToAdd = new Task();
            taskToAdd.Task_Name = "Task from Unit Test Project111";
            taskToAdd.Priority = 50;
            taskToAdd.Start_Date = DateTime.Now;
            taskToAdd.End_Date = DateTime.Now.AddDays(2);
            IHttpActionResult result = tc.PostTask(taskToAdd);
            var actual = result as OkNegotiatedContentResult<Task>;
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Content);

        }

        [Test]
        public void Test_UpdateTask()
        {
            TaskController tc = new TaskController();
            Task taskToAdd = new Task();
            taskToAdd.Task_ID = "ef83c747-2001-406e-af1d-ab564d74666d";
            taskToAdd.Task_Name = "Task updated from Unit Test Project";
            taskToAdd.Priority = 50;
            taskToAdd.Start_Date = DateTime.Now;
            taskToAdd.End_Date = DateTime.Now.AddDays(5);
            IHttpActionResult result = tc.UpdateTask(taskToAdd);
            var actual = result as OkNegotiatedContentResult<Task>;
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Content);

        }

        [Test]
        public void Test_DeleteTask()
        {
            TaskController tc = new TaskController();
            IHttpActionResult result = tc.DeleteTask("d99a96ad-0ab5-422d-8f38-16df34df315e");
            var actual = result as OkNegotiatedContentResult<bool>;
            Assert.AreEqual(actual.Content, true);
        }
    }
}
