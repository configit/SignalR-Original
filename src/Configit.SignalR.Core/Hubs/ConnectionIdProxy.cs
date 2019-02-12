// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.md in the project root for license information.

using Configit.SignalR.Hubs.Pipeline;
using Configit.SignalR.Infrastructure;

namespace Configit.SignalR.Hubs
{
    public class ConnectionIdProxy : SignalProxy
    {
        public ConnectionIdProxy(IConnection connection, IHubPipelineInvoker invoker, string signal, string hubName, params string[] exclude) :
            base(connection, invoker, signal, hubName, PrefixHelper.HubConnectionIdPrefix, exclude)
        {

        }
    }
}
