using System;
using Configit.SignalR.Hubs.Extensions;
using Configit.SignalR.Hubs.Lookup;
using Configit.SignalR.Hubs.Lookup.Descriptors;
using Xunit;

namespace Configit.SignalR.Tests.Core.Hubs.Extensions
{
    public class HubManagerExtensionsFacts
    {
        [Fact]
        public void EnsureHubThrowsWhenCantResolve()
        {
            var resolver = new DefaultDependencyResolver();
            var hubManager = new DefaultHubManager(resolver);

            Assert.Throws<InvalidOperationException>(() => hubManager.EnsureHub("__ELLO__"));
        }

        [Fact]
        public void EnsureHubSuccessfullyResolves()
        {
            var resolver = new DefaultDependencyResolver();
            var hubManager = new DefaultHubManager(resolver);
            var TestHubName = "CoreTestHubWithMethod";

            HubDescriptor hub = null,
                          actualDescriptor = hubManager.GetHub(TestHubName);

            Assert.DoesNotThrow(() =>
            {
                hub = hubManager.EnsureHub(TestHubName);
            });

            Assert.Equal(hub, actualDescriptor);
        }
    }
}
