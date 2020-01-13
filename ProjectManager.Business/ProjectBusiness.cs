using ProjectManager.Data;
using ProjectManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ProjectManager.Business
{

    public class ProjectBusiness
    {

        public List<Project> GetAllProjects()
        {
            using (ProjectDBContext _db = new ProjectDBContext())
            {
                return _db.Projects.ToList();
            }
        }

        public Project GetProjectByID(string id)
        {
            using (ProjectDBContext _db = new ProjectDBContext())
            {
                if (_db.Projects.Any(a => a.Project_ID == id))
                {
                    return _db.Projects.FirstOrDefault(a => a.Project_ID == id);
                }
                else
                {
                    throw new Exception(string.Format("Project with the id - {0} could not be found", id));
                }
            }
        }

        public bool AddProject(Project newProject)
        {
            using (ProjectDBContext _db = new ProjectDBContext())
            {
                _db.Projects.Add(newProject);
                _db.SaveChanges();
                return true;
            }
        }

        public bool UpdateProject(Project updateProject)
        {
            using (ProjectDBContext _db = new ProjectDBContext())
            {
                if (_db.Projects.Any(a => a.Project_ID == updateProject.Project_ID))
                {
                    Project projectToRemove = _db.Projects.FirstOrDefault(a => a.Project_ID == updateProject.Project_ID);
                    _db.Projects.Remove(projectToRemove);
                    _db.Projects.Add(updateProject);
                    _db.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception(string.Format("Project with the name - {0} could not be found", updateProject.Project_Name));
                }
            }
        }


        public bool DeleteProject(string id)
        {
            using (ProjectDBContext _db = new ProjectDBContext())
            {
                if (_db.Projects.Any(a => a.Project_ID == id))
                {
                    Project projectToRemove = _db.Projects.FirstOrDefault(a => a.Project_ID == id);
                    _db.Projects.Remove(projectToRemove);
                    _db.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception(string.Format("Project with the name - {0} could not be found", id));
                }
            }
        }

        public Project GetProjectFromDetails(ProjectDetails projDetails)
        {
            Project retVal = new Project();
            retVal.Project_ID = projDetails.Project_ID;
            retVal.Project_Name = projDetails.Project_Name;
            retVal.Start_Date = projDetails.Start_Date;
            retVal.End_Date = projDetails.End_Date;
            retVal.Priority = projDetails.Priority;
            return retVal;
        }
    }
}
