// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.md in the project root for license information.

using System.Collections.Generic;
using Configit.SignalR.Hubs.Pipeline;
using Configit.SignalR.Infrastructure;

namespace Configit.SignalR.Hubs
{
    public class GroupProxy : SignalProxy
    {
        public GroupProxy(IConnection connection, IHubPipelineInvoker invoker, string signal, string hubName, IList<string> exclude) :
            base(connection, invoker, signal, hubName, PrefixHelper.HubGroupPrefix, exclude)
        {

        }
    }
}
