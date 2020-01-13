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
    [Route("api/Project")]
    public class ProjectController : ApiController
    {
        [HttpGet]
        [Route("GetAllProjects")]
        public IHttpActionResult GetAllProjects()
        {
            ProjectBusiness tb = new ProjectBusiness();
            List<Project> allProjects = tb.GetAllProjects();
            return Ok(allProjects);
        }


        [HttpGet]
        [Route("GetProjectByID")]
        public IHttpActionResult GetProjectByID(string id)
        {
            ProjectBusiness tb = new ProjectBusiness();
            Project selectedProject = tb.GetProjectByID(id);
            return Ok(selectedProject);
        }

        [HttpGet]
        [Route("GetAllProjectDetails")]
        public IHttpActionResult GetAllProjectDetails()
        {
            ProjectBusiness pb = new ProjectBusiness();
            TaskBusiness tb = new TaskBusiness();
            UserBusiness ub = new UserBusiness();
            List<ProjectDetails> retVal = new List<ProjectDetails>();

            List<Project> allProjects = new List<Project>();
            List<Task> allTasks = new List<Task>();
            List<User> allUsers = new List<User>();
            allProjects = pb.GetAllProjects();
            allTasks = tb.GetAllTasks();
            allUsers = ub.GetAllUsers();
            foreach (Project selectedProject in allProjects)
            {
                ProjectDetails pd = new ProjectDetails();
                pd.Project_ID = selectedProject.Project_ID;
                pd.Project_Name = selectedProject.Project_Name;
                pd.Start_Date = selectedProject.Start_Date;
                pd.End_Date = selectedProject.End_Date;
                pd.Priority = selectedProject.Priority;
                if (allTasks.Any(a => a.Project_ID == selectedProject.Project_ID))
                {
                    var projectTasks = allTasks.Where(a => a.Project_ID == selectedProject.Project_ID).ToList();
                    pd.NoOfTasks = projectTasks.Count;
                    pd.NoOfTasksCompleted = projectTasks.Where(a => a.Status == 1).Count();
                }
                if (allUsers.Any(a => a.Project_ID == selectedProject.Project_ID))
                {
                    pd.Manager = allUsers.Where(a => a.Project_ID == selectedProject.Project_ID).LastOrDefault();
                }
                retVal.Add(pd);
            }

            return Ok(retVal);
        }


        [HttpPost]
        [Route("PostProject")]
        public IHttpActionResult PostProject([FromBody] ProjectDetails projectToAdd)
        {
            ProjectBusiness tb = new ProjectBusiness();
            projectToAdd.Project_ID = Guid.NewGuid().ToString();
            tb.AddProject(tb.GetProjectFromDetails(projectToAdd));
            return Ok(projectToAdd);
        }

        [HttpPut]
        [Route("UpdateProject")]
        public IHttpActionResult UpdateProject([FromBody] ProjectDetails projectToUpdate)
        {
            ProjectBusiness tb = new ProjectBusiness();
            tb.UpdateProject(tb.GetProjectFromDetails(projectToUpdate));
            return Ok(projectToUpdate);
        }


        [HttpDelete]
        [Route("DeleteProject")]
        public IHttpActionResult DeleteProject(string id)
        {
            ProjectBusiness tb = new ProjectBusiness();
            var isDeleted = tb.DeleteProject(id);
            return Ok(isDeleted);
        }

    }
}