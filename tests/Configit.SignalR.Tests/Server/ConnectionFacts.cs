using System;
using Configit.SignalR.Infrastructure;
using Configit.SignalR.Json;
using Configit.SignalR.Messaging;
using Configit.SignalR.Tracing;
using Moq;
using Xunit;

namespace Configit.SignalR.Tests.Server
{
    public class ConnectionFacts
    {
        [Fact]
        public void SendingCommandObjectSetsCommandOnBus()
        {
            var messageBus = new Mock<IMessageBus>();
            var counters = new PerformanceCounterManager();
            Message message = null;
            messageBus.Setup(m => m.Publish(It.IsAny<Message>())).Returns<Message>(m =>
            {
                message = m;
                return TaskAsyncHelper.Empty;
            });

            var serializer = JsonUtility.CreateDefaultSerializer();
            var traceManager = new Mock<ITraceManager>();
            var connection = new Connection(messageBus.Object,
                                            serializer,
                                            "signal",
                                            "connectonid",
                                            new[] { "a", "signal", "connectionid" },
                                            new string[] { },
                                            traceManager.Object,
                                            new AckHandler(completeAcksOnTimeout: false,
                                                           ackThreshold: TimeSpan.Zero,
                                                           ackInterval: TimeSpan.Zero),
                                            counters,
                                            new Mock<IProtectedData>().Object);

            connection.Send("a", new Command
            {
                CommandType = CommandType.AddToGroup,
                Value = "foo"
            });

            Assert.NotNull(message);
            Assert.True(message.IsCommand);
            var command = serializer.Parse<Command>(message.Value, message.Encoding);
            Assert.Equal(CommandType.AddToGroup, command.CommandType);
            Assert.Equal("foo", command.Value);
        }
    }
}
