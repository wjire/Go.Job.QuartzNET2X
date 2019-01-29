using System;
using System.Threading;
using System.Threading.Tasks;
using Quartz;
using Quartz.Listener;

namespace Go.Job.Service.Logic.Listener
{
    /// <summary>
    /// 触发器监听器基类
    /// </summary>
    public sealed class DefaultTriggerListener : TriggerListenerSupport
    {

        public Action<IJobExecutionContext, ITrigger> FiredAction;

        public Action<IJobExecutionContext, ITrigger> CompleteAction;

        public Action<ITrigger> MisFiredAction;

        public Action<ITrigger> VetoJobAction;

        public override string Name { get; } = "Default";


        public override void TriggerFired(ITrigger trigger, IJobExecutionContext context)
        {

            FiredAction?.Invoke(context, trigger);
            base.TriggerFired(trigger, context);
        }

        public override void TriggerComplete(ITrigger trigger, IJobExecutionContext context, SchedulerInstruction triggerInstructionCode)
        {

            CompleteAction?.Invoke(context, trigger);

            base.TriggerComplete(trigger, context, triggerInstructionCode);
        }

        public override void TriggerMisfired(ITrigger trigger)
        {

            MisFiredAction?.Invoke(trigger);

            base.TriggerMisfired(trigger);
        }

        public override bool VetoJobExecution(ITrigger trigger, IJobExecutionContext context)
        {

            VetoJobAction?.Invoke(trigger);

           return base.VetoJobExecution(trigger, context);
        }
    }
}
