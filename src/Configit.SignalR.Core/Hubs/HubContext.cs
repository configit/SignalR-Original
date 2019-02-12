// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.md in the project root for license information.

using Configit.SignalR.Hubs.Pipeline;
using Configit.SignalR.Infrastructure;

namespace Configit.SignalR.Hubs
{
    internal class HubContext : IHubContext<object>, IHubContext
    {
        public HubContext(IConnection connection, IHubPipelineInvoker invoker, string hubName)
        {
            Clients = new HubConnectionContextBase(connection, invoker, hubName);
            Groups = new GroupManager(connection, PrefixHelper.GetHubGroupName(hubName));
        }

        public IHubConnectionContext<dynamic> Clients { get; private set; }

        public IGroupManager Groups { get; private set; }
    }
}
