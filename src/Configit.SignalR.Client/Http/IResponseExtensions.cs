// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.md in the project root for license information.

using System;
using System.Text;
using System.Threading.Tasks;
using Configit.SignalR.Client.Transports;

namespace Configit.SignalR.Client.Http
{
    public static class IResponseExtensions
    {
        public static Task<string> ReadAsString(this IResponse response, Func<ArraySegment<byte>, bool> onChunk)
        {
            if (response == null)
            {
                throw new ArgumentNullException("response");
            }

            var stream = response.GetStream();
            var reader = new AsyncStreamReader(stream);
            var result = new StringBuilder();
            var resultTcs = new TaskCompletionSource<string>();

            reader.Data = buffer =>
            {
                if (onChunk(buffer))
                {
                    result.Append(Encoding.UTF8.GetString(buffer.Array, buffer.Offset, buffer.Count));
                }
            };

            reader.Closed = exception =>
            {
                response.Dispose();
                resultTcs.SetResult(result.ToString());
            };

            reader.Start();

            return resultTcs.Task;
        }

        public static Task<string> ReadAsString(this IResponse response)
        {
            // Read all chunks by default
            return response.ReadAsString(chunk => true);
        }
    }
}
