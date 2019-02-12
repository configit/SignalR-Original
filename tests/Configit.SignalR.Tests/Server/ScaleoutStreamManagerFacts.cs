using System;
using System.Collections.Generic;
using System.Diagnostics;
using Configit.SignalR.Messaging;
using Xunit;

namespace Configit.SignalR.Tests.Server
{
    public class ScaleoutStreamManagerFacts
    {
        [Fact]
        public void StreamManagerValidatesScaleoutConfig()
        {
            var perfCounters = new Infrastructure.PerformanceCounterManager();
            var config = new ScaleoutConfiguration();

            config.QueueBehavior = QueuingBehavior.Always;
            config.MaxQueueLength = 0;

            Assert.Throws<InvalidOperationException>(() => new ScaleoutStreamManager((int x, IList<Message> list) => { return TaskAsyncHelper.Empty; },
                (int x, ulong y, ScaleoutMessage msg) => { }, 0, new TraceSource("Stream Manager"), perfCounters, config));
        }
    }
}
