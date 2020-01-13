using ProjectManager.Data;
using ProjectManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ProjectManager.Business
{

    public class TaskBusiness
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Model.Task> GetAllTasks()
        {
            using (ProjectDBContext _db = new ProjectDBContext())
            {
                return _db.Tasks.ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Task GetTaskByID(string id)
        {
            using (ProjectDBContext _db = new ProjectDBContext())
            {
                List<Model.Task> allTasks = (from task1 in _db.Tasks
                                             select task1).ToList();
                Model.Task task = allTasks.Where(a => a.Task_ID == id).FirstOrDefault();
                return task;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newTask"></param>
        public void AddTask(Model.Task newTask)
        {
            using (ProjectDBContext _db = new ProjectDBContext())
            {
                _db.Tasks.Add(newTask);
                _db.SaveChanges();
            }
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="taskToUpdate"></param>
        public void UpdateTask(Model.Task taskToUpdate)
        {
            using (ProjectDBContext _db = new ProjectDBContext())
            {
                Model.Task updateTask = _db.Tasks.FirstOrDefault(a => a.Task_ID == taskToUpdate.Task_ID);
                if (updateTask != null)
                {
                    _db.Tasks.Remove(updateTask);
                    _db.Tasks.Add(taskToUpdate);
                    _db.SaveChanges();
                }
                else
                {
                    throw new Exception(string.Format("Task - {0} not found", taskToUpdate.Task_Name));
                }
            }
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteTask(string id)
        {
            using (ProjectDBContext _db = new ProjectDBContext())
            {
                Task taskToDelete = _db.Tasks.FirstOrDefault(a => a.Task_ID == id);
                if (taskToDelete != null)
                {
                    _db.Tasks.Remove(taskToDelete);
                    _db.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception(string.Format("Task - {0} not found", taskToDelete.Task_Name));
                }
            }
        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Model.Task> GetAllTasksByProjectID(string id)
        {
            using (ProjectDBContext _db = new ProjectDBContext())
            {
                List<Model.Task> allTasks = (from task1 in _db.Tasks
                                             select task1).ToList();

                return allTasks.Where(a => a.Project_ID == id).ToList();
            }

        }
    }
}
