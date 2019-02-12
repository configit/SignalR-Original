// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.md in the project root for license information.

using System;

namespace Configit.SignalR.Client.Hubs
{
    public interface IHubConnection : IConnection
    {
        string RegisterCallback(Action<HubResult> callback);
        void RemoveCallback(string callbackId);
    }
}
