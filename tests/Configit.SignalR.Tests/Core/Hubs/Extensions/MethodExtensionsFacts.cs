using Configit.SignalR.Hubs.Extensions;
using Configit.SignalR.Hubs.Lookup;
using Configit.SignalR.Hubs.Lookup.Descriptors;
using Configit.SignalR.Json;
using Xunit;

namespace Configit.SignalR.Tests.Core.Hubs.Extensions
{
    public class MethodExtensionsFacts
    {
        [Fact]
        public void MatchSuccessful()
        {
            var resolver = new DefaultDependencyResolver();
            var hubManager = new DefaultHubManager(resolver);

            // Should be AddNumbers
            MethodDescriptor methodDescriptor = hubManager.GetHubMethod("CoreTestHubWithMethod", "AddNumbers", new IJsonValue[] { null, null });

            // We should find our method descriptor
            Assert.NotNull(methodDescriptor);

            // Value does not matter, hence the null;
            Assert.True(methodDescriptor.Matches(new IJsonValue[] { null, null }));
        }
    }
}
