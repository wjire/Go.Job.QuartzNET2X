using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Quartz;
using Quartz.Listener;

namespace Go.Job.Service.Logic.Listener
{
    /// <summary>
    /// job监听器基类
    /// </summary>
    public sealed class DefaultJobListener : JobListenerSupport
    {
        public Action<IJobExecutionContext> JobToBeExecutedAction;

        public Action<IJobExecutionContext> JobWasExecutedAction;

        public Action<IJobExecutionContext> JobExecutionVetoedAction;


        public override string Name { get; } = "Default";


        public override void JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException)
        {
            JobWasExecutedAction?.Invoke(context);
            base.JobWasExecuted(context, jobException);
        }

        public override void JobExecutionVetoed(IJobExecutionContext context)
        {
            JobExecutionVetoedAction?.Invoke(context);
            base.JobExecutionVetoed(context);
        }

        public override void JobToBeExecuted(IJobExecutionContext context)
        {
            JobToBeExecutedAction?.Invoke(context);
            base.JobToBeExecuted(context);
        }
    }
}
