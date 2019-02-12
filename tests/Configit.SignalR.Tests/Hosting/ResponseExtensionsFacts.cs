using System;
using System.Text;
using Configit.SignalR.Hosting;
using Moq;
using Xunit;

namespace Configit.SignalR.Tests.Hosting
{
    public class ResponseExtensionsFacts
    {
        [Fact]
        public void EndAsyncWritesUtf8BufferToResponse()
        {
            // Arrange
            var response = new Mock<IResponse>();
            string value = null;
            response.Setup(m => m.Write(It.IsAny<ArraySegment<byte>>()))
                    .Callback<ArraySegment<byte>>(data =>
                    {
                        value = Encoding.UTF8.GetString(data.Array, data.Offset, data.Count);
                    });

            // Act
            response.Object.End("Hello World");

            // Assert
            Assert.Equal("Hello World", value);
        }
    }
}
