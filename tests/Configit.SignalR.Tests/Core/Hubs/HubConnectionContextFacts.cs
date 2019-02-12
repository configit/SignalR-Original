using System;
using Configit.SignalR.Hubs;
using Xunit;

namespace Configit.SignalR.Tests.Core.Hubs
{
    public class HubConnectionContextFacts
    {
        [Fact]
        public void GroupThrowsNullExceptionWhenGroupNameIsNull()
        {
            var hubConContext = new HubConnectionContext();
            Assert.Throws<ArgumentException>(() => hubConContext.Group(null));
        }

        [Fact]
        public void ClientThrowsNullExceptionWhenClientIdIsNull()
        {
            var hubConContext = new HubConnectionContext();
            Assert.Throws<ArgumentException>(() => hubConContext.Client(null));
        }
    }
}
