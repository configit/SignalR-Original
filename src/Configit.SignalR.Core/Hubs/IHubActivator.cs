// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.md in the project root for license information.

using Configit.SignalR.Hubs.Lookup.Descriptors;

namespace Configit.SignalR.Hubs
{
    public interface IHubActivator
    {
        IHub Create(HubDescriptor descriptor);
    }
}
