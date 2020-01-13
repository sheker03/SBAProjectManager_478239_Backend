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
    [Route("api/Task")]
    public class TaskController : ApiController
    {


        [HttpGet]
        [Route("GetAllTasks")]
        public IHttpActionResult GetAllTasks()
        {
            TaskBusiness tb = new TaskBusiness();
            List<Task> allTasks = tb.GetAllTasks();
            return Ok(allTasks);
        }


        [HttpGet]
        [Route("GetTaskByID")]
        public IHttpActionResult GetTaskByID(string id)
        {
            TaskBusiness tb = new TaskBusiness();
            Task selectedTask = tb.GetTaskByID(id);
            return Ok(selectedTask);
        }

        [HttpGet]
        [Route("GetAllTasksByProjectID")]
        public IHttpActionResult GetAllTasksByProjectID(string id)
        {
            TaskBusiness tb = new TaskBusiness();
            List<Task> selectedTasks = tb.GetAllTasksByProjectID(id);
            return Ok(selectedTasks);
        }


        [HttpPost]
        [Route("PostTask")]
        public IHttpActionResult PostTask([FromBody] Task taskToAdd)
        {
            TaskBusiness tb = new TaskBusiness();
            taskToAdd.Task_ID = Guid.NewGuid().ToString();
            tb.AddTask(taskToAdd);
            return Ok(taskToAdd);
        }

        [HttpPut]
        [Route("UpdateTask")]
        public IHttpActionResult UpdateTask([FromBody] Task taskToUpdate)
        {
            TaskBusiness tb = new TaskBusiness();
            tb.UpdateTask(taskToUpdate);
            return Ok(taskToUpdate);
        }


        [HttpDelete]
        [Route("DeleteTask")]
        public IHttpActionResult DeleteTask(string id)
        {
            TaskBusiness tb = new TaskBusiness();
            var isDeleted = tb.DeleteTask(id);
            return Ok(isDeleted);
        }

    }
}
