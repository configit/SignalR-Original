using System;
using Configit.SignalR.Messaging;
using Xunit;
using Xunit.Extensions;

namespace Configit.SignalR.Tests.Server
{
    public class ScaleoutConfigurationFacts
    {
        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(100)]
        public void ValidMaxQueueLength(int maxLength)
        {
            var config = new ScaleoutConfiguration();
            config.MaxQueueLength = maxLength;

            Assert.Equal(maxLength, config.MaxQueueLength);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        public void InvalidMaxQueueLength(int maxLength)
        {
            var config = new ScaleoutConfiguration();
            Assert.Throws<ArgumentOutOfRangeException>(() => config.MaxQueueLength = maxLength);
        }
    }
}
