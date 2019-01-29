using System;
using Go.Job.Model;
using Go.Job.Service.Api;

namespace Go.Job.Service.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var schedulerName = JobServiceBuilder.BuilderProduce().Start();
            JobApiStartHelper.Start(schedulerName);

            //JobServiceBuilder.BuilderTest().Start(new JobInfo
            //{
            //    AssemblyPath = @"E:\gongwei\my\Go.Job\TestJob1\bin\Debug\TestJob1.dll",
            //    ClassType = "TestJob1.Job1",
            //    Second = 5,
            //});
        }
    }
}
