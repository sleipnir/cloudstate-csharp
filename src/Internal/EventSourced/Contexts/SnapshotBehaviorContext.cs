using System;
using CloudState.CSharpSupport.Contexts.Abstractions;
using CloudState.CSharpSupport.Interfaces.EventSourced.Contexts;

namespace CloudState.CSharpSupport.EventSourced.Contexts
{
    internal class SnapshotBehaviorContext : DelegatingEventSourcedContext, ISnapshotBehaviorContext
    {
        private Action<object[]> Become { get; }
        
        public SnapshotBehaviorContext(IEventSourcedContext @delegate, Action<object[]> become) : base(@delegate)
        {
            Become = become;
        }

        void IBehaviorContext.Become(params object[] behaviors) => Become(behaviors);
    }
}