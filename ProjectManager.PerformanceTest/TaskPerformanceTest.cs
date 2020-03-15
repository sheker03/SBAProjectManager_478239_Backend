using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManager.Service.Controllers;
using NBench;
using ProjectManager.Model;

namespace ProjectManager.PerformanceTest
{

    public class TaskPerformanceTest
    {

        [PerfBenchmark(Description = "Performace Test for GET", RunMode = RunMode.Iterations, TestMode = TestMode.Test)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThan, 100000d)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 500)]
        [CounterMeasurement("TestTaskCounter")]
        public void GetAllTasks_PassingTest()
        {
            TaskController controller = new TaskController();
            controller.GetAllTasks();
        }

        [PerfBenchmark(Description = "Performace Test for GET (By ID)", RunMode = RunMode.Iterations, TestMode = TestMode.Test)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThan, 100000d)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 500)]
        [CounterMeasurement("TestTaskCounter")]
        public void GetTaskByID_PassingTest()
        {
            TaskController tc = new TaskController();
            tc.GetTaskByID("3feec7df-2c8a-4894-81d8-8665ea5116ad");
        }

        [PerfBenchmark(Description = "Performace Test for POST", RunMode = RunMode.Iterations, TestMode = TestMode.Test)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThan, 100000d)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 500)]
        [CounterMeasurement("TestTaskCounter")]
        public void PostTask_PassingTest()
        {
            TaskController tc = new TaskController();
            Task taskToAdd = new Task()
            {
                Task_Name = "Task from Unit Test Project234",
                Priority = 50,
                Start_Date = DateTime.Now,
                End_Date = DateTime.Now.AddDays(2)
            };
            tc.PostTask(taskToAdd);

        }

        [PerfBenchmark(Description = "Performace Test for UPDATE", RunMode = RunMode.Iterations, TestMode = TestMode.Test)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThan, 100000d)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 500)]
        [CounterMeasurement("TestTaskCounter")]
        public void UpdateTask_PassingTest()
        {
            TaskController tc = new TaskController();
            Task taskToAdd = new Task();
            taskToAdd.Task_ID = "3feec7df-2c8a-4894-81d8-8665ea5116ad";
            taskToAdd.Task_Name = "Task from Unit Test Project";
            taskToAdd.Priority = 50;
            taskToAdd.Start_Date = DateTime.Now;
            taskToAdd.End_Date = DateTime.Now.AddDays(5);
            taskToAdd.Project_ID = "7dabb20c-5376-4aa0-be24-fa94fb3ce82d";
            tc.UpdateTask(taskToAdd);

        }
    }
}
