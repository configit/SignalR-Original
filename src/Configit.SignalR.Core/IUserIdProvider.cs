// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.md in the project root for license information.

namespace Configit.SignalR
{
    public interface IUserIdProvider
    {
        string GetUserId(IRequest request);
    }
}
