using System;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using ProjectManager.Model;
using ProjectManager.Service.Controllers;
using System.Collections.Generic;
using System.Web.Http;
using Assert = NUnit.Framework.Assert;

namespace ProjectManager.UnitTest
{

    [TestFixture]
    public class ProjectTest
    {
        [Test]
        public void Test_GetAllProjects()
        {
            ProjectController tc = new ProjectController();
            var result = tc.GetAllProjects();
            var actual = result as OkNegotiatedContentResult<List<Project>>;
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Content);

        }

        [Test]
        public void Test_GetProjectByID()
        {
            ProjectController tc = new ProjectController();
            IHttpActionResult result = tc.GetProjectByID("7dabb20c-5376-4aa0-be24-fa94fb3ce82d");
            var actual = result as OkNegotiatedContentResult<Project>;
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Content);

        }


        [Test]
        public void Test_PostProject()
        {
            ProjectController tc = new ProjectController();
            ProjectDetails projectToAdd = new ProjectDetails();
            projectToAdd.Project_Name = "Aumaujaya8888";
            projectToAdd.Priority = 50;
            projectToAdd.Start_Date = DateTime.Now;
            projectToAdd.End_Date = DateTime.Now.AddDays(2);
            projectToAdd.NoOfTasks = 1;
            projectToAdd.NoOfTasksCompleted = 0;
            projectToAdd.Manager = new User();
            IHttpActionResult result = tc.PostProject(projectToAdd);
            var actual = result as OkNegotiatedContentResult<ProjectDetails>;
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Content);

        }

        [Test]
        public void Test_UpdateProject()
        {
            ProjectController tc = new ProjectController();
            ProjectDetails projectToAdd = new ProjectDetails();
            projectToAdd.Project_ID = "7dabb20c-5376-4aa0-be24-fa94fb3ce82d";
            projectToAdd.Project_Name = "DelhiEllecation222";
            projectToAdd.Priority = 50;
            projectToAdd.Start_Date = DateTime.Now;
            projectToAdd.End_Date = DateTime.Now.AddDays(5);
            projectToAdd.NoOfTasks = 1;
            projectToAdd.NoOfTasksCompleted = 0;
            projectToAdd.Manager = new User();
            IHttpActionResult result = tc.UpdateProject(projectToAdd);
            var actual = result as OkNegotiatedContentResult<ProjectDetails>;
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Content);

        }

        [Test]
        public void Test_DeleteProject()
        {
            ProjectController tc = new ProjectController();
            IHttpActionResult result = tc.DeleteProject("d547a060-21c1-4b73-9a44-e3ad944dae7b");
            var actual = result as OkNegotiatedContentResult<bool>;
            Assert.AreEqual(actual.Content, true);
        }
    }

}
