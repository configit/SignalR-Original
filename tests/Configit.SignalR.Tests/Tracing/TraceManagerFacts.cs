using System.Diagnostics;
using System.IO;
using Configit.SignalR.Tracing;
using Xunit;

namespace Configit.SignalR.Tests.Tracing
{
    public class TraceManagerFacts
    {
        [Fact]
        public void NoHostListenerOnlyHasDefaultListenerOnSource()
        {
            var traceManager = new TraceManager();
            TraceSource source = traceManager["Random"];

            Assert.Equal(1, source.Listeners.Count);
        }

        [Fact]
        public void PassingHostListenerSetsListenerOnSources()
        {
            var hostListener = new TextWriterTraceListener(new StringWriter());
            var traceManager = new TraceManager(hostListener);
            TraceSource source = traceManager["Random"];

            Assert.Equal(1, source.Listeners.Count);
            Assert.Same(hostListener, source.Listeners[0]);
        }
    }
}
