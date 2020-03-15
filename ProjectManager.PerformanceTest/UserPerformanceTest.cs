using NBench;
using ProjectManager.Model;
using ProjectManager.Service.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ProjectManager.PerformanceTest
{
    public class UserPerformanceTest
    {

        [PerfBenchmark(Description = "Performace Test for GET", RunMode = RunMode.Iterations, TestMode = TestMode.Test)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThan, 100000d)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 500)]
        [CounterMeasurement("TestUserCounter")]
        public void GetAllUsers_PassingTest()
        {
            UserController controller = new UserController();
            controller.GetAllUsers();
        }

        [PerfBenchmark(Description = "Performace Test for GET (By ID)", RunMode = RunMode.Iterations, TestMode = TestMode.Test)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThan, 100000d)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 500)]
        [CounterMeasurement("TestUserCounter")]
        public void GetUserByID_PassingTest()
        {
            UserController tc = new UserController();
            tc.GetUserByID("791fd25b-3869-43c1-9aa7-7657f54e93d4");
        }

        [PerfBenchmark(Description = "Performace Test for POST", RunMode = RunMode.Iterations, TestMode = TestMode.Test)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThan, 100000d)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 500)]
        [CounterMeasurement("TestUserCounter")]
        public void PostTask_PassingTest()
        {
            UserController tc = new UserController();
            User userToAdd = new User()
            {
                First_Name = "User FN from Performance Unit Test Project678",
                Last_Name = "User LN from Performance Unit Test Project678",
                Employee_ID = 21
            };
            tc.PostUser(userToAdd);
        }

        [PerfBenchmark(Description = "Performace Test for UPDATE", RunMode = RunMode.Iterations, TestMode = TestMode.Test)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThan, 100000d)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 500)]
        [CounterMeasurement("TestUserCounter")]
        public void UpdateUser_PassingTest()
        {
            UserController tc = new UserController();
            User userToAdd = new User();
            userToAdd.User_ID = "791fd25b-3869-43c1-9aa7-7657f54e93d4";
            userToAdd.First_Name = "123User FN updated from Performance Unit Test Project";
            userToAdd.Last_Name = "User LN updated from Performance Unit Test Project";
            tc.UpdateUser(userToAdd);
        }
    }
}
