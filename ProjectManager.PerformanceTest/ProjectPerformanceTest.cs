using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectManager.Service.Controllers;
using NBench;
using ProjectManager.Model;

namespace ProjectManager.PerformanceTest
{

    public class ProjectPerformanceTest
    {        
        [PerfBenchmark(Description = "Performace Test for GET", RunMode = RunMode.Iterations, TestMode = TestMode.Test)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThan, 100000d)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 500)]
        [CounterMeasurement("TestProjectCounter")]
        public void GetAllProjects_PassingTest()
        {
            ProjectController controller = new ProjectController();
            controller.GetAllProjects();
        }

        [PerfBenchmark(Description = "Performace Test for GET (By ID)", RunMode = RunMode.Iterations, TestMode = TestMode.Test)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThan, 100000d)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 500)]
        [CounterMeasurement("TestProjectCounter")]
        public void GetProjectByID_PassingTest()
        {
            ProjectController tc = new ProjectController();
            tc.GetProjectByID("9f714350-8333-46a1-93b4-d1f307795e3d");
        }

        [PerfBenchmark(Description = "Performace Test for POST", RunMode = RunMode.Iterations, TestMode = TestMode.Test)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThan, 100000d)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 500)]
        [CounterMeasurement("TestProjectCounter")]
        public void PostProject_PassingTest()
        {
            ProjectController tc = new ProjectController();
            ProjectDetails projectToAdd = new ProjectDetails()
            {
                Project_Name = "Aumaujaya project123",
                Priority = 50,
                Start_Date = DateTime.Now,
                End_Date = DateTime.Now.AddDays(2),
                NoOfTasks = 1,
                NoOfTasksCompleted = 0,
                Manager = new User()
            };
            tc.PostProject(projectToAdd);

        }

        [PerfBenchmark(Description = "Performace Test for UPDATE", RunMode = RunMode.Iterations, TestMode = TestMode.Test)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThan, 100000d)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 500)]
        [CounterMeasurement("TestProjectCounter")]
        public void UpdateProject_PassingTest()
        {
            ProjectController tc = new ProjectController();
            ProjectDetails projectToAdd = new ProjectDetails();
            projectToAdd.Project_ID = "9f714350-8333-46a1-93b4-d1f307795e3d";
            projectToAdd.Project_Name = "Project updated from Performance Unit Test Project";
            projectToAdd.Priority = 50;
            projectToAdd.Start_Date = DateTime.Now;
            projectToAdd.End_Date = DateTime.Now.AddDays(5);
            projectToAdd.NoOfTasks = 1;
            projectToAdd.NoOfTasksCompleted = 0;
            projectToAdd.Manager = new User();
            tc.UpdateProject(projectToAdd);

        }
    }
}
