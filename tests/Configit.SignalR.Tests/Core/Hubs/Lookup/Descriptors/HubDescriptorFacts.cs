using Configit.SignalR.Hubs.Lookup.Descriptors;
using Xunit;

namespace Configit.SignalR.Tests.Core.Hubs.Lookup.Descriptors
{
    public class HubDescriptorFacts
    {
        [Fact]
        public void CorrectQualifiedName()
        {
            string hubName = "MyHubDescriptor",
                   unqualifiedName = "MyUnqualifiedName";

            HubDescriptor hubDescriptor = new HubDescriptor()
            {
                Name = hubName
            };

            Assert.Equal(hubDescriptor.CreateQualifiedName(unqualifiedName), hubName + "." + unqualifiedName);
        }
    }
}
